namespace DNSsniffer.View
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tboxKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lvDisplay = new System.Windows.Forms.ListView();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tboxValue = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Domain";
            // 
            // tboxKey
            // 
            this.tboxKey.Location = new System.Drawing.Point(81, 10);
            this.tboxKey.Name = "tboxKey";
            this.tboxKey.Size = new System.Drawing.Size(341, 28);
            this.tboxKey.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(428, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(428, 40);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(99, 28);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lvDisplay
            // 
            this.lvDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvDisplay.FullRowSelect = true;
            this.lvDisplay.GridLines = true;
            this.lvDisplay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDisplay.HideSelection = false;
            this.lvDisplay.Location = new System.Drawing.Point(16, 74);
            this.lvDisplay.Name = "lvDisplay";
            this.lvDisplay.Size = new System.Drawing.Size(511, 329);
            this.lvDisplay.TabIndex = 6;
            this.lvDisplay.UseCompatibleStateImageBehavior = false;
            this.lvDisplay.View = System.Windows.Forms.View.Details;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(16, 409);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(259, 28);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(268, 409);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(259, 28);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Domain";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Address";
            this.columnHeader2.Width = 250;
            // 
            // tboxValue
            // 
            this.tboxValue.Location = new System.Drawing.Point(81, 40);
            this.tboxValue.Mask = "999.999.999.999";
            this.tboxValue.Name = "tboxValue";
            this.tboxValue.PromptChar = ' ';
            this.tboxValue.Size = new System.Drawing.Size(341, 28);
            this.tboxValue.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 450);
            this.Controls.Add(this.tboxValue);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lvDisplay);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxKey);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DNSsniffer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListView lvDisplay;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.MaskedTextBox tboxValue;
    }
}

