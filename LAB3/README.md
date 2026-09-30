# LAB 3 - HỆ THỐNG QUẢN LÝ KHÁCH SẠN

## 1. Giới thiệu

Bài lab xây dựng **Hệ thống quản lý khách sạn** bằng **Windows Forms**, kết nối với cơ sở dữ liệu **SQL Server**. Nội dung chính của bài gồm thiết kế cơ sở dữ liệu, thiết kế giao diện WinForms và kết nối ứng dụng với cơ sở dữ liệu để thực hiện các nghiệp vụ quản lý khách sạn.

Hệ thống hướng đến các nghiệp vụ chính như:

- Quản lý khu vực, phòng và tiện nghi.
- Theo dõi việc lắp đặt/luân chuyển tiện nghi giữa các phòng.
- Quản lý khách hàng, đặt phòng và nhận phòng.
- Quản lý người lưu trú.
- Ghi nhận dịch vụ khách sử dụng trong thời gian lưu trú.
- Quản lý đền bù khi tiện nghi bị hư hỏng hoặc mất mát.
- Lập hóa đơn, thanh toán và trả phòng.
- Thống kê dữ liệu hoạt động của khách sạn.

---

## 2. Công nghệ sử dụng

- **Ngôn ngữ:** C#
- **Giao diện:** Windows Forms
- **Framework:** .NET Framework 4.7.2
- **IDE:** Visual Studio 2022
- **Cơ sở dữ liệu:** Microsoft SQL Server
- **Công cụ quản trị CSDL:** SQL Server Management Studio 21
- **Truy cập dữ liệu:** ADO.NET (`System.Data.SqlClient`)

---

## 3. Kiến trúc chương trình

Ứng dụng được tổ chức theo hướng tách giao diện, xử lý nghiệp vụ và truy cập dữ liệu:

```text
WinForms UI
    ↓
Services / Business Logic
    ↓
Data / Db.cs
    ↓
SQL Server
```

Trong đó:

- **Forms:** chứa giao diện và xử lý sự kiện người dùng.
- **Services:** xử lý nghiệp vụ và thực hiện các truy vấn cần thiết.
- **Data/Db.cs:** quản lý kết nối SQL Server và cung cấp các hàm dùng chung như `Query`, `Execute`, `Scalar`.
- **SQL Server:** lưu trữ toàn bộ dữ liệu của hệ thống.

Form không thực hiện câu lệnh SQL trực tiếp. Các thao tác liên quan đến nhiều bảng được xử lý tại tầng Service và sử dụng transaction khi cần thiết.

---

## 4. Thiết kế cơ sở dữ liệu

Cơ sở dữ liệu được thiết kế và tạo trực tiếp trên SQL Server bằng SQL Server Management Studio.

Tên cơ sở dữ liệu sử dụng:

```text
QuanLyKhachSan
```

Các bảng chính gồm:

1. `NhanVien`
2. `KhuVuc`
3. `Phong`
4. `LoaiTienNghi`
5. `TienNghi`
6. `PhieuLapDat`
7. `KhachHang`
8. `PhieuDatPhong`
9. `ChiTietDatPhong`
10. `NguoiLuuTru`
11. `DichVu`
12. `PhieuSuDungDV`
13. `ChiTietPhieuSuDungDV`
14. `QuyDinhDenBu`
15. `PhieuDenBu`
16. `ChiTietPhieuDenBu`
17. `HoaDon`
18. `ThanhToan`

### Một số ràng buộc chính

- Sức chứa phòng phải lớn hơn 0.
- Đơn giá phòng không được âm.
- Một tiện nghi được phân biệt theo loại và số thứ tự.
- Trong cùng một ngày, một thiết bị chỉ được lắp cho một phòng.
- Ngày trả dự kiến không được trước ngày nhận.
- Dịch vụ sử dụng nhiều lần trong cùng ngày được cộng dồn số lượng.
- Thanh toán hỗ trợ các hình thức: tiền mặt, chuyển khoản, thẻ và ví điện tử.

---

## 5. Các Form chính

### `FormMain`

Màn hình chính dùng để điều hướng tới các chức năng của hệ thống.

### `FrmDanhMuc`

Quản lý các dữ liệu nền:

- Khu vực.
- Nhân viên.
- Loại tiện nghi.
- Dịch vụ.
- Quy định đền bù.

### `FrmPhongTienNghi`

Quản lý:

- Phòng.
- Tiện nghi.
- Lắp đặt/luân chuyển tiện nghi giữa các phòng.

### `FrmDatPhong`

Quản lý:

- Khách hàng.
- Lập phiếu đặt phòng.
- Chọn nhiều phòng cho một phiếu đặt.
- Người lưu trú.
- Nhận phòng.
- Trường hợp khách không đến nhận phòng (No-show).

