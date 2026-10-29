using System.Data;
using System.Windows.Forms;
using QuanLyNuocGiaiKhat.Data;
namespace QuanLyNuocGiaiKhat.Forms
{
    public static class UiHelper
    {
        // Hiển thị thông báo, trả về true nếu xử lý thành công
        public static bool H(KetQuaXuLy k) { MessageBox.Show(k.ThongBao, "Thông báo"); return k.ThanhCong; }
        public static string V(ComboBox c) { return c.SelectedValue as string ?? ""; }
        public static void Bind(ComboBox c, DataTable dt, string display, string value)
        { c.DisplayMember = display; c.ValueMember = value; c.DataSource = dt; c.DropDownStyle = ComboBoxStyle.DropDownList; }
        public static Label Lb(Control p, string text, int x, int y) { var l = new Label { Text = text, Left = x, Top = y + 4, AutoSize = true }; p.Controls.Add(l); return l; }
        public static T Add<T>(Control p, T c, int x, int y, int w, int h = 24) where T : Control { c.Left = x; c.Top = y; c.Width = w; c.Height = h; p.Controls.Add(c); return c; }
        public static DataGridView Grid(Control p, int x, int y, int w, int h)
        {
            var g = new DataGridView
            {
                Left = x,
                Top = y,
                Width = w,
                Height = h,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White
            };
            p.Controls.Add(g); return g;
        }
    }
}
