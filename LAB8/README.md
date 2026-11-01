# LAB 8 – Quản lý Cửa hàng Nước giải khát

Bài thực hành môn **Phương pháp phát triển phần mềm hướng đối tượng (OOSD)** – Bài 2.
Phân tích, thiết kế bằng UML, thiết kế CSDL SQL Server và hiện thực giao diện C# WinForms cho nghiệp vụ cửa hàng nước giải khát (NGK): nhập hàng từ nhà cung ứng, bán hàng, hẹn giao nhiều đợt và ghi nợ khách quen.

## Mục tiêu

- Phân tích nghiệp vụ: danh mục, đơn đặt hàng (ĐĐH) gửi nhà cung ứng (NCU), phiếu giao hàng tối đa 3 đợt, hóa đơn bán hàng, phiếu hẹn giao, phiếu ghi nợ, tra cứu và thống kê.
- Xây dựng bộ mô hình UML (Use Case, Class phân tích, Sequence, Activity) bằng **PlantUML**.
- Thiết kế CSDL SQL Server; ERD sinh từ mã **DBML** trên dbdiagram.io, khớp hoàn toàn với script SQL.
- Hiện thực C# WinForms (.NET Framework 4.7.2) theo kiến trúc **UI (Form) → Service → Data**.
- Kiểm thử theo kịch bản và truy vết: quy tắc nghiệp vụ → UML → Form/Service → bảng CSDL → test case.

## Cấu trúc thư mục

```
LAB8/
├── PTTK/
│   ├── UseCase/      Use Case tổng quát; phân rã “Lập hóa đơn bán hàng”, “Nhập hàng từ nhà cung ứng”
│   ├── Class/        Biểu đồ lớp phân tích (14 lớp)
│   ├── Sequence/     Tuần tự – Lập hóa đơn bán hàng (BanHangService)
│   ├── Activity/     Hoạt động – Bán hàng
│   ├── CSDL/         ERD (mã DBML), QuanLyNuocGiaiKhat.sql (script SQL Server)
│   └── Forms/        Ảnh chụp giao diện
├── QuanLyCuaHangNuocGiaiKhat/   Mã nguồn C# WinForms
│   ├── Forms/            Trang chủ, Lập hóa đơn bán hàng, Lập đơn nhập hàng
│   ├── Services/         Tầng Service – nghiệp vụ (BanHangService, …)
│   ├── Data/             Tầng Data – truy cập CSDL (ADO.NET)
│   ├── DTO/              Đối tượng truyền dữ liệu
│   └── App.config        Chuỗi kết nối CSDL
└── LAB8_QuanLyCuaHangNuocGiaiKhat.docx   Báo cáo
```

## Mô hình hệ thống

- **Tác nhân:** Nhân viên cửa hàng, Quản lý cửa hàng.
  Khách hàng và nhà cung ứng **không** là Actor vì không thao tác trực tiếp (nhân viên nhập thông tin thay).
- **Use Case:** Quản lý danh mục · Lập đơn đặt hàng · Ghi nhận phiếu giao hàng · Lập hóa đơn bán hàng · Giao hàng theo phiếu hẹn · Tra cứu hóa đơn, phiếu · Thống kê – báo cáo.
- **Quan hệ giữa Use Case:** *Lập hóa đơn bán hàng* **include** Kiểm tra tồn kho; **extend** bởi Lập phiếu hẹn giao và Lập phiếu ghi nợ (chỉ phát sinh khi có điều kiện).
- **14 lớp thực thể:** `LoaiNGK`, `NhaCungUng`, `NuocGiaiKhat`, `NhanVien`, `KhachHang`, `DonDatHang`, `ChiTietDonDatHang`, `PhieuGiaoHang`, `ChiTietPhieuGiao`, `HoaDon`, `ChiTietHoaDon`, `PhieuHenGiao`, `ChiTietPhieuHen`, `PhieuGhiNo`.
- **Quan hệ hợp thành (composition):** mỗi chứng từ với phần chi tiết của nó (ĐĐH, phiếu giao, hóa đơn, phiếu hẹn).
- **Quy ước lớp chi tiết:** ID là `STT` ghép với ID lớp chính. Bản số `PhieuGiaoHang`–`DonDatHang` là `0..3 – 1` (tối đa 3 đợt giao).

## Cơ sở dữ liệu `QuanLyNuocGiaiKhat`

14 bảng: `LoaiNGK`, `NhaCungUng`, `NuocGiaiKhat`, `NhanVien`, `KhachHang`, `DonDatHang`, `ChiTietDonDatHang`, `PhieuGiaoHang`, `ChiTietPhieuGiao`, `HoaDon`, `ChiTietHoaDon`, `PhieuHenGiao`, `ChiTietPhieuHen`, `PhieuGhiNo`.

Các ràng buộc nghiệp vụ chính:

| Quy tắc                                                                    | Cách hiện thực                                                      |
| -------------------------------------------------------------------------- | ------------------------------------------------------------------- |
| Mỗi NGK thuộc một loại và chỉ nhập từ **một** NCU                          | Khóa ngoại `MaLoai`, `MaNCU` (NOT NULL) trong `NuocGiaiKhat`        |
| Không trùng tên NGK trong cùng một loại                                    | `UNIQUE(MaLoai, TenNGK)`                                            |
| Giá bán ≥ 0; tồn kho không âm                                              | CHECK `DonGiaBan >= 0`, `SoLuongTon >= 0`                           |
| Mỗi ĐĐH giao tối đa 3 đợt                                                  | CHECK `DotGiao BETWEEN 1 AND 3` + `UNIQUE(SoDDH, DotGiao)`          |
| Không lặp mặt hàng trong cùng một chứng từ; số lượng > 0                   | `UNIQUE(chứng từ, MaNGK)` + CHECK                                   |
| Ngày nhận dự kiến ≥ ngày đặt                                               | CHECK `CK_DDH_Ngay`                                                 |
| Ngày dự kiến trả ≥ ngày lập phiếu nợ; số tiền nợ > 0                       | CHECK `CK_PN_Ngay`, `SoTienNo > 0`                                  |
| Mỗi hóa đơn tối đa một phiếu ghi nợ                                        | `UNIQUE(SoHD)` trên `PhieuGhiNo`                                    |
| Loại khách, hình thức thanh toán, trạng thái giao, trạng thái chứng từ     | CHECK theo danh sách giá trị                                        |
| Thành tiền = số lượng × đơn giá                                            | Cột tính toán `PERSISTED`                                           |
| Mặt hàng trong ĐĐH phải thuộc NCU của đơn                                  | Service kiểm tra                                                    |
| Tổng số lượng giao của một mặt hàng không vượt số lượng đặt                | Service kiểm tra                                                    |
| Nhận hàng tăng tồn kho; bán hàng giảm tồn kho                              | Service trong transaction                                           |
| Chỉ **khách quen** được hẹn giao và trả chậm; khách vãng lai chỉ mua số có sẵn | Service kiểm tra                                                |
| Số tiền nợ không vượt tổng tiền hóa đơn                                    | Service kiểm tra                                                    |
| Giao theo phiếu hẹn phải còn đủ tồn kho; giao xong chuyển `Đã giao`        | Service kiểm tra                                                    |

### Quy ước triển khai

- Khách vãng lai không lưu thông tin cá nhân; hệ thống dùng một khách đặc biệt mã **`VL000`** để mọi hóa đơn đều có khách.
- “Mỗi loại chỉ nhập từ một NCU” được hiểu là mỗi **NGK** có đúng một NCU.
- Hóa đơn ghi `SoLuongGiaoNgay` cho từng dòng; phần thiếu được ghi trong phiếu hẹn giao.
- Giá bán lưu ở `NuocGiaiKhat.DonGiaBan`; giá nhập lưu ở từng dòng phiếu giao (`DonGiaNhap`).
- Bổ sung bảng `NhanVien`, `KhachHang` (khóa `MaNV`, `MaKH`) để lưu người lập chứng từ và thông tin khách.

## Cách chạy

**Yêu cầu:** Windows, Visual Studio 2022, .NET Framework 4.7.2, SQL Server LocalDB hoặc SQL Server Express.

1. Mở **SSMS**, chạy toàn bộ `PTTK/CSDL/QuanLyNuocGiaiKhat.sql` (tạo CSDL, bảng, chỉ mục và dữ liệu mẫu).
   > Script có lệnh `DROP TABLE` ở đầu để chạy lại được; sẽ xóa các bảng cùng tên nếu đã tồn tại.
2. Mở solution `QuanLyCuaHangNuocGiaiKhat` bằng Visual Studio.
3. Sửa chuỗi kết nối trong `App.config` cho đúng tên máy chủ SQL Server của bạn.
4. Nhấn **F5**. Từ trang chủ, mở form _Lập hóa đơn bán hàng_ hoặc _Lập đơn nhập hàng_.

**Xem ERD:** dán mã DBML trong `PTTK/CSDL/` vào <https://dbdiagram.io>.

## Kiểm thử

Dữ liệu mẫu có sẵn: loại `PEPSI`, `COCA`, `BIASG`; NCU `NCU01`–`NCU03`; NGK `NGK01`–`NGK06`; nhân viên `NV01`, `NV02`; khách `VL000`, `KH001`, `KH002` (hai khách quen).

| Kịch bản                                                                      | Kết quả mong đợi                                   |
| ----------------------------------------------------------------------------- | -------------------------------------------------- |
| Bán `NGK01` cho `KH001`, số lượng ≤ tồn kho, trả ngay                         | Lưu thành công, tồn kho giảm                       |
| Bán vượt tồn kho cho khách quen (`KH001`)                                     | Giao phần có sẵn, lập phiếu hẹn cho phần thiếu     |
| Bán vượt tồn kho cho khách vãng lai (`VL000`)                                 | Từ chối                                            |
| Khách vãng lai chọn trả chậm                                                  | Từ chối                                            |
| Khách quen trả chậm, số tiền nợ ≤ tổng tiền hóa đơn                           | Lập phiếu ghi nợ thành công                        |
| Số tiền nợ lớn hơn tổng tiền hóa đơn                                          | Từ chối                                            |
| Ngày dự kiến trả trước ngày lập phiếu nợ                                      | CHECK từ chối                                      |
| Lập hai phiếu ghi nợ cho cùng một hóa đơn                                     | UNIQUE từ chối                                     |
| Lập ĐĐH gửi `NCU01` có chứa `NGK03` (thuộc `NCU02`)                           | Từ chối                                            |
| Ghi nhận phiếu giao đợt 1, 2, 3 cho cùng một ĐĐH                              | Thành công, tồn kho tăng sau mỗi đợt               |
| Ghi nhận phiếu giao đợt 4                                                     | CHECK từ chối                                      |
| Giao tổng cộng nhiều hơn số lượng đặt                                         | Từ chối                                            |
| Giao theo phiếu hẹn khi tồn kho chưa đủ                                       | Từ chối; đủ hàng thì phiếu chuyển `Đã giao`        |
| Thêm cùng một mặt hàng hai lần vào một chứng từ                               | UNIQUE từ chối                                     |
| Số lượng ≤ 0 hoặc để trống trường bắt buộc                                    | Từ chối, thông báo nguyên nhân                     |
| Xóa NGK / khách / NCU đã phát sinh chứng từ                                   | Khóa ngoại chặn                                    |

## Công nghệ

C# WinForms · .NET Framework 4.7.2 · SQL Server LocalDB/Express · ADO.NET · PlantUML · dbdiagram.io (DBML)
