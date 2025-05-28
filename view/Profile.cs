using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PharmacySystem.view
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            FillData();
            this.SaveBTN.Visible = false;
        }

        private void FillData()
        {
            this.EmailTB      .Text = UserInformation.email;
            this.IDTB         .Text = UserInformation.employee_id.ToString()  ;
            this.NameTB       .Text = UserInformation.name  ;
            this.PasswordTB   .Text = UserInformation.password  ;
            this.PhoneTB      .Text = UserInformation.phone  ;
            this.SalaryTB     .Text = UserInformation.salary.ToString()  ;
            this.TypeTB       .Text = UserInformation.type  ;
            if(UserInformation.image != null && UserInformation.image.Length > 0)
            {
                this.ProfilePicBox.Image = ByteArrayToImage(UserInformation.image);
                RemoveProfileBTN.Enabled = true;
            }
            else
            {
                RemoveProfileBTN.Enabled = false;
            }
        }

        private void EditProfileBTN_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "صور|*.jpg;*.jpeg;*.png|كل الملفات|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ProfilePicBox.Image = Image.FromFile(openFileDialog.FileName);
                        RemoveProfileBTN.Enabled = true;
                        this.SaveBTN.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الصورة: {ex.Message}");
            }
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            try
            {
                if (byteArray == null || byteArray.Length == 0)
                    return null;

                using (var ms = new System.IO.MemoryStream(byteArray))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        private void RemoveProfileBTN_Click(object sender, EventArgs e)
        {
            if(ProfilePicBox.Image != null)
            {
                ProfilePicBox.Image = null;
                this.SaveBTN.Visible = true;
            }
            RemoveProfileBTN.Enabled = false;
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NameTB_Click(object sender, EventArgs e)
        {
            this.SaveBTN.Visible = true;
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = null;
            
            if(this.ProfilePicBox.Image != null)
            {
                try
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        ProfilePicBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }
                }
                catch
                {
                    MessageBox.Show("تعذر تحديث صورة الملف الشخصي..!!");
                }
            }
            
            using(var db = new DataBaseConnection())
            {
                var emp = db.employees.FirstOrDefault(d => d.employee_id == UserInformation.employee_id);
                if(emp != null)
                {
                    emp.name     = this.NameTB.Text;
                    emp.password = this.PasswordTB.Text;
                    emp.phone = this.PhoneTB.Text;
                    emp.image = imageBytes;
                    if(db.SaveChanges() > 0)
                    {
                        UserInformation.name     = this.NameTB.Text;
                        UserInformation.password = this.PasswordTB.Text;
                        UserInformation.phone    = this.PhoneTB.Text;
                        UserInformation.image = imageBytes;
                        MessageBox.Show("تم حفظ البيانات بنجاح");
                        this.SaveBTN.Visible = false;
                    }
                }
            }
        }

        private void NameTB_Click(object sender, PaintEventArgs e)
        {
            this.SaveBTN.Visible = true;
        }
    }
}
