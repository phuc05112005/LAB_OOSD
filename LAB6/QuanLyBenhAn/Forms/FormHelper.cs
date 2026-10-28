using QuanLyBenhAn.Data;
using QuanLyBenhAn.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBenhAn.Forms
{
    public static class FormHelper
    {
        // Hiển thị thông báo và trả về true nếu thao tác thành công
        public static bool H(KetQuaXuLy res)
        {
            if (res == null) return false;
            if (res.ThanhCong)
            {
                if (!string.IsNullOrEmpty(res.ThongBao))
                    MessageBox.Show(res.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show(res.ThongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy chuỗi SelectedValue từ ComboBox
        public static string V(ComboBox cbo)
        {
            return cbo?.SelectedValue?.ToString() ?? "";
        }

        // Gắn dữ liệu DataTable vào ComboBox
        public static void Bind(ComboBox cbo, DataTable dt, string displayMember, string valueMember)
        {
            cbo.DataSource = dt;
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }
    }
}