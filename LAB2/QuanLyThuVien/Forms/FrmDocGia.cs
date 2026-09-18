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
    public partial class FrmDocGia : Form
    {
        private readonly DocGiaService service
            = new DocGiaService();
        public FrmDocGia()
        {
            InitializeComponent();
        }

        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            // Nạp giới tính
            cboPhai.Items.Clear();

            cboPhai.Items.AddRange(
                new object[] { "Nam", "Nữ", "Khác" });

            if (cboPhai.Items.Count > 0)
            {
                cboPhai.SelectedIndex = 0;
            }

            // Giá trị mặc định cho thẻ
            dtNgayCap.Value = DateTime.Today;
            dtHan.Value = DateTime.Today.AddYears(1);

            // Nạp dữ liệu
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            dgvDocGia.DataSource =
                service.LayDanhSach();

            dgvDocGia.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}