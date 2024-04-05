namespace accessYouku
{
    partial class accessYouku
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txbYoukuLink = new System.Windows.Forms.TextBox();
            this.lblYoukuLink = new System.Windows.Forms.Label();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.grbVideoInfo = new System.Windows.Forms.GroupBox();
            this.grbVideoInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(412, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txbYoukuLink
            // 
            this.txbYoukuLink.Location = new System.Drawing.Point(98, 13);
            this.txbYoukuLink.Name = "txbYoukuLink";
            this.txbYoukuLink.Size = new System.Drawing.Size(308, 20);
            this.txbYoukuLink.TabIndex = 1;
            this.txbYoukuLink.Text = "http://v.youku.com/v_show/id_XMjIxMjUzNjQ0.html";
            // 
            // lblYoukuLink
            // 
            this.lblYoukuLink.AutoSize = true;
            this.lblYoukuLink.Location = new System.Drawing.Point(13, 13);
            this.lblYoukuLink.Name = "lblYoukuLink";
            this.lblYoukuLink.Size = new System.Drawing.Size(79, 13);
            this.lblYoukuLink.TabIndex = 2;
            this.lblYoukuLink.Text = "优酷视频地址";
            // 
            // rtbInfo
            // 
            this.rtbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbInfo.Location = new System.Drawing.Point(3, 16);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(469, 186);
            this.rtbInfo.TabIndex = 3;
            this.rtbInfo.Text = "";
            // 
            // grbVideoInfo
            // 
            this.grbVideoInfo.Controls.Add(this.rtbInfo);
            this.grbVideoInfo.Location = new System.Drawing.Point(12, 39);
            this.grbVideoInfo.Name = "grbVideoInfo";
            this.grbVideoInfo.Size = new System.Drawing.Size(475, 205);
            this.grbVideoInfo.TabIndex = 4;
            this.grbVideoInfo.TabStop = false;
            this.grbVideoInfo.Text = "视频信息";
            // 
            // accessYouku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 256);
            this.Controls.Add(this.grbVideoInfo);
            this.Controls.Add(this.lblYoukuLink);
            this.Controls.Add(this.txbYoukuLink);
            this.Controls.Add(this.btnRefresh);
            this.Name = "accessYouku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刷新优酷视频播放数";
            this.grbVideoInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txbYoukuLink;
        private System.Windows.Forms.Label lblYoukuLink;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.GroupBox grbVideoInfo;
    }
}

