using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmThongKe : Form
    {
        readonly ThongKeService s = new ThongKeService();

        private DateTimePicker dtTu, dtDen;
        private NumericUpDown numNam;
        private Label lblHoSoMoi, lblLePhi, lblLuotKham, lblKhamDinhKy, lblHetHan;
        private DataGridView dgvKhoa, dgvQuy, dgvSapHetHan;
        private Button btnTK, btnDong;

        public FrmThongKe()
        {
            InitializeComponent();
            dtTu.Value = new DateTime(DateTime.Today.Year, 1, 1);
            numNam.Value = DateTime.Today.Year;
        }

        private void btnTK_Click(object a, EventArgs e)
        {
            if (dtDen.Value.Date < dtTu.Value.Date) { MessageBox.Show("Đến ngày không được trước từ ngày.", "Thông báo"); return; }
            var r = s.TongHop(dtTu.Value, dtDen.Value).Rows[0];
            lblHoSoMoi.Text = "Hồ sơ mới: " + r["HoSoMoi"];
            lblLePhi.Text = "Lệ phí thu: " + Convert.ToDecimal(r["TongLePhi"]).ToString("N0") + " đ";
            lblLuotKham.Text = "Lượt khám: " + r["LuotKham"];
            lblKhamDinhKy.Text = "Khám định kỳ: " + r["KhamDinhKy"];
            lblHetHan.Text = "Hồ sơ hết hạn: " + r["HoSoHetHan"];

            dgvKhoa.DataSource = s.LuotKhamTheoKhoa(dtTu.Value, dtDen.Value);
            dgvQuy.DataSource = s.KhamDinhKyTheoQuy((int)numNam.Value);
            dgvSapHetHan.DataSource = s.HoSoSapHetHan(30);
        }

        private void btnDong_Click(object a, EventArgs e) { Close(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(820, 600);
            this.Name = "FrmThongKe";
            this.Text = "Báo Cáo Thống Kê Bệnh Án";
            this.StartPosition = FormStartPosition.CenterScreen;

            dtTu = new DateTimePicker { Location = new Point(70, 15), Size = new Size(110, 20), Format = DateTimePickerFormat.Short };
            dtDen = new DateTimePicker { Location = new Point(260, 15), Size = new Size(110, 20), Format = DateTimePickerFormat.Short };
            numNam = new NumericUpDown { Location = new Point(440, 15), Size = new Size(70, 20), Maximum = 2100, Minimum = 2000 };
            btnTK = new Button { Text = "Xem Thống Kê", Location = new Point(530, 13), Size = new Size(110, 25) };
            btnTK.Click += btnTK_Click;

            lblHoSoMoi = new Label { Location = new Point(15, 50), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            lblLePhi = new Label { Location = new Point(160, 50), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            lblLuotKham = new Label { Location = new Point(340, 50), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            lblKhamDinhKy = new Label { Location = new Point(480, 50), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            lblHetHan = new Label { Location = new Point(650, 50), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold), ForeColor = Color.Red };

            TabControl tab = new TabControl { Location = new Point(15, 85), Size = new Size(790, 465) };

            TabPage t1 = new TabPage("Lượt Khám Theo Khoa & BS");
            dgvKhoa = new DataGridView { Location = new Point(5, 5), Size = new Size(770, 425), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            t1.Controls.Add(dgvKhoa);

            TabPage t2 = new TabPage("Lịch Khám Định Kỳ Theo Quý");
            dgvQuy = new DataGridView { Location = new Point(5, 5), Size = new Size(770, 425), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            t2.Controls.Add(dgvQuy);

            TabPage t3 = new TabPage("Hồ Sơ Sắp Hết Hạn (30 Ngày)");
            dgvSapHetHan = new DataGridView { Location = new Point(5, 5), Size = new Size(770, 425), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            t3.Controls.Add(dgvSapHetHan);

            tab.TabPages.AddRange(new TabPage[] { t1, t2, t3 });

            btnDong = new Button { Text = "Đóng", Location = new Point(715, 560), Size = new Size(90, 30) };
            btnDong.Click += btnDong_Click;

            this.Controls.AddRange(new Control[] {
                new Label { Text = "Từ ngày:", Location = new Point(15, 18), AutoSize = true }, dtTu,
                new Label { Text = "Đến ngày:", Location = new Point(195, 18), AutoSize = true }, dtDen,
                new Label { Text = "Năm:", Location = new Point(395, 18), AutoSize = true }, numNam, btnTK,
                lblHoSoMoi, lblLePhi, lblLuotKham, lblKhamDinhKy, lblHetHan, tab, btnDong
            });
            this.ResumeLayout(false);
        }
    }
}