using QuanLyThuVien.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService service
            = new DanhMucService();

        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu cho ComboBox phái
            cboNVPhai.Items.Clear();
            cboNVPhai.Items.AddRange(
                new object[] { "Nam", "Nữ", "Khác" });

            if (cboNVPhai.Items.Count > 0)
            {
                cboNVPhai.SelectedIndex = 0;
            }

            // Tải dữ liệu từ CSDL lên 3 DataGridView
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            dgvNV.DataSource = service.LayNhanVien();
            dgvTL.DataSource = service.LayTheLoai();
            dgvNXB.DataSource = service.LayNhaXuatBan();

            dgvNV.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTL.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvNXB.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}