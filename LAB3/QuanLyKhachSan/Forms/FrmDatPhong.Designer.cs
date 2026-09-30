namespace QuanLyKhachSan.Forms
{
    partial class FrmDatPhong
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvKhach = new System.Windows.Forms.DataGridView();
            this.btnThemKhach = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cboKhach = new System.Windows.Forms.ComboBox();
            this.cboKenh = new System.Windows.Forms.ComboBox();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.dtLap = new System.Windows.Forms.DateTimePicker();
            this.dtTra = new System.Windows.Forms.DateTimePicker();
            this.dtNhan = new System.Windows.Forms.DateTimePicker();
            this.numCoc = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(48, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1087, 707);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvKhach);
            this.tabPage1.Controls.Add(this.btnThemKhach);
            this.tabPage1.Controls.Add(this.txtSDT);
            this.tabPage1.Controls.Add(this.txtQT);
            this.tabPage1.Controls.Add(this.txtCMND);
            this.tabPage1.Controls.Add(this.txtTenKH);
            this.tabPage1.Controls.Add(this.txtMaKH);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1079, 674);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Khách hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvKhach
            // 
            this.dgvKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhach.Location = new System.Drawing.Point(51, 260);
            this.dgvKhach.MultiSelect = false;
            this.dgvKhach.Name = "dgvKhach";
            this.dgvKhach.ReadOnly = true;
            this.dgvKhach.RowHeadersWidth = 62;
            this.dgvKhach.RowTemplate.Height = 28;
            this.dgvKhach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhach.Size = new System.Drawing.Size(981, 388);
            this.dgvKhach.TabIndex = 11;
            // 
            // btnThemKhach
            // 
            this.btnThemKhach.Location = new System.Drawing.Point(838, 159);
            this.btnThemKhach.Name = "btnThemKhach";
            this.btnThemKhach.Size = new System.Drawing.Size(194, 76);
            this.btnThemKhach.TabIndex = 10;
            this.btnThemKhach.Text = "Thêm";
            this.btnThemKhach.UseVisualStyleBackColor = true;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(707, 110);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(325, 26);
            this.txtSDT.TabIndex = 9;
            // 
            // txtQT
            // 
            this.txtQT.Location = new System.Drawing.Point(707, 63);
            this.txtQT.Name = "txtQT";
            this.txtQT.Size = new System.Drawing.Size(325, 26);
            this.txtQT.TabIndex = 8;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(214, 153);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(325, 26);
            this.txtCMND.TabIndex = 7;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(214, 108);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(325, 26);
            this.txtTenKH.TabIndex = 6;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(214, 63);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(325, 26);
            this.txtMaKH.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số điện thoại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quốc tịch:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "CMND/CCCD:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numCoc);
            this.tabPage2.Controls.Add(this.dtNhan);
            this.tabPage2.Controls.Add(this.dtTra);
            this.tabPage2.Controls.Add(this.dtLap);
            this.tabPage2.Controls.Add(this.cboNV);
            this.tabPage2.Controls.Add(this.cboKenh);
            this.tabPage2.Controls.Add(this.cboKhach);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtSoPhieu);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1079, 674);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Đặt phòng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(97, 334);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Tiền cọc:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(97, 298);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 20);
            this.label12.TabIndex = 7;
            this.label12.Text = "Ngày trả dự kiến:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Ngày nhận:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(97, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ngày lập:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Kênh đặt:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Nhân viên lễ tân:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Khách hàng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Số phiếu:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(243, 71);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(251, 26);
            this.txtSoPhieu.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1079, 674);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Nhận phòng / Người lưu trú";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cboKhach
            // 
            this.cboKhach.FormattingEnabled = true;
            this.cboKhach.Location = new System.Drawing.Point(243, 108);
            this.cboKhach.Name = "cboKhach";
            this.cboKhach.Size = new System.Drawing.Size(251, 28);
            this.cboKhach.TabIndex = 9;
            // 
            // cboKenh
            // 
            this.cboKenh.FormattingEnabled = true;
            this.cboKenh.Location = new System.Drawing.Point(243, 180);
            this.cboKenh.Name = "cboKenh";
            this.cboKenh.Size = new System.Drawing.Size(251, 28);
            this.cboKenh.TabIndex = 10;
            // 
            // cboNV
            // 
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(243, 144);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(251, 28);
            this.cboNV.TabIndex = 11;
            // 
            // dtLap
            // 
            this.dtLap.Location = new System.Drawing.Point(243, 218);
            this.dtLap.Name = "dtLap";
            this.dtLap.Size = new System.Drawing.Size(251, 26);
            this.dtLap.TabIndex = 12;
            // 
            // dtTra
            // 
            this.dtTra.Location = new System.Drawing.Point(243, 292);
            this.dtTra.Name = "dtTra";
            this.dtTra.Size = new System.Drawing.Size(251, 26);
            this.dtTra.TabIndex = 13;
            // 
            // dtNhan
            // 
            this.dtNhan.Location = new System.Drawing.Point(243, 255);
            this.dtNhan.Name = "dtNhan";
            this.dtNhan.Size = new System.Drawing.Size(251, 26);
            this.dtNhan.TabIndex = 14;
            // 
            // numCoc
            // 
            this.numCoc.Location = new System.Drawing.Point(243, 328);
            this.numCoc.Name = "numCoc";
            this.numCoc.Size = new System.Drawing.Size(251, 26);
            this.numCoc.TabIndex = 15;
            // 
            // FrmDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 810);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmDatPhong";
            this.Text = "FrmDatPhong";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvKhach;
        private System.Windows.Forms.Button btnThemKhach;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtQT;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtNhan;
        private System.Windows.Forms.DateTimePicker dtTra;
        private System.Windows.Forms.DateTimePicker dtLap;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.ComboBox cboKenh;
        private System.Windows.Forms.ComboBox cboKhach;
        private System.Windows.Forms.NumericUpDown numCoc;
    }
}