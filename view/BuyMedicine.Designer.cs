namespace PharmacySystem.view
{
    partial class BuyMedicine
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.medicinescontainer = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox_companiy = new System.Windows.Forms.ComboBox();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.combox_categories = new System.Windows.Forms.ComboBox();
            this.searchMed = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 48);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(869, 204);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1_Paint);
            // 
            // medicinescontainer
            // 
            this.medicinescontainer.AutoScroll = true;
            this.medicinescontainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.medicinescontainer.Location = new System.Drawing.Point(0, 355);
            this.medicinescontainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.medicinescontainer.Name = "medicinescontainer";
            this.medicinescontainer.Size = new System.Drawing.Size(870, 252);
            this.medicinescontainer.TabIndex = 1;
            // 
            // comboBox_companiy
            // 
            this.comboBox_companiy.FormattingEnabled = true;
            this.comboBox_companiy.Location = new System.Drawing.Point(670, 302);
            this.comboBox_companiy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_companiy.Name = "comboBox_companiy";
            this.comboBox_companiy.Size = new System.Drawing.Size(171, 21);
            this.comboBox_companiy.TabIndex = 2;
            this.comboBox_companiy.SelectedIndexChanged += new System.EventHandler(this.ComboBox_companiy_SelectedIndexChanged);
            // 
            // comboBox_type
            // 
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Location = new System.Drawing.Point(465, 302);
            this.comboBox_type.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(171, 21);
            this.comboBox_type.TabIndex = 3;
            this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.ComboBox_type_SelectedIndexChanged);
            // 
            // combox_categories
            // 
            this.combox_categories.FormattingEnabled = true;
            this.combox_categories.Location = new System.Drawing.Point(261, 302);
            this.combox_categories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combox_categories.Name = "combox_categories";
            this.combox_categories.Size = new System.Drawing.Size(171, 21);
            this.combox_categories.TabIndex = 4;
            this.combox_categories.SelectedIndexChanged += new System.EventHandler(this.Combox_categories_SelectedIndexChanged);
            // 
            // searchMed
            // 
            this.searchMed.Location = new System.Drawing.Point(56, 302);
            this.searchMed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchMed.Name = "searchMed";
            this.searchMed.Size = new System.Drawing.Size(171, 20);
            this.searchMed.TabIndex = 5;
            this.searchMed.TextChanged += new System.EventHandler(this.SearchMed_TextChanged);
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.Black;
            this.btnBuy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.ForeColor = System.Drawing.Color.White;
            this.btnBuy.Location = new System.Drawing.Point(789, 257);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(71, 27);
            this.btnBuy.TabIndex = 9;
            this.btnBuy.Text = "شراء";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.BtnBuy_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.BackColor = System.Drawing.Color.Black;
            this.btnDeleteAll.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAll.ForeColor = System.Drawing.Color.Transparent;
            this.btnDeleteAll.Location = new System.Drawing.Point(56, 258);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(106, 26);
            this.btnDeleteAll.TabIndex = 10;
            this.btnDeleteAll.Text = "حذف الكل";
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.BtnDeleteAll_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(870, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(670, 258);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 26);
            this.button1.TabIndex = 10;
            this.button1.Text = "علاج جديد";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.add_medicine_BTN_Click);
            // 
            // BuyMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 601);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.searchMed);
            this.Controls.Add(this.combox_categories);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.comboBox_companiy);
            this.Controls.Add(this.medicinescontainer);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BuyMedicine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "شراء علاجات";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel medicinescontainer;
        private System.Windows.Forms.ComboBox comboBox_companiy;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.ComboBox combox_categories;
        private System.Windows.Forms.TextBox searchMed;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
    }

}