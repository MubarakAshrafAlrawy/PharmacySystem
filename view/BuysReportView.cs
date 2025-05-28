using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PharmacySystem.view
{
    public partial class BuysReportView : Form
    {
        private Buy Buy;
        private List<buy_report> Buys;
        private supplier supplier;
        private DataBaseConnection Dbb;
        private readonly string stateOfForm;

        public BuysReportView(List<buy_report> BuyReports)
        {
            InitializeComponent();
            stateOfForm = "new";
            Dbb = new DataBaseConnection();
            this.supplier = new supplier();
            this.Buys = new List<buy_report>();
            InitializeForm(BuyReports);
        }

        //public BuysReportView(Buy buy)
        //{
        //    InitializeComponent();
        //    Dbb = new DataBaseConnection();

        //    if (buy == null)
        //    {
        //        MessageBox.Show("بيانات الشراء غير صالحة");
        //        Dbb.Dispose();Close();
        //        return;
        //    }

        //    if (buy.buy_id > 0)
        //    {
        //        Buy = Dbb.Buys
        //            .Include(s => s.buy_report.Select(sr => sr.medicine))
        //            .Include(s => s.supplier)
        //            .FirstOrDefault(s => s.buy_id == buy.buy_id);

        //        if (Buy == null)
        //        {
        //            MessageBox.Show("لم يتم العثور على بيانات الشراء");
        //            Dbb.Dispose();Close();
        //            return;
        //        }

        //        Buys = Buy.buy_report.ToList();
        //        this.stateOfForm = "update";
        //    }
        //    else
        //    {
        //        Buy = buy;
        //        Buys = buy.buy_report?.ToList() ?? new List<buy_report>();
        //        supplier = buy.supplier ?? new supplier();
        //        this.stateOfForm = "new";
        //    }

        //    InitializeForm(Buys);
        //}

        public BuysReportView(int buy_id)
        {
            InitializeComponent();
            this.stateOfForm = "update";
            Dbb = new DataBaseConnection();

            if (buy_id <= 0)
            {
                MessageBox.Show("معرف الشراء غير صالح");
                Dbb.Dispose(); Close();
                return;
            }

            Buy = Dbb.Buys
                .Include(s => s.buy_report.Select(sr => sr.medicine))
                .Include(s => s.supplier)
                .FirstOrDefault(s => s.buy_id == buy_id);

            if (Buy == null)
            {
                MessageBox.Show("لم يتم العثور على بيانات البيع");
                Dbb.Dispose(); Close();
                return;
            }

            Buys = Buy.buy_report.ToList();
            supplier = Buy.supplier ?? (Buy.supplier_id > 0 ? Dbb.suppliers.FirstOrDefault(s => s.supplier_id == Buy.supplier_id) : new supplier());
            InitializeForm(Buys);
        }

        private void InitializeForm(List<buy_report> BuyReports)
        {
            try
            {
                if (BuyReports == null)
                {
                    Buys = new List<buy_report>();
                }
                else if (BuyReports.Any(m => m.medicine == null))
                {
                    LoadMissingMedicines(BuyReports);
                }

                UpdateSupplierInformations();
                InitializeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تهيئة النموذج: {ex.Message}");
                Dbb.Dispose(); Close();
            }
        }
        private void LoadMissingMedicines(List<buy_report> BuyReports)
        {
            try
            {
                var medicineIds = BuyReports
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

                Buys = BuyReports.Select(s => new buy_report
                {
                    medicine_id = s.medicine_id,
                    count = s.count,
                    unit_price = s.unit_price,
                    medicine = medicineDict.ContainsKey(s.medicine_id) ? medicineDict[s.medicine_id] : null
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل بيانات الأدوية: {ex.Message}");
                Buys = BuyReports;
            }
        }
        private void UpdateSupplierInformations()
        {
            if (supplier != null)
            {
                this.NameTB.Text = supplier.name;
                this.PhoneTB.Text = supplier.phone;
                this.EmailTB.Text = supplier.email;
                this.FaxTB.Text = supplier.fax;
                if (supplier.logo != null && supplier.logo.Length > 0)
                    this.LogoPicBox.Image = ByteArrayToImage(supplier.logo);
                if (Buy != null && !string.IsNullOrWhiteSpace(Buy.state))
                {
                    this.StateTB.Text = Buy.state;
                    this.DateTP.Value = Buy.date;
                }
                if (Buys != null)
                    UpdateTotal();
                else
                    this.RemoveLogoBTN.Enabled = false;
            }
        }
        private void BuysTabelView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Buys.Count) return;
            try
            {
                if (e.ColumnIndex == BuysTabelView.Columns["العدد"].Index)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out int count) || count <= 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("الرجاء إدخال عدد صحيح موجب");
                    }
                }
                else if (e.ColumnIndex == BuysTabelView.Columns["سعر الوحدة"].Index)
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
        private void InitializeDataGridView()
        {
            try
            {
                if (Buys == null || !Buys.Any())
                {
                    BuysTabelView.DataSource = new DataTable();
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

                foreach (var report in Buys.Where(r => r != null && r.medicine != null))
                {
                    dataTable.Rows.Add(
                        report.medicine.name ?? "N/A",
                        report.medicine.generic_name ?? "N/A",
                        report.medicine.Type?.name ?? "N/A",
                        report.medicine.category?.name ?? "N/A",
                        report.medicine.company?.name ?? "N/A",
                        report.count,
                        report.unit_price,
                        (report.count * report.unit_price)//.ToString("F2")
                    );
                }

                BuysTabelView.DataSource = dataTable;

                for (int i = 0; i < BuysTabelView.Columns.Count - 3; i++)
                {
                    BuysTabelView.Columns[i].ReadOnly = true;
                }

                BuysTabelView.CellEndEdit += BuysTabelView_CellEndEdit;
                BuysTabelView.CellValidating += BuysTabelView_CellValidating;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تهيئة الجدول: {ex.Message}");
            }
        }

        private void BuysTabelView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Buys.Count) return;

            try
            {
                var row = BuysTabelView.Rows[e.RowIndex];
                var report = Buys[e.RowIndex];

                if (e.ColumnIndex == BuysTabelView.Columns["العدد"].Index)
                {

                    if (int.TryParse(row.Cells["العدد"].Value?.ToString(), out int newCount))
                    {
                        report.count = newCount;
                    }
                }
                else if (e.ColumnIndex == BuysTabelView.Columns["سعر الوحدة"].Index)
                {
                    if (double.TryParse(row.Cells["سعر الوحدة"].Value?.ToString(), out double newPrice))
                    {
                        report.unit_price = newPrice;
                    }
                }

                row.Cells["الاجمالي"].Value = (report.count * report.unit_price);//.ToString("F2");
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
                double total = Buys?.Sum(r => r.count * r.unit_price) ?? 0;
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

        private void Button1_Click(object sender, EventArgs e){
            this.Dbb.Dispose();
            Close();
        }
        
        private void ChangeLogoBTN_Click(object sender, EventArgs e)
        {
            try
            {
                using (var  openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "صور|*.jpg;*.jpeg;*.png|كل الملفات|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        LogoPicBox.Image = Image.FromFile(openFileDialog.FileName);
                        RemoveLogoBTN.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الصورة: {ex.Message}");
            }
        }
        private void RemoveLogoBTN_Click(object sender, EventArgs e)
        {
            LogoPicBox.Image = null;
            RemoveLogoBTN.Enabled = false;
        }
        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (SaveOrUpdateBuys())
            {
                this.Dbb.Dispose();Close();
            }
            else
            {
                MessageBox.Show("حدث خطأ اثناء حفض البيانات عليك التحقق من ان البيانات المدخلة صحيحة !!");
            }
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

            if (string.IsNullOrWhiteSpace(FaxTB.Text))
            {
                MessageBox.Show("الفاكس مطلوب");
                FaxTB.Focus();
                return false;
            }

            if (DateTP.Value > DateTime.Now)
            {
                MessageBox.Show("لا يمكن تحديد تاريخ في المستقبل");
                DateTP.Focus();
                return false;
            }

            if (Buys == null || !Buys.Any())
            {
                MessageBox.Show("لا توجد عناصر في الفاتورة");
                return false;
            }

            return true;
        }

        private bool SaveOrUpdatesupplier()
        {
            if (!ValidateInputs())
                return false;
            byte[] imageBytes = null;
            try
            {
                if (this.LogoPicBox.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        LogoPicBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }
                }
            }
            catch
            {
                imageBytes = supplier.logo;
                if(this.stateOfForm == "new")
                {
                    MessageBox.Show("تعذر حفظ صورة الشعار سيتم تخطي العملية ومتابعة حفظ البيانات ..!!");
                }
            }
            try
            {
                var dbsupplier = Dbb.suppliers.FirstOrDefault(cs => cs.supplier_id == supplier.supplier_id || (cs.name.Equals(NameTB.Text.Trim()) && cs.phone.Equals(PhoneTB.Text.Trim())));
                if (dbsupplier != null)
                {
                    dbsupplier.name = NameTB.Text.Trim();
                    dbsupplier.phone = PhoneTB.Text.Trim();
                    dbsupplier.email = EmailTB.Text.Trim();
                    dbsupplier.fax = FaxTB.Text.Trim();
                    dbsupplier.logo = imageBytes;
                    supplier = dbsupplier;
                }
                else
                {
                    supplier = new supplier
                    {
                        name = NameTB.Text.Trim(),
                        phone = PhoneTB.Text.Trim(),
                        email = EmailTB.Text.Trim(),
                        fax = FaxTB.Text.Trim(),
                        logo = imageBytes
                    };
                    Dbb.suppliers.Add(supplier);
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
                if (this.stateOfForm != "new")
                {
                    Dbb.buy_report.RemoveRange(Dbb.buy_report.Where(s => s.buy_id == Buy.buy_id).ToList());
                    Dbb.SaveChanges();
                }
                foreach (var report in Buys.Where(r => r != null && r.medicine != null).ToList())
                {
                    buy_report ss = new buy_report
                    {
                        buy_id = Buy.buy_id,
                        medicine_id = report.medicine_id,
                        unit_price = report.unit_price,
                        count = report.count
                    };
                    Dbb.buy_report.Add(ss);
                    //MessageBox.Show($"ByID: {ss.buy_id} , medicine_id: {ss.medicine_id} unit_price: {ss.unit_price} count: {ss.count}");
                }
                //MessageBox.Show($"Its Now To Save It");

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
        private bool SaveOrUpdateBuys()
        {
            Dbb.Dispose();
            Dbb = new DataBaseConnection();
            using (var transaction = Dbb.Database.BeginTransaction())
            {
                try
                {
                    if (!SaveOrUpdatesupplier())
                    {
                        transaction.Rollback();
                        return false;
                    }

                    if (this.stateOfForm == "new")
                    {
                        var buy = new Buy
                        {
                            supplier_id = supplier.supplier_id,
                            employee_id = UserInformation.employee_id,
                            date = DateTime.Now,
                            state = StateTB.Text,
                        };
                        Dbb.Buys.Add(buy);
                        Dbb.SaveChanges();
                        Buy = buy;
                    }
                    else if (this.stateOfForm == "update")
                    {
                        var buy = Dbb.Buys.FirstOrDefault(s => s.buy_id == Buy.buy_id);
                        buy.supplier_id = supplier.supplier_id;
                        buy.employee_id = UserInformation.employee_id;
                        buy.date = DateTP.Value;
                        buy.state = StateTB.Text;
                        Dbb.SaveChanges();
                        Buy = buy;
                    }
                    Dbb.SaveChanges();

                    //MessageBox.Show($"ByID: {Buy.buy_id} , date: {Buy.date.ToString("MM/dd/yyy")} state: {Buy.state}");
                    if (!SaveReports())
                    {
                        MessageBox.Show("حدث خطأ في حفض تقارير الشراء");
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
    }
}