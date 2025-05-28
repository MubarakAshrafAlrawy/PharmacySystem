using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace PharmacySystem.view
{
    public partial class Sales : Form
    {
        public Sales()
        {
            MinuStripMain.history.Add("sales");
            InitializeComponent();
            Load_Filters();
            UpdateTable();
            this.MinuBar.Items.Add(MinuStripMain.instance());
            this.Disposed += (c, d) => { MinuStripMain.history.Remove("sales"); };
            //this.m.Items = MinuStripMain.items;
        }
        private List<sale> SalesData;
        private void Load_Filters()
        {
            this.CompanyCB.Items.Clear();
            this.CategoryCB.Items.Clear();
            this.TypeCB.Items.Clear();

            using (var db = new DataBaseConnection())
            {
                // Load all required related data in one query
                SalesData = db.sales
                    .Include(s => s.customer)
                    .Include(s => s.employee)
                    .Include(s => s.Sale_report.Select(sr => sr.medicine))
                    .Include(s => s.Sale_report.Select(sr => sr.medicine.company))
                    .Include(s => s.Sale_report.Select(sr => sr.medicine.category))
                    .Include(s => s.Sale_report.Select(sr => sr.medicine.Type))
                    .Where(s => s.Sale_report.Any(ss => ss != null && ss.medicine != null))
                    .ToList();

                // Rest of your filter loading code remains the same...
                if (SalesData.Any())
                {
                    Console.WriteLine($"Loaded {SalesData.Count} sales.");
                    this.FromDate.MaxDate = this.ToDate.MaxDate = SalesData.Max(s => s.date);
                    this.FromDate.MinDate = this.ToDate.MinDate = SalesData.Min(s => s.date);
                    this.FromDate.Value = SalesData.Min(s => s.date);
                    this.ToDate.Value = SalesData.Max(s => s.date);
                }

                // Populate ComboBoxes using the already loaded data
                this.CompanyCB.Items.Add("الكل");
                var companies = SalesData
                    .SelectMany(s => s.Sale_report)
                    .Where(sr => sr.medicine?.company != null)
                    .Select(sr => sr.medicine.company.name)
                    .Distinct()
                    .ToList();
                companies.ForEach(c => this.CompanyCB.Items.Add(c));

                this.CategoryCB.Items.Add("الكل");
                var categories = SalesData
                    .SelectMany(s => s.Sale_report)
                    .Where(sr => sr.medicine?.category != null)
                    .Select(sr => sr.medicine.category.name.Trim())
                    .Distinct()
                    .ToList();
                categories.ForEach(c => this.CategoryCB.Items.Add(c));

                this.TypeCB.Items.Add("الكل");
                var types = SalesData
                    .SelectMany(s => s.Sale_report)
                    .Where(sr => sr.medicine?.Type != null)
                    .Select(sr => sr.medicine.Type.name)
                    .Distinct()
                    .ToList();
                types.ForEach(t => this.TypeCB.Items.Add(t));

                this.CompanyCB.SelectedIndex = this.TypeCB.SelectedIndex = this.CategoryCB.SelectedIndex = 0;
            }
        }
        private void UpdateTable()
        {
            DataTable data = new DataTable();
            data.Columns.Add("رقم العملية", typeof(int));
            data.Columns.Add("اسم البائع");
            data.Columns.Add("اسم العميل", typeof(string));
            data.Columns.Add("الوثيقة الطبية", typeof(Image));
            data.Columns.Add("الاجمالي", typeof(float));
            data.Columns.Add("تاريخ البيع", typeof(DateTime));
            data.Columns.Add("الحالة", typeof(string));

            List<sale> datasales = SalesData?
                .Where(sale => sale != null &&
                      sale.date <= this.ToDate.Value &&
                      sale.date >= this.FromDate.Value)
                .ToList() ?? new List<sale>();

            if (!string.IsNullOrEmpty(this.SearchText.Text))
            {
                string searchText = SearchText.Text.ToLower().Trim();
                datasales = datasales.Where(x =>
                    x.customer.name.ToLower().Contains(searchText) ||
                    x.employee.name.ToLower().Contains(searchText) ||
                    x.state.ToLower().Contains(searchText) ||
                    x.Sale_report?.Any(s =>
                        (s?.medicine?.name ?? string.Empty).ToLower().Contains(searchText) ||
                        (s?.medicine?.generic_name ?? string.Empty).ToLower().Contains(searchText)
                        ) == true) 
                    .ToList();
            }

            if (this.CategoryCB.SelectedItem != null && this.CategoryCB.SelectedIndex != 0)
            {
                string category = CategoryCB.SelectedItem.ToString().ToLower();
                datasales = datasales.Where(x =>
                    x.Sale_report?.Any(s =>
                        (s?.medicine?.category?.name ?? string.Empty).ToLower() == category) == true)
                    .ToList();
            }

            // Apply type filter
            if (this.TypeCB.SelectedItem != null && this.TypeCB.SelectedIndex != 0)
            {
                string type = TypeCB.SelectedItem.ToString().ToLower();
                datasales = datasales.Where(x =>
                    x.Sale_report?.Any(s =>
                        (s?.medicine?.Type?.name ?? string.Empty).ToLower() == type) == true)
                    .ToList();
            }
            if (this.CompanyCB.SelectedItem != null && this.CompanyCB.SelectedIndex != 0)
            {
                string company = CompanyCB.SelectedItem.ToString().ToLower();
                datasales = datasales.Where(x =>
                    x.Sale_report?.Any(s =>
                        (s?.medicine?.company?.name ?? string.Empty).ToLower() == company) == true)
                    .ToList();
            }
            foreach (var s in datasales)
            {
                double totalPrice = s.Sale_report?.Sum(sr => sr.count * sr.sale_unit_price) ?? 0;
                Image medicalDocImage = null;

                if (s.image != null && s.image.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(s.image))
                        {
                            medicalDocImage = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        medicalDocImage = null;
                    }
                }

                data.Rows.Add(
                    s.sale_id,
                    s.employee.name?? "عامل محذوف",
                    s.customer?.name ?? "عميل محذوف",
                    medicalDocImage,
                    totalPrice,
                    s.date,
                    s.state
                );
            }
            this.DataTableContainer.DataSource = data;
            ((DataGridViewImageColumn)DataTableContainer.Columns[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            this.ToDate.MinDate = this.FromDate.Value;
            UpdateTable();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            this.FromDate.MaxDate = this.ToDate.Value;
            UpdateTable();
        }

        private void CompanyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateTable();
        }

        private void TypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateTable();
        }

        private void CategoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateTable();
        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            this.UpdateTable();
        }

        private void Search_click(object sender, EventArgs e)
        {
            this.SearchText.Focus();

        }

        private void GoBabk_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void TabelCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = DataTableContainer.Rows[e.RowIndex];
                var slr = new SalesReportView(int.Parse(row.Cells[0].Value.ToString()));
                slr.FormClosed += RefreshBTN_Click;
                slr.Visible = true;

            }
        }

        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            Load_Filters();
            UpdateTable();
        }
    }
}
