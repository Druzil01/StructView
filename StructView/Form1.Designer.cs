namespace StructView
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "0",
            "Base",
            "Integer",
            ""}, -1);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv = new System.Windows.Forms.TreeView();
            this.DataSplit = new System.Windows.Forms.SplitContainer();
            this.txt_adr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_offs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dta = new System.Windows.Forms.ListView();
            this.Offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Datatype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Curent_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcMemAdressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSplit)).BeginInit();
            this.DataSplit.Panel1.SuspendLayout();
            this.DataSplit.Panel2.SuspendLayout();
            this.DataSplit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataSplit);
            this.splitContainer1.Size = new System.Drawing.Size(997, 432);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 0;
            // 
            // tv
            // 
            this.tv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tv.Location = new System.Drawing.Point(11, 10);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(460, 404);
            this.tv.TabIndex = 0;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // DataSplit
            // 
            this.DataSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataSplit.Location = new System.Drawing.Point(0, 0);
            this.DataSplit.Name = "DataSplit";
            this.DataSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // DataSplit.Panel1
            // 
            this.DataSplit.Panel1.Controls.Add(this.txt_adr);
            this.DataSplit.Panel1.Controls.Add(this.label3);
            this.DataSplit.Panel1.Controls.Add(this.txt_offs);
            this.DataSplit.Panel1.Controls.Add(this.label2);
            this.DataSplit.Panel1.Controls.Add(this.txt_desc);
            this.DataSplit.Panel1.Controls.Add(this.label1);
            this.DataSplit.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // DataSplit.Panel2
            // 
            this.DataSplit.Panel2.Controls.Add(this.dta);
            this.DataSplit.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DataSplit.Size = new System.Drawing.Size(503, 428);
            this.DataSplit.SplitterDistance = 104;
            this.DataSplit.TabIndex = 0;
            // 
            // txt_adr
            // 
            this.txt_adr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_adr.Location = new System.Drawing.Point(80, 77);
            this.txt_adr.Name = "txt_adr";
            this.txt_adr.Size = new System.Drawing.Size(91, 20);
            this.txt_adr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "calc. Adress";
            // 
            // txt_offs
            // 
            this.txt_offs.Location = new System.Drawing.Point(80, 40);
            this.txt_offs.Name = "txt_offs";
            this.txt_offs.Size = new System.Drawing.Size(91, 20);
            this.txt_offs.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "offset";
            // 
            // txt_desc
            // 
            this.txt_desc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_desc.Location = new System.Drawing.Point(80, 14);
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(408, 20);
            this.txt_desc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "descripton";
            // 
            // dta
            // 
            this.dta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Offset,
            this.description,
            this.Datatype,
            this.Curent_Value});
            this.dta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dta.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dta.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.dta.Location = new System.Drawing.Point(0, 0);
            this.dta.Name = "dta";
            this.dta.Size = new System.Drawing.Size(499, 316);
            this.dta.TabIndex = 1;
            this.dta.UseCompatibleStateImageBehavior = false;
            this.dta.View = System.Windows.Forms.View.Details;
            // 
            // Offset
            // 
            this.Offset.Text = "Offset";
            // 
            // description
            // 
            this.description.Text = "description";
            this.description.Width = 105;
            // 
            // Datatype
            // 
            this.Datatype.Text = "Datatype";
            // 
            // Curent_Value
            // 
            this.Curent_Value.Text = "current Value";
            this.Curent_Value.Width = 267;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(997, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcMemAdressToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // calcMemAdressToolStripMenuItem
            // 
            this.calcMemAdressToolStripMenuItem.Name = "calcMemAdressToolStripMenuItem";
            this.calcMemAdressToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.calcMemAdressToolStripMenuItem.Text = "Calc Mem Adress";
            this.calcMemAdressToolStripMenuItem.Click += new System.EventHandler(this.calcMemAdressToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 460);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.DataSplit.Panel1.ResumeLayout(false);
            this.DataSplit.Panel1.PerformLayout();
            this.DataSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataSplit)).EndInit();
            this.DataSplit.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer DataSplit;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_adr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_offs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView dta;
        private System.Windows.Forms.ColumnHeader Offset;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ColumnHeader Datatype;
        private System.Windows.Forms.ColumnHeader Curent_Value;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calcMemAdressToolStripMenuItem;
    }
}

