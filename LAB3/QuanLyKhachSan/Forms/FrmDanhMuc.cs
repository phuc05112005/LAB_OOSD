using QuanLyKhachSan.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService service =
            new DanhMucService();

        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void FrmD_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }
        // =========================
        // TẢI DỮ LIỆU
        // =========================
        private void TaiDuLieu()
        {
            dgvKhu.DataSource =
                service.LayKhuVuc();

            dgvNV.DataSource =
                service.LayNhanVien();

            dgvLoaiTN.DataSource =
                service.LayLoaiTienNghi();

            dgvDV.DataSource =
                service.LayDichVu();

            dgvQD.DataSource =
                service.LayQuyDinhDenBu();

            // Load loại tiện nghi vào ComboBox
            cboQDLoai.DataSource =
                service.LayLoaiTienNghi();

            cboQDLoai.DisplayMember =
                "TenLoaiTN";

            cboQDLoai.ValueMember =
                "MaLoaiTN";
        }

        // =========================
        // THÊM KHU VỰC
        // =========================
        private void btnThemKhu_Click(object sender, EventArgs e)
        {
            string message =
                service.ThemKhu(
                    txtKhuMa.Text.Trim(),
                    txtKhuTen.Text.Trim()
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();
        }

        // =========================
        // THÊM NHÂN VIÊN
        // =========================
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string message =
                service.ThemNhanVien(
                    txtNVMa.Text.Trim(),
                    txtNVTen.Text.Trim(),
                    txtNVVaiTro.Text.Trim(),
                    txtNVSDT.Text.Trim()
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();
        }

        // =========================
        // THÊM LOẠI TIỆN NGHI
        // =========================
        private void btnThemLoaiTN_Click(object sender, EventArgs e)
        {
            string message =
                service.ThemLoaiTN(
                    txtLoaiMa.Text.Trim(),
                    txtLoaiTen.Text.Trim()
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();
        }

        // =========================
        // THÊM DỊCH VỤ
        // =========================
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            string message =
                service.ThemDichVu(
                    txtDVMa.Text.Trim(),
                    txtDVTen.Text.Trim(),
                    txtDVDVT.Text.Trim(),
                    numDVGia.Value
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();
        }

        // =========================
        // THÊM QUY ĐỊNH ĐỀN BÙ
        // =========================
        private void btnThemQD_Click(object sender, EventArgs e)
        {
            string maLoai = "";

            if (cboQDLoai.SelectedValue != null)
            {
                maLoai =
                    cboQDLoai.SelectedValue.ToString();
            }

            string message =
                service.ThemQuyDinh(
                    txtQDMa.Text.Trim(),
                    maLoai,
                    txtQDMucDo.Text.Trim(),
                    numQDTien.Value
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();
        }

        // =========================
        // ĐÓNG FORM
        // =========================
        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}