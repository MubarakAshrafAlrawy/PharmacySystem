using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace PharmacySystem.view
{
    public partial class Buys : Form
    {
        public Buys()
        {
            InitializeComponent();
            Load_Filters();
            UpdateTable();
        }
        private List<Buy> BuysData;
        private void Load_Filters()
        {
            this.CompanyCB.Items.Clear();
            this.CategoryCB.Items.Clear();
            this.TypeCB.Items.Clear();

            using (var db = new DataBaseConnection())
            {
                // Load all required related data in one query
                BuysData = db.Buys
                    .Include(s => s.supplier)
                    .Include(s => s.employee)
                    .Include(s => s.buy_report.Select(sr => sr.medicine))
                    .Include(s => s.buy_report.Select(sr => sr.medicine.company))
                    .Include(s => s.buy_report.Select(sr => sr.medicine.category))
                    .Include(s => s.buy_report.Select(sr => sr.medicine.Type))
                    .Where(s => s.buy_report.Any(ss => ss != null && ss.medicine != null))
                    .ToList();

                // Rest of your filter loading code remains the same...
                if (BuysData.Any())
                {
                    Console.WriteLine($"Loaded {BuysData.Count} Buys.");
                    this.FromDate.MaxDate = this.ToDate.MaxDate = BuysData.Max(s => s.date);
                    this.FromDate.MinDate = this.ToDate.MinDate = BuysData.Min(s => s.date);
                    this.FromDate.Value = BuysData.Min(s => s.date);
                    this.ToDate.Value = BuysData.Max(s => s.date);
                }

                // Populate ComboBoxes using the already loaded data
                this.CompanyCB.Items.Add("الكل");
                var companies = BuysData
                    .SelectMany(s => s.buy_report)
                    .Where(sr => sr.medicine?.company != null)
                    .Select(sr => sr.medicine.company.name)
                    .Distinct()
                    .ToList();
                companies.ForEach(c => this.CompanyCB.Items.Add(c));

                this.CategoryCB.Items.Add("الكل");
                var categories = BuysData
                    .SelectMany(s => s.buy_report)
                    .Where(sr => sr.medicine?.category != null)
                    .Select(sr => sr.medicine.category.name.Trim())
                    .Distinct()
                    .ToList();
                categories.ForEach(c => this.CategoryCB.Items.Add(c));

                this.TypeCB.Items.Add("الكل");
                var types = BuysData
                    .SelectMany(s => s.buy_report)
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
            data.Columns.Add("اسم العميل");
            data.Columns.Add("الاجمالي", typeof(float));
            data.Columns.Add("تاريخ البيع", typeof(DateTime));
            data.Columns.Add("الحالة");

            List<Buy> dataBuys = BuysData?
                .Where(Buy => Buy != null &&
                      Buy.date <= this.ToDate.Value &&
                      Buy.date >= this.FromDate.Value)
                .ToList() ?? new List<Buy>();

            if (!string.IsNullOrWhiteSpace(this.SearchText.Text))
            {// ينظبق البحث هنا على اسم البائع او اسم المشتري او اسم العلاج او الاسم العالمي او حالة البيع
                string searchText = SearchText.Text.ToLower().Trim();
                dataBuys = dataBuys.Where(x =>
                    x.supplier.name.ToLower().Contains(searchText) ||
                    x.employee.name.ToLower().Contains(searchText) ||
                    x.state.ToLower().Contains(searchText) ||
                    x.buy_report?.Any(s =>
                        (s?.medicine?.name ?? string.Empty).ToLower().Contains(searchText) ||
                        (s?.medicine?.generic_name ?? string.Empty).ToLower().Contains(searchText)
                        ) == true)
                    .ToList() ?? new List<Buy>();
            }
            if (this.CategoryCB.SelectedItem != null && this.CategoryCB.SelectedIndex != 0)
            {
                string category = CategoryCB.SelectedItem.ToString().ToLower();
                dataBuys = dataBuys.Where(x =>
                    x.buy_report?.Any(s =>
                        (s?.medicine?.category?.name ?? string.Empty).ToLower() == category) == true)
                    .ToList();
            }
            if (this.TypeCB.SelectedItem != null && this.TypeCB.SelectedIndex != 0)
            {
                string type = TypeCB.SelectedItem.ToString().ToLower();
                dataBuys = dataBuys.Where(x =>
                    x.buy_report?.Any(s =>
                        (s?.medicine?.Type?.name ?? string.Empty).ToLower() == type) == true)
                    .ToList();
            }
            if (this.CompanyCB.SelectedItem != null && this.CompanyCB.SelectedIndex != 0)
            {
                string company = CompanyCB.SelectedItem.ToString().ToLower();
                dataBuys = dataBuys.Where(x =>
                    x.buy_report?.Any(s =>
                        (s?.medicine?.company?.name ?? string.Empty).ToLower() == company) == true)
                    .ToList();
            }
            foreach (var s in dataBuys)
            {
                double totalPrice = s.buy_report?.Sum(sr => sr.count * sr.unit_price) ?? 0;
                //DataTable data = new DataTable();
                //data.Columns.Add("رقم العملية", typeof(int));
                //data.Columns.Add("اسم البائع");
                //data.Columns.Add("اسم العميل");
                //data.Columns.Add("الاجمالي", typeof(float));
                //data.Columns.Add("تاريخ البيع", typeof(DateTime));
                //data.Columns.Add("الحالة");
                data.Rows.Add(
                    s.buy_id,
                    s.employee.name?? "عامل محذوف",
                    s.supplier?.name ?? "مورد محذوف",
                    totalPrice,
                    s.date,
                    s.state
                );
            }
            this.DataTableContainer.DataSource = data;
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

        private void Filter_Data_Table(object sender, EventArgs e)
        {
            this.UpdateTable();
        }

        private void Search_click(object sender, EventArgs e)
        {
            this.SearchText.Focus();

        }

        private void GoBabk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TabelCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = DataTableContainer.Rows[e.RowIndex];
                var slr = new BuysReportView(int.Parse(row.Cells[0].Value.ToString()));
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
