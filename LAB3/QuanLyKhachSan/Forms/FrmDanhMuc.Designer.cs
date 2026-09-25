namespace QuanLyKhachSan.Forms
{
    partial class FrmDanhMuc
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDanhMuc));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvKhu = new System.Windows.Forms.DataGridView();
            this.btnThemKhu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKhuTen = new System.Windows.Forms.TextBox();
            this.txtKhuMa = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.txtNVVaiTro = new System.Windows.Forms.TextBox();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnThemLoaiTN = new System.Windows.Forms.Button();
            this.txtLoaiTen = new System.Windows.Forms.TextBox();
            this.txtLoaiMa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvLoaiTN = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            this.numDVGia = new System.Windows.Forms.NumericUpDown();
            this.txtDVTen = new System.Windows.Forms.TextBox();
            this.txtDVDVT = new System.Windows.Forms.TextBox();
            this.txtDVMa = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnThemQD = new System.Windows.Forms.Button();
            this.numQDTien = new System.Windows.Forms.NumericUpDown();
            this.cboQDLoai = new System.Windows.Forms.ComboBox();
            this.txtQDMucDo = new System.Windows.Forms.TextBox();
            this.txtQDMa = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvQD = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTN)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDVGia)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQDTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.dgvKhu);
            this.tabPage1.Controls.Add(this.btnThemKhu);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtKhuTen);
            this.tabPage1.Controls.Add(this.txtKhuMa);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvKhu
            // 
            resources.ApplyResources(this.dgvKhu, "dgvKhu");
            this.dgvKhu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhu.MultiSelect = false;
            this.dgvKhu.Name = "dgvKhu";
            this.dgvKhu.ReadOnly = true;
            this.dgvKhu.RowTemplate.Height = 28;
            this.dgvKhu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnThemKhu
            // 
            resources.ApplyResources(this.btnThemKhu, "btnThemKhu");
            this.btnThemKhu.Name = "btnThemKhu";
            this.btnThemKhu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtKhuTen
            // 
            resources.ApplyResources(this.txtKhuTen, "txtKhuTen");
            this.txtKhuTen.Name = "txtKhuTen";
            // 
            // txtKhuMa
            // 
            resources.ApplyResources(this.txtKhuMa, "txtKhuMa");
            this.txtKhuMa.Name = "txtKhuMa";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.dgvNV);
            this.tabPage2.Controls.Add(this.btnThemNV);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtNVTen);
            this.tabPage2.Controls.Add(this.txtNVVaiTro);
            this.tabPage2.Controls.Add(this.txtNVSDT);
            this.tabPage2.Controls.Add(this.txtNVMa);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvNV
            // 
            resources.ApplyResources(this.dgvNV, "dgvNV");
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.MultiSelect = false;
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.ReadOnly = true;
            this.dgvNV.RowTemplate.Height = 28;
            this.dgvNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnThemNV
            // 
            resources.ApplyResources(this.btnThemNV, "btnThemNV");
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtNVTen
            // 
            resources.ApplyResources(this.txtNVTen, "txtNVTen");
            this.txtNVTen.Name = "txtNVTen";
            // 
            // txtNVVaiTro
            // 
            resources.ApplyResources(this.txtNVVaiTro, "txtNVVaiTro");
            this.txtNVVaiTro.Name = "txtNVVaiTro";
            // 
            // txtNVSDT
            // 
            resources.ApplyResources(this.txtNVSDT, "txtNVSDT");
            this.txtNVSDT.Name = "txtNVSDT";
            // 
            // txtNVMa
            // 
            resources.ApplyResources(this.txtNVMa, "txtNVMa");
            this.txtNVMa.Name = "txtNVMa";
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.btnThemLoaiTN);
            this.tabPage3.Controls.Add(this.txtLoaiTen);
            this.tabPage3.Controls.Add(this.txtLoaiMa);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.dgvLoaiTN);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnThemLoaiTN
            // 
            resources.ApplyResources(this.btnThemLoaiTN, "btnThemLoaiTN");
            this.btnThemLoaiTN.Name = "btnThemLoaiTN";
            this.btnThemLoaiTN.UseVisualStyleBackColor = true;
            // 
            // txtLoaiTen
            // 
            resources.ApplyResources(this.txtLoaiTen, "txtLoaiTen");
            this.txtLoaiTen.Name = "txtLoaiTen";
            // 
            // txtLoaiMa
            // 
            resources.ApplyResources(this.txtLoaiMa, "txtLoaiMa");
            this.txtLoaiMa.Name = "txtLoaiMa";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // dgvLoaiTN
            // 
            resources.ApplyResources(this.dgvLoaiTN, "dgvLoaiTN");
            this.dgvLoaiTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiTN.MultiSelect = false;
            this.dgvLoaiTN.Name = "dgvLoaiTN";
            this.dgvLoaiTN.ReadOnly = true;
            this.dgvLoaiTN.RowTemplate.Height = 28;
            this.dgvLoaiTN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Controls.Add(this.dgvDV);
            this.tabPage4.Controls.Add(this.numDVGia);
            this.tabPage4.Controls.Add(this.txtDVTen);
            this.tabPage4.Controls.Add(this.txtDVDVT);
            this.tabPage4.Controls.Add(this.txtDVMa);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.btnThemDV);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvDV
            // 
            resources.ApplyResources(this.dgvDV, "dgvDV");
            this.dgvDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDV.MultiSelect = false;
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.ReadOnly = true;
            this.dgvDV.RowTemplate.Height = 28;
            this.dgvDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // numDVGia
            // 
            resources.ApplyResources(this.numDVGia, "numDVGia");
            this.numDVGia.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numDVGia.Name = "numDVGia";
            // 
            // txtDVTen
            // 
            resources.ApplyResources(this.txtDVTen, "txtDVTen");
            this.txtDVTen.Name = "txtDVTen";
            // 
            // txtDVDVT
            // 
            resources.ApplyResources(this.txtDVDVT, "txtDVDVT");
            this.txtDVDVT.Name = "txtDVDVT";
            // 
            // txtDVMa
            // 
            resources.ApplyResources(this.txtDVMa, "txtDVMa");
            this.txtDVMa.Name = "txtDVMa";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // btnThemDV
            // 
            resources.ApplyResources(this.btnThemDV, "btnThemDV");
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Controls.Add(this.btnThemQD);
            this.tabPage5.Controls.Add(this.numQDTien);
            this.tabPage5.Controls.Add(this.cboQDLoai);
            this.tabPage5.Controls.Add(this.txtQDMucDo);
            this.tabPage5.Controls.Add(this.txtQDMa);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.dgvQD);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnThemQD
            // 
            resources.ApplyResources(this.btnThemQD, "btnThemQD");
            this.btnThemQD.Name = "btnThemQD";
            this.btnThemQD.UseVisualStyleBackColor = true;
            // 
            // numQDTien
            // 
            resources.ApplyResources(this.numQDTien, "numQDTien");
            this.numQDTien.Name = "numQDTien";
            // 
            // cboQDLoai
            // 
            resources.ApplyResources(this.cboQDLoai, "cboQDLoai");
            this.cboQDLoai.FormattingEnabled = true;
            this.cboQDLoai.Name = "cboQDLoai";
            // 
            // txtQDMucDo
            // 
            resources.ApplyResources(this.txtQDMucDo, "txtQDMucDo");
            this.txtQDMucDo.Name = "txtQDMucDo";
            // 
            // txtQDMa
            // 
            resources.ApplyResources(this.txtQDMa, "txtQDMa");
            this.txtQDMa.Name = "txtQDMa";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // dgvQD
            // 
            resources.ApplyResources(this.dgvQD, "dgvQD");
            this.dgvQD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQD.MultiSelect = false;
            this.dgvQD.Name = "dgvQD";
            this.dgvQD.ReadOnly = true;
            this.dgvQD.RowTemplate.Height = 28;
            this.dgvQD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // FrmDanhMuc
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmDanhMuc";
            this.Load += new System.EventHandler(this.FrmD_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTN)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDVGia)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQDTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtKhuTen;
        private System.Windows.Forms.TextBox txtKhuMa;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemKhu;
        private System.Windows.Forms.DataGridView dgvKhu;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.TextBox txtNVVaiTro;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.TextBox txtLoaiTen;
        private System.Windows.Forms.TextBox txtLoaiMa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLoaiTN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnThemLoaiTN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.NumericUpDown numDVGia;
        private System.Windows.Forms.TextBox txtDVTen;
        private System.Windows.Forms.TextBox txtDVDVT;
        private System.Windows.Forms.TextBox txtDVMa;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvQD;
        private System.Windows.Forms.Button btnThemQD;
        private System.Windows.Forms.NumericUpDown numQDTien;
        private System.Windows.Forms.ComboBox cboQDLoai;
        private System.Windows.Forms.TextBox txtQDMucDo;
        private System.Windows.Forms.TextBox txtQDMa;
    }
}