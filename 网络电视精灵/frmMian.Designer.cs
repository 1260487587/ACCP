namespace 网络电视精灵
{
    partial class frmMian
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvList = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvProgramList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabProgram = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.更新节目单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提醒管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.加入我的电台ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDgvList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.播放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramList)).BeginInit();
            this.tabProgram.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cmsInto.SuspendLayout();
            this.cmsDelete.SuspendLayout();
            this.cmsDgvList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvList
            // 
            this.tvList.Location = new System.Drawing.Point(22, 63);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(260, 456);
            this.tvList.TabIndex = 0;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvProgramList);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(594, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "节目";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvProgramList
            // 
            this.dgvProgramList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProgramList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgramList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvProgramList.ContextMenuStrip = this.cmsDgvList;
            this.dgvProgramList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProgramList.Location = new System.Drawing.Point(3, 3);
            this.dgvProgramList.Name = "dgvProgramList";
            this.dgvProgramList.RowTemplate.Height = 27;
            this.dgvProgramList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgramList.Size = new System.Drawing.Size(588, 421);
            this.dgvProgramList.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PlayTime";
            this.Column1.HeaderText = "播放时间";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "节目名称";
            this.Column2.Name = "Column2";
            // 
            // tabProgram
            // 
            this.tabProgram.Controls.Add(this.tabPage1);
            this.tabProgram.Location = new System.Drawing.Point(307, 63);
            this.tabProgram.Name = "tabProgram";
            this.tabProgram.SelectedIndex = 0;
            this.tabProgram.Size = new System.Drawing.Size(602, 456);
            this.tabProgram.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新节目单ToolStripMenuItem,
            this.提醒管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 更新节目单ToolStripMenuItem
            // 
            this.更新节目单ToolStripMenuItem.Name = "更新节目单ToolStripMenuItem";
            this.更新节目单ToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.更新节目单ToolStripMenuItem.Text = "更新节目单";
            // 
            // 提醒管理ToolStripMenuItem
            // 
            this.提醒管理ToolStripMenuItem.Name = "提醒管理ToolStripMenuItem";
            this.提醒管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.提醒管理ToolStripMenuItem.Text = "提醒管理";
            // 
            // cmsInto
            // 
            this.cmsInto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加入我的电台ToolStripMenuItem});
            this.cmsInto.Name = "cmsInto";
            this.cmsInto.Size = new System.Drawing.Size(169, 28);
            // 
            // 加入我的电台ToolStripMenuItem
            // 
            this.加入我的电台ToolStripMenuItem.Name = "加入我的电台ToolStripMenuItem";
            this.加入我的电台ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.加入我的电台ToolStripMenuItem.Text = "加入我的电台";
            this.加入我的电台ToolStripMenuItem.Click += new System.EventHandler(this.加入我的电台ToolStripMenuItem_Click);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(109, 28);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // cmsDgvList
            // 
            this.cmsDgvList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.播放ToolStripMenuItem});
            this.cmsDgvList.Name = "cmsDgvList";
            this.cmsDgvList.Size = new System.Drawing.Size(153, 50);
            // 
            // 播放ToolStripMenuItem
            // 
            this.播放ToolStripMenuItem.Name = "播放ToolStripMenuItem";
            this.播放ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.播放ToolStripMenuItem.Text = "播放";
            this.播放ToolStripMenuItem.Click += new System.EventHandler(this.播放ToolStripMenuItem_Click);
            // 
            // frmMian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 549);
            this.Controls.Add(this.tabProgram);
            this.Controls.Add(this.tvList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMian";
            this.Text = "网络电视精灵";
            this.Load += new System.EventHandler(this.frmMian_Load);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramList)).EndInit();
            this.tabProgram.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmsInto.ResumeLayout(false);
            this.cmsDelete.ResumeLayout(false);
            this.cmsDgvList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabProgram;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 更新节目单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 提醒管理ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvProgramList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ContextMenuStrip cmsInto;
        private System.Windows.Forms.ToolStripMenuItem 加入我的电台ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsDelete;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsDgvList;
        private System.Windows.Forms.ToolStripMenuItem 播放ToolStripMenuItem;
    }
}

