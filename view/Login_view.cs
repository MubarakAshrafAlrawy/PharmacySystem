using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PharmacySystem.view
{
    public partial class Login_view : Form
    {
        private string imagePath;
        private byte[] imageByte;
        //private UserInformation userInformation;
        public Login_view()
        {
            InitializeComponent();
            //userInformation = new UserInformation();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {


            using (var db = new DataBaseConnection())
            {
                var employee = db.employees.FirstOrDefault(s => s.email == emailtb.Text && s.password == passwordtb.Text);

                if (employee != null)
                {
                    UserInformation.employee_id = employee.employee_id;
                    UserInformation.name = employee.name;
                    UserInformation.email = employee.email;
                    UserInformation.password = employee.password;
                    UserInformation.adress = employee.adress;
                    UserInformation.image = employee.image;
                    UserInformation.type = employee.type;
                    UserInformation.phone = employee.phone;
                    UserInformation.hire_date = employee.hire_date;
                    // ادارة المبيعات
                    // ادارة الشرائات
                    // ادارة المستخدمين
                    // ادارة الانواع والاصناف والشركات
                    // الواجهة الرئيسية
                    // ادارة العلاجات
                    MinuStripMain.items = new ToolStripMenuItem("القائمة");

                    ToolStripMenuItem salesViewItem0 = new ToolStripMenuItem("الملف الشخصي");
                    ToolStripMenuItem salesViewItem = new ToolStripMenuItem("ادارة المبيعات");
                    ToolStripMenuItem salesViewItem1 = new ToolStripMenuItem("ادارة الشرائات");
                    ToolStripMenuItem salesViewItem2 = new ToolStripMenuItem("ادارة الانواع والشركات والاصناف");
                    ToolStripMenuItem salesViewItem3 = new ToolStripMenuItem("ادارة العلاجات");
                    ToolStripMenuItem salesViewItem5 = new ToolStripMenuItem("شراء علاجات");

                    salesViewItem0.Click += (a,b) => {
                        if(!MinuStripMain.history.Any(h => h.Equals(salesViewItem0.Text)))
                        {
                           MinuStripMain.history.Add(salesViewItem0.Text);
                           var f =  new Profile();
                            f.FormClosed += (j, d) => { MinuStripMain.history.Remove(salesViewItem0.Text); };
                           f.Show();
                        }
                        else
                        {
                            MessageBox.Show("العنصر المحدد مفتوح بالفعل..!!");
                        }
                    };
                    salesViewItem.Click += (a,b) => {
                        if(!MinuStripMain.history.Any(h => h.Equals(salesViewItem.Text)))
                        {
                           MinuStripMain.history.Add(salesViewItem.Text);
                           var f =  new Sales();
                           f.FormClosed += (j, d) => { MinuStripMain.history.Remove(salesViewItem.Text); };
                           f.Show();
                        }
                        else
                        {
                            MessageBox.Show("العنصر المحدد مفتوح بالفعل..!!");
                        }
                    };
                    salesViewItem1.Click += (a,b) => {
                        if (!MinuStripMain.history.Any(h => h.Equals(salesViewItem1.Text)))
                        {
                            MinuStripMain.history.Add(salesViewItem1.Text);
                            var f = new Buys();
                            f.FormClosed += (j, d) => { MinuStripMain.history.Remove(salesViewItem1.Text); };
                            f.Show();

                        }
                        else
                        {
                            MessageBox.Show("العنصر المحدد مفتوح بالفعل..!!");
                        }
                    };
                    salesViewItem2.Click += (a, b) => {
                        if (!MinuStripMain.history.Any(h => h.Equals(salesViewItem2.Text)))
                        {
                            MinuStripMain.history.Add(salesViewItem2.Text);
                            var f = new Managing_varieties_species();
                            f.FormClosed += (j, d) => { MinuStripMain.history.Remove(salesViewItem2.Text); };
                            f.Show();

                        }
                        else
                        {
                            MessageBox.Show("العنصر المحدد مفتوح بالفعل..!!");
                        }
                    };
                    salesViewItem3.Click += (a,b) =>{
                        if (!MinuStripMain.history.Any(h => h.Equals(salesViewItem3.Text)))
                        {
                            MinuStripMain.history.Add(salesViewItem3.Text);
                            var f = new Medicines_View();
                            f.FormClosed += (j, d) => { MinuStripMain.history.Remove(salesViewItem3.Text); };
                            f.Show();

                        }
                        else
                        {
                            MessageBox.Show("العنصر المحدد مفتوح بالفعل..!!");
                        }
                    };
                    salesViewItem5.Click += (a,b) =>{
                        if (!MinuStripMain.history.Any(h => h.Equals(salesViewItem5.Text)))
                        {
                            MinuStripMain.history.Add(salesViewItem5.Text);
                            var f = new BuyMedicine();
                            f.Disposed += (j, d) => { MinuStripMain.history.Remove(salesViewItem5.Text); };
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("العنصر المحدد مفتوح بالفعل..!!");
                        }
                    };

                    MinuStripMain.items.DropDownItems.Add(salesViewItem0);
                    MinuStripMain.items.DropDownItems.Add(salesViewItem);
                    MinuStripMain.items.DropDownItems.Add(salesViewItem1);
                    MinuStripMain.items.DropDownItems.Add(salesViewItem2);
                    MinuStripMain.items.DropDownItems.Add(salesViewItem3);
                    MinuStripMain.items.DropDownItems.Add(salesViewItem5);

                    if (employee.type.Equals("مدير"))
                    {
                        ToolStripMenuItem salesViewItem6 = new ToolStripMenuItem("ادارة المستخدمين");
                        salesViewItem6.Click += (a,b) => {
                            MinuStripMain.history.Add(salesViewItem6.Text);
                            var f = new Users_View();
                            f.FormClosed += (j, d) => { MinuStripMain.history.Remove(salesViewItem6.Text); };
                            f.Show();
                        };
                        MinuStripMain.items.DropDownItems.Add(salesViewItem6);
                    }
                    launcher l =  new launcher();
                    l.Disposed += (a,c) => { this.Dispose();};
                    l.Visible = true;
                    this.Visible = false;

                }
                else
                {
                    MessageBox.Show("Not Found Email");
                }
            }
        }

        private void Btnaddemployee_Click(object sender, EventArgs e)
        {
            /*
            using (var db = new DataBaseConnection())
            {
                var newEmp = new employee
                {

                    name = "Mohammed Ali",
                    phone = "772867128",
                    email = "maho772867@gmail.com",
                    adress = "Taiz",
                    password = "12345678",
                    salary = 50000,
                    hire_date = Convert.ToDateTime("1-2-2020"),
                    image = imageByte,
                    type = "مدير",


                };
                if (imageByte != null)
                {
                    db.employees.Add(newEmp);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Enter the image ");
                }
            }
            */
            //SalesReportView salesReport = new SalesReportView();
            Managing_varieties_species managing = new Managing_varieties_species();
            managing.Visible = true;
        }

        private void Selectimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;.bmp;*.gif|All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                

                imageByte = File.ReadAllBytes(imagePath);


            }
        }

        
    }
}
