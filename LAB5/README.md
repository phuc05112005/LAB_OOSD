# LAB 5 – Quản lý Công ty Du lịch Văn Hóa Việt

Bài thực hành môn **Phương pháp phát triển phần mềm hướng đối tượng (OOSD)**.
Phân tích, thiết kế bằng UML, thiết kế CSDL SQL Server và hiện thực giao diện C# WinForms cho nghiệp vụ quản lý tour của công ty du lịch.

## Mục tiêu

- Phân tích nghiệp vụ: tour và hành trình, khách lẻ theo chuyến, khách theo đoàn, phân công hướng dẫn viên, lương, kết thúc tour và khảo sát (đánh giá).
- Trả lời 6 câu hỏi của đề bằng bộ mô hình UML (Class, Use Case, Activity, Sequence).
- Thiết kế CSDL SQL Server nhất quán với mô hình lớp.
- Hiện thực C# WinForms (.NET Framework 4.7.2) theo kiến trúc **UI → Service → Data**.
- Kiểm thử theo kịch bản và truy vết: yêu cầu → UML → Form/Service → bảng CSDL → test case.
  |

## Cấu trúc thư mục

```
LAB5/
├── PTTK/
│   ├── UseCase/      Use Case tổng quát, phân rã “Đăng ký tour”
│   ├── Class/        Lớp tổng thể + 3 sơ đồ chi tiết
│   │                 (Quản lý tour và lịch trình, Đăng ký và thanh toán, Điều hành và đánh giá)
│   ├── Sequence/     Tuần tự – Đăng ký tour
│   ├── Activity/     Hoạt động – Đăng ký tour
│   ├── CSDL/         ERD.png, script.txt (script SQL Server)
│   └── Forms/           Ảnh chụp giao diện và cấu trúc solution
├── QuanLyCongTyDuLich/   Mã nguồn C# WinForms
│   ├── Forms/          Form giao diện (FormDangKyTourDoan)
│   ├── Services/          Tầng Service – nghiệp vụ (DangKyDoanBUS)
│   ├── Data/          Tầng Data – truy cập CSDL (DangKyDoanDAL, DatabaseHelper)
│   ├── DTO/          Đối tượng truyền dữ liệu (DangKyDoanDTO)
│   └── App.config    Chuỗi kết nối CSDL
└── LAB6_QuanLyCongTyDuLich.docx   Báo cáo
```

## Mô hình hệ thống

- **Tác nhân:** Khách hàng, Nhân viên quản lý và điều hành tour, Nhân viên kế toán, Hướng dẫn viên, Ban quản lý.
- **11 Use Case:** UC01 Tra cứu thông tin tour · UC02 Quản lý lịch trình tour · UC03 Quản lý thông tin khách hàng · UC04 Đăng ký tour · UC05 Quản lý chuyến khởi hành · UC06 Phân công hướng dẫn viên · UC07 Theo dõi thanh toán tour · UC08 Tính lương hướng dẫn viên · UC09 Tra cứu lịch công tác · UC10 Ghi nhận đánh giá tour · UC11 Lập báo cáo.
- **18 lớp**, trong đó `DangKy` là lớp trừu tượng, kế thừa bởi `DangKyDoan` và `DangKyKhachLe`.

## Cơ sở dữ liệu `QL_TourDuLich`

18 bảng: `Tour`, `LichTrinh`, `ChangLichTrinh`, `DiemThamQuan`, `PhuongTien`, `CoSoLuuTru`, `ChuyenKhoiHanh`, `KhachHang`, `DangKy`, `DangKyDoan`, `DangKyKhachLe`, `ThanhVienDangKy`, `ThanhToan`, `HuongDanVien`, `PhanCong`, `BangLuong`, `ChiTietLuong`, `DanhGia`.

Các ràng buộc nghiệp vụ chính:

| Quy tắc                                                   | Cách hiện thực                            |
| --------------------------------------------------------- | ----------------------------------------- |
| Khách đoàn từ 12 người trở lên                            | Trigger `TRG_Check_DangKyDoan_SoLuong`    |
| Khách lẻ dưới 12 người                                    | Trigger `TRG_Check_DangKyKhachLe_SoLuong` |
| Hướng dẫn viên không trùng lịch                           | Trigger `TRG_Check_PhanCong_TrungLich`    |
| Ngày kết thúc ≥ ngày khởi hành                            | CHECK `CK_Chuyen_Ngay`                    |
| Số tiền thanh toán > 0, điểm đánh giá 1–5, hạng sao 2–5   | CHECK                                     |
| Tổng tiền dòng lương = lương cơ bản + tiền công theo tour | Cột tính toán `PERSISTED`                 |

> Quy ước hiện tại: đúng **12 người được xếp vào khách đoàn**. Đề bài chưa quy định riêng trường hợp này, cần công ty xác nhận.

## Cách chạy

**Yêu cầu:** Windows, Visual Studio 2019 trở lên, .NET Framework 4.7.2, SQL Server (hoặc SQL Server Express/LocalDB).

1. Mở **SSMS**, chạy toàn bộ `PTTK/CSDL/script.txt` (tạo CSDL, bảng, trigger và dữ liệu mẫu).
2. Mở solution `QuanLyCongTyDuLich` bằng Visual Studio.
3. Sửa chuỗi kết nối trong `App.config` cho đúng tên máy chủ SQL Server của bạn.
4. Nhấn **F5**. Form _Lập phiếu đăng ký tour theo đoàn_ sẽ nạp danh sách chuyến và khách hàng từ CSDL.

## Kiểm thử

Dữ liệu mẫu có sẵn: `KH001`, `KH002`, `TOUR001`, `TOUR002`, `CHUYEN001`, `CHUYEN002`.

| Kịch bản                                                | Kết quả mong đợi          |
| ------------------------------------------------------- | ------------------------- |
| Đăng ký đoàn 12 người                                   | Lưu thành công            |
| Đăng ký đoàn 11 người                                   | Trigger từ chối, rollback |
| Đăng ký khách lẻ 5 người                                | Lưu thành công            |
| Đăng ký khách lẻ 12 người                               | Trigger từ chối           |
| Phân công cùng hướng dẫn viên vào hai chuyến trùng ngày | Lần thứ hai bị từ chối    |
| Thanh toán số tiền 0 / đánh giá 6 điểm                  | CHECK từ chối             |

Danh sách 12 test case đầy đủ nằm ở Chương 4 của báo cáo.

## Công nghệ

C# WinForms · .NET Framework 4.7.2 · SQL Server · StarUML / draw.io / PlantUML · dbdiagram.io
