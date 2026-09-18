namespace QuanLyThuVien.Forms
{
    partial class FrmMain
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
            this.btnDanhMuc_Click = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDanhMuc_Click
            // 
            this.btnDanhMuc_Click.Location = new System.Drawing.Point(99, 141);
            this.btnDanhMuc_Click.Name = "btnDanhMuc_Click";
            this.btnDanhMuc_Click.Size = new System.Drawing.Size(240, 82);
            this.btnDanhMuc_Click.TabIndex = 0;
            this.btnDanhMuc_Click.Text = "Danh mục / Nhân viên";
            this.btnDanhMuc_Click.UseVisualStyleBackColor = true;
            this.btnDanhMuc_Click.Click += new System.EventHandler(this.BtnDanhMuc_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(575, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 82);
            this.button2.TabIndex = 1;
            this.button2.Text = "Quản lý đầu sách";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(99, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(240, 82);
            this.button3.TabIndex = 2;
            this.button3.Text = "Độc giả và thẻ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(575, 280);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(240, 82);
            this.button4.TabIndex = 3;
            this.button4.Text = "Mượn - Trả sách";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(99, 408);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(240, 82);
            this.button5.TabIndex = 4;
            this.button5.Text = "Thống kê";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(575, 408);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(240, 82);
            this.button6.TabIndex = 5;
            this.button6.Text = "Thoát";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ THƯ VIÊN ";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 538);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDanhMuc_Click);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDanhMuc_Click;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
    }
}