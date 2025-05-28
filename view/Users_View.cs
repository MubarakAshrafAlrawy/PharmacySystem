using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PharmacySystem.view
{
    public partial class Users_View: Form
    {
        // دالة لتحويل الصورة إلى مصفوفة بايت
        //private byte[] ImageToByteArray(System.Drawing.Image image)
        //{
        //    if (image == null) return null;  // التحقق من أن الصورة ليست null

        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        // حفظ الصورة في الذاكرة
        //        image.Save(ms, image.RawFormat);
        //        return ms.ToArray();  // إعادة المصفوفة
        //    }
        //}
        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            if (image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // استخدم تنسيق معروف
                    return ms.ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء تحويل الصورة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        // دالة لمقارنة بين مصفوفتين من البايتات
        private bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            // إذا كانت إحدى المصفوفات null والأخرى ليست null، أرجع false
            if (a1 == null || a2 == null) return a1 == a2;

            // إذا كان الطول غير متساوي، أرجع false
            if (a1.Length != a2.Length) return false;

            // مقارنة بين كل عنصر في المصفوفات
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i]) return false;
            }
            return true;  // إذا كانت المصفوفات متساوية
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ClearFields()
        {
            userId.Text = "";
            userName.Text = "";
            email.Text = "";
            password.Text = "";
            phone.Text = "";
            hireDate.Value = DateTime.Now;
            type.Text = "";
            address.Text = "";
            salary.Text = "";
            photo.Image = null;
        }

        public Users_View()
        {
            InitializeComponent();
            menuStrip1.Items.Add(MinuStripMain.instance());
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {

            using ( var contect = new DataBaseConnection())

            {
                int search = Convert.ToInt32(userId.Text);

                var user = contect.employees.SingleOrDefault(x => x.employee_id == search );
                if (user != null)
                {
                    userName.Text = user.name;
                    email.Text = user.email;
                    password.Text = user.password;
                    phone.Text = user.phone;
                    hireDate.Value = user.hire_date;
                    type.Text = user.type;
                    address.Text = user.adress;
                    salary.Text = user.salary.ToString();
                    if (user.image != null)
                    {
                        using (MemoryStream ms = new MemoryStream(user.image))
                        {
                            photo.Image = System.Drawing.Image.FromStream(ms);


                        }
                    }
                    else
                    {
                        //photo.Image = null;
                        MessageBox.Show(" No photo ");
                    }
                    {

                    }
                }
                else
                {

                    ClearFields();
                    MessageBox.Show(" المستخدم غير موجود!");

                }

            }



        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userId.Text))
            {
                MessageBox.Show("يرجى ادخال رقم المستخدم المراد حذفه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(userId.Text, out int id))
            {
                MessageBox.Show("رقم المستخدم غير صالح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("هل أنت متأكد من حذف هذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            using (var context = new DataBaseConnection())
            {
                var user = context.employees.SingleOrDefault(x => x.employee_id == id);
                if (user == null)
                {
                    MessageBox.Show("المستخدم غير موجود في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                context.employees.Remove(user);
                context.SaveChanges();

                MessageBox.Show("تم حذف المستخدم بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
        }

        private void BtnEdite_Click(object sender, EventArgs e)
        {
            if (!Checkinputs())
                return;
            if (!int.TryParse(salary.Text, out int salaryValue))
            {
                MessageBox.Show("يرجى إدخال قيمة صحيحة للراتب", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var contect = new DataBaseConnection())
            {
                int id = Convert.ToInt32(userId.Text);

                var user = contect.employees.SingleOrDefault(x => x.employee_id == id);
                if (user != null)
                {
                    user.name = userName.Text;
                    user.email = email.Text;
                    user.password = password.Text;
                    user.phone = phone.Text;
                    user.hire_date = hireDate.Value;
                    user.type = type.Text;
                    user.adress = address.Text;
                    user.salary = salaryValue;
                    user.image = ImageToByteArray(photo.Image)??user.image; // إذا كان لديك صورة
                    contect.SaveChanges();
                    MessageBox.Show("تم تعديل بيانات المستخدم بنجاح");
                }
                else
                {
                    MessageBox.Show("المستخدم غير موجود");
                }
            }
        }

        private void BtnChangeImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "إختر صورة";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    photo.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private bool Checkinputs()
        {
            // التحقق من تعبئة جميع الحقول
            if (
                string.IsNullOrWhiteSpace(userName.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(password.Text) ||
                string.IsNullOrWhiteSpace(phone.Text) ||
                string.IsNullOrWhiteSpace(type.Text) ||
                string.IsNullOrWhiteSpace(address.Text) ||
                string.IsNullOrWhiteSpace(salary.Text) ||
                photo.Image == null)
            {
                MessageBox.Show("يرجى تعبئة جميع الحقول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // التحقق من صحة البريد الإلكتروني
            if (!IsValidEmail(email.Text))
            {
                MessageBox.Show("يرجى إدخال بريد إلكتروني صحيح.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // تحويل الراتب إلى رقم صحيح
            if (!int.TryParse(salary.Text, out _))
            {
                MessageBox.Show("يرجى إدخال قيمة صحيحة للراتب", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!Checkinputs())
                return;

            using (var context = new DataBaseConnection())
            {
                // التحقق إذا كان المستخدم موجود مسبقاً
                var exists = context.employees.Any(x => x.email == email.Text);
                if (exists)
                {
                    MessageBox.Show("المستخدم موجود مسبقًا. استخدم زر التعديل لتحديث البيانات.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(salary.Text, out int salaryValue))
                {
                    // إنشاء مستخدم جديد
                    var newUser = new employee
                    {
                        name = userName.Text,
                        email = email.Text,
                        password = password.Text,
                        phone = phone.Text,
                        hire_date = hireDate.Value,
                        type = type.Text,
                        adress = address.Text,
                        salary = salaryValue,
                        image = ImageToByteArray(photo.Image) // إذا كان لديك صورة
                    };
                    context.employees.Add(newUser);
                    context.SaveChanges();
                    MessageBox.Show("تم حفظ المستخدم بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("يجب ان يكون الراتب عددا صحيحا");
                }

            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
