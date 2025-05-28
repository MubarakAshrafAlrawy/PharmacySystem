namespace PharmacySystem.view
{
    partial class Managing_varieties_species
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
            this.categroiesDataGrade = new System.Windows.Forms.DataGridView();
            this.category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typedataGridView = new System.Windows.Forms.DataGridView();
            this.Type_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compainydataGridView = new System.Windows.Forms.DataGridView();
            this.Companies_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Companies_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCompanies = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Categories_search = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Types_search = new System.Windows.Forms.TextBox();
            this.Companies_search = new System.Windows.Forms.TextBox();
            this.btnAddCat = new System.Windows.Forms.Button();
            this.btnAddType = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.categroiesDataGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typedataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compainydataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // categroiesDataGrade
            // 
            this.categroiesDataGrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categroiesDataGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categroiesDataGrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.category_id,
            this.category_name});
            this.categroiesDataGrade.Location = new System.Drawing.Point(621, 108);
            this.categroiesDataGrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categroiesDataGrade.Name = "categroiesDataGrade";
            this.categroiesDataGrade.RowHeadersWidth = 51;
            this.categroiesDataGrade.RowTemplate.Height = 24;
            this.categroiesDataGrade.Size = new System.Drawing.Size(227, 283);
            this.categroiesDataGrade.TabIndex = 0;
            this.categroiesDataGrade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.categroies_CellContentClick);
            // 
            // category_id
            // 
            this.category_id.HeaderText = "المعرف";
            this.category_id.MinimumWidth = 6;
            this.category_id.Name = "category_id";
            // 
            // category_name
            // 
            this.category_name.HeaderText = "الاسم";
            this.category_name.MinimumWidth = 6;
            this.category_name.Name = "category_name";
            // 
            // typedataGridView
            // 
            this.typedataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.typedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.typedataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type_id,
            this.Type_name});
            this.typedataGridView.Location = new System.Drawing.Point(341, 108);
            this.typedataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.typedataGridView.Name = "typedataGridView";
            this.typedataGridView.RowHeadersWidth = 51;
            this.typedataGridView.RowTemplate.Height = 24;
            this.typedataGridView.Size = new System.Drawing.Size(227, 283);
            this.typedataGridView.TabIndex = 1;
            this.typedataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TypedataGridView_CellValueChanged);
            this.typedataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.TypedataGridView_CellValueChanged);
            // 
            // Type_id
            // 
            this.Type_id.HeaderText = "المعرف";
            this.Type_id.MinimumWidth = 6;
            this.Type_id.Name = "Type_id";
            // 
            // Type_name
            // 
            this.Type_name.HeaderText = "الاسم";
            this.Type_name.MinimumWidth = 6;
            this.Type_name.Name = "Type_name";
            // 
            // compainydataGridView
            // 
            this.compainydataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.compainydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.compainydataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Companies_id,
            this.country,
            this.Companies_name});
            this.compainydataGridView.Location = new System.Drawing.Point(63, 108);
            this.compainydataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.compainydataGridView.Name = "compainydataGridView";
            this.compainydataGridView.RowHeadersWidth = 51;
            this.compainydataGridView.RowTemplate.Height = 24;
            this.compainydataGridView.Size = new System.Drawing.Size(227, 283);
            this.compainydataGridView.TabIndex = 1;
            // 
            // Companies_id
            // 
            this.Companies_id.HeaderText = "المعرف";
            this.Companies_id.MinimumWidth = 6;
            this.Companies_id.Name = "Companies_id";
            // 
            // country
            // 
            this.country.HeaderText = "Country";
            this.country.Name = "country";
            // 
            // Companies_name
            // 
            this.Companies_name.HeaderText = "الاسم";
            this.Companies_name.MinimumWidth = 6;
            this.Companies_name.Name = "Companies_name";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(747, 418);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 31);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "عودة";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnCompanies
            // 
            this.btnCompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompanies.Location = new System.Drawing.Point(55, 418);
            this.btnCompanies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCompanies.Name = "btnCompanies";
            this.btnCompanies.Size = new System.Drawing.Size(69, 27);
            this.btnCompanies.TabIndex = 4;
            this.btnCompanies.Text = "حفظ";
            this.btnCompanies.UseVisualStyleBackColor = true;
            this.btnCompanies.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(723, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "الاصناف";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(455, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "الانواع";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(185, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "الشركة";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // Categories_search
            // 
            this.Categories_search.Location = new System.Drawing.Point(621, 85);
            this.Categories_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Categories_search.Name = "Categories_search";
            this.Categories_search.Size = new System.Drawing.Size(229, 20);
            this.Categories_search.TabIndex = 6;
            this.Categories_search.TextChanged += new System.EventHandler(this.Categories_search_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(-213, 36);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Types_search
            // 
            this.Types_search.Location = new System.Drawing.Point(341, 85);
            this.Types_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Types_search.Name = "Types_search";
            this.Types_search.Size = new System.Drawing.Size(229, 20);
            this.Types_search.TabIndex = 6;
            this.Types_search.TextChanged += new System.EventHandler(this.Types_search_TextChanged);
            // 
            // Companies_search
            // 
            this.Companies_search.Location = new System.Drawing.Point(63, 85);
            this.Companies_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Companies_search.Name = "Companies_search";
            this.Companies_search.Size = new System.Drawing.Size(229, 20);
            this.Companies_search.TabIndex = 6;
            this.Companies_search.TextChanged += new System.EventHandler(this.Companies_search_TextChanged);
            // 
            // btnAddCat
            // 
            this.btnAddCat.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCat.Location = new System.Drawing.Point(621, 414);
            this.btnAddCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.Size = new System.Drawing.Size(70, 31);
            this.btnAddCat.TabIndex = 7;
            this.btnAddCat.Text = "حفظ";
            this.btnAddCat.UseVisualStyleBackColor = true;
            this.btnAddCat.Click += new System.EventHandler(this.BtnAddCat_Click);
            // 
            // btnAddType
            // 
            this.btnAddType.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddType.Location = new System.Drawing.Point(341, 414);
            this.btnAddType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(67, 31);
            this.btnAddType.TabIndex = 8;
            this.btnAddType.Text = "حفظ";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.BtnAddType_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(910, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Managing_varieties_species
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 466);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.btnAddCat);
            this.Controls.Add(this.Companies_search);
            this.Controls.Add(this.Types_search);
            this.Controls.Add(this.Categories_search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCompanies);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.compainydataGridView);
            this.Controls.Add(this.typedataGridView);
            this.Controls.Add(this.categroiesDataGrade);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Managing_varieties_species";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ادارة الشركات والاصناف والانواع";
            ((System.ComponentModel.ISupportInitialize)(this.categroiesDataGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typedataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compainydataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView categroiesDataGrade;
        private System.Windows.Forms.DataGridView typedataGridView;
        private System.Windows.Forms.DataGridView compainydataGridView;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCompanies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Categories_search;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Types_search;
        private System.Windows.Forms.TextBox Companies_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Companies_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Companies_name;
        private System.Windows.Forms.Button btnAddCat;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}