# LAB 7 – Quản lý Nhân sự Công ty Sơn Đông Á

Bài thực hành môn **Phương pháp phát triển phần mềm hướng đối tượng (OOSD)** – Bài 7.
Phân tích, thiết kế bằng UML, thiết kế CSDL SQL Server và hiện thực giao diện C# WinForms cho nghiệp vụ quản lý nhân sự: tuyển dụng – thử việc, hợp đồng – bảo hiểm, quyết định chức vụ/lương, phân công – chấm công – phụ trội, bảng lương, khen thưởng – kỷ luật.

## Mục tiêu

- Phân tích nghiệp vụ nhân sự của công ty có nhiều phòng ban, ban, phân xưởng.
- Xây dựng bộ mô hình UML (Use Case, Class phân tích, Sequence, Activity) với **năm loại quyết định kế thừa lớp trừu tượng `QuyetDinh`**.
- Thiết kế CSDL SQL Server theo mô hình **table-per-type** nhất quán với mô hình lớp.
- Hiện thực C# WinForms (.NET Framework 4.7.2) theo kiến trúc **UI (Form) → Service → Data**.
- Kiểm thử theo kịch bản và truy vết: quy tắc nghiệp vụ → UML → Form/Service → bảng CSDL → test case.

## Cấu trúc thư mục

```
LAB7/
├── PTTK/
│   ├── UseCase/      Use Case tổng quát, phân rã: Danh mục – nhân viên, QĐ chức vụ – lương,
│   │                 Chấm công – phụ trội, Khen thưởng – kỷ luật, Thống kê
│   ├── Class/        Lớp phân tích (22 lớp)
│   ├── Sequence/     Tuần tự – Lập quyết định tuyển dụng, Ký hợp đồng chính thức (và Lập bảng lương)
│   ├── Activity/     Hoạt động – Từ thử việc đến hợp đồng chính thức; Lập bảng lương
│   ├── CSDL/         ERD, QuanLyNhanSu.sql (script SQL Server)
│   └── Forms/        Ảnh chụp giao diện
├── QuanLyNhanSu/         Mã nguồn C# WinForms
│   ├── Forms/            FrmMain, FrmDanhMuc, FrmTuyenDung, …
│   ├── Services/         Tầng Service – nghiệp vụ (có BangLuongService)
│   ├── Data/             Tầng Data – truy cập CSDL (ADO.NET)
│   ├── DTO/              Đối tượng truyền dữ liệu
│   └── App.config        Chuỗi kết nối CSDL
└── LAB7_QuanLyNhanSu.docx   Báo cáo
```

## Mô hình hệ thống

- **Tác nhân:** NV nhân sự, Trưởng phòng/ban/phân xưởng, Ban chấm công, NV kế toán, Giám đốc.
  Người được tuyển dụng **không** là Actor vì không thao tác trực tiếp (nhân viên nhân sự nhập thay).
- **Nhóm Use Case:** Quản lý danh mục · Quản lý nhân viên · Quản lý QĐ tuyển dụng · Quản lý hợp đồng lao động · Lập hồ sơ BHYT, BHXH (extend, chỉ hợp đồng dài hạn) · Quản lý QĐ chức vụ/lương · Quản lý QĐ khen thưởng/kỷ luật (include Ký duyệt) · Lập kế hoạch phân công/phụ trội · Lập phiếu chấm công, phiếu phụ trội · Lập bảng lương, phiếu chi, phiếu thu · Ký duyệt quyết định · Thống kê – báo cáo nhân sự.
- **22 lớp thực thể**, trong đó `QuyetDinh` là lớp trừu tượng, kế thừa bởi `QDTuyenDung`, `QDChucVu`, `QDLuong`, `QDKhenThuong`, `QDKyLuat`.
- **Quan hệ hợp thành (composition):** `KeHoachPhanCong`–`ChiTietPhanCong`, `PhieuChamCong`–`ChiTietChamCong`, `PhieuPhuTroi`–`ChiTietPhieuPhuTroi`, `BangLuong`–`ChiTietBangLuong`.
- **Quy ước lớp chi tiết:** ID là `STT` ghép với ID lớp chính.
- Các phụ thuộc của `ChiTietBangLuong` (QĐ lương, QĐ chức vụ, chấm công, phụ trội, bảo hiểm, thưởng, phạt) không vẽ trên biểu đồ lớp mà thể hiện ở biểu đồ tuần tự **Lập bảng lương**.

## Cơ sở dữ liệu `QuanLyNhanSu`

22 bảng: `PhongBan`, `ChucVu`, `CaLamViec`, `NhanVien`, `QuyetDinh`, `QDTuyenDung`, `QDChucVu`, `QDLuong`, `QDKhenThuong`, `QDKyLuat`, `HopDong`, `HoSoBaoHiem`, `KeHoachPhanCong`, `ChiTietPhanCong`, `PhieuChamCong`, `ChiTietChamCong`, `PhieuPhuTroi`, `ChiTietPhieuPhuTroi`, `BangLuong`, `ChiTietBangLuong`, `PhieuChiKhenThuong`, `PhieuThuNopPhat`.

Bảng `QuyetDinh` là bảng cha dùng chung; năm bảng con có **khóa chính đồng thời là khóa ngoại** tới `QuyetDinh.SoQD`.

Các ràng buộc nghiệp vụ chính:

| Quy tắc                                                                       | Cách hiện thực                                                   |
| ----------------------------------------------------------------------------- | ---------------------------------------------------------------- |
| CCCD nhân viên không trùng                                                    | `UNIQUE` trên `NhanVien.CCCD`                                    |
| Trạng thái nhân viên: Thử việc / Chính thức / Đã nghỉ                         | CHECK `CK_NhanVien_TrangThai`                                    |
| Loại quyết định ∈ {TD, CV, LU, KT, KL}; trạng thái Chờ ký / Đã ký / Hủy       | CHECK `CK_QD_Loai`, `CK_QD_TrangThai`                            |
| Quyết định phải có đối tượng: nhân viên hoặc phòng ban                        | CHECK `CK_QD_DoiTuong`                                           |
| Quyết định đã ký không được sửa hoặc xóa                                      | Service chặn theo trạng thái                                     |
| Thời gian thử việc > 0, lương thử việc ≥ 0; các khoản lương/phụ cấp ≥ 0       | CHECK                                                            |
| Chỉ ký hợp đồng chính thức khi hết thử việc và đánh giá đạt                   | Service kiểm tra                                                 |
| Hợp đồng: Dài hạn / Ngắn hạn; ngày kết thúc ≥ ngày bắt đầu                    | CHECK `CK_HD_Loai`, `CK_HD_Ngay`                                 |
| Chỉ hợp đồng dài hạn có hồ sơ BHYT, BHXH; mỗi hợp đồng một hồ sơ              | `HoSoBaoHiem.SoHD` `UNIQUE` + Service                            |
| Mức đóng bảo hiểm trong [0, 1]                                                | CHECK                                                            |
| Một nhân viên không bị phân công hai lần cùng ca trong cùng ngày              | `UNIQUE(SoKH, MaNV, NgayLamViec, MaCa)`                          |
| Mỗi nhân viên một dòng chấm công cho một ngày; số giờ làm trong [0, 24]       | `UNIQUE(SoPhieuCC, MaNV, NgayCong)` + CHECK                      |
| Giờ phụ trội > 0; hệ số mặc định **1.5**; hình thức Tăng ca / Ngày lễ / Ngày nghỉ | CHECK, `DEFAULT 1.5`                                          |
| Mỗi tháng chỉ có một bảng lương                                               | `UNIQUE(Thang, Nam)` trên `BangLuong`                            |
| Thực lãnh = lương + phụ cấp + phụ trội + thưởng − bảo hiểm − phạt             | Cột tính toán `PERSISTED` (`ThucLanh`)                           |
| Phiếu chi: Tiền mặt / Chuyển khoản / Cộng vào lương; phiếu thu: Nộp tiền / Trừ lương | CHECK                                                     |
| Số tiền trên phiếu chi, phiếu thu > 0                                         | CHECK                                                            |

### Quy ước triển khai (đề bài chưa quy định rõ, cần xác nhận nếu thay đổi)

- Quyết định tập thể: `SoTienThuong`/`SoTienPhat` là mức cho **từng thành viên**; phiếu chi/phiếu thu ghi tổng = mức × số nhân viên của phòng ban.
- `MucDongBHXH`, `MucDongBHYT` lưu tỷ lệ trích trừ trên lương cơ bản (ví dụ `0.08` = 8%, `0.015` = 1.5%), cấu hình theo từng hồ sơ.
- Tham số tính lương nằm trong `BangLuongService`: **26 ngày công/tháng**, **8 giờ/ngày công**.
- Thưởng/phạt chỉ vào bảng lương khi phiếu chi là `Cộng vào lương` hoặc phiếu thu là `Trừ lương` phát sinh trong tháng.

## Cách chạy

**Yêu cầu:** Windows, Visual Studio 2022, .NET Framework 4.7.2, SQL Server LocalDB hoặc SQL Server Express.

1. Mở **SSMS**, chạy toàn bộ `PTTK/CSDL/QuanLyNhanSu.sql` (tạo CSDL, bảng, chỉ mục và dữ liệu mẫu).
   > Script có lệnh `DROP TABLE` ở đầu để chạy lại được; sẽ xóa các bảng cùng tên nếu đã tồn tại.
2. Mở solution `QuanLyNhanSu` bằng Visual Studio.
3. Sửa chuỗi kết nối trong `App.config` cho đúng tên máy chủ SQL Server của bạn.
4. Nhấn **F5**. Màn hình `FrmMain` dùng để điều hướng.

| Form           | Đối tượng sử dụng            | Mục đích                                                |
| -------------- | ---------------------------- | ------------------------------------------------------- |
| `FrmMain`      | Nhân viên                    | Điều hướng                                              |
| `FrmDanhMuc`   | NV nhân sự                   | Danh mục nền và hồ sơ nhân viên                         |
| `FrmTuyenDung` | NV nhân sự / Giám đốc        | Quyết định tuyển dụng, hợp đồng, bảo hiểm               |

## Kiểm thử

Dữ liệu mẫu có sẵn: phòng ban `PB01`–`PB06`, chức vụ `CV01`–`CV04`, ca `CA1`–`CA3`, nhân viên `NV01`–`NV06` (`NV06` đang thử việc), quyết định `TD001`, `LU001`–`LU004`, `CV001`, hợp đồng `HD001`–`HD004` (`HD004` ngắn hạn), hồ sơ bảo hiểm `HS001`–`HS003`.

| Kịch bản                                                                  | Kết quả mong đợi            |
| ------------------------------------------------------------------------- | --------------------------- |
| Thêm nhân viên có CCCD trùng nhân viên đã có                              | UNIQUE từ chối              |
| Lập quyết định không có cả `MaNV` lẫn `MaPB`                              | CHECK từ chối               |
| Thời gian thử việc = 0                                                    | CHECK từ chối               |
| Hợp đồng có ngày kết thúc trước ngày bắt đầu                              | CHECK từ chối               |
| Lập hồ sơ BHXH/BHYT cho hợp đồng ngắn hạn (`HD004`)                       | Service từ chối             |
| Lập hồ sơ bảo hiểm thứ hai cho cùng một hợp đồng                          | UNIQUE từ chối              |
| Mức đóng bảo hiểm = 1.5 (> 1)                                             | CHECK từ chối               |
| Phân công cùng nhân viên hai lần cùng ca, cùng ngày                       | Lần thứ hai bị từ chối      |
| Chấm công cùng nhân viên hai lần cho một ngày                             | Lần thứ hai bị từ chối      |
| Chấm công với số giờ làm 25                                               | CHECK từ chối               |
| Lập phiếu phụ trội không nhập hệ số                                       | `HeSo` mặc định 1.5         |
| Lập bảng lương lần thứ hai cho cùng tháng/năm                             | UNIQUE từ chối              |
| Lập phiếu chi / phiếu thu với số tiền 0                                   | CHECK từ chối               |
| Sửa quyết định đang ở trạng thái `Đã ký`                                  | Service từ chối             |
| Lập bảng lương tháng có đủ chấm công, phụ trội, bảo hiểm, thưởng, phạt    | `ThucLanh` tính đúng công thức |

## Công nghệ

C# WinForms · .NET Framework 4.7.2 · SQL Server LocalDB/Express · ADO.NET · UML (Use Case, Class, Sequence, Activity)
