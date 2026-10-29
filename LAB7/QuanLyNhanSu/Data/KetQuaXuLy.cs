namespace QuanLyNhanSu.Data
{
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }

        public static KetQuaXuLy Ok(string m) { return new KetQuaXuLy { ThanhCong = true, ThongBao = m }; }
        public static KetQuaXuLy Fail(string m) { return new KetQuaXuLy { ThanhCong = false, ThongBao = m }; }
    }
}