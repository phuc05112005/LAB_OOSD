# LAB 4 - Hệ thống phần mềm Cửa hàng online e-SHOPPING

## Giới thiệu

Bài lab thực hiện phân tích và thiết kế hệ thống bán hàng trực tuyến **e-SHOPPING** theo phương pháp phát triển phần mềm hướng đối tượng. Hệ thống hỗ trợ khách hàng xem và lựa chọn sản phẩm, quản lý giỏ hàng, đăng ký hoặc đăng nhập tài khoản, lựa chọn hình thức giao hàng, cung cấp thông tin người nhận, thanh toán bằng thẻ và ghi nhận đơn đặt hàng.

Thông tin sản phẩm không được quản lý trực tiếp trong e-SHOPPING mà được lấy từ **Hệ thống quản lý sản phẩm** của cửa hàng. Việc xác minh thông tin thẻ và khả năng thanh toán được thực hiện thông qua **Hệ thống dịch vụ thanh toán trực tuyến**.

Trong phạm vi cài đặt minh họa, bài lab xây dựng một giao diện đăng ký khách hàng bằng Windows Forms và kết nối với SQL Server để thực hiện đọc và ghi dữ liệu.

## Nội dung thực hiện

Bài lab gồm hai phần chính: phân tích hệ thống và thiết kế hệ thống.

### Phân tích hệ thống

Phần phân tích tập trung xác định phạm vi nghiệp vụ, tác nhân, các trường hợp sử dụng và các đối tượng nghiệp vụ của e-SHOPPING.

Các tác nhân chính gồm:

1. **Khách hàng** - trực tiếp sử dụng e-SHOPPING để lựa chọn sản phẩm, quản lý giỏ hàng, đăng ký, đăng nhập và đặt mua hàng.
2. **Hệ thống quản lý sản phẩm** - cung cấp thông tin nhóm sản phẩm, sản phẩm, giá hiện hành và tình trạng hàng.
3. **Hệ thống dịch vụ thanh toán trực tuyến** - xác minh thông tin thẻ và khả năng thanh toán của giao dịch.

Các mô hình đã thực hiện:

- Sơ đồ Use Case tổng quát.
- Sơ đồ phân rã Use Case **Đặt mua hàng**.
- Sơ đồ phân rã Use Case **Thanh toán giao dịch**.
- Đặc tả các Use Case từ UC01 đến UC15.
- Activity Diagram cho quy trình **Đặt mua hàng và thanh toán**.
- Activity Diagram cho quy trình **Xác định chi phí giao hàng và tổng trị giá đơn hàng**.
- Sequence Diagram cho kịch bản **Xem danh sách và chi tiết sản phẩm**.
- Sequence Diagram cho kịch bản **Đặt mua hàng và thanh toán**.
- Biểu đồ lớp phân tích của hệ thống.

### Thiết kế hệ thống

Hệ thống được thiết kế theo kiến trúc phân tầng, tách biệt phần giao diện, điều khiển, xử lý nghiệp vụ, truy cập dữ liệu và tích hợp với các hệ thống bên ngoài.

Cấu trúc logic:

```text
Presentation
    ↓
Controller
    ↓
Service / Domain
    ↓
Repository
    ↓
Database

Service / Domain
    ↓
Gateway
    ↓
External Systems
```

Phần thiết kế cơ sở dữ liệu tập trung vào dữ liệu thuộc phạm vi bán hàng trực tuyến. Thông tin sản phẩm và nhóm sản phẩm được quản lý bởi hệ thống bên ngoài; e-SHOPPING chỉ lưu các thông tin cần thiết để phục vụ nghiệp vụ và đảm bảo dữ liệu lịch sử của đơn hàng.

Các bảng được thiết kế gồm:

`KHACH_HANG`, `GIO_HANG`, `CHI_TIET_GIO_HANG`, `HINH_THUC_GIAO_HANG`, `PHI_GIAO_HANG`, `LOAI_THE`, `DON_DAT_HANG`, `CHI_TIET_DON_HANG`, `GIAO_DICH_THANH_TOAN`.

## Giao diện cài đặt minh họa

Phần cài đặt sử dụng **C# Windows Forms** để xây dựng giao diện `FrmDangKyKhachHang`.

Giao diện cho phép nhập mã khách hàng, họ tên, ngày sinh, CMND/Passport, địa chỉ, số điện thoại, email, tên đăng nhập và mật khẩu. Các chức năng được triển khai gồm **Đăng ký**, **Làm mới** và **Đóng**. Danh sách khách hàng được hiển thị bằng `DataGridView`.

Luồng xử lý:

```text
FrmDangKyKhachHang
        ↓
KhachHangService
        ↓
Db
        ↓
SQL Server
        ↓
KhachHang
```

Form có thể đọc dữ liệu khách hàng từ cơ sở dữ liệu và ghi khách hàng mới khi dữ liệu hợp lệ. Chuỗi kết nối được khai báo trong file cấu hình và lớp `Db` được dùng để thực hiện truy vấn và cập nhật dữ liệu.

## Cơ sở dữ liệu dùng cho phần cài đặt

Phần giao diện minh họa sử dụng cơ sở dữ liệu `EShoppingDB` và bảng `KhachHang`.

```sql
CREATE DATABASE EShoppingDB;
GO

USE EShoppingDB;
GO

CREATE TABLE KhachHang
(
    MaKH VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    CMNDPassport VARCHAR(20) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    DienThoai VARCHAR(20) NOT NULL,
    Email VARCHAR(100) NULL,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhauHash VARCHAR(255) NOT NULL
);
GO
```

Tên đăng nhập được đặt ràng buộc duy nhất. Mật khẩu không được lưu trực tiếp dưới dạng văn bản mà được chuyển thành giá trị băm trước khi ghi vào cơ sở dữ liệu.

## Công nghệ sử dụng

- C#
- Windows Forms
- .NET Framework
- SQL Server
- ADO.NET
- `System.Data.SqlClient`
- PlantUML
- draw.io

## Cấu trúc phần cài đặt

```text
QuanLyShopping/
├── Data/
│   └── Db.cs
├── Services/
│   └── KhachHangService.cs
├── Forms/
│   └── FrmDangKyKhachHang.cs
├── App.config
└── Program.cs
```

`Db.cs` chịu trách nhiệm kết nối và thao tác với cơ sở dữ liệu. `KhachHangService.cs` xử lý nghiệp vụ đăng ký khách hàng. `FrmDangKyKhachHang.cs` tiếp nhận dữ liệu từ người dùng và hiển thị kết quả.

## Chạy chương trình

1. Tạo cơ sở dữ liệu `EShoppingDB` và bảng `KhachHang` trên SQL Server.
2. Cập nhật chuỗi kết nối trong `App.config` theo SQL Server đang sử dụng.
3. Mở project bằng Visual Studio.
4. Build và chạy chương trình.
5. Nhập thông tin trên `FrmDangKyKhachHang`, chọn **Đăng ký** và kiểm tra dữ liệu trên `DataGridView` và trong SQL Server.

## Kết quả

Bài lab đã hoàn thành phần phân tích và thiết kế hệ thống e-SHOPPING bằng các mô hình UML, thiết kế kiến trúc và cơ sở dữ liệu. Phần cài đặt minh họa đã xây dựng giao diện đăng ký khách hàng bằng Windows Forms, kết nối thành công với SQL Server và thực hiện được thao tác đọc và ghi dữ liệu khách hàng.
