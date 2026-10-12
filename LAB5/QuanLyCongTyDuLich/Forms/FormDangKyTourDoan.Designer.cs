namespace QuanLyCongTyDuLich.GUI
{
    partial class FormDangKyTourDoan
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
            this.gbThongTinTour = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboChuyenTour = new System.Windows.Forms.ComboBox();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.gbThongTinDoan = new System.Windows.Forms.GroupBox();
            this.txtTenDonVi = new System.Windows.Forms.TextBox();
            this.txtNguoiDaiDien = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.nudSoLuongKhach = new System.Windows.Forms.NumericUpDown();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.gbChiPhi = new System.Windows.Forms.GroupBox();
            this.numTongTien = new System.Windows.Forms.NumericUpDown();
            this.numTienCoc = new System.Windows.Forms.NumericUpDown();
            this.btnLuuDangKy = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtDiaDiemDon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbThongTinTour.SuspendLayout();
            this.gbThongTinDoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongKhach)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.gbChiPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTongTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienCoc)).BeginInit();
            this.SuspendLayout();
            // 
            // gbThongTinTour
            // 
            this.gbThongTinTour.Controls.Add(this.cboKhachHang);
            this.gbThongTinTour.Controls.Add(this.cboChuyenTour);
            this.gbThongTinTour.Controls.Add(this.label2);
            this.gbThongTinTour.Controls.Add(this.label1);
            this.gbThongTinTour.Location = new System.Drawing.Point(16, 79);
            this.gbThongTinTour.Name = "gbThongTinTour";
            this.gbThongTinTour.Size = new System.Drawing.Size(740, 100);
            this.gbThongTinTour.TabIndex = 0;
            this.gbThongTinTour.TabStop = false;
            this.gbThongTinTour.Text = "THÔNG TIN TOUR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chuyến tour (*):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Khách đại diện (*):";
            // 
            // cboChuyenTour
            // 
            this.cboChuyenTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenTour.DropDownWidth = 250;
            this.cboChuyenTour.FormattingEnabled = true;
            this.cboChuyenTour.Location = new System.Drawing.Point(218, 24);
            this.cboChuyenTour.Name = "cboChuyenTour";
            this.cboChuyenTour.Size = new System.Drawing.Size(476, 28);
            this.cboChuyenTour.TabIndex = 2;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.DropDownWidth = 250;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(218, 66);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(476, 28);
            this.cboKhachHang.TabIndex = 3;
            // 
            // gbThongTinDoan
            // 
            this.gbThongTinDoan.Controls.Add(this.label7);
            this.gbThongTinDoan.Controls.Add(this.label8);
            this.gbThongTinDoan.Controls.Add(this.label6);
            this.gbThongTinDoan.Controls.Add(this.label5);
            this.gbThongTinDoan.Controls.Add(this.label4);
            this.gbThongTinDoan.Controls.Add(this.txtDiaDiemDon);
            this.gbThongTinDoan.Controls.Add(this.nudSoLuongKhach);
            this.gbThongTinDoan.Controls.Add(this.txtSoDienThoai);
            this.gbThongTinDoan.Controls.Add(this.txtNguoiDaiDien);
            this.gbThongTinDoan.Controls.Add(this.txtTenDonVi);
            this.gbThongTinDoan.Location = new System.Drawing.Point(16, 197);
            this.gbThongTinDoan.Name = "gbThongTinDoan";
            this.gbThongTinDoan.Size = new System.Drawing.Size(740, 273);
            this.gbThongTinDoan.TabIndex = 1;
            this.gbThongTinDoan.TabStop = false;
            this.gbThongTinDoan.Text = "THÔNG TIN ĐOÀN ĐĂNG KÝ";
            // 
            // txtTenDonVi
            // 
            this.txtTenDonVi.Location = new System.Drawing.Point(218, 39);
            this.txtTenDonVi.Name = "txtTenDonVi";
            this.txtTenDonVi.Size = new System.Drawing.Size(476, 26);
            this.txtTenDonVi.TabIndex = 0;
            // 
            // txtNguoiDaiDien
            // 
            this.txtNguoiDaiDien.Location = new System.Drawing.Point(218, 75);
            this.txtNguoiDaiDien.Name = "txtNguoiDaiDien";
            this.txtNguoiDaiDien.Size = new System.Drawing.Size(476, 26);
            this.txtNguoiDaiDien.TabIndex = 1;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(218, 116);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(476, 26);
            this.txtSoDienThoai.TabIndex = 2;
            // 
            // nudSoLuongKhach
            // 
            this.nudSoLuongKhach.Location = new System.Drawing.Point(218, 158);
            this.nudSoLuongKhach.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSoLuongKhach.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudSoLuongKhach.Name = "nudSoLuongKhach";
            this.nudSoLuongKhach.Size = new System.Drawing.Size(476, 26);
            this.nudSoLuongKhach.TabIndex = 3;
            this.nudSoLuongKhach.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(771, 73);
            this.pnlHeader.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(120, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(547, 38);
            this.label3.TabIndex = 0;
            this.label3.Text = "LẬP PHIẾU ĐĂNG KÝ TOUR THEO ĐOÀN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbChiPhi
            // 
            this.gbChiPhi.Controls.Add(this.label10);
            this.gbChiPhi.Controls.Add(this.label9);
            this.gbChiPhi.Controls.Add(this.numTienCoc);
            this.gbChiPhi.Controls.Add(this.numTongTien);
            this.gbChiPhi.Location = new System.Drawing.Point(16, 476);
            this.gbChiPhi.Name = "gbChiPhi";
            this.gbChiPhi.Size = new System.Drawing.Size(740, 136);
            this.gbChiPhi.TabIndex = 3;
            this.gbChiPhi.TabStop = false;
            this.gbChiPhi.Text = "THÔNG TIN CHI PHÍ";
            // 
            // numTongTien
            // 
            this.numTongTien.Location = new System.Drawing.Point(218, 37);
            this.numTongTien.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numTongTien.Name = "numTongTien";
            this.numTongTien.Size = new System.Drawing.Size(476, 26);
            this.numTongTien.TabIndex = 0;
            this.numTongTien.ThousandsSeparator = true;
            // 
            // numTienCoc
            // 
            this.numTienCoc.Location = new System.Drawing.Point(218, 81);
            this.numTienCoc.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numTienCoc.Name = "numTienCoc";
            this.numTienCoc.Size = new System.Drawing.Size(476, 26);
            this.numTienCoc.TabIndex = 1;
            this.numTienCoc.ThousandsSeparator = true;
            // 
            // btnLuuDangKy
            // 
            this.btnLuuDangKy.Location = new System.Drawing.Point(454, 629);
            this.btnLuuDangKy.Name = "btnLuuDangKy";
            this.btnLuuDangKy.Size = new System.Drawing.Size(139, 45);
            this.btnLuuDangKy.TabIndex = 4;
            this.btnLuuDangKy.Text = "Lưu & Lập phiếu";
            this.btnLuuDangKy.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(625, 629);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(131, 45);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Đóng";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // txtDiaDiemDon
            // 
            this.txtDiaDiemDon.Location = new System.Drawing.Point(218, 200);
            this.txtDiaDiemDon.Multiline = true;
            this.txtDiaDiemDon.Name = "txtDiaDiemDon";
            this.txtDiaDiemDon.Size = new System.Drawing.Size(476, 26);
            this.txtDiaDiemDon.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên đơn vị/Đoàn (*):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Người đại diện (*):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Số điện thoại liên hệ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Số lượng khách (*):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Địa điểm đón đoàn:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Tổng tiền dự kiến (VNĐ):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Số tiền đặt cọc (VNĐ):";
            // 
            // FormDangKyTourDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 695);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuuDangKy);
            this.Controls.Add(this.gbChiPhi);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.gbThongTinDoan);
            this.Controls.Add(this.gbThongTinTour);
            this.Name = "FormDangKyTourDoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập Phiếu Đăng Ký Tour Theo Đoàn";
            this.Load += new System.EventHandler(this.FormDangKyTourDoan_Load);
            this.gbThongTinTour.ResumeLayout(false);
            this.gbThongTinTour.PerformLayout();
            this.gbThongTinDoan.ResumeLayout(false);
            this.gbThongTinDoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongKhach)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.gbChiPhi.ResumeLayout(false);
            this.gbChiPhi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTongTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienCoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbThongTinTour;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.ComboBox cboChuyenTour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbThongTinDoan;
        private System.Windows.Forms.TextBox txtNguoiDaiDien;
        private System.Windows.Forms.TextBox txtTenDonVi;
        private System.Windows.Forms.NumericUpDown nudSoLuongKhach;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbChiPhi;
        private System.Windows.Forms.NumericUpDown numTienCoc;
        private System.Windows.Forms.NumericUpDown numTongTien;
        private System.Windows.Forms.Button btnLuuDangKy;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txtDiaDiemDon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
    }
}