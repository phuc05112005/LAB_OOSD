using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNuocGiaiKhat.Services;
using static QuanLyNuocGiaiKhat.Forms.UiHelper;
namespace QuanLyNuocGiaiKhat.Forms
{
    public class FrmBanHang : Form
    {
        readonly BanHangService s = new BanHangService();
        readonly DataTable gio = new DataTable();
        ComboBox cboKhach, cboNV, cboNGK; TextBox txtSoHD, txtLyDo; NumericUpDown numSL, numTienNo;
        CheckBox chkTraCham; DateTimePicker dtDuKienTra, dtNgayHen; Label lblTong, lblTon;
        DataGridView dgvGio, dgvHoaDon, dgvHen; Button btnThem, btnXoa, btnLap, btnGiao, btnDong;

        public FrmBanHang()
        {
            Text = "Bán hàng - Lập hóa đơn"; Width = 1040; Height = 770; StartPosition = FormStartPosition.CenterScreen;
            BuildUi(); Load += (a, e) => Tai();
        }
        void BuildUi()
        {
            gio.Columns.Add("MaNGK"); gio.Columns.Add("TenNGK"); gio.Columns.Add("SoLuong", typeof(int));
            gio.Columns.Add("DonGia", typeof(decimal)); gio.Columns.Add("ThanhTien", typeof(decimal));
            Lb(this, "Số hóa đơn:", 15, 15); txtSoHD = Add(this, new TextBox(), 100, 15, 110);
            Lb(this, "Khách hàng:", 230, 15); cboKhach = Add(this, new ComboBox(), 315, 15, 230);
            Lb(this, "Nhân viên:", 565, 15); cboNV = Add(this, new ComboBox(), 640, 15, 170);
            Lb(this, "Mặt hàng:", 15, 55); cboNGK = Add(this, new ComboBox(), 100, 55, 330);
            lblTon = Lb(this, "Tồn: -", 440, 55);
            Lb(this, "Số lượng:", 530, 55); numSL = Add(this, new NumericUpDown { Minimum = 1, Maximum = 100000, Value = 1 }, 600, 55, 80);
            btnThem = Add(this, new Button { Text = "Thêm vào hóa đơn" }, 700, 53, 130, 28);
            btnXoa = Add(this, new Button { Text = "Xóa dòng" }, 840, 53, 90, 28);
            dgvGio = Grid(this, 15, 95, 990, 200); dgvGio.DataSource = gio;
            lblTong = Lb(this, "Tổng tiền: 0 đ", 15, 305); lblTong.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chkTraCham = Add(this, new CheckBox { Text = "Trả chậm (ghi nợ - chỉ khách quen)" }, 15, 340, 260);
            Lb(this, "Số tiền nợ:", 290, 340); numTienNo = Add(this, new NumericUpDown { Maximum = 1000000000, Increment = 10000 }, 370, 340, 120);
            Lb(this, "Dự kiến trả:", 505, 340); dtDuKienTra = Add(this, new DateTimePicker { Format = DateTimePickerFormat.Short }, 590, 340, 110);
            Lb(this, "Lý do nợ:", 715, 340); txtLyDo = Add(this, new TextBox(), 780, 340, 225);
            Lb(this, "Ngày hẹn giao phần thiếu:", 15, 380); dtNgayHen = Add(this, new DateTimePicker { Format = DateTimePickerFormat.Short }, 190, 380, 110);
            btnLap = Add(this, new Button { Text = "Lập hóa đơn" }, 330, 378, 130, 30);
            Lb(this, "Hóa đơn gần đây:", 15, 420); dgvHoaDon = Grid(this, 15, 445, 490, 230);
            Lb(this, "Phiếu hẹn chưa giao:", 520, 420); dgvHen = Grid(this, 520, 445, 485, 190);
            btnGiao = Add(this, new Button { Text = "Giao hàng theo phiếu hẹn" }, 520, 645, 190, 30);
            btnDong = Add(this, new Button { Text = "Đóng" }, 915, 690, 90, 30);

            cboNGK.SelectedIndexChanged += (a, e) => CapNhatTon();
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += (a, e) => { if (dgvGio.CurrentRow != null) { gio.Rows.RemoveAt(dgvGio.CurrentRow.Index); TinhTong(); } };
            btnLap.Click += BtnLap_Click; btnGiao.Click += BtnGiao_Click; btnDong.Click += (a, e) => Close();
        }
        void Tai()
        {
            Bind(cboKhach, s.LayKhachHang(), "Ten", "MaKH"); Bind(cboNV, s.LayNhanVien(), "HoTen", "MaNV");
            Bind(cboNGK, s.LayNuocGiaiKhat(), "TenNGK", "MaNGK");
            dtNgayHen.Value = DateTime.Today.AddDays(3); dtDuKienTra.Value = DateTime.Today.AddDays(15);
            LamMoi();
        }
        void LamMoi() { dgvHoaDon.DataSource = s.LayHoaDon(); dgvHen.DataSource = s.LayPhieuHenChuaGiao(); CapNhatTon(); TinhTong(); }
        void CapNhatTon() { lblTon.Text = "Tồn: " + (cboNGK.SelectedValue == null ? "-" : s.LayTon(V(cboNGK)).ToString()); }
        void TinhTong()
        {
            decimal tong = 0; foreach (DataRow r in gio.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            lblTong.Text = "Tổng tiền: " + tong.ToString("N0") + " đ"; numTienNo.Value = Math.Min(tong, numTienNo.Maximum);
        }
        private void BtnThem_Click(object a, EventArgs e)
        {
            var item = cboNGK.SelectedItem as DataRowView; if (item == null) return;
            string ma = item["MaNGK"].ToString(); int sl = (int)numSL.Value; decimal gia = Convert.ToDecimal(item["DonGiaBan"]);
            foreach (DataRow r in gio.Rows)
                if (r["MaNGK"].ToString() == ma) { r["SoLuong"] = (int)r["SoLuong"] + sl; r["ThanhTien"] = (int)r["SoLuong"] * gia; TinhTong(); return; }
            gio.Rows.Add(ma, item["TenNGK"], sl, gia, sl * gia); TinhTong();
        }
        private void BtnLap_Click(object a, EventArgs e)
        {
            var ds = new List<DongHang>();
            foreach (DataRow r in gio.Rows) ds.Add(new DongHang { MaNGK = r["MaNGK"].ToString(), SoLuong = (int)r["SoLuong"] });
            if (H(s.LapHoaDon(txtSoHD.Text.Trim(), V(cboKhach), V(cboNV), ds, chkTraCham.Checked, numTienNo.Value, dtDuKienTra.Value, txtLyDo.Text.Trim(), dtNgayHen.Value)))
            { gio.Clear(); txtSoHD.Clear(); txtLyDo.Clear(); chkTraCham.Checked = false; Bind(cboNGK, s.LayNuocGiaiKhat(), "TenNGK", "MaNGK"); LamMoi(); }
        }
        private void BtnGiao_Click(object a, EventArgs e)
        {
            if (dgvHen.CurrentRow == null) return;
            if (H(s.GiaoHangTheoPhieuHen(dgvHen.CurrentRow.Cells["SoPhieuHen"].Value.ToString()))) LamMoi();
        }
    }
}
