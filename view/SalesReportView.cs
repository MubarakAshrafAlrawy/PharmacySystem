using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PharmacySystem.view
{
    public partial class SalesReportView : Form
    {
        private sale Ssale;
        private List<Sale_report> Ssales;
        private customer Customer;
        private DataBaseConnection Dbb;
        private readonly string stateOfForm;

        public SalesReportView(List<Sale_report> saleReports)
        {
            InitializeComponent();
            stateOfForm = "new";
            Dbb = new DataBaseConnection();
            this.Customer = new customer();
            this.Ssales = new List<Sale_report>();
            InitializeForm(saleReports);
        }

        public SalesReportView(sale sale)
        {
            InitializeComponent();
            Dbb = new DataBaseConnection();

            if (sale == null)
            {
                MessageBox.Show("بيانات البيع غير صالحة");
                Close();
                return;
            }

            if (sale.sale_id > 0)
            {
                Ssale = Dbb.sales
                    .Include(s => s.Sale_report.Select(sr => sr.medicine))
                    .Include(s => s.customer)
                    .FirstOrDefault(s => s.sale_id == sale.sale_id);

                if (Ssale == null)
                {
                    MessageBox.Show("لم يتم العثور على بيانات البيع");
                    Close();
                    return;
                }

                Ssales = Ssale.Sale_report.ToList();
                Customer = Ssale.customer ?? new customer();
                this.stateOfForm = "update";
            }
            else
            {
                Ssale = sale;
                Ssales = sale.Sale_report?.ToList() ?? new List<Sale_report>();
                Customer = sale.customer ?? new customer();
                this.stateOfForm = "new";
            }

            InitializeForm(Ssales);
        }

        public SalesReportView(int saleId)
        {
            InitializeComponent();
            this.stateOfForm = "update";
            Dbb = new DataBaseConnection();

            if (saleId <= 0)
            {
                MessageBox.Show("معرف البيع غير صالح");
                Close();
                return;
            }

            Ssale = Dbb.sales
                .Include(s => s.Sale_report.Select(sr => sr.medicine))
                .Include(s => s.customer)
                .FirstOrDefault(s => s.sale_id == saleId);

            if (Ssale == null)
            {
                MessageBox.Show("لم يتم العثور على بيانات البيع");
                Close();
                return;
            }

            Ssales = Ssale.Sale_report.ToList();
            Customer = Ssale.customer ?? new customer();
            InitializeForm(Ssales);
        }

        private void InitializeForm(List<Sale_report> saleReports)
        {
            try
            {
                if (saleReports == null)
                {
                    Ssales = new List<Sale_report>();
                }
                else if (saleReports.Any(m => m.medicine == null))
                {
                    LoadMissingMedicines(saleReports);
                }

                UpdateUserInformation();
                InitializeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تهيئة النموذج: {ex.Message}");
                Close();
            }
        }

        private void LoadMissingMedicines(List<Sale_report> saleReports)
        {
            try
            {
                var medicineIds = saleReports
                    .Where(s => s.medicine_id > 0)
                    .Select(s => s.medicine_id)
                    .Distinct()
                    .ToList();

                if (!medicineIds.Any()) return;

                var medicines = Dbb.medicines
                    .Where(m => medicineIds.Contains(m.medicine_id))
                    .Include(m => m.category)
                    .Include(m => m.Type)
                    .Include(m => m.company)
                    .ToList();

                var medicineDict = medicines.ToDictionary(m => m.medicine_id);

                Ssales = saleReports.Select(s => new Sale_report
                {
                    medicine_id = s.medicine_id,
                    count = s.count,
                    sale_unit_price = s.sale_unit_price,
                    medicine = medicineDict.ContainsKey(s.medicine_id) ? medicineDict[s.medicine_id] : null
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل بيانات الأدوية: {ex.Message}");
                Ssales = saleReports;
            }
        }


        private void CloseForm(object sender, EventArgs e) => Close();
        private void UpdateUserInformation()
        {
            try
            {
                if (Customer != null)
                {
                    NameTB.Text = Customer.name ?? string.Empty;
                    PhoneTB.Text = Customer.phone ?? string.Empty;
                    EmailTB.Text = Customer.email ?? string.Empty;
                    AdressTB.Text = Customer.adress ?? string.Empty;
                }

                if (Ssale != null)
                {
                    StateTB.Text = Ssale.state ?? string.Empty;
                    DateTP.Value = Ssale.date > DateTime.MinValue ? Ssale.date : DateTime.Now;

                    if (Ssale.image != null && Ssale.image.Length > 0)
                    {
                        pictureBox1.Image = ByteArrayToImage(Ssale.image);
                        RemoveReportImageBTN.Enabled = true;
                    }
                }

                if (Ssales != null)
                {
                    UpdateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحديث معلومات المستخدم: {ex.Message}");
            }
        }

        private void InitializeDataGridView()
        {
            try
            {
                if (Ssales == null || !Ssales.Any())
                {
                    SalesTabelView.DataSource = new DataTable();
                    return;
                }

                var dataTable = new DataTable();
                dataTable.Columns.Add("اسم العلاج");
                dataTable.Columns.Add("الاسم العالمي");
                dataTable.Columns.Add("النوع");
                dataTable.Columns.Add("الصنف");
                dataTable.Columns.Add("الشركة المصنعة");
                dataTable.Columns.Add("العدد", typeof(int));
                dataTable.Columns.Add("سعر الوحدة", typeof(double));
                dataTable.Columns.Add("الاجمالي");

                foreach (var report in Ssales.Where(r => r != null && r.medicine != null))
                {
                    dataTable.Rows.Add(
                        report.medicine.name ?? "N/A",
                        report.medicine.generic_name ?? "N/A",
                        report.medicine.Type?.name ?? "N/A",
                        report.medicine.category?.name ?? "N/A",
                        report.medicine.company?.name ?? "N/A",
                        report.count,
                        report.sale_unit_price,
                        (report.count * report.sale_unit_price).ToString("F2")
                    );
                }

                SalesTabelView.DataSource = dataTable;

                for (int i = 0; i < SalesTabelView.Columns.Count - 3; i++)
                {
                    SalesTabelView.Columns[i].ReadOnly = true;
                }

                SalesTabelView.CellEndEdit += SalesTabelView_CellEndEdit;
                SalesTabelView.CellValidating += SalesTabelView_CellValidating;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تهيئة الجدول: {ex.Message}");
            }
        }

        private void SalesTabelView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Ssales.Count) return;

            try
            {
                if (e.ColumnIndex == SalesTabelView.Columns["العدد"].Index)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out int count) || count <= 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("الرجاء إدخال عدد صحيح موجب");
                    }
                }
                else if (e.ColumnIndex == SalesTabelView.Columns["سعر الوحدة"].Index)
                {
                    if (!double.TryParse(e.FormattedValue.ToString(), out double price) || price <= 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("الرجاء إدخال سعر موجب");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في التحقق من صحة الخلية: {ex.Message}");
            }
        }

        private void SalesTabelView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Ssales.Count) return;

            try
            {
                var row = SalesTabelView.Rows[e.RowIndex];
                var report = Ssales[e.RowIndex];

                if (e.ColumnIndex == SalesTabelView.Columns["العدد"].Index)
                {
                    if (int.TryParse(row.Cells["العدد"].Value?.ToString(), out int newCount))
                    {
                        report.count = newCount;
                    }
                }
                else if (e.ColumnIndex == SalesTabelView.Columns["سعر الوحدة"].Index)
                {
                    if (double.TryParse(row.Cells["سعر الوحدة"].Value?.ToString(), out double newPrice))
                    {
                        report.sale_unit_price = newPrice;
                    }
                }

                row.Cells["الاجمالي"].Value = (report.count * report.sale_unit_price).ToString("F2");
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحديث البيانات: {ex.Message}");
            }
        }

        private void UpdateTotal()
        {
            try
            {
                double total = Ssales?.Sum(r => r.count * r.sale_unit_price) ?? 0;
                TotalTB.Text = total.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حساب الإجمالي: {ex.Message}");
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            try
            {
                if (byteArray == null || byteArray.Length == 0)
                    return null;

                using (var ms = new MemoryStream(byteArray))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        private void AddReprtImagebBTN_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "صور|*.jpg;*.jpeg;*.png|كل الملفات|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                        RemoveReportImageBTN.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الصورة: {ex.Message}");
            }
        }

        private void RemoveReportImageBTN_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            RemoveReportImageBTN.Enabled = false;
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (SaveOrUpdateSales())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text))
            {
                MessageBox.Show("اسم العميل مطلوب");
                NameTB.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(PhoneTB.Text))
            {
                MessageBox.Show("رقم الهاتف مطلوب");
                PhoneTB.Focus();
                return false;
            }

            if (DateTP.Value > DateTime.Now)
            {
                MessageBox.Show("لا يمكن تحديد تاريخ في المستقبل");
                DateTP.Focus();
                return false;
            }

            if (Ssales == null || !Ssales.Any())
            {
                MessageBox.Show("لا توجد عناصر في الفاتورة");
                return false;
            }

            return true;
        }

        private bool SaveOrUpdateCustomer()
        { 
            if (!ValidateInputs())
                return false;
            try
            {
                if (Customer.customer_id > 0)
                {
                    var dbCustomer = Dbb.customers.FirstOrDefault(cs => cs.customer_id == Customer.customer_id || (cs.name.Equals(NameTB.Text.Trim()) && cs.phone.Equals(PhoneTB.Text.Trim())));
                    if (dbCustomer != null)
                    {
                        dbCustomer.name = NameTB.Text.Trim();
                        dbCustomer.phone = PhoneTB.Text.Trim();
                        dbCustomer.email = EmailTB.Text.Trim();
                        dbCustomer.adress = AdressTB.Text.Trim();
                        Customer = dbCustomer;
                    }
                    else
                    {
                        Customer = new customer
                        {
                            name = NameTB.Text.Trim(),
                            phone = PhoneTB.Text.Trim(),
                            email = EmailTB.Text.Trim(),
                            adress = AdressTB.Text.Trim()
                        };
                        Dbb.customers.Add(Customer);
                    }
                }
                else
                {
                    Customer = new customer
                    {
                        name = NameTB.Text.Trim(),
                        phone = PhoneTB.Text.Trim(),
                        email = EmailTB.Text.Trim(),
                        adress = AdressTB.Text.Trim()
                    };
                    Dbb.customers.Add(Customer);
                }

                Dbb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حفظ بيانات العميل: {ex.Message}");
                return false;
            }
        }
        private bool SaveReports()
        {
            try
            {
                if(this.stateOfForm != "new")
                {
                    foreach (var sl in Dbb.Sale_report.Where(s => s.sale_id == Ssale.sale_id).ToList())
                        Dbb.Sale_report.Remove(sl);
                    Dbb.SaveChanges();
                }
                foreach (var report in Ssales.Where(r => r != null && r.medicine != null).ToList())
                {
                    Sale_report ss = new Sale_report
                    {
                        sale_id = Ssale.sale_id,
                        medicine_id = report.medicine_id,
                        sale_unit_price = report.sale_unit_price,
                        count = report.count
                    };
                    Dbb.Sale_report.Add(ss);
                }
                Dbb.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show("تم تعديل البيانات بواسطة مستخدم آخر. يرجى تحديث البيانات والمحاولة مرة أخرى");
                return false;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"خطأ في تحديث بيانات تقارير العملية تفاصيل الخطأ : " + ex.Message.ToString());
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}");
                return false;
            }
        }
        private bool SaveOrUpdateSales()
        {
            Dbb.Dispose();
            Dbb = new DataBaseConnection();
            using (var transaction = Dbb.Database.BeginTransaction())
            {
                byte[] imageBytes = null;
                if (pictureBox1.Image != null)
                {
                    try
                    {
                        using (var ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                            imageBytes = ms.ToArray();
                        }
                    }
                    catch(Exception)
                    {
                        imageBytes = Ssale.image;
                        if (this.stateOfForm == "new")
                        {
                            MessageBox.Show("تعذر حفظ صورة التقرير سيتم تخطي العملية ومتابعة حفظ البيانات ..!!");
                        }
                    }
                }
                try
                {
                    if (!SaveOrUpdateCustomer())
                    {
                        transaction.Rollback();
                        return false;
                    }

                    if (this.stateOfForm == "new")
                    {
                        var sale = new sale
                        {
                            customer_id = Customer.customer_id,
                            employee_id = UserInformation.employee_id,
                            date = DateTime.Now,
                            state = StateTB.Text,
                            image = imageBytes
                        };
                        Dbb.sales.Add(sale);
                        Dbb.SaveChanges();
                        Ssale = sale;
                    }
                    else if(this.stateOfForm == "update")
                    {
                        var sale = Dbb.sales.FirstOrDefault(s => s.sale_id == Ssale.sale_id);
                        sale.customer_id = Customer.customer_id;
                        sale.employee_id = UserInformation.employee_id;
                        sale.date = DateTP.Value;
                        sale.state = StateTB.Text;
                        sale.image = imageBytes;
                        Dbb.SaveChanges();
                        Ssale = sale;
                    }
                    Dbb.SaveChanges();

                    if (!SaveReports())
                    {
                        MessageBox.Show("حدث خطأ في حفض تقارير البيع");
                        transaction.Rollback();
                        return false;
                    }
                    transaction.Commit();
                    return true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    transaction.Rollback();
                    MessageBox.Show("تم تعديل البيانات بواسطة مستخدم آخر. يرجى تحديث البيانات والمحاولة مرة أخرى");
                    return false;
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"خطأ في قاعدة البيانات: {ex.InnerException?.Message ?? ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}");
                    return false;
                }
            }
        }

        private void BackBTN_Click(object sender, EventArgs e) => Close();
    }
}