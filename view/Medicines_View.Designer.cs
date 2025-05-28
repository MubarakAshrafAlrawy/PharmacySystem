namespace PharmacySystem.view
{
    partial class Medicines_View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.leb1 = new System.Windows.Forms.Label();
            this.leb2 = new System.Windows.Forms.Label();
            this.leb3 = new System.Windows.Forms.Label();
            this.leb4 = new System.Windows.Forms.Label();
            this.leb5 = new System.Windows.Forms.Label();
            this.leb6 = new System.Windows.Forms.Label();
            this.leb7 = new System.Windows.Forms.Label();
            this.leb8 = new System.Windows.Forms.Label();
            this.leb9 = new System.Windows.Forms.Label();
            this.Scientific_Name = new System.Windows.Forms.TextBox();
            this.Medicine_ID = new System.Windows.Forms.TextBox();
            this.Category = new System.Windows.Forms.ComboBox();
            this.btnAddCategroy = new System.Windows.Forms.Button();
            this.btnAddCompany = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Unit_Brice = new System.Windows.Forms.TextBox();
            this.Type = new System.Windows.Forms.ComboBox();
            this.btnAddType = new System.Windows.Forms.Button();
            this.Company = new System.Windows.Forms.ComboBox();
            this.Generic_Name = new System.Windows.Forms.TextBox();
            this.Cost = new System.Windows.Forms.TextBox();
            this.Barcode = new System.Windows.Forms.TextBox();
            this.Photo = new System.Windows.Forms.PictureBox();
            this.Prod_Date = new System.Windows.Forms.DateTimePicker();
            this.btnChooseImg = new System.Windows.Forms.Button();
            this.Exp_Date = new System.Windows.Forms.DateTimePicker();
            this.leb10 = new System.Windows.Forms.Label();
            this.leb11 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).BeginInit();
            this.SuspendLayout();
            // 
            // leb1
            // 
            this.leb1.AutoSize = true;
            this.leb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb1.Location = new System.Drawing.Point(24, 79);
            this.leb1.Name = "leb1";
            this.leb1.Size = new System.Drawing.Size(99, 20);
            this.leb1.TabIndex = 0;
            this.leb1.Text = "الرقم التعريفي:";
            this.leb1.Click += new System.EventHandler(this.label1_Click);
            // 
            // leb2
            // 
            this.leb2.AutoSize = true;
            this.leb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb2.Location = new System.Drawing.Point(26, 120);
            this.leb2.Name = "leb2";
            this.leb2.Size = new System.Drawing.Size(86, 20);
            this.leb2.TabIndex = 1;
            this.leb2.Text = "الاسم العلمي:";
            this.leb2.Click += new System.EventHandler(this.label2_Click);
            // 
            // leb3
            // 
            this.leb3.AutoSize = true;
            this.leb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb3.Location = new System.Drawing.Point(24, 156);
            this.leb3.Name = "leb3";
            this.leb3.Size = new System.Drawing.Size(98, 20);
            this.leb3.TabIndex = 2;
            this.leb3.Text = "الاسم التجاري:";
            this.leb3.Click += new System.EventHandler(this.label3_Click);
            // 
            // leb4
            // 
            this.leb4.AutoSize = true;
            this.leb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb4.Location = new System.Drawing.Point(26, 189);
            this.leb4.Name = "leb4";
            this.leb4.Size = new System.Drawing.Size(82, 20);
            this.leb4.TabIndex = 3;
            this.leb4.Text = "رقم الصنف:";
            this.leb4.Click += new System.EventHandler(this.Category_Click);
            // 
            // leb5
            // 
            this.leb5.AutoSize = true;
            this.leb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb5.Location = new System.Drawing.Point(24, 232);
            this.leb5.Name = "leb5";
            this.leb5.Size = new System.Drawing.Size(46, 20);
            this.leb5.TabIndex = 4;
            this.leb5.Text = "النوع:";
            this.leb5.Click += new System.EventHandler(this.Type_Click);
            // 
            // leb6
            // 
            this.leb6.AutoSize = true;
            this.leb6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb6.Location = new System.Drawing.Point(24, 277);
            this.leb6.Name = "leb6";
            this.leb6.Size = new System.Drawing.Size(57, 20);
            this.leb6.TabIndex = 5;
            this.leb6.Text = "الشركة:";
            this.leb6.Click += new System.EventHandler(this.Company_Click);
            // 
            // leb7
            // 
            this.leb7.AutoSize = true;
            this.leb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb7.Location = new System.Drawing.Point(24, 323);
            this.leb7.Name = "leb7";
            this.leb7.Size = new System.Drawing.Size(59, 20);
            this.leb7.TabIndex = 6;
            this.leb7.Text = "بار كود:";
            this.leb7.Click += new System.EventHandler(this.Barcode_Click);
            // 
            // leb8
            // 
            this.leb8.AutoSize = true;
            this.leb8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb8.Location = new System.Drawing.Point(24, 367);
            this.leb8.Name = "leb8";
            this.leb8.Size = new System.Drawing.Size(83, 20);
            this.leb8.TabIndex = 7;
            this.leb8.Text = "سعر الوحدة:";
            this.leb8.Click += new System.EventHandler(this.Unit_Brice_Click);
            // 
            // leb9
            // 
            this.leb9.AutoSize = true;
            this.leb9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb9.Location = new System.Drawing.Point(24, 402);
            this.leb9.Name = "leb9";
            this.leb9.Size = new System.Drawing.Size(53, 20);
            this.leb9.TabIndex = 8;
            this.leb9.Text = "التكلفة:";
            this.leb9.Click += new System.EventHandler(this.Cost_Click);
            // 
            // Scientific_Name
            // 
            this.Scientific_Name.Location = new System.Drawing.Point(123, 121);
            this.Scientific_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Scientific_Name.Multiline = true;
            this.Scientific_Name.Name = "Scientific_Name";
            this.Scientific_Name.Size = new System.Drawing.Size(223, 24);
            this.Scientific_Name.TabIndex = 9;
            this.Scientific_Name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Medicine_ID
            // 
            this.Medicine_ID.Location = new System.Drawing.Point(123, 79);
            this.Medicine_ID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Medicine_ID.Multiline = true;
            this.Medicine_ID.Name = "Medicine_ID";
            this.Medicine_ID.Size = new System.Drawing.Size(223, 24);
            this.Medicine_ID.TabIndex = 9;
            this.Medicine_ID.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Category
            // 
            this.Category.FormattingEnabled = true;
            this.Category.Location = new System.Drawing.Point(123, 192);
            this.Category.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Category.Name = "Category";
            this.Category.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Category.Size = new System.Drawing.Size(223, 21);
            this.Category.TabIndex = 10;
            this.Category.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnAddCategroy
            // 
            this.btnAddCategroy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategroy.Location = new System.Drawing.Point(360, 192);
            this.btnAddCategroy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCategroy.Name = "btnAddCategroy";
            this.btnAddCategroy.Size = new System.Drawing.Size(41, 24);
            this.btnAddCategroy.TabIndex = 11;
            this.btnAddCategroy.Text = "+";
            this.btnAddCategroy.UseVisualStyleBackColor = true;
            this.btnAddCategroy.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddCompany
            // 
            this.btnAddCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCompany.Location = new System.Drawing.Point(360, 279);
            this.btnAddCompany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCompany.Name = "btnAddCompany";
            this.btnAddCompany.Size = new System.Drawing.Size(41, 21);
            this.btnAddCompany.TabIndex = 11;
            this.btnAddCompany.Text = "+";
            this.btnAddCompany.UseVisualStyleBackColor = true;
            this.btnAddCompany.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarcode.Location = new System.Drawing.Point(360, 326);
            this.btnBarcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(41, 21);
            this.btnBarcode.TabIndex = 11;
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(767, 404);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 31);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(936, 402);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(48, 32);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "عودة";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(855, 404);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(57, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Unit_Brice
            // 
            this.Unit_Brice.Location = new System.Drawing.Point(123, 368);
            this.Unit_Brice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Unit_Brice.Multiline = true;
            this.Unit_Brice.Name = "Unit_Brice";
            this.Unit_Brice.Size = new System.Drawing.Size(223, 24);
            this.Unit_Brice.TabIndex = 9;
            this.Unit_Brice.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Type
            // 
            this.Type.FormattingEnabled = true;
            this.Type.Location = new System.Drawing.Point(123, 239);
            this.Type.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Type.Name = "Type";
            this.Type.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Type.Size = new System.Drawing.Size(223, 21);
            this.Type.TabIndex = 10;
            this.Type.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnAddType
            // 
            this.btnAddType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddType.Location = new System.Drawing.Point(360, 237);
            this.btnAddType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(41, 21);
            this.btnAddType.TabIndex = 11;
            this.btnAddType.Text = "+";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.button2_Click);
            // 
            // Company
            // 
            this.Company.FormattingEnabled = true;
            this.Company.Location = new System.Drawing.Point(123, 281);
            this.Company.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Company.Name = "Company";
            this.Company.Size = new System.Drawing.Size(223, 21);
            this.Company.TabIndex = 10;
            this.Company.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Generic_Name
            // 
            this.Generic_Name.Location = new System.Drawing.Point(123, 157);
            this.Generic_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Generic_Name.Multiline = true;
            this.Generic_Name.Name = "Generic_Name";
            this.Generic_Name.Size = new System.Drawing.Size(223, 24);
            this.Generic_Name.TabIndex = 9;
            this.Generic_Name.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Cost
            // 
            this.Cost.Location = new System.Drawing.Point(123, 403);
            this.Cost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cost.Multiline = true;
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(223, 24);
            this.Cost.TabIndex = 9;
            this.Cost.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Barcode
            // 
            this.Barcode.Location = new System.Drawing.Point(123, 324);
            this.Barcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Barcode.Multiline = true;
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new System.Drawing.Size(223, 24);
            this.Barcode.TabIndex = 9;
            this.Barcode.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Photo
            // 
            this.Photo.Location = new System.Drawing.Point(831, 66);
            this.Photo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Photo.Name = "Photo";
            this.Photo.Size = new System.Drawing.Size(133, 132);
            this.Photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Photo.TabIndex = 12;
            this.Photo.TabStop = false;
            // 
            // Prod_Date
            // 
            this.Prod_Date.Location = new System.Drawing.Point(831, 246);
            this.Prod_Date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Prod_Date.Name = "Prod_Date";
            this.Prod_Date.Size = new System.Drawing.Size(133, 20);
            this.Prod_Date.TabIndex = 13;
            // 
            // btnChooseImg
            // 
            this.btnChooseImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImg.Location = new System.Drawing.Point(837, 203);
            this.btnChooseImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChooseImg.Name = "btnChooseImg";
            this.btnChooseImg.Size = new System.Drawing.Size(119, 29);
            this.btnChooseImg.TabIndex = 11;
            this.btnChooseImg.Text = "اختار صورة ";
            this.btnChooseImg.UseVisualStyleBackColor = true;
            this.btnChooseImg.Click += new System.EventHandler(this.BtnChooseImg_Click);
            // 
            // Exp_Date
            // 
            this.Exp_Date.Location = new System.Drawing.Point(831, 287);
            this.Exp_Date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exp_Date.Name = "Exp_Date";
            this.Exp_Date.Size = new System.Drawing.Size(133, 20);
            this.Exp_Date.TabIndex = 13;
            // 
            // leb10
            // 
            this.leb10.AutoSize = true;
            this.leb10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb10.Location = new System.Drawing.Point(728, 244);
            this.leb10.Name = "leb10";
            this.leb10.Size = new System.Drawing.Size(92, 20);
            this.leb10.TabIndex = 0;
            this.leb10.Text = "تاريخ الانتاج:";
            // 
            // leb11
            // 
            this.leb11.AutoSize = true;
            this.leb11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leb11.Location = new System.Drawing.Point(728, 286);
            this.leb11.Name = "leb11";
            this.leb11.Size = new System.Drawing.Size(98, 20);
            this.leb11.TabIndex = 0;
            this.leb11.Text = "تاريخ الانتهاء:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(360, 79);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Medicines_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 500);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Exp_Date);
            this.Controls.Add(this.Prod_Date);
            this.Controls.Add(this.Photo);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.btnAddCompany);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChooseImg);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.btnAddCategroy);
            this.Controls.Add(this.Company);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Medicine_ID);
            this.Controls.Add(this.Generic_Name);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.Barcode);
            this.Controls.Add(this.Unit_Brice);
            this.Controls.Add(this.Scientific_Name);
            this.Controls.Add(this.leb9);
            this.Controls.Add(this.leb8);
            this.Controls.Add(this.leb7);
            this.Controls.Add(this.leb6);
            this.Controls.Add(this.leb5);
            this.Controls.Add(this.leb4);
            this.Controls.Add(this.leb3);
            this.Controls.Add(this.leb2);
            this.Controls.Add(this.leb11);
            this.Controls.Add(this.leb10);
            this.Controls.Add(this.leb1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Medicines_View";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Treatments_View";
            this.Load += new System.EventHandler(this.Treatments_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label leb1;
        private System.Windows.Forms.Label leb2;
        private System.Windows.Forms.Label leb3;
        private System.Windows.Forms.Label leb4;
        private System.Windows.Forms.Label leb5;
        private System.Windows.Forms.Label leb6;
        private System.Windows.Forms.Label leb7;
        private System.Windows.Forms.Label leb8;
        private System.Windows.Forms.Label leb9;
        private System.Windows.Forms.TextBox Scientific_Name;
        private System.Windows.Forms.TextBox Medicine_ID;
        private System.Windows.Forms.ComboBox Category;
        private System.Windows.Forms.Button btnAddCategroy;
        private System.Windows.Forms.Button btnAddCompany;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox Unit_Brice;
        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.ComboBox Company;
        private System.Windows.Forms.TextBox Generic_Name;
        private System.Windows.Forms.TextBox Cost;
        private System.Windows.Forms.TextBox Barcode;
        private System.Windows.Forms.PictureBox Photo;
        private System.Windows.Forms.DateTimePicker Prod_Date;
        private System.Windows.Forms.Button btnChooseImg;
        private System.Windows.Forms.DateTimePicker Exp_Date;
        private System.Windows.Forms.Label leb10;
        private System.Windows.Forms.Label leb11;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}