# LAB 2 - QUẢN LÝ THƯ VIỆN WINFORMS

## 1. Thông tin bài Lab

Bài Lab xây dựng ứng dụng **Quản lý thư viện** bằng **C# WinForms (.NET Framework 4.7.2)** và kết nối với **SQL Server LocalDB**.

Trong buổi thực hành hôm nay, project tập trung vào các nội dung:

- Tạo cấu trúc project WinForms.
- Kết nối ứng dụng với cơ sở dữ liệu `QuanLyThuVienDB`.
- Xây dựng giao diện chính `FrmMain`.
- Xây dựng giao diện `FrmDanhMuc`.
- Đọc dữ liệu từ SQL Server và hiển thị lên `DataGridView`.
- Tổ chức mã nguồn theo hướng tách phần giao diện, truy xuất dữ liệu và xử lý nghiệp vụ.

## 2. Công nghệ sử dụng

- **Ngôn ngữ:** C#
- **Giao diện:** Windows Forms
- **Framework:** .NET Framework 4.7.2
- **Cơ sở dữ liệu:** SQL Server LocalDB
- **Thư viện truy cập dữ liệu:** `System.Data.SqlClient`
- **IDE:** Visual Studio

## 3. Cấu trúc project

```text
QuanLyThuVien
├── Data
│   └── Db.cs
├── Forms
│   ├── FrmMain.cs
│   └── FrmDanhMuc.cs
├── Services
│   └── DanhMucService.cs
├── Models.cs
├── App.config
└── Program.cs
```

### Ý nghĩa các thành phần

- `Data/Db.cs`: quản lý kết nối và thực thi câu lệnh SQL.
- `Services/DanhMucService.cs`: lấy dữ liệu danh mục từ cơ sở dữ liệu.
- `Forms/FrmMain.cs`: giao diện chính và điều hướng sang các chức năng.
- `Forms/FrmDanhMuc.cs`: hiển thị dữ liệu Nhân viên, Thể loại và Nhà xuất bản.
- `Models.cs`: chứa các lớp mô hình dữ liệu.
- `App.config`: chứa chuỗi kết nối cơ sở dữ liệu.
- `Program.cs`: điểm bắt đầu chạy chương trình.

## 4. Kết nối cơ sở dữ liệu

Chuỗi kết nối được khai báo trong `App.config`:

```xml
<connectionStrings>
  <add name="QuanLyThuVienDb"
       connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=QuanLyThuVienDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Lớp `Db.cs` đọc chuỗi kết nối và cung cấp các hàm dùng chung như:

- `OpenConnection()`
- `Query()`
- `Execute()`
- `Scalar()`

Trong phần thực hành hôm nay chủ yếu sử dụng `Query()` để lấy dữ liệu từ SQL Server.

## 5. Giao diện FrmMain

`FrmMain` là màn hình chính của chương trình.

Các chức năng dự kiến gồm:

- Danh mục / Nhân viên
- Quản lý đầu sách
- Độc giả
- Mượn / Trả
- Thống kê
- Thoát chương trình

Trong buổi hôm nay đã kết nối nút **Danh mục / Nhân viên** với `FrmDanhMuc`.

Ví dụ:

```csharp
private void btnDanhMuc_Click(object sender, EventArgs e)
{
    FrmDanhMuc f = new FrmDanhMuc();
    f.ShowDialog();
}
```

## 6. Giao diện FrmDanhMuc

`FrmDanhMuc` gồm 3 tab:

### Tab Nhân viên

Các control chính:

- `txtNVMa`
- `txtNVHo`
- `txtNVTen`
- `cboNVPhai`
- `dtNVNgaySinh`
- `txtNVChucVu`
- `txtNVSDT`
- `dgvNV`

### Tab Thể loại

Các control chính:

- `txtTLMa`
- `txtTLTen`
- `dgvTL`

### Tab Nhà xuất bản

Các control chính:

- `txtNXBMa`
- `txtNXBDiaChi`
- `txtNXBSDT`
- `dgvNXB`

Hiện tại các nút Thêm, Cập nhật, Xóa, Làm mới mới được thiết kế giao diện, chưa triển khai CRUD trong buổi này.

## 7. Đọc dữ liệu từ cơ sở dữ liệu

`DanhMucService` chịu trách nhiệm lấy dữ liệu từ SQL Server.

Ví dụ:

```csharp
public DataTable LayTheLoai()
{
    return Db.Query(
        @"SELECT MaTheLoai, TenTheLoai
          FROM TheLoai
          ORDER BY TenTheLoai");
}
```

Trong `FrmDanhMuc`, dữ liệu được gán cho `DataGridView`:

```csharp
private void TaiDuLieu()
{
    dgvNV.DataSource = service.LayNhanVien();
    dgvTL.DataSource = service.LayTheLoai();
    dgvNXB.DataSource = service.LayNhaXuatBan();

    dgvNV.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.Fill;

    dgvTL.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.Fill;

    dgvNXB.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.Fill;
}
```

## 8. Luồng hoạt động hiện tại

```text
Program.cs
    ↓
FrmMain
    ↓
Bấm "Danh mục / Nhân viên"
    ↓
FrmDanhMuc
    ↓
FrmDanhMuc_Load
    ↓
DanhMucService
    ↓
Db.Query()
    ↓
SQL Server - QuanLyThuVienDB
    ↓
DataTable
    ↓
DataGridView
```

Luồng trên cho thấy giao diện không truy vấn SQL trực tiếp mà thông qua `Service` và lớp `Db`.

## 9. Một số lỗi đã xử lý trong buổi thực hành

### 9.1. Double-click control làm Visual Studio tự sinh event

Khi double-click vào Button, TextBox, Label hoặc DataGridView trong Designer, Visual Studio có thể tự sinh các event như:

```csharp
button5_Click
textBox7_TextChanged
label1_Click
dataGridView1_CellContentClick
```

Cách xử lý:

- Chọn control.
- Mở `Properties`.
- Chọn biểu tượng sự kiện `⚡`.
- Xóa event không sử dụng.
- Sau đó mới xóa method rỗng trong file `.cs`.

Không nên xóa method trước khi gỡ event trong Designer.

### 9.2. DataGridView bị lặp cột

Nguyên nhân là vừa tạo cột thủ công trong Designer, vừa để `AutoGenerateColumns = true`.

Cách xử lý trong buổi hôm nay:

- Xóa các cột tạo thủ công.
- Giữ `AutoGenerateColumns = true`.
- Để `DataGridView` tự sinh cột từ `DataTable`.

### 9.3. Nút Danh mục không mở Form

Nguyên nhân là event `Click` của button đã bị xóa.

Cách sửa:

```text
Chọn button
→ Properties
→ ⚡
→ Click
→ btnDanhMuc_Click
```

## 10. Kết quả đạt được

Sau buổi thực hành, project đã thực hiện được:

- Khởi chạy chương trình từ `FrmMain`.
- Mở được `FrmDanhMuc`.
- Kết nối thành công với SQL Server LocalDB.
- Đọc dữ liệu từ database `QuanLyThuVienDB`.
- Hiển thị dữ liệu lên:
  - `dgvNV`
  - `dgvTL`
  - `dgvNXB`
- Tách phần truy xuất dữ liệu ra khỏi giao diện bằng `Db.cs` và `DanhMucService.cs`.

## 11. Phần sẽ tiếp tục

Các phần tiếp theo của bài Lab:

- Hoàn thiện `FrmSach`.
- Hoàn thiện `FrmDocGia`.
- Hoàn thiện `FrmMuonTra`.
- Hoàn thiện `FrmThongKe`.
- Kết nối dữ liệu cho các Form còn lại.
- Sau đó mới triển khai các chức năng Thêm, Cập nhật, Xóa, Tìm kiếm, Mượn sách, Trả sách và Thống kê.

## 12. Ghi chú

Trong giai đoạn hiện tại, mục tiêu chính là:

> **Hoàn thiện giao diện và kết nối cơ sở dữ liệu trước, chưa tập trung xử lý toàn bộ chức năng CRUD.**

Điều này giúp kiểm tra lần lượt từng tầng của chương trình và hạn chế lỗi khi phát triển các chức năng phức tạp hơn.
