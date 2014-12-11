namespace StructView
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "0",
            "Base",
            "Integer",
            ""}, -1);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv = new System.Windows.Forms.TreeView();
            this.tvContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataSplit = new System.Windows.Forms.SplitContainer();
            this.cmb_structure = new System.Windows.Forms.ComboBox();
            this.txt_adr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ofsChain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.findValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tvContext.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1020, 431);
            this.splitContainer1.SplitterDistance = 495;
            this.splitContainer1.TabIndex = 0;
            // 
            // tv
            // 
            this.tv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv.ContextMenuStrip = this.tvContext;
            this.tv.Location = new System.Drawing.Point(11, 10);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(469, 403);
            this.tv.TabIndex = 0;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            // 
            // tvContext
            // 
            this.tvContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOffsetToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.tvContext.Name = "tvContext";
            this.tvContext.Size = new System.Drawing.Size(153, 92);
            // 
            // addOffsetToolStripMenuItem
            // 
            this.addOffsetToolStripMenuItem.Name = "addOffsetToolStripMenuItem";
            this.addOffsetToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.addOffsetToolStripMenuItem.Text = "Add Offset";
            this.addOffsetToolStripMenuItem.Click += new System.EventHandler(this.addOffsetToolStripMenuItem_Click);
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
            this.DataSplit.Panel1.Controls.Add(this.cmb_structure);
            this.DataSplit.Panel1.Controls.Add(this.txt_adr);
            this.DataSplit.Panel1.Controls.Add(this.label3);
            this.DataSplit.Panel1.Controls.Add(this.txt_ofsChain);
            this.DataSplit.Panel1.Controls.Add(this.label5);
            this.DataSplit.Panel1.Controls.Add(this.label4);
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
            this.DataSplit.Size = new System.Drawing.Size(517, 427);
            this.DataSplit.SplitterDistance = 102;
            this.DataSplit.TabIndex = 0;
            // 
            // cmb_structure
            // 
            this.cmb_structure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmb_structure.FormattingEnabled = true;
            this.cmb_structure.Location = new System.Drawing.Point(235, 76);
            this.cmb_structure.Name = "cmb_structure";
            this.cmb_structure.Size = new System.Drawing.Size(187, 21);
            this.cmb_structure.TabIndex = 2;
            this.cmb_structure.TextChanged += new System.EventHandler(this.cmb_structure_TextChanged);
            // 
            // txt_adr
            // 
            this.txt_adr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_adr.Location = new System.Drawing.Point(80, 75);
            this.txt_adr.Name = "txt_adr";
            this.txt_adr.Size = new System.Drawing.Size(91, 20);
            this.txt_adr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "calc. Adress";
            // 
            // txt_ofsChain
            // 
            this.txt_ofsChain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ofsChain.Location = new System.Drawing.Point(231, 40);
            this.txt_ofsChain.Name = "txt_ofsChain";
            this.txt_ofsChain.ReadOnly = true;
            this.txt_ofsChain.Size = new System.Drawing.Size(271, 20);
            this.txt_ofsChain.TabIndex = 1;
            this.txt_ofsChain.Leave += new System.EventHandler(this.txt_offs_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Structure";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ofs-Chain";
            // 
            // txt_offs
            // 
            this.txt_offs.Location = new System.Drawing.Point(80, 40);
            this.txt_offs.Name = "txt_offs";
            this.txt_offs.Size = new System.Drawing.Size(91, 20);
            this.txt_offs.TabIndex = 1;
            this.txt_offs.Leave += new System.EventHandler(this.txt_offs_Leave);
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
            this.txt_desc.Size = new System.Drawing.Size(422, 20);
            this.txt_desc.TabIndex = 1;
            this.txt_desc.Leave += new System.EventHandler(this.txt_desc_Leave);
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
            listViewItem4});
            this.dta.Location = new System.Drawing.Point(0, 0);
            this.dta.Name = "dta";
            this.dta.Size = new System.Drawing.Size(513, 317);
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
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
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
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcMemAdressToolStripMenuItem,
            this.findValueToolStripMenuItem});
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
            // findValueToolStripMenuItem
            // 
            this.findValueToolStripMenuItem.Name = "findValueToolStripMenuItem";
            this.findValueToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.findValueToolStripMenuItem.Text = "Find Value";
            this.findValueToolStripMenuItem.Click += new System.EventHandler(this.findValueToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Duplicate";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 459);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "StructureView";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tvContext.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip tvContext;
        private System.Windows.Forms.ToolStripMenuItem addOffsetToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_ofsChain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem findValueToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmb_structure;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

