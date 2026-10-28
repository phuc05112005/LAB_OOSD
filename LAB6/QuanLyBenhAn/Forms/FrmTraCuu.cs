using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmTraCuu : Form
    {
        readonly TraCuuService s = new TraCuuService();

        private TextBox txtTuKhoa;
        private Label lblTrangBia;
        private DataGridView dgvHoSo, dgvLichSu, dgvTrieuChung, dgvToa, dgvXN;
        private Button btnTim, btnDong;

        public FrmTraCuu() { InitializeComponent(); }

        private string Cell(DataGridView g, string col) { return g.CurrentRow == null ? "" : Convert.ToString(g.CurrentRow.Cells[col].Value); }

        private void btnTim_Click(object a, EventArgs e)
        {
            var dt = s.TimHoSo(txtTuKhoa.Text); dgvHoSo.DataSource = dt;
            if (dt.Rows.Count == 0) MessageBox.Show("Không tìm thấy hồ sơ phù hợp.", "Thông báo");
        }

        private void dgvHoSo_SelectionChanged(object a, EventArgs e)
        {
            string ma = Cell(dgvHoSo, "MaHoSo"); if (ma == "") return;
            lblTrangBia.Text = "Hồ sơ: " + ma + " - Bệnh nhân: " + Cell(dgvHoSo, "HoTen") + " - SĐT: " + Cell(dgvHoSo, "DienThoai") + " - Trạng thái: " + Cell(dgvHoSo, "TrangThai");
            dgvLichSu.DataSource = s.LayLichSuKham(ma);
        }

        private void dgvLichSu_SelectionChanged(object a, EventArgs e)
        {
            string p = Cell(dgvLichSu, "SoPhieuKham"); if (p == "") return;
            dgvTrieuChung.DataSource = s.LayTrieuChung(p);
            dgvToa.DataSource = s.LayToaThuoc(p);
            dgvXN.DataSource = s.LayXetNghiem(p);
        }

        private void btnDong_Click(object a, EventArgs e) { Close(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(850, 640);
            this.Name = "FrmTraCuu";
            this.Text = "Tra Cứu Hồ Sơ & Lịch Sử Bệnh Án";
            this.StartPosition = FormStartPosition.CenterScreen;

            txtTuKhoa = new TextBox { Location = new Point(180, 15), Size = new Size(250, 20) };
            btnTim = new Button { Text = "Tìm Kiếm", Location = new Point(440, 13), Size = new Size(90, 25) };
            btnTim.Click += btnTim_Click;

            dgvHoSo = new DataGridView { Location = new Point(15, 50), Size = new Size(820, 130), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            dgvHoSo.SelectionChanged += dgvHoSo_SelectionChanged;

            lblTrangBia = new Label { Location = new Point(15, 190), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold), ForeColor = Color.DarkRed };

            dgvLichSu = new DataGridView { Location = new Point(15, 215), Size = new Size(820, 140), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            dgvLichSu.SelectionChanged += dgvLichSu_SelectionChanged;

            TabControl tab = new TabControl { Location = new Point(15, 365), Size = new Size(820, 230) };
            TabPage t1 = new TabPage("Triệu Chứng");
            dgvTrieuChung = new DataGridView { Location = new Point(5, 5), Size = new Size(800, 190), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            t1.Controls.Add(dgvTrieuChung);

            TabPage t2 = new TabPage("Toa Thuốc");
            dgvToa = new DataGridView { Location = new Point(5, 5), Size = new Size(800, 190), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            t2.Controls.Add(dgvToa);

            TabPage t3 = new TabPage("Xét Nghiệm");
            dgvXN = new DataGridView { Location = new Point(5, 5), Size = new Size(800, 190), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            t3.Controls.Add(dgvXN);

            tab.TabPages.AddRange(new TabPage[] { t1, t2, t3 });
            btnDong = new Button { Text = "Đóng", Location = new Point(745, 600), Size = new Size(90, 30) };
            btnDong.Click += btnDong_Click;

            this.Controls.AddRange(new Control[] {
                new Label { Text = "Từ khóa (Mã HS/Tên/SĐT/Ngày sinh):", Location = new Point(15, 18), AutoSize = true }, txtTuKhoa, btnTim,
                dgvHoSo, lblTrangBia, dgvLichSu, tab, btnDong
            });
            this.ResumeLayout(false);
        }
    }
}