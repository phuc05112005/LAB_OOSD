# LAB 2 – HỆ THỐNG QUẢN LÝ THƯ VIỆN

## 1. Giới thiệu

Bài thực hành xây dựng ứng dụng **Quản lý thư viện** bằng **C# Windows Forms** trên nền **.NET Framework 4.7.2**, kết nối với **SQL Server LocalDB**.

Mục tiêu của bài là làm quen với cách tổ chức một ứng dụng WinForms có kết nối cơ sở dữ liệu, tách phần giao diện, truy xuất dữ liệu và xử lý nghiệp vụ thành các thành phần riêng để thuận tiện cho việc phát triển và bảo trì.

Trong giai đoạn hiện tại, bài làm tập trung vào thiết kế giao diện, kết nối cơ sở dữ liệu và hiển thị dữ liệu từ SQL Server lên các Form. Các chức năng thêm, cập nhật, xóa và các nghiệp vụ mượn – trả sẽ được hoàn thiện ở các bước tiếp theo.

---

## 2. Công nghệ sử dụng

- Ngôn ngữ lập trình: **C#**
- Giao diện: **Windows Forms**
- Nền tảng: **.NET Framework 4.7.2**
- Hệ quản trị cơ sở dữ liệu: **SQL Server LocalDB**
- Thư viện truy xuất dữ liệu: **System.Data.SqlClient**
- Môi trường phát triển: **Microsoft Visual Studio**
- Quản lý mã nguồn: **Git và GitHub**

---

## 3. Cấu trúc project

```text
QuanLyThuVien
├── Data
│   └── Db.cs
│
├── Forms
│   ├── FrmMain.cs
│   ├── FrmDanhMuc.cs
│   ├── FrmSach.cs
│   └── FrmDocGia.cs
│
├── Services
│   ├── DanhMucService.cs
│   ├── SachService.cs
│   ├── DocGiaService.cs
│   ├── MuonTraService.cs
│   └── ThongKeService.cs
│
├── Models.cs
├── App.config
├── Program.cs
└── QuanLyThuVien.csproj
```

### Vai trò của các thành phần

- `Data/Db.cs`: quản lý kết nối và cung cấp các hàm truy vấn dùng chung.
- `Forms`: chứa các màn hình giao diện của chương trình.
- `Services`: thực hiện truy xuất dữ liệu và xử lý nghiệp vụ tương ứng với từng nhóm chức năng.
- `Models.cs`: khai báo các lớp mô hình dữ liệu.
- `App.config`: lưu cấu hình kết nối cơ sở dữ liệu.
- `Program.cs`: điểm khởi động của ứng dụng.

Cách tổ chức này giúp giao diện không thực hiện câu lệnh SQL trực tiếp mà thông qua lớp Service và lớp truy cập dữ liệu.

---

## 4. Cơ sở dữ liệu

Ứng dụng sử dụng cơ sở dữ liệu:

```text
QuanLyThuVienDB
```

Một số bảng chính của hệ thống gồm:

- `NhanVien`
- `TheLoai`
- `NhaXuatBan`
- `DauSach`
- `DocGia`
- `TheDocGia`
- `PhieuMuon`
- `ChiTietPhieuMuon`
- `PhieuPhat`

Chuỗi kết nối được khai báo trong `App.config`:

```xml
<connectionStrings>
  <add name="QuanLyThuVienDb"
       connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=QuanLyThuVienDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

## 5. Lớp truy cập dữ liệu

File `Data/Db.cs` được sử dụng làm lớp truy cập dữ liệu dùng chung.

Các phương thức chính:

```text
OpenConnection()
Query()
Execute()
Scalar()
```

Trong giai đoạn hiện tại, phương thức `Query()` được sử dụng chủ yếu để đọc dữ liệu từ SQL Server và trả về `DataTable`.

Luồng truy xuất dữ liệu:

```text
Form
   ↓
Service
   ↓
Db.cs
   ↓
SQL Server
   ↓
DataTable
   ↓
