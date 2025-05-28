namespace PharmacySystem.view
{
    partial class Sales
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
            this.MinuBar = new System.Windows.Forms.MenuStrip();
            this.Header = new System.Windows.Forms.Panel();
            this.GoBabk = new System.Windows.Forms.Button();
            this.DataTableContainer = new System.Windows.Forms.DataGridView();
            this.FilterContainer = new System.Windows.Forms.TableLayoutPanel();
            this.CategotyLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.FromLabel = new System.Windows.Forms.Label();
            this.SearchContainer = new System.Windows.Forms.TableLayoutPanel();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchPicture = new System.Windows.Forms.PictureBox();
            this.CategoryCB = new System.Windows.Forms.ComboBox();
            this.TypeCB = new System.Windows.Forms.ComboBox();
            this.CompanyCB = new System.Windows.Forms.ComboBox();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.RefreshBTN = new System.Windows.Forms.Button();
            this.MainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableContainer)).BeginInit();
            this.FilterContainer.SuspendLayout();
            this.SearchContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPicture)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MinuBar
            // 
            this.MinuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MinuBar.Location = new System.Drawing.Point(0, 0);
            this.MinuBar.Name = "MinuBar";
            this.MinuBar.Padding = new System.Windows.Forms.Padding(13, 4, 0, 4);
            this.MinuBar.Size = new System.Drawing.Size(955, 24);
            this.MinuBar.TabIndex = 1;
            this.MinuBar.Text = "menuStrip1";
            // 
            // Header
            // 
            this.Header.Controls.Add(this.GoBabk);
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Location = new System.Drawing.Point(7, 7);
            this.Header.Margin = new System.Windows.Forms.Padding(7);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(941, 77);
            this.Header.TabIndex = 2;
            // 
            // GoBabk
            // 
            this.GoBabk.Dock = System.Windows.Forms.DockStyle.Right;
            this.GoBabk.Location = new System.Drawing.Point(825, 0);
            this.GoBabk.Name = "GoBabk";
            this.GoBabk.Size = new System.Drawing.Size(116, 77);
            this.GoBabk.TabIndex = 0;
            this.GoBabk.Text = "الرجوع للخلف";
            this.GoBabk.UseVisualStyleBackColor = true;
            this.GoBabk.Click += new System.EventHandler(this.GoBabk_Click);
            // 
            // DataTableContainer
            // 
            this.DataTableContainer.AllowUserToAddRows = false;
            this.DataTableContainer.AllowUserToDeleteRows = false;
            this.DataTableContainer.AllowUserToOrderColumns = true;
            this.DataTableContainer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataTableContainer.ColumnHeadersHeight = 50;
            this.DataTableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTableContainer.Location = new System.Drawing.Point(3, 200);
            this.DataTableContainer.Name = "DataTableContainer";
            this.DataTableContainer.ReadOnly = true;
            this.DataTableContainer.Size = new System.Drawing.Size(949, 447);
            this.DataTableContainer.TabIndex = 4;
            this.DataTableContainer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TabelCellDoubleClick);
            // 
            // FilterContainer
            // 
            this.FilterContainer.ColumnCount = 6;
            this.FilterContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.FilterContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.FilterContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.FilterContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.FilterContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.FilterContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57142F));
            this.FilterContainer.Controls.Add(this.CategotyLabel, 4, 0);
            this.FilterContainer.Controls.Add(this.TypeLabel, 3, 0);
            this.FilterContainer.Controls.Add(this.CompanyLabel, 2, 0);
            this.FilterContainer.Controls.Add(this.ToLabel, 1, 0);
            this.FilterContainer.Controls.Add(this.FromLabel, 0, 0);
            this.FilterContainer.Controls.Add(this.SearchContainer, 5, 1);
            this.FilterContainer.Controls.Add(this.CategoryCB, 4, 1);
            this.FilterContainer.Controls.Add(this.TypeCB, 3, 1);
            this.FilterContainer.Controls.Add(this.CompanyCB, 2, 1);
            this.FilterContainer.Controls.Add(this.ToDate, 1, 1);
            this.FilterContainer.Controls.Add(this.FromDate, 0, 1);
            this.FilterContainer.Controls.Add(this.tableLayoutPanel1, 5, 0);
            this.FilterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterContainer.Location = new System.Drawing.Point(7, 98);
            this.FilterContainer.Margin = new System.Windows.Forms.Padding(7);
            this.FilterContainer.Name = "FilterContainer";
            this.FilterContainer.RowCount = 2;
            this.FilterContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FilterContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FilterContainer.Size = new System.Drawing.Size(941, 92);
            this.FilterContainer.TabIndex = 3;
            // 
            // CategotyLabel
            // 
            this.CategotyLabel.AutoSize = true;
            this.CategotyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategotyLabel.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CategotyLabel.Location = new System.Drawing.Point(278, 0);
            this.CategotyLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.CategotyLabel.Name = "CategotyLabel";
            this.CategotyLabel.Size = new System.Drawing.Size(120, 29);
            this.CategotyLabel.TabIndex = 1;
            this.CategotyLabel.Text = "الصنف";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeLabel.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TypeLabel.Location = new System.Drawing.Point(412, 0);
            this.TypeLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(120, 29);
            this.TypeLabel.TabIndex = 2;
            this.TypeLabel.Text = "النوع";
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyLabel.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CompanyLabel.Location = new System.Drawing.Point(546, 0);
            this.CompanyLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(120, 29);
            this.CompanyLabel.TabIndex = 3;
            this.CompanyLabel.Text = "الشركة المصنعة";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToLabel.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToLabel.Location = new System.Drawing.Point(680, 0);
            this.ToLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(120, 29);
            this.ToLabel.TabIndex = 4;
            this.ToLabel.Text = "حتى";
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FromLabel.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromLabel.Location = new System.Drawing.Point(814, 0);
            this.FromLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(120, 29);
            this.FromLabel.TabIndex = 5;
            this.FromLabel.Text = "من تاريخ";
            // 
            // SearchContainer
            // 
            this.SearchContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.SearchContainer.ColumnCount = 2;
            this.SearchContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SearchContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.SearchContainer.Controls.Add(this.SearchText, 1, 0);
            this.SearchContainer.Controls.Add(this.SearchPicture, 0, 0);
            this.SearchContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchContainer.Location = new System.Drawing.Point(7, 36);
            this.SearchContainer.Margin = new System.Windows.Forms.Padding(7);
            this.SearchContainer.Name = "SearchContainer";
            this.SearchContainer.RowCount = 1;
            this.SearchContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchContainer.Size = new System.Drawing.Size(257, 49);
            this.SearchContainer.TabIndex = 6;
            this.SearchContainer.Click += new System.EventHandler(this.Search_click);
            // 
            // SearchText
            // 
            this.SearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchText.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.SearchText.Location = new System.Drawing.Point(5, 10);
            this.SearchText.Margin = new System.Windows.Forms.Padding(7);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(199, 34);
            this.SearchText.TabIndex = 1;
            this.SearchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SearchText.TextChanged += new System.EventHandler(this.SearchText_TextChanged);
            // 
            // SearchPicture
            // 
            this.SearchPicture.Location = new System.Drawing.Point(217, 6);
            this.SearchPicture.Name = "SearchPicture";
            this.SearchPicture.Size = new System.Drawing.Size(34, 38);
            this.SearchPicture.TabIndex = 2;
            this.SearchPicture.TabStop = false;
            // 
            // CategoryCB
            // 
            this.CategoryCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryCB.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CategoryCB.FormattingEnabled = true;
            this.CategoryCB.Location = new System.Drawing.Point(278, 36);
            this.CategoryCB.Margin = new System.Windows.Forms.Padding(7);
            this.CategoryCB.Name = "CategoryCB";
            this.CategoryCB.Size = new System.Drawing.Size(120, 35);
            this.CategoryCB.TabIndex = 7;
            this.CategoryCB.SelectedIndexChanged += new System.EventHandler(this.CategoryCB_SelectedIndexChanged);
            // 
            // TypeCB
            // 
            this.TypeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeCB.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TypeCB.FormattingEnabled = true;
            this.TypeCB.Location = new System.Drawing.Point(412, 36);
            this.TypeCB.Margin = new System.Windows.Forms.Padding(7);
            this.TypeCB.Name = "TypeCB";
            this.TypeCB.Size = new System.Drawing.Size(120, 35);
            this.TypeCB.TabIndex = 8;
            this.TypeCB.SelectedIndexChanged += new System.EventHandler(this.TypeCB_SelectedIndexChanged);
            // 
            // CompanyCB
            // 
            this.CompanyCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyCB.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CompanyCB.FormattingEnabled = true;
            this.CompanyCB.Location = new System.Drawing.Point(546, 36);
            this.CompanyCB.Margin = new System.Windows.Forms.Padding(7);
            this.CompanyCB.Name = "CompanyCB";
            this.CompanyCB.Size = new System.Drawing.Size(120, 35);
            this.CompanyCB.TabIndex = 9;
            this.CompanyCB.SelectedIndexChanged += new System.EventHandler(this.CompanyCB_SelectedIndexChanged);
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "dd/mm/yyyy";
            this.ToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToDate.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDate.Location = new System.Drawing.Point(680, 36);
            this.ToDate.Margin = new System.Windows.Forms.Padding(7);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(120, 34);
            this.ToDate.TabIndex = 10;
            this.ToDate.ValueChanged += new System.EventHandler(this.ToDate_ValueChanged);
            // 
            // FromDate
            // 
            this.FromDate.CustomFormat = "dd/mm/yyyy";
            this.FromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FromDate.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDate.Location = new System.Drawing.Point(814, 36);
            this.FromDate.Margin = new System.Windows.Forms.Padding(7);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(120, 34);
            this.FromDate.TabIndex = 11;
            this.FromDate.ValueChanged += new System.EventHandler(this.FromDate_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.84791F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.15209F));
            this.tableLayoutPanel1.Controls.Add(this.SearchLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RefreshBTN, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(265, 23);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchLabel.Font = new System.Drawing.Font("PT Bold Dusky", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.SearchLabel.Location = new System.Drawing.Point(61, 0);
            this.SearchLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(197, 23);
            this.SearchLabel.TabIndex = 0;
            this.SearchLabel.Text = "البحث";
            // 
            // RefreshBTN
            // 
            this.RefreshBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RefreshBTN.Font = new System.Drawing.Font("Perpetua Titling MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBTN.Location = new System.Drawing.Point(3, 3);
            this.RefreshBTN.Name = "RefreshBTN";
            this.RefreshBTN.Size = new System.Drawing.Size(48, 17);
            this.RefreshBTN.TabIndex = 1;
            this.RefreshBTN.Text = "R";
            this.RefreshBTN.UseVisualStyleBackColor = true;
            this.RefreshBTN.Click += new System.EventHandler(this.RefreshBTN_Click);
            // 
            // MainContainer
            // 
            this.MainContainer.ColumnCount = 1;
            this.MainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainContainer.Controls.Add(this.Header, 0, 0);
            this.MainContainer.Controls.Add(this.FilterContainer, 0, 1);
            this.MainContainer.Controls.Add(this.DataTableContainer, 0, 2);
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 24);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.RowCount = 3;
            this.MainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.MainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.MainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainContainer.Size = new System.Drawing.Size(955, 650);
            this.MainContainer.TabIndex = 4;
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 674);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.MinuBar);
            this.Font = new System.Drawing.Font("PT Bold Broken", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MainMenuStrip = this.MinuBar;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Sales";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Sales";
            this.Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableContainer)).EndInit();
            this.FilterContainer.ResumeLayout(false);
            this.FilterContainer.PerformLayout();
            this.SearchContainer.ResumeLayout(false);
            this.SearchContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPicture)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MainContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MinuBar;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.DataGridView DataTableContainer;
        private System.Windows.Forms.TableLayoutPanel FilterContainer;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label CategotyLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label CompanyLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.TableLayoutPanel SearchContainer;
        private System.Windows.Forms.PictureBox SearchPicture;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.ComboBox CategoryCB;
        private System.Windows.Forms.ComboBox TypeCB;
        private System.Windows.Forms.ComboBox CompanyCB;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.Button GoBabk;
        private System.Windows.Forms.TableLayoutPanel MainContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button RefreshBTN;
    }
}