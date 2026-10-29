using System.Windows.Forms;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Forms
{
    public static class FormHelper
    {
        public static bool H(KetQuaXuLy k)
        {
            MessageBox.Show(k.ThongBao, "Thông báo");
            return k.ThanhCong;
        }

        public static string V(ComboBox c)
        {
            return c.SelectedValue == null ? "" : c.SelectedValue.ToString();
        }

        public static void Bind(ComboBox c, System.Data.DataTable dt, string display, string value)
        {
            c.DataSource = dt;
            c.DisplayMember = display;
            c.ValueMember = value;
            c.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}