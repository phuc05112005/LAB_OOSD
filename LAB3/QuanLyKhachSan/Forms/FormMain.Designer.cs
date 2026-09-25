namespace QuanLyKhachSan.Forms
{
    partial class FormMain
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
            this.FrmDanhMuc = new System.Windows.Forms.Button();
            this.FrmPhongTienNghi = new System.Windows.Forms.Button();
            this.FrmDatPhong = new System.Windows.Forms.Button();
            this.FrmThongKe = new System.Windows.Forms.Button();
            this.FrmTraPhong = new System.Windows.Forms.Button();
            this.FrmDichVu = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FrmDanhMuc
            // 
            this.FrmDanhMuc.Location = new System.Drawing.Point(77, 182);
            this.FrmDanhMuc.Name = "FrmDanhMuc";
            this.FrmDanhMuc.Size = new System.Drawing.Size(296, 84);
            this.FrmDanhMuc.TabIndex = 0;
            this.FrmDanhMuc.Text = "Danh mục";
            this.FrmDanhMuc.UseVisualStyleBackColor = true;
            this.FrmDanhMuc.Click += new System.EventHandler(this.FrmDanhMuc_Click);
            // 
            // FrmPhongTienNghi
            // 
            this.FrmPhongTienNghi.Location = new System.Drawing.Point(411, 182);
            this.FrmPhongTienNghi.Name = "FrmPhongTienNghi";
            this.FrmPhongTienNghi.Size = new System.Drawing.Size(296, 84);
            this.FrmPhongTienNghi.TabIndex = 1;
            this.FrmPhongTienNghi.Text = "Phòng - Tiện nghi";
            this.FrmPhongTienNghi.UseVisualStyleBackColor = true;
            this.FrmPhongTienNghi.Click += new System.EventHandler(this.btnPhongTienNghi_Click);
            // 
            // FrmDatPhong
            // 
            this.FrmDatPhong.Location = new System.Drawing.Point(747, 182);
            this.FrmDatPhong.Name = "FrmDatPhong";
            this.FrmDatPhong.Size = new System.Drawing.Size(296, 84);
            this.FrmDatPhong.TabIndex = 2;
            this.FrmDatPhong.Text = "Đặt / Nhận phòng";
            this.FrmDatPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FrmDatPhong.UseVisualStyleBackColor = true;
            // 
            // FrmThongKe
            // 
            this.FrmThongKe.Location = new System.Drawing.Point(747, 292);
            this.FrmThongKe.Name = "FrmThongKe";
            this.FrmThongKe.Size = new System.Drawing.Size(296, 84);
            this.FrmThongKe.TabIndex = 5;
            this.FrmThongKe.Text = "Thống kê";
            this.FrmThongKe.UseVisualStyleBackColor = true;
            // 
            // FrmTraPhong
            // 
            this.FrmTraPhong.Location = new System.Drawing.Point(411, 292);
            this.FrmTraPhong.Name = "FrmTraPhong";
            this.FrmTraPhong.Size = new System.Drawing.Size(296, 84);
            this.FrmTraPhong.TabIndex = 4;
            this.FrmTraPhong.Text = "Trả phòng - Thanh toán";
            this.FrmTraPhong.UseVisualStyleBackColor = true;
            // 
            // FrmDichVu
            // 
            this.FrmDichVu.Location = new System.Drawing.Point(77, 292);
            this.FrmDichVu.Name = "FrmDichVu";
            this.FrmDichVu.Size = new System.Drawing.Size(296, 84);
            this.FrmDichVu.TabIndex = 3;
            this.FrmDichVu.Text = "Sử dụng dịch vụ";
            this.FrmDichVu.UseVisualStyleBackColor = true;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(411, 405);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(296, 84);
            this.btn_Thoat.TabIndex = 8;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 544);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.FrmThongKe);
            this.Controls.Add(this.FrmTraPhong);
            this.Controls.Add(this.FrmDichVu);
            this.Controls.Add(this.FrmDatPhong);
            this.Controls.Add(this.FrmPhongTienNghi);
            this.Controls.Add(this.FrmDanhMuc);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FrmDanhMuc;
        private System.Windows.Forms.Button FrmPhongTienNghi;
        private System.Windows.Forms.Button FrmDatPhong;
        private System.Windows.Forms.Button FrmThongKe;
        private System.Windows.Forms.Button FrmTraPhong;
        private System.Windows.Forms.Button FrmDichVu;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Label label1;
    }
}