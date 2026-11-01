# LAB 6 – Quản lý Hồ sơ Bệnh án của Bệnh nhân

Bài thực hành môn **Phương pháp phát triển phần mềm hướng đối tượng (OOSD)** – Bài 5.
Phân tích, thiết kế bằng UML, thiết kế CSDL SQL Server và hiện thực giao diện C# WinForms cho nghiệp vụ quản lý hồ sơ bệnh án của bệnh viện đa khoa quốc tế.

## Mục tiêu

- Phân tích nghiệp vụ: đăng ký khám bệnh, thu lệ phí hằng năm, cấp và gia hạn hồ sơ, lịch hẹn khám định kỳ theo quý, phiếu khám (triệu chứng, toa thuốc, xét nghiệm), tra cứu và thống kê.
- Xây dựng bộ mô hình UML (Use Case, Class phân tích, Sequence, Class chi tiết, Activity).
- Thiết kế CSDL SQL Server nhất quán với mô hình lớp.
- Hiện thực C# WinForms (.NET Framework 4.7.2) theo kiến trúc **UI (Form) → Service → Data**.
- Kiểm thử theo kịch bản và truy vết: quy tắc nghiệp vụ → UML → Form/Service → bảng CSDL → test case.

## Cấu trúc thư mục

```
LAB6/
├── PTTK/
│   ├── UseCase/      Use Case tổng quát, phân rã: Đăng ký – cấp hồ sơ, Ghi nhận phiếu khám,
│   │                 Khám định kỳ theo quý, Quản lý danh mục, Tra cứu, Thống kê
│   ├── Class/        Lớp phân tích (16 lớp) và lớp thiết kế chi tiết
│   ├── Sequence/     Tuần tự – Đăng ký/Cấp hồ sơ, Gia hạn lệ phí
│   ├── Activity/     Hoạt động – Từ lần khám đầu đến khi được phát hồ sơ; Khám định kỳ theo quý
│   ├── CSDL/         ERD, script SQL Server
│   └── Forms/        Ảnh chụp giao diện
├── QuanLyHoSoBenhAn/     Mã nguồn C# WinForms
│   ├── Forms/            FrmMain, FrmDanhMuc, FrmDangKy, FrmLichHen, FrmPhieuKham, FrmTraCuu, FrmThongKe
│   ├── Services/         Tầng Service – nghiệp vụ
│   ├── Data/             Tầng Data – truy cập CSDL (ADO.NET)
│   ├── DTO/              Đối tượng truyền dữ liệu
│   └── App.config        Chuỗi kết nối CSDL
└── LAB6_QuanLyHoSoBenhAn.docx   Báo cáo
```

## Mô hình hệ thống

- **Tác nhân:** Nhân viên chăm sóc khách hàng, Bác sĩ, Quản lý bệnh viện.
  Bệnh nhân **không** là Actor vì không thao tác trực tiếp trên hệ thống (nhân viên nhập thay khi đăng ký, nộp lệ phí hoặc gọi điện hẹn).
- **Use Case chính:** Quản lý danh mục · Cấp hồ sơ bệnh án (include: Lập phiếu đăng ký khám bệnh, Thu lệ phí hằng năm; Gia hạn lệ phí) · Ghi nhận phiếu khám · Đặt lịch khám sức khỏe định kỳ · Tra cứu hồ sơ bệnh án · Xem lịch sử bệnh án (extend của Tra cứu) · Thống kê – báo cáo.
- **16 lớp thực thể:** `BenhNhan`, `PhieuDangKy`, `HoSoBenhAn`, `BienLaiLePhi`, `NhanVien`, `Khoa`, `BacSi`, `LichHenKham`, `PhieuKham`, `TrieuChung`, `ChiTietTrieuChung`, `Thuoc`, `ToaThuoc`, `ChiTietToaThuoc`, `XetNghiem`, `ChiTietXetNghiem`.
- **Quan hệ hợp thành (composition):** `HoSoBenhAn`–`BienLaiLePhi`, `PhieuKham`–`ChiTietTrieuChung`, `ToaThuoc`–`ChiTietToaThuoc`, `PhieuKham`–`ChiTietXetNghiem`.
- **Quy ước lớp chi tiết:** ID là `STT` ghép với ID lớp chính (ví dụ `SoToa` + `STT`).

## Quyết định thiết kế quan trọng

| Nội dung                      | Cách hiện thực                                                                                     |
| ----------------------------- | -------------------------------------------------------------------------------------------------- |
| Mã hồ sơ                      | Hệ thống tự sinh theo mẫu `HS` + năm + số thứ tự, ví dụ `HS2026-0001`                              |
| Hiệu lực hồ sơ                | 1 năm kể từ ngày đóng lệ phí                                                                       |
| Gia hạn                       | Cộng thêm 1 năm tính từ ngày hết hạn cũ (hoặc từ hôm nay nếu đã quá hạn)                           |
| Ảnh 3x4                       | Lưu **đường dẫn tệp** trong cột `AnhChup`, không lưu nhị phân                                      |
| Trạng thái phiếu khám         | `Đang nhập` (còn thêm được chi tiết) → `Đã ghi nhận` (khóa, không sửa/xóa)                         |
| Khám định kỳ                  | Bắt buộc có lịch hẹn; mỗi hồ sơ chỉ có một lịch hẹn còn hiệu lực trong mỗi quý (chỉ mục UNIQUE có điều kiện) |
| Mức lệ phí                    | Đề bài không nêu; nhân viên nhập khi thu và hệ thống kiểm tra số tiền > 0                          |
| Khóa kỹ thuật bổ sung         | `MaBN`, `MaNVLap`, `MaNVThu`, `MaNVGhi`, `MaKhoa`                                                  |

## Cơ sở dữ liệu

Thiết kế theo mô hình lớp: khóa ngoại thể hiện quan hệ kết hợp, bảng chi tiết có khóa chính ghép (chứng từ + `STT`).

Các ràng buộc nghiệp vụ chính:

| Quy tắc                                                                        | Cách hiện thực                                   |
| ------------------------------------------------------------------------------ | ------------------------------------------------ |
| Mỗi bệnh nhân một hồ sơ, mã hồ sơ duy nhất                                     | UNIQUE                                           |
| Chỉ cấp hồ sơ khi có phiếu đăng ký và lệ phí một năm                           | Service kiểm tra trong transaction               |
| Số tiền lệ phí > 0; ngày sinh không ở tương lai                                | Service / CHECK                                  |
| Một khoa có nhiều bác sĩ, mỗi bác sĩ thuộc một khoa                            | Khóa ngoại                                       |
| Một bác sĩ không có hai lịch hẹn cùng giờ                                      | Kiểm tra trùng giờ (`kiemTraTrungGio`)           |
| Khám định kỳ miễn phí một lần mỗi quý, chỉ khi hồ sơ còn hạn                   | `kiemTraQuyenLoiQuy`, `kiemTraHanSuDung`         |
| Phiếu khám chỉ ghi nhận sau khi xuất viện và thanh toán (trừ khám định kỳ)     | `kiemTraDieuKienGhiNhan`                         |
| Phiếu khám đã ghi nhận không được sửa/xóa                                      | Service chặn theo trạng thái                     |
| Mỗi dòng thuốc điều trị một triệu chứng đã ghi trong cùng phiếu khám           | Service kiểm tra                                 |
| Hồ sơ quá hạn chuyển `Hết hạn`: tra cứu được, không đặt lịch định kỳ miễn phí  | Trạng thái hồ sơ                                 |

## Cách chạy

**Yêu cầu:** Windows, Visual Studio 2022, .NET Framework 4.7.2, SQL Server LocalDB hoặc SQL Server Express.

1. Mở **SSMS**, chạy toàn bộ script trong `PTTK/CSDL/` (tạo CSDL, bảng, ràng buộc và dữ liệu mẫu).
2. Mở solution `QuanLyHoSoBenhAn` bằng Visual Studio.
3. Sửa chuỗi kết nối trong `App.config` cho đúng tên máy chủ SQL Server của bạn.
4. Nhấn **F5**. Màn hình `FrmMain` dùng để điều hướng đến các chức năng.

| Form           | Đối tượng sử dụng                   | Mục đích                                              |
| -------------- | ----------------------------------- | ----------------------------------------------------- |
| `FrmMain`      | Nhân viên                           | Điều hướng                                            |
| `FrmDanhMuc`   | NV chăm sóc khách hàng              | Danh mục nền (khoa, bác sĩ, thuốc, triệu chứng…)      |
| `FrmDangKy`    | NV chăm sóc khách hàng              | Đăng ký, thu lệ phí, cấp và gia hạn hồ sơ             |
| `FrmLichHen`   | NV chăm sóc khách hàng              | Lịch hẹn khám sức khỏe định kỳ                        |
| `FrmPhieuKham` | NV chăm sóc khách hàng              | Ghi nhận phiếu khám bệnh                              |
| `FrmTraCuu`    | Bác sĩ / NV chăm sóc khách hàng     | Tra cứu hồ sơ theo mã, họ tên, điện thoại, ngày sinh  |
| `FrmThongKe`   | Quản lý bệnh viện                   | Thống kê hồ sơ, lệ phí, lượt khám, khám định kỳ       |

## Kiểm thử

| Kịch bản                                                              | Kết quả mong đợi                          |
| --------------------------------------------------------------------- | ----------------------------------------- |
| Đăng ký bệnh nhân mới, thu lệ phí hợp lệ, cấp hồ sơ                   | Sinh mã `HSnnnn-xxxx`, hạn = +1 năm       |
| Cấp hồ sơ khi chưa có phiếu đăng ký hoặc chưa đóng lệ phí             | Từ chối                                   |
| Thu lệ phí với số tiền 0                                              | Từ chối                                   |
| Gia hạn hồ sơ đã quá hạn                                              | Hạn mới tính từ ngày hôm nay              |
| Đặt lịch khám định kỳ cho hồ sơ `Hết hạn`                             | Từ chối                                   |
| Đặt lịch lần thứ hai trong cùng một quý của cùng hồ sơ                | Từ chối                                   |
| Hai lịch hẹn cùng bác sĩ, cùng ngày giờ                               | Lần thứ hai bị từ chối                    |
| Ghi nhận phiếu khám khi chưa xuất viện / chưa thanh toán              | Từ chối                                   |
| Sửa hoặc xóa phiếu khám đã `Đã ghi nhận`                              | Từ chối                                   |
| Thêm chi tiết vào phiếu khám không còn ở trạng thái `Đang nhập`       | Từ chối                                   |
| Tra cứu hồ sơ theo mã hồ sơ / điện thoại / họ tên + ngày sinh         | Hiển thị trang bìa và lịch sử khám        |

## Công nghệ

C# WinForms · .NET Framework 4.7.2 · SQL Server LocalDB/Express · ADO.NET · UML (Use Case, Class, Sequence, Activity)
