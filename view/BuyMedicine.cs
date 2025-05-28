using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PharmacySystem.view
{
    public partial class BuyMedicine : Form

    {
        byte[] imageByte;
        string imagePath;
        private List<medicine> medicines;
        private List<category> categories;
        private List<PharmacySystem.Type> types;
        private List<company> companies;
        private List<buy_report> sale_Reports;

        //private UserInformation ;
        public BuyMedicine()
        {
            InitializeComponent();
            GetAllCategries();
            GetAllCompainy();
            GetAllType();
            Initialize();
            this.MainMenuStrip.Items.Add(MinuStripMain.instance());
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private System.Windows.Forms.Panel To_item_panel(medicine m)
        {
            Panel itemcontainer;
            Label name;
            TextBox nametb;
            TextBox genericnametb;
            TextBox compainytb;
            Label compainyla;

            PictureBox picbox;
            Label label3;
            TextBox typetb;
            Label label2;
            TextBox categorytb;
            Label label1;

            itemcontainer = new Panel();
            name = new Label();
            picbox = new PictureBox();
            nametb = new TextBox();
            compainytb = new TextBox();

            label1 = new Label();
            categorytb = new TextBox();
            label2 = new Label();
            typetb = new TextBox();
            label3 = new Label();
            compainyla = new Label();
            genericnametb = new TextBox();
            // 
            // itemcontainer
            // 
            Label label_id = new Label
            {
                Name = "medicine_id",
                Text = $"{m.medicine_id}",
                Visible = false
            };

            itemcontainer.Controls.Add(genericnametb);
            itemcontainer.Controls.Add(label3);
            itemcontainer.Controls.Add(typetb);
            itemcontainer.Controls.Add(label2);
            itemcontainer.Controls.Add(categorytb);
            itemcontainer.Controls.Add(label1);
            itemcontainer.Controls.Add(nametb);
            itemcontainer.Controls.Add(name);
            itemcontainer.Controls.Add(picbox);
            itemcontainer.Controls.Add(compainytb);
            itemcontainer.Controls.Add(compainyla);
            itemcontainer.Name = "itemcontainer";
            itemcontainer.Controls.Add(label_id);
            itemcontainer.Size = new System.Drawing.Size(202, 223);
            itemcontainer.TabIndex = 0;
            itemcontainer.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            itemcontainer.Click += (sender, e) =>
            {
                float new_scale;
                if (medicinescontainer.Controls.Contains(itemcontainer))
                {


                    label2.Text = "Count  : ";
                    label2.BackColor = Color.White;

                    categorytb.Enabled = true;
                    categorytb.Text = "1";

                    compainyla.Text = "U Price :";
                    typetb.Enabled = true;
                    typetb.Text = ($"{m.selling_price + 3}");
                    float.TryParse("0.8", out new_scale);
                    itemcontainer.Scale(new_scale);

                    flowLayoutPanel1.Controls.Add(itemcontainer);
                    medicinescontainer.Controls.Remove(itemcontainer);


                }
                else if (flowLayoutPanel1.Controls.Contains(itemcontainer))
                {
                    float.TryParse("1.2", out new_scale);
                    itemcontainer.Scale(new_scale);

                    label2.Text = "categroy";
                    label2.BackColor = Color.Transparent;

                    categorytb.Enabled = false;
                    categorytb.Text = m.category.name;

                    typetb.Enabled = false;
                    typetb.Text = m.Type.name;
                    //count.Click += new System.EventHandler(this.Label1_Click);

                    medicinescontainer.Controls.Add(itemcontainer);
                    flowLayoutPanel1.Controls.Remove(itemcontainer);

                }

            };
            itemcontainer.BackColor = Color.Transparent;
            itemcontainer.BorderStyle = BorderStyle.FixedSingle;

            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new System.Drawing.Point(4, 106);
            name.Name = "name";
            name.Size = new System.Drawing.Size(55, 17);
            name.TabIndex = 1;
            name.Text = "name : ";
            name.Click += new System.EventHandler(this.Label1_Click);
            // 
            // picbox
            // 
            picbox.Location = new System.Drawing.Point(38, 3);
            picbox.Name = "picbox";
            picbox.Size = new System.Drawing.Size(104, 92);
            picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picbox.TabIndex = 0;
            picbox.TabStop = false;
            byte[] image = m.image;
            if (image != null)
            {
                MemoryStream ms = new MemoryStream(image);
                picbox.Image = Image.FromStream(ms);
            }


            // 
            // nametb
            // 
            nametb.Enabled = false;
            nametb.Location = new System.Drawing.Point(83, 106);
            nametb.Name = "nametb";
            nametb.Size = new System.Drawing.Size(100, 24);
            nametb.TabIndex = 2;
            nametb.Text = m.name;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 136);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 17);
            label1.TabIndex = 1;
            label1.Text = "G name : ";
            label1.ForeColor = Color.White;
            label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // categorytb
            // 
            categorytb.Enabled = false;
            categorytb.Location = new System.Drawing.Point(83, 166);
            categorytb.Name = "categorytb";
            categorytb.Size = new System.Drawing.Size(100, 24);
            categorytb.TabIndex = 2;
            categorytb.Text = m.category.name;

            //
            //campaintb leabel
            // 

            compainyla.AutoSize = true;
            compainyla.Location = new System.Drawing.Point(4, 196);
            compainyla.Name = "label3";
            compainyla.Size = new System.Drawing.Size(39, 17);
            compainyla.TabIndex = 1;
            compainyla.Text = "Type";
            compainyla.ForeColor = Color.Black;
            compainyla.Click += new System.EventHandler(this.Label1_Click);

            //
            //cpmpainytp 
            //

            compainytb.Enabled = false;
            compainytb.Location = new System.Drawing.Point(83, 136);
            compainytb.Name = "compainytb";
            compainytb.Size = new System.Drawing.Size(100, 24);
            compainytb.TabIndex = 2;
            /*
            if (m.company.name != null)
            {
                compainytb.Text = m.company.name;
            }
            */

            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 166);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 17);
            label2.TabIndex = 1;
            label2.Text = "category :";
            label2.Click += new System.EventHandler(this.Label1_Click);
            // 
            // typetb
            // 
            typetb.Enabled = false;
            typetb.Text = m.Type.name;
            typetb.Location = new System.Drawing.Point(83, 193);
            typetb.Name = "typetb";
            typetb.Size = new System.Drawing.Size(100, 24);
            typetb.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 196);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(39, 17);
            label3.TabIndex = 1;
            label3.Text = "Type";
            label3.Click += new System.EventHandler(this.Label1_Click);
            // 
            // genericnametb
            // 
            genericnametb.Enabled = false;
            genericnametb.Location = new System.Drawing.Point(83, 136);
            genericnametb.Name = "genericnametb";
            genericnametb.Size = new System.Drawing.Size(100, 24);
            genericnametb.TabIndex = 2;
            genericnametb.Text = m.generic_name;

            //itemcontainer.MouseClick +=  new MouseEventHandler()

            return itemcontainer;
        }

        /*
        void itemcontainer_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add((Panel)sender );
        }
        */

        private void Initialize()
        {
            using (var db = new DataBaseConnection())
            {
                medicines = db.medicines.ToList();
                foreach (var med in medicines)
                {
                    this.medicinescontainer.Controls.Add(To_item_panel(med));
                }
            }
        }

        private void GetAllCategries()
        {
            using (var db = new DataBaseConnection())
            {
                categories = db.categories.ToList();
                combox_categories.Items.Add("جميع الأصناف");
                foreach (var category in categories)
                {
                    combox_categories.Items.Add(category.name);
                }
                combox_categories.SelectedIndex = 0;
            }
        }


        private void GetAllType()
        {
            using (var db = new DataBaseConnection())
            {
                types = db.Types.ToList();

                comboBox_type.Items.Add("جميع الانواع");
                foreach (var type in types)
                {
                    comboBox_type.Items.Add(type.name);
                }
                comboBox_type.SelectedIndex = 0;
            }
        }


        private void GetAllCompainy()
        {
            using (var db = new DataBaseConnection())
            {
                companies = db.companies.ToList();
                comboBox_companiy.Items.Add("جميع الشرائك");
                foreach (var company in companies)
                {
                    comboBox_companiy.Items.Add(company.name);
                }
                comboBox_companiy.SelectedIndex = 0;

            }
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // flowLayoutPanel1.Controls.it(itemcontainer);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void ComboBox_companiy_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicinescontainer.Controls.Clear();
            using (var db = new DataBaseConnection())
            {
                medicines = db.medicines.ToList();
                foreach (var med in medicines)
                {
                    if (comboBox_companiy.Text == "جميع الشرائك" || (comboBox_companiy.Text == med.company.name))
                    {
                        this.medicinescontainer.Controls.Add(To_item_panel(med));
                    }
                }
            }
        }

        [Obsolete]
        private void ComboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicinescontainer.Controls.Clear();
            using (var db = new DataBaseConnection())
            {
                medicines = db.medicines.ToList();
                foreach (var med in medicines)
                {
                    if (comboBox_type.Text == "جميع الانواع" || (comboBox_type.Text == med.Type.name))
                    {
                        this.medicinescontainer.Controls.Add(To_item_panel(med));
                    }

                }
            }
        }

        [Obsolete]
        private void Combox_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicinescontainer.Controls.Clear();
            using (var db = new DataBaseConnection())
            {
                medicines = db.medicines.ToList();
                foreach (var med in medicines)
                {
                    if (combox_categories.Text == "جميع الأصناف" || (combox_categories.Text == med.category.name))
                    {
                        this.medicinescontainer.Controls.Add(To_item_panel(med));
                    }
                }
            }
        }

        private void SearchMed_TextChanged(object sender, EventArgs e)
        {
            this.medicinescontainer.Controls.Clear();

            using (var db = new DataBaseConnection())
            {
                medicines = db.medicines.ToList();
                String searchText = this.searchMed.Text.ToLower().Trim();

                foreach (var med in medicines)
                {
                    if (//this.searchMed.Text.Contains (med.name)
                        med != null && (string.IsNullOrWhiteSpace(searchText) ||
                        (med.name ?? "Null").ToLower().Contains(searchText)
                        || ((med.generic_name ?? "Null").ToLower().Contains(searchText))
                        || ((med.category?.name ?? "Null").ToLower().Contains(searchText))
                        || ((med.Type?.name ?? "Null").ToLower().Contains(searchText))
                        || (med.company?.name ?? "Null").ToLower().Contains(searchText)))
                    {
                        this.medicinescontainer.Controls.Add(To_item_panel(med));
                    }
                }
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;.bmp;*.gif|All Files|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;


                imageByte = File.ReadAllBytes(imagePath);

                using (var db = new DataBaseConnection())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var updateMedicensById = db.medicines.FirstOrDefault(s =>
                         s.medicine_id == i);

                        if (updateMedicensById != null)
                        {
                            updateMedicensById.image = imageByte;
                            db.SaveChanges();
                        }
                    }

                }


            }

        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {


            sale_Reports = new List<buy_report>();

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Panel itemPanel)
                {
                    Label nameTextBox = itemPanel.Controls.OfType<Label>().FirstOrDefault(tb => tb.Name == "medicine_id");
                    TextBox countTextBox = itemPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "categorytb");
                    TextBox price = itemPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "typetb");

                    if (nameTextBox != null && countTextBox != null && price != null)
                    {
                        int.TryParse(nameTextBox.Text, out int id);
                        int.TryParse(countTextBox.Text, out int count);
                        float.TryParse(price.Text, out float price_unit);

                        var selectMed = medicines.FirstOrDefault(m => m.medicine_id == id);
                        if(selectMed != null)
                        {
                            var report = new buy_report
                            {
                                medicine_id = id,
                                count = count,
                                unit_price = (double)price_unit
                            };

                            sale_Reports.Add(report);
                        }
                    }
                }
            }
            if (sale_Reports.Count > 0)
            {
                BuysReportView sales = new BuysReportView(sale_Reports)
                {
                    Visible = true
                };
            }

        }

        [Obsolete]
        private void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            var items = flowLayoutPanel1.Controls.OfType<Panel>().ToList();

            foreach (var item in items)
            {
                item.Scale(float.Parse("1.2"));
                medicinescontainer.Controls.Add(item);

            }
            flowLayoutPanel1.Controls.Clear();
        }

        private void Launcher_Load(object sender, EventArgs e)
        {

        }
        bool opened = false;

        private void add_medicine_BTN_Click(object sender, EventArgs e)
        {
            if (!opened)
            {
                opened = true;
                var f = new Medicines_View();
                f.Disposed += SearchMed_TextChanged;
                f.Disposed += (b,v) => { opened = false; };
                f.Show();
            }
            else
            {
                MessageBox.Show("يتم الان اضافة علاج جديد بالفعل....!!");
            }
        }
    }

}