DataGridView / ComboBox
```

---

## 6. FrmMain – Giao diện chính

`FrmMain` là cửa sổ chính và đóng vai trò điều hướng tới các chức năng của hệ thống.

Các nhóm chức năng gồm:

- Danh mục / Nhân viên
- Quản lý đầu sách
- Quản lý độc giả
- Mượn / Trả sách
- Thống kê
- Thoát chương trình

Các Form con được mở từ `FrmMain` bằng `ShowDialog()`.

Ví dụ mở Form quản lý sách:

```csharp
private void btnSach_Click(object sender, EventArgs e)
{
    FrmSach f = new FrmSach();
    f.ShowDialog();
}
```

---

## 7. FrmDanhMuc – Danh mục và nhân viên

`FrmDanhMuc` được chia thành ba tab.

### 7.1. Nhân viên

Thông tin được quản lý gồm:

- Mã nhân viên
- Họ
- Tên
- Phái
- Ngày sinh
- Chức vụ
- Số điện thoại

Dữ liệu được hiển thị trên `dgvNV`.

### 7.2. Thể loại

Thông tin gồm:

- Mã thể loại
- Tên thể loại

Dữ liệu được hiển thị trên `dgvTL`.

### 7.3. Nhà xuất bản

Thông tin gồm:

- Mã nhà xuất bản
- Địa chỉ
- Số điện thoại

Dữ liệu được hiển thị trên `dgvNXB`.

`FrmDanhMuc` sử dụng `DanhMucService` để lấy dữ liệu từ cơ sở dữ liệu.

```csharp
private void TaiDuLieu()
{
    dgvNV.DataSource = service.LayNhanVien();
    dgvTL.DataSource = service.LayTheLoai();
    dgvNXB.DataSource = service.LayNhaXuatBan();

    dgvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    dgvTL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    dgvNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
}
```

---

## 8. FrmSach – Quản lý đầu sách

`FrmSach` đã được thiết kế giao diện và kết nối với cơ sở dữ liệu.

Các thông tin chính:

- Mã đầu sách
- Tên sách
- Năm xuất bản
- Số lượng hiện có
- Thể loại
- Nhà xuất bản

Hai `ComboBox` được nạp dữ liệu từ các danh mục có sẵn:

```text
cboTheLoai → bảng TheLoai
cboNXB     → bảng NhaXuatBan
```

Danh sách đầu sách được lấy từ bảng `DauSach` thông qua `SachService` và hiển thị trên `dgvSach`.

```csharp
private void FrmSach_Load(object sender, EventArgs e)
{
    cboTheLoai.DataSource = danhMuc.LayTheLoai();
    cboTheLoai.DisplayMember = "TenTheLoai";
    cboTheLoai.ValueMember = "MaTheLoai";

    cboNXB.DataSource = danhMuc.LayNhaXuatBan();
    cboNXB.DisplayMember = "MaNhaXuatBan";
    cboNXB.ValueMember = "MaNhaXuatBan";

    TaiDuLieu();
}
```

---

## 9. FrmDocGia – Độc giả và thẻ thư viện

`FrmDocGia` đã được thiết kế giao diện và chuẩn bị phần kết nối dữ liệu.

Thông tin độc giả gồm:

- Mã độc giả
- Họ
- Tên
- Ngày sinh
- Phái
- Số điện thoại
- Địa chỉ
- Email
- Ảnh 3x4

Thông tin thẻ thư viện gồm:

- Ngày cấp
- Hạn sử dụng
- Trạng thái đóng lệ phí

Danh sách độc giả và thông tin thẻ gần nhất được lấy thông qua `DocGiaService` và hiển thị trên `dgvDocGia`.

---

## 10. Kết quả thực hiện

Đến thời điểm hiện tại, bài thực hành đã hoàn thành các nội dung:

- Tạo project WinForms đúng cấu trúc.
- Kết nối thành công với SQL Server LocalDB.
- Khởi chạy chương trình từ `FrmMain`.
- Điều hướng từ `FrmMain` tới các Form đã xây dựng.
- Hoàn thiện giao diện `FrmDanhMuc`.
- Hiển thị dữ liệu Nhân viên, Thể loại và Nhà xuất bản từ cơ sở dữ liệu.
- Hoàn thiện giao diện `FrmSach`.
- Nạp dữ liệu Thể loại và Nhà xuất bản vào `ComboBox`.
- Kết nối `FrmSach` với bảng `DauSach`.
- Hoàn thiện giao diện `FrmDocGia`.
- Chuẩn bị kết nối dữ liệu độc giả và thẻ thư viện.
- Tách phần truy xuất dữ liệu khỏi giao diện thông qua các lớp Service và `Db.cs`.

---

## 11. Một số vấn đề đã xử lý trong quá trình thực hiện

### 11.1. Event được tạo ngoài ý muốn

Khi double-click vào control trong WinForms Designer, Visual Studio tự động tạo event như:

```text
button_Click
textBox_TextChanged
label_Click
```

Nếu không sử dụng, cần gỡ event trong cửa sổ Properties trước khi xóa method trong file `.cs`.

### 11.2. DataGridView bị lặp cột

Nguyên nhân là vừa tạo cột thủ công trong Designer vừa để `AutoGenerateColumns = true`.

Cách xử lý:

- Xóa các cột tạo thủ công.
- Để `DataGridView` tự sinh cột từ `DataSource`.

### 11.3. Nút điều hướng không mở Form

Nguyên nhân là event `Click` của Button chưa được nối hoặc đã bị xóa.

Cách xử lý:

```text
Chọn Button
→ Properties
→ Events
→ Click
→ chọn đúng hàm xử lý
```

### 11.4. Không đưa thư mục tạm của Visual Studio lên Git

Các thư mục và file sinh tự động như:

```text
.vs/
bin/
obj/
*.suo
*.cache
```

được loại trừ bằng `.gitignore`.

---

## 12. Hướng hoàn thiện tiếp theo

- Hoàn tất kết nối dữ liệu cho `FrmDocGia`.
- Xây dựng `FrmMuonTra`.
- Xây dựng `FrmThongKe`.
- Hoàn thiện các chức năng thêm, cập nhật, xóa dữ liệu.
- Hoàn thiện chức năng cấp thẻ và gia hạn thẻ độc giả.
- Xử lý nghiệp vụ mượn và trả sách.
- Kiểm tra điều kiện mượn sách và tình trạng thẻ.
- Xử lý phạt khi trả trễ, làm mất hoặc làm hư sách.
- Xây dựng phần thống kê.
- Kiểm thử toàn bộ chương trình trước khi hoàn thành bài Lab.

---

## 13. Ghi chú

Bài làm được triển khai theo từng bước: thiết kế giao diện, kiểm tra kết nối cơ sở dữ liệu, hiển thị dữ liệu và sau đó mới bổ sung nghiệp vụ.

Cách thực hiện này giúp dễ kiểm tra lỗi ở từng phần và hạn chế việc xử lý quá nhiều chức năng cùng lúc.