### `FrmDichVu`

Ghi nhận các dịch vụ khách sử dụng trong thời gian lưu trú.

### `FrmTraPhong`

Xử lý:

- Kiểm tra tiện nghi khi trả phòng.
- Đền bù hư hỏng/mất mát.
- Lập hóa đơn.
- Ghi nhận thanh toán.
- Hoàn tất trả phòng.

### `FrmThongKe`

Hiển thị các số liệu thống kê của hệ thống.

---

## 6. Cấu trúc thư mục

```text
QuanLyKhachSan/
│
├── Data/
│   └── Db.cs
│
├── Services/
│   ├── DanhMucService.cs
│   ├── PhongTienNghiService.cs
│   ├── DatPhongService.cs
│   ├── DichVuService.cs
│   ├── TraPhongService.cs
│   └── ThongKeService.cs
│
├── Forms/
│   ├── FormMain.cs
│   ├── FrmDanhMuc.cs
│   ├── FrmPhongTienNghi.cs
│   ├── FrmDatPhong.cs
│   ├── FrmDichVu.cs
│   ├── FrmTraPhong.cs
│   └── FrmThongKe.cs
│
├── Models/
│   └── PhongDatItem.cs
│
├── App.config
└── Program.cs
```

---

## 7. Kết nối cơ sở dữ liệu

Chuỗi kết nối được cấu hình trong `App.config`.

Ví dụ:

```xml
<connectionStrings>
  <add name="QuanLyKhachSanDB"
       connectionString="Server=.\\SQLEXPRESS;Database=QuanLyKhachSan;Integrated Security=True;TrustServerCertificate=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Tùy máy, giá trị `Server` cần thay bằng đúng tên SQL Server instance đang sử dụng trong SQL Server Management Studio.

Lớp `Db.cs` đọc chuỗi kết nối này và cung cấp các hàm:

```text
OpenConnection()
Query()
Execute()
Scalar()
```

Kết nối giữa ứng dụng WinForms và SQL Server đã được kiểm tra thành công.

---

## 8. Quy trình chạy chương trình

1. Mở SQL Server và bảo đảm database `QuanLyKhachSan` đã tồn tại.
2. Kiểm tra tên SQL Server instance trong SQL Server Management Studio.
3. Cập nhật connection string trong `App.config` nếu cần.
4. Mở solution bằng Visual Studio 2022.
5. Build solution.
6. Chạy chương trình bằng `F5`.
7. Từ `FormMain`, chọn chức năng cần sử dụng.

---

## 9. Một số nghiệp vụ kiểm tra

Các trường hợp cần kiểm tra trong quá trình chạy chương trình gồm:

- Không cho tạo phòng có sức chứa bằng 0.
- Không cho đặt số người vượt quá sức chứa phòng.
- Không cho đặt phòng bị trùng khoảng thời gian với phiếu đang còn hiệu lực.
- Không cho một tiện nghi được lắp ở hai phòng trong cùng một ngày.
- Khi cùng một dịch vụ được sử dụng nhiều lần trong ngày, số lượng được cộng dồn.
- Chỉ cho nhận phòng đối với phiếu đang ở trạng thái phù hợp.
- Không cho thêm số người lưu trú vượt quá số người đã đăng ký cho phòng.
- Hóa đơn bao gồm tiền phòng và tiền dịch vụ.
- Hỗ trợ nhiều giao dịch thanh toán cho một hóa đơn nhưng không được vượt tổng tiền hóa đơn.
- Chỉ hoàn tất trả phòng khi hóa đơn đã được thanh toán đầy đủ.

---

## 10. Kết quả thực hiện

- Đã thiết kế cơ sở dữ liệu trên SQL Server.
- Đã tạo các bảng, khóa chính, khóa ngoại và các ràng buộc cần thiết.
- Đã thiết kế giao diện chương trình bằng Windows Forms.
- Đã xây dựng lớp kết nối dữ liệu `Db.cs`.
- Đã cấu hình kết nối SQL Server trong `App.config`.
- Đã kiểm tra kết nối từ ứng dụng WinForms tới cơ sở dữ liệu thành công.
- Dữ liệu từ SQL Server có thể được tải và hiển thị trên giao diện WinForms thông qua tầng Service.

---

## 11. Ghi chú

Bài lab tập trung vào việc kết hợp giữa **thiết kế cơ sở dữ liệu SQL Server**, **thiết kế giao diện Windows Forms** và **lập trình kết nối dữ liệu bằng ADO.NET**. Việc tách chương trình thành `Forms - Services - Data` giúp mã nguồn rõ ràng hơn, hạn chế viết SQL trực tiếp trong giao diện và thuận tiện cho việc bảo trì, kiểm thử và mở rộng chức năng.
