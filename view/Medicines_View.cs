using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PharmacySystem.view
{
    public partial class Medicines_View: Form
    {
        byte[] imageByte;
        string imagePath;
        public Medicines_View()
        {
            InitializeComponent();
            this.menuStrip1.Items.Add(MinuStripMain.instance());
        }

        private void photo_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Treatments_View_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Unit_Brice_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Category_Click(object sender, EventArgs e)
        {

        }

        private void Type_Click(object sender, EventArgs e)
        {

        }

        private void Company_Click(object sender, EventArgs e)
        {

        }

        private void Barcode_Click(object sender, EventArgs e)
        {

        }

        private void Cost_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var conect = new DataBaseConnection())
            {
                int search = Convert.ToInt32(Medicine_ID.Text);

                var med = conect.medicines.SingleOrDefault(x => x.medicine_id == search);
                if(med != null)
                {
                    Scientific_Name.Text = med.name;
                    Generic_Name.Text = med.generic_name;
                    Category.Text = Convert.ToString(med.category_id);
                    Type.Text = Convert.ToString(med.type_id);
                    Company.Text = Convert.ToString(med.company_id);
                    Barcode.Text = med.barcode;
                    Unit_Brice.Text = Convert.ToString(med.unit_price);
                    Cost.Text = Convert.ToString(med.selling_price);
                    Prod_Date.Value = Convert.ToDateTime(med.start_date);
                    Exp_Date.Value = Convert.ToDateTime(med.end_date);
                    if (med.image != null)
                    {
                        imageByte = med.image;
                        MemoryStream ms = new MemoryStream(imageByte);
                        Photo.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        MessageBox.Show("لا توجد صورة");
                    }
                }
                else
                {
                    MessageBox.Show("العلاج غير موجود");
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Medicine_ID.Text))
            {
                MessageBox.Show("يرجى ادخال رقم العلاج  المراد حذفه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id;
            if (!int.TryParse(Medicine_ID.Text, out id))
            {
                MessageBox.Show("رقم العلاج  غير صالح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("هل أنت متأكد من حذف هذا العلاج؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            using (var context = new DataBaseConnection())
            {
                var delMed = context.medicines.SingleOrDefault(x => x.medicine_id == id);
                if (delMed == null)
                {
                    MessageBox.Show("العلاج غير موجود في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                context.medicines.Remove(delMed);
                context.SaveChanges();

                MessageBox.Show("تم حذف العلاج بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Scientific_Name.Text = "";
                Generic_Name.Text = "";
                Category.Text = "";
                Type.Text = "";
                Company.Text = "";
                Barcode.Text = "";
                Unit_Brice.Text = "";
                Cost.Text = "";
                Prod_Date.Value = DateTime.Now;
                Exp_Date.Value = DateTime.Now;
            }
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
          using (var db = new DataBaseConnection())
            {
                if (imageByte != null)
                {
                    var newMed = new medicine
                    {
                        name = Scientific_Name.Text,
                        generic_name = Generic_Name.Text,
                        category_id = Convert.ToInt32(Category.Text),
                        company_id = Convert.ToInt32(Company.Text),
                        type_id = Convert.ToInt32(Type.Text),
                        start_date = Prod_Date.Value,
                        end_date = Exp_Date.Value,
                        count = Convert.ToInt32(Cost.Text),
                        image = imageByte,
                        unit_price = Convert.ToInt32(Unit_Brice.Text),
                        barcode = Barcode.Text


                    };

                    db.medicines.Add(newMed);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Enter the Image");
                }
            }
        }

    

        private void BtnChooseImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "إختر صورة";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    
                    Photo.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);

                    imageByte = File.ReadAllBytes(imagePath);
                    
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
