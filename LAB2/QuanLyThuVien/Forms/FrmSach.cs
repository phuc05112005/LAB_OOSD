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
    public partial class FrmSach : Form
    {
        private readonly SachService service
            = new SachService();

        private readonly DanhMucService danhMuc
            = new DanhMucService();
        public FrmSach()
        {
            InitializeComponent();
        }

        private void FrmSach_Load(object sender, EventArgs e)
        {
            // Nạp danh sách thể loại
            cboTheLoai.DataSource = danhMuc.LayTheLoai();
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";

            // Nạp danh sách nhà xuất bản
            cboNXB.DataSource = danhMuc.LayNhaXuatBan();
            cboNXB.DisplayMember = "MaNhaXuatBan";
            cboNXB.ValueMember = "MaNhaXuatBan";

            // Nạp danh sách sách
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            dgvSach.DataSource = service.LayDanhSach("");

            dgvSach.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
