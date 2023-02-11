namespace ResourceMonitor
{
    partial class MonitorForm
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
            this.MemoryLabel = new System.Windows.Forms.Label();
            this.CpuLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MemoryLabel
            // 
            this.MemoryLabel.AutoSize = true;
            this.MemoryLabel.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryLabel.Location = new System.Drawing.Point(13, 13);
            this.MemoryLabel.Name = "MemoryLabel";
            this.MemoryLabel.Size = new System.Drawing.Size(81, 20);
            this.MemoryLabel.TabIndex = 0;
            this.MemoryLabel.Text = "Memory: ";
            this.MemoryLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonitorForm_MouseDown);
            // 
            // CpuLabel
            // 
            this.CpuLabel.AutoSize = true;
            this.CpuLabel.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CpuLabel.Location = new System.Drawing.Point(13, 42);
            this.CpuLabel.Name = "CpuLabel";
            this.CpuLabel.Size = new System.Drawing.Size(54, 20);
            this.CpuLabel.TabIndex = 1;
            this.CpuLabel.Text = "CPU: ";
            this.CpuLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonitorForm_MouseDown);
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(167, 74);
            this.Controls.Add(this.CpuLabel);
            this.Controls.Add(this.MemoryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MonitorForm";
            this.Text = "MonitorForm";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonitorForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MemoryLabel;
        private System.Windows.Forms.Label CpuLabel;
    }
}

