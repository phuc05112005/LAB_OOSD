using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyNuocGiaiKhat.Services;
using static QuanLyNuocGiaiKhat.Forms.UiHelper;
namespace QuanLyNuocGiaiKhat.Forms
{
    public class FrmDonDatHang : Form
    {
        readonly NhapHangService s = new NhapHangService();
        readonly DataTable ct = new DataTable();
        ComboBox cboNCU, cboNV, cboNGK; TextBox txtSoDDH; NumericUpDown numSL; DateTimePicker dtNgayNhan;
        DataGridView dgvCT, dgvDDH; Button btnThem, btnXoa, btnLap, btnDong;

        public FrmDonDatHang()
        {
            Text = "Nhập hàng - Lập đơn đặt hàng"; Width = 960; Height = 680; StartPosition = FormStartPosition.CenterScreen;
            BuildUi(); Load += (a, e) => Tai();
        }
        void BuildUi()
        {
            ct.Columns.Add("MaNGK"); ct.Columns.Add("TenNGK"); ct.Columns.Add("SoLuong", typeof(int));
            Lb(this, "Số đơn đặt hàng:", 15, 15); txtSoDDH = Add(this, new TextBox(), 125, 15, 110);
            Lb(this, "Nhà cung ứng:", 255, 15); cboNCU = Add(this, new ComboBox(), 345, 15, 260);
            Lb(this, "Nhân viên:", 625, 15); cboNV = Add(this, new ComboBox(), 695, 15, 160);
            Lb(this, "Ngày nhận dự kiến:", 15, 55); dtNgayNhan = Add(this, new DateTimePicker { Format = DateTimePickerFormat.Short }, 135, 55, 110);
            Lb(this, "Mặt hàng:", 265, 55); cboNGK = Add(this, new ComboBox(), 330, 55, 300);
            Lb(this, "Số lượng:", 650, 55); numSL = Add(this, new NumericUpDown { Minimum = 1, Maximum = 100000, Value = 10 }, 710, 55, 70);
            btnThem = Add(this, new Button { Text = "Thêm" }, 795, 53, 60, 28); btnXoa = Add(this, new Button { Text = "Xóa" }, 860, 53, 60, 28);
            Lb(this, "Chi tiết đơn đặt hàng:", 15, 95); dgvCT = Grid(this, 15, 120, 905, 170); dgvCT.DataSource = ct;
            btnLap = Add(this, new Button { Text = "Lập đơn đặt hàng" }, 15, 300, 150, 30);
            Lb(this, "Đơn đặt hàng gần đây:", 15, 345); dgvDDH = Grid(this, 15, 370, 905, 220);
            btnDong = Add(this, new Button { Text = "Đóng" }, 830, 600, 90, 30);

            cboNCU.SelectedIndexChanged += (a, e) => { ct.Clear(); if (cboNCU.SelectedValue is string) Bind(cboNGK, s.LayNGKTheoNCU(V(cboNCU)), "TenNGK", "MaNGK"); };
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += (a, e) => { if (dgvCT.CurrentRow != null) ct.Rows.RemoveAt(dgvCT.CurrentRow.Index); };
            btnLap.Click += BtnLap_Click; btnDong.Click += (a, e) => Close();
        }
        void Tai()
        {
            Bind(cboNV, s.LayNhanVien(), "HoTen", "MaNV"); Bind(cboNCU, s.LayNhaCungUng(), "TenNCU", "MaNCU");
            dtNgayNhan.Value = DateTime.Today.AddDays(7); dgvDDH.DataSource = s.LayDonDatHang();
        }
        private void BtnThem_Click(object a, EventArgs e)
        {
            var item = cboNGK.SelectedItem as DataRowView; if (item == null) return;
            string ma = item["MaNGK"].ToString(); int sl = (int)numSL.Value;
            foreach (DataRow r in ct.Rows) if (r["MaNGK"].ToString() == ma) { r["SoLuong"] = (int)r["SoLuong"] + sl; return; }
            ct.Rows.Add(ma, item["TenNGK"], sl);
        }
        private void BtnLap_Click(object a, EventArgs e)
        {
            var ds = new List<DongDat>();
            foreach (DataRow r in ct.Rows) ds.Add(new DongDat { MaNGK = r["MaNGK"].ToString(), SoLuong = (int)r["SoLuong"] });
            if (H(s.LapDonDatHang(txtSoDDH.Text.Trim(), V(cboNCU), V(cboNV), dtNgayNhan.Value, ds))) { ct.Clear(); txtSoDDH.Clear(); dgvDDH.DataSource = s.LayDonDatHang(); }
        }
    }
}
