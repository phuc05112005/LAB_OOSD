# PHƯƠNG PHÁP PHÁT TRIỂN PHẦN MỀM HƯỚNG ĐỐI TƯỢNG

<p align="center">
  <strong>OBJECT-ORIENTED SOFTWARE DEVELOPMENT (OOSD)</strong><br/>
  <sub>Tổng hợp bài thực hành · Phân tích nghiệp vụ · Mô hình hóa UML · Thiết kế dữ liệu · Hiện thực ứng dụng</sub>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/COURSE-OOSD-2457A7?style=flat-square" />
  <img src="https://img.shields.io/badge/LABS-00--08-2F855A?style=flat-square" />
  <img src="https://img.shields.io/badge/C%23-Windows%20Forms-512BD4?style=flat-square" />
  <img src="https://img.shields.io/badge/DATABASE-SQL%20Server-CC2927?style=flat-square" />
  <img src="https://img.shields.io/badge/MODELING-UML%20%7C%20ERD-6F42C1?style=flat-square" />
</p>

Repository lưu trữ bài tập và sản phẩm thực hành của học phần **Phương pháp phát triển phần mềm hướng đối tượng**. Nội dung được sắp xếp theo từng LAB/buổi học; mỗi LAB là **một bài toán hoặc yêu cầu thực hành độc lập**, có phạm vi và kết quả riêng. Các bài không phải những giai đoạn nối tiếp để xây dựng một hệ thống duy nhất.

Tùy theo yêu cầu từng buổi, sản phẩm có thể bao gồm tài liệu bài tập, phân tích nghiệp vụ, mô hình UML, thiết kế cơ sở dữ liệu, giao diện Windows Forms, mã nguồn kết nối SQL Server, kiểm thử và hình ảnh minh chứng. Vì vậy, không phải LAB nào cũng có đầy đủ tất cả các loại tài liệu hoặc chức năng.

## Thông tin học phần

| Thông tin | Nội dung |
|---|---|
| **Sinh viên** | Lê Hoàng Phúc |
| **Mã số sinh viên** | 1250080145 |
| **Lớp** | 12_ĐH_CNPM2 |
| **Giảng viên hướng dẫn** | ThS. Phạm Trọng Huynh |
| **Học phần** | Phương pháp phát triển phần mềm hướng đối tượng |
| **Repository** | [phuc05112005/LAB_OOSD](https://github.com/phuc05112005/LAB_OOSD) |

## Danh mục bài thực hành

Các đường dẫn bên dưới trỏ đến tài liệu hoặc thư mục tương ứng trong repository. LAB01 hiện lưu báo cáo bài tập Word và hình mô hình trong IMAGES/LAB1; các LAB từ LAB02 trở đi có README riêng để xem chi tiết cách tổ chức và kết quả.

| Bài thực hành | Chủ đề | Nội dung và sản phẩm được lưu trữ |
|---|---|---|
| [LAB 00](LAB0/README.txt) | **Thiết lập môi trường và kiểm tra công cụ** | Cấu hình môi trường Windows x64; kiểm tra JDK 21, Maven, Git; sử dụng IntelliJ IDEA và PlantUML Integration; tạo Maven project Java, chạy chương trình, thực hiện mvn clean test, đóng gói JAR và chạy ứng dụng từ JAR. Có README và minh chứng theo từng bước. |
| [LAB 01](LAB1/) | **Bài tập phân tích và mô hình hóa hướng đối tượng** | Lưu hai báo cáo Lab01_Bai1 và Lab01_Bai2. Bộ hình minh họa cho thấy Bài 1 có sơ đồ riêng; Bài 2 có Use Case tổng quát, Activity, Sequence và Class Diagram. Xem [báo cáo Bài 1](LAB1/Lab01_Bai1_1250080145_LeHoangPhuc.docx), [báo cáo Bài 2](LAB1/Lab01_Bai2_1250080145_LeHoangPhuc.docx) và [hình minh họa LAB01](IMAGES/LAB1/). |
| [LAB 02](LAB2/README.md) | **Hệ thống quản lý thư viện** | Xây dựng ứng dụng C# Windows Forms trên .NET Framework 4.7.2, kết nối SQL Server LocalDB. Có các màn hình danh mục/nhân viên, đầu sách và độc giả; tổ chức mã nguồn theo Forms – Services – Data – Models; đọc và hiển thị dữ liệu từ CSDL. README nêu rõ phần thêm/sửa/xóa và nghiệp vụ mượn–trả là các nội dung dự kiến hoàn thiện tiếp, không mô tả chúng như chức năng đã hoàn tất. |
| [LAB 03](LAB3/README.md) | **Hệ thống quản lý khách sạn** | Phân tích nghiệp vụ phòng, tiện nghi, đặt/nhận phòng, người lưu trú, dịch vụ, đền bù, hóa đơn, thanh toán và trả phòng. Thiết kế CSDL SQL Server gồm 18 bảng; xây dựng giao diện WinForms, lớp kết nối Db.cs, các tầng Forms/Services/Data và kiểm tra kết nối ứng dụng với CSDL. |
| [LAB 04](LAB4/README.md) | **Hệ thống cửa hàng trực tuyến e-SHOPPING** | Phân tích tác nhân và 15 Use Case; đặc tả, phân rã Use Case Đặt mua hàng và Thanh toán giao dịch; xây dựng Activity, Sequence và Class Diagram. Thiết kế kiến trúc phân tầng, CSDL cho phạm vi e-SHOPPING. Phần cài đặt minh họa bằng WinForms: đăng ký khách hàng, đọc/ghi dữ liệu SQL Server và băm mật khẩu trước khi lưu. |
| [LAB 05](LAB5/README.md) | **Quản lý Công ty Du lịch Văn Hóa Việt** | Phân tích nghiệp vụ tour, 11 Use Case và 18 lớp; mô hình hóa đăng ký tour bằng Activity/Sequence; thiết kế ERD và CSDL SQL Server gồm 18 bảng. Hiện thực WinForms theo UI – Service – Data cho đăng ký tour theo đoàn; áp dụng PK/FK, CHECK, trigger và kiểm thử các trường hợp nghiệp vụ. |
| [LAB 06](LAB6/README.md) | **Quản lý hồ sơ bệnh án của bệnh nhân** | Phân tích đăng ký khám, thu lệ phí, cấp/gia hạn hồ sơ, lịch khám định kỳ theo quý, phiếu khám, tra cứu và thống kê. Có Use Case, Class (16 lớp phân tích), Sequence, Activity, ERD/CSDL SQL Server và ứng dụng WinForms theo UI – Service – Data; quy tắc được kiểm tra ở Service và CSDL. |
| [LAB 07](LAB7/README.md) | **Quản lý nhân sự Công ty Sơn Đông Á** | Phân tích tuyển dụng, thử việc, hợp đồng, bảo hiểm, quyết định, phân công, chấm công, phụ trội, tính lương, khen thưởng và kỷ luật. Thiết kế UML và CSDL 22 bảng theo mô hình table-per-type; hiện thực WinForms, áp dụng ràng buộc dữ liệu và kiểm thử các quy tắc nhân sự – tiền lương. |
| [LAB 08](LAB8/README.md) | **Quản lý cửa hàng nước giải khát** | Phân tích nhập hàng, bán hàng, giao hàng nhiều đợt, hẹn giao và ghi nợ khách quen. Có Use Case, Class (14 lớp), Activity, Sequence, ERD/DBML và CSDL SQL Server 14 bảng; hiện thực WinForms theo UI – Service – Data, dùng transaction khi cập nhật tồn kho và kiểm thử quy tắc bán hàng/nhập hàng/công nợ. |

## Hình ảnh minh họa các bài thực hành

Thư mục [IMAGES/](IMAGES/) lưu hình ảnh sơ đồ, giao diện và minh chứng theo từng LAB. Các hình dưới đây được nhúng trực tiếp từ repository; có thể mở ảnh để xem kích thước đầy đủ.

<details>
<summary><strong>LAB 00 – Thiết lập môi trường và kiểm tra công cụ</strong></summary>

Các hình ảnh dưới đây là minh chứng cho quá trình thiết lập và kiểm tra môi trường phát triển: Java JDK 21, Maven, Git, IntelliJ IDEA, PlantUML Integration, chạy chương trình Java, build/test bằng Maven và đóng gói/chạy file JAR.

**Bước 01–04 – Kiểm tra công cụ và môi trường**

| Bước 01 | Bước 02 |
|---|---|
| ![LAB00 – Bước 01](IMAGES/LAB0/step-01/result.png) | ![LAB00 – Bước 02](IMAGES/LAB0/step-02/result.png) |

![LAB00 – Bước 03](IMAGES/LAB0/step-03/Screenshot%202026-09-04%20155927.png)

![LAB00 – Bước 04](IMAGES/LAB0/step-04/result.png)

**Bước 05–08 – Cấu hình project và công cụ phát triển**

| Bước 05 | Bước 06 |
|---|---|
| ![LAB00 – Bước 05](IMAGES/LAB0/step-05/result.png) | ![LAB00 – Bước 06](IMAGES/LAB0/step-06/result.png) |

| Bước 07 | Bước 08 |
|---|---|
| ![LAB00 – Bước 07](IMAGES/LAB0/step-07/result.png) | ![LAB00 – Bước 08](IMAGES/LAB0/step-08/result.png) |

**Bước 09–12 – Chạy chương trình và kiểm tra Maven**

| Bước 09 | Bước 10 |
|---|---|
| ![LAB00 – Bước 09](IMAGES/LAB0/step-09/result.png) | ![LAB00 – Bước 10](IMAGES/LAB0/step-10/result.png) |

![LAB00 – Bước 10: minh chứng bổ sung](IMAGES/LAB0/step-10/result2.png)

| Bước 11 – Minh chứng 1 | Bước 11 – Minh chứng 2 |
|---|---|
| ![LAB00 – Bước 11: minh chứng 1](IMAGES/LAB0/step-11/result1.png) | ![LAB00 – Bước 11: minh chứng 2](IMAGES/LAB0/step-11/result2.png) |

![LAB00 – Bước 12](IMAGES/LAB0/step-12/result.png)

**Bước 13–17 – Đóng gói, chạy JAR và hoàn tất môi trường**

![LAB00 – Bước 13](IMAGES/LAB0/step-13/result.png)

| Bước 14 – Minh chứng 1 | Bước 14 – Minh chứng 2 |
|---|---|
| ![LAB00 – Bước 14: minh chứng 1](IMAGES/LAB0/step-14/result1.png) | ![LAB00 – Bước 14: minh chứng 2](IMAGES/LAB0/step-14/result2.png) |

| Bước 14 – Minh chứng 3 | Bước 14 – Minh chứng 4 |
|---|---|
| ![LAB00 – Bước 14: minh chứng 3](IMAGES/LAB0/step-14/result3.png) | ![LAB00 – Bước 14: minh chứng 4](IMAGES/LAB0/step-14/result4.png) |

![LAB00 – Bước 15](IMAGES/LAB0/step-15/result.png)

Bước 16 lưu thông tin môi trường trong file [environment.txt](IMAGES/LAB0/step-16/environment.txt).

![LAB00 – Bước 17](IMAGES/LAB0/step-17/result.png)

</details>

<details>
<summary><strong>LAB 01 – Bài tập và mô hình UML</strong></summary>

**Bài 1**

![LAB01 – Bài tập 1](IMAGES/LAB1/bai1/bai1.drawio.png)

**Bài 2 – Use Case, Activity, Sequence và Class**

| Use Case tổng quát | Activity |
|---|---|
| ![LAB01 Use Case](IMAGES/LAB1/bai2/usecasetongquat.drawio.png) | ![LAB01 Activity](IMAGES/LAB1/bai2/activity.drawio.png) |

| Sequence | Class |
|---|---|
| ![LAB01 Sequence](IMAGES/LAB1/bai2/sequence.drawio.png) | ![LAB01 Class](IMAGES/LAB1/bai2/class.drawio.png) |

</details>

<details>
<summary><strong>LAB 02 – Hệ thống quản lý thư viện</strong></summary>

![LAB02 – ERD](IMAGES/LAB2/ERD.png)

![LAB02 – Giao diện trang chủ](IMAGES/LAB2/Form_trangchu.png)

![LAB02 – Activity mượn sách](IMAGES/LAB2/activity_muonsach.drawio.png)

</details>

<details>
<summary><strong>LAB 03 – Hệ thống quản lý khách sạn</strong></summary>

![LAB03 – Use Case tổng quát](IMAGES/LAB3/usecasetongquat.drawio.png)

![LAB03 – Giao diện quản lý khách sạn](IMAGES/LAB3/Form_quanlykhachsan.png)

![LAB03 – Sequence đặt phòng](IMAGES/LAB3/sequence_datphong.drawio.png)

</details>

<details>
<summary><strong>LAB 04 – Hệ thống e-SHOPPING</strong></summary>

![LAB04 – Use Case tổng quát](IMAGES/LAB4/usecasetongquat.drawio.png)

![LAB04 – ERD](IMAGES/LAB4/ERD.png)

![LAB04 – Giao diện đăng ký khách hàng](IMAGES/LAB4/Form_dangkykhachhang.png)

</details>

<details>
<summary><strong>LAB 05 – Quản lý Công ty Du lịch Văn Hóa Việt</strong></summary>

![LAB05 – Use Case tổng quát](IMAGES/LAB5/usecasetongquat.drawio.png)

![LAB05 – ERD](IMAGES/LAB5/ERD.png)

![LAB05 – Giao diện lập phiếu đăng ký](IMAGES/LAB5/Form_lapphieudangky.png)

</details>

<details>
<summary><strong>LAB 06 – Quản lý hồ sơ bệnh án</strong></summary>

![LAB06 – Use Case tổng quát](IMAGES/LAB6/uscasetongquqt.drawio.png)

![LAB06 – ERD](IMAGES/LAB6/erd.drawio.png)

![LAB06 – Giao diện đăng ký bệnh nhân](IMAGES/LAB6/Form_dangkybenhnhan.png)

</details>

<details>
<summary><strong>LAB 07 – Quản lý nhân sự Công ty Sơn Đông Á</strong></summary>

![LAB07 – Use Case tổng quát](IMAGES/LAB7/usecasetongquat.drawio.png)

![LAB07 – ERD](IMAGES/LAB7/erd.png)

![LAB07 – Giao diện tuyển dụng](IMAGES/LAB7/Form_tuyendung.png)

</details>

<details>
<summary><strong>LAB 08 – Quản lý cửa hàng nước giải khát</strong></summary>

![LAB08 – Use Case tổng quát](IMAGES/LAB8/usecasetongquat.drawio.png)

![LAB08 – ERD](IMAGES/LAB8/erd.png)

![LAB08 – Giao diện lập hóa đơn bán hàng](IMAGES/LAB8/Form_laphoadonbanhang.png)

</details>

## Cấu trúc repository

~~~text
LAB_OOSD/
├── LAB0/                         # LAB00: môi trường Java, Maven, Git, PlantUML
│   ├── evidence/                 # Minh chứng theo các bước thực hiện
│   └── README.txt
├── LAB1/                         # LAB01: hai báo cáo bài tập Word
│   ├── Lab01_Bai1_1250080145_LeHoangPhuc.docx
│   └── Lab01_Bai2_1250080145_LeHoangPhuc.docx
├── LAB2/                         # LAB02: ứng dụng quản lý thư viện
│   ├── QuanLyThuVien/            # Forms, Services, Data, Models
│   └── README.md
├── LAB3/                         # LAB03: ứng dụng quản lý khách sạn
│   ├── QuanLyKhachSan/           # Forms, Services, Data, Models
│   └── README.md
├── LAB4/                         # LAB04: phân tích e-SHOPPING và WinForms minh họa
│   ├── PTTK/                     # Tài liệu phân tích – thiết kế
│   ├── QuanLyShopping/           # Mã nguồn WinForms
│   └── README.md
├── LAB5/                         # LAB05: quản lý công ty du lịch
│   ├── PTTK/                     # UML, ERD, script SQL, hình giao diện
│   ├── QuanLyCongTyDuLich/       # Forms, Services, Data, DTO
│   └── README.md
├── LAB6/                         # LAB06: quản lý hồ sơ bệnh án
│   ├── PTTK/                     # UML, ERD, script SQL, hình giao diện
│   ├── QuanLyHoSoBenhAn/         # Forms, Services, Data, DTO
│   └── README.md
├── LAB7/                         # LAB07: quản lý nhân sự
│   ├── PTTK/                     # UML, ERD, script SQL, hình giao diện
│   ├── QuanLyNhanSu/             # Forms, Services, Data, DTO
│   └── README.md
├── LAB8/                         # LAB08: quản lý cửa hàng nước giải khát
│   ├── PTTK/                     # UML, ERD/DBML, script SQL, hình giao diện
│   ├── QuanLyNuocGiaiKhat/       # Forms, Services, Data, DTO
│   └── README.md
├── IMAGES/                       # Hình ảnh minh họa, chia theo LAB0–LAB8
│   ├── LAB0/
│   ├── LAB1/
│   ├── LAB2/
│   ├── LAB3/
│   ├── LAB4/
│   ├── LAB5/
│   ├── LAB6/
│   ├── LAB7/
│   └── LAB8/
├── TongHopLab/                   # Báo cáo Word từng LAB và báo cáo tổng hợp
└── README.md                     # Tài liệu tổng quan repository
~~~

> Cấu trúc trên trình bày các thư mục và thành phần chính để định hướng tra cứu, không liệt kê mọi file mã nguồn. Một số LAB lưu báo cáo trong cả thư mục LAB riêng và TongHopLab; README của từng LAB là nơi xem hướng dẫn, cấu trúc và chi tiết triển khai tương ứng.

---

## Quy trình phân tích, thiết kế và hiện thực phần mềm

Đây là **quy trình phương pháp luận tổng quát** được tổng kết từ nội dung học phần và vận dụng ở những bài có yêu cầu tương ứng. Không nên hiểu rằng tất cả LAB đều triển khai đủ mọi bước hoặc mọi biểu đồ dưới đây.

### 1. Đọc đề, xác định bài toán và phạm vi

- Tóm tắt vấn đề cần giải quyết, mục tiêu và kết quả mong muốn.
- Xác định phạm vi hệ thống, phần nằm ngoài phạm vi và các giả định.
- Nhận diện người sử dụng, bên liên quan và hệ thống bên ngoài.
- Phân biệt yêu cầu được nêu rõ trong đề với những điểm cần thống nhất thành quyết định triển khai.

### 2. Phân tích yêu cầu nghiệp vụ

Làm rõ nghiệp vụ theo mô hình **Input – Process – Output** và các yếu tố liên quan:

| Thành phần | Câu hỏi cần trả lời |
|---|---|
| **Input** | Người dùng nhập gì? Dữ liệu đến từ đâu? Trường nào bắt buộc và hợp lệ theo điều kiện nào? |
| **Process** | Hệ thống thực hiện những bước nào? Cần kiểm tra, tính toán, cập nhật trạng thái hay phối hợp dữ liệu nào? |
| **Output** | Kết quả hiển thị hoặc lưu lại là gì? Có chứng từ, thông báo hay báo cáo nào? |
| **Actor** | Ai hoặc hệ thống bên ngoài nào trực tiếp tương tác với hệ thống? |
| **Business Rules** | Điều kiện, giới hạn, công thức, trạng thái, ngoại lệ và các trường hợp bị từ chối là gì? |
| **Implementation Decisions** | Những điểm đề chưa quy định sẽ được xử lý thế nào, vì sao chọn cách đó và cần xác nhận với ai? |

Các quyết định triển khai phải nhất quán với nghiệp vụ, được ghi nhận rõ và không được âm thầm biến thành yêu cầu gốc của đề bài.

### 3. Mô tả hệ thống và đặc tả yêu cầu

- **Giới thiệu hệ thống:** mục tiêu, phạm vi, đối tượng sử dụng, môi trường và giới hạn.
- **Yêu cầu chức năng:** hệ thống phải cung cấp những nghiệp vụ nào, thể hiện bằng hành động và kết quả có thể kiểm tra.
- **Yêu cầu phi chức năng:** bảo mật, hiệu năng, độ tin cậy, khả năng sử dụng, bảo trì, tương thích và các ràng buộc kỹ thuật.
- Kiểm tra yêu cầu có rõ nghĩa, không mâu thuẫn và có thể kiểm chứng hay không.

### 4. Mô hình hóa chức năng bằng Use Case

Use Case mô tả **hệ thống cung cấp chức năng gì và tương tác với ai**.

1. Xác định ranh giới hệ thống và các Actor trực tiếp tương tác.
2. Xây dựng Use Case tổng quát theo nghiệp vụ.
3. Đặc tả từng Use Case: mục tiêu, Actor, tiền điều kiện, hậu điều kiện, luồng chính, luồng thay thế và ngoại lệ.
4. Phân rã Use Case phức tạp theo **phân hệ hoặc nhóm chức năng nghiệp vụ**, không chia sơ đồ máy móc theo từng Actor.
5. Dùng include cho hành vi bắt buộc được dùng chung; dùng extend cho hành vi mở rộng chỉ phát sinh khi có điều kiện.

### 5. Mô hình hóa quy trình và tương tác

| Biểu đồ | Mục đích sử dụng |
|---|---|
| **Activity Diagram** | Mô tả quy trình công việc, hành động, điều kiện, nhánh rẽ và luồng song song nếu có. |
| **Sequence Diagram** | Mô tả thứ tự thông điệp giữa Actor và các đối tượng trong một kịch bản; làm rõ đối tượng gửi/nhận lời gọi và trách nhiệm xử lý. |

Activity tập trung vào **luồng công việc**; Sequence tập trung vào **sự phối hợp giữa các đối tượng theo thời gian**. Hai biểu đồ bổ sung cho nhau, không thay thế nhau.

### 6. Phân tích và thiết kế lớp

Class Diagram mô tả cấu trúc tĩnh và trách nhiệm của các lớp:

- Xác định lớp nghiệp vụ, thuộc tính và phương thức.
- Xác định kết hợp, kết tập, hợp thành, kế thừa và phụ thuộc khi có ý nghĩa trong miền bài toán.
- Thể hiện bội số, vai trò quan hệ và các ràng buộc quan trọng.
- Phân biệt lớp phân tích với lớp thiết kế/cài đặt; bổ sung kiểu dữ liệu và chữ ký phương thức ở mức chi tiết phù hợp.
- Xác định lớp tiếp nhận yêu cầu, lớp điều phối nghiệp vụ, lớp quản lý dữ liệu và lớp truy cập CSDL.

Mỗi lớp cần có trách nhiệm rõ ràng. Không nên dồn toàn bộ nghiệp vụ vào Form hoặc tạo lớp chỉ để sao chép máy móc cấu trúc bảng dữ liệu.

### 7. Thiết kế cơ sở dữ liệu

Quá trình chuyển mô hình nghiệp vụ thành cấu trúc lưu trữ gồm:

1. **ERD:** xác định thực thể, thuộc tính, quan hệ và lực lượng kết hợp.
2. **Lược đồ quan hệ:** chuyển thực thể thành bảng, xác định cột, khóa chính, khóa ngoại; xử lý quan hệ N–N bằng bảng kết hợp khi cần.
3. **Ràng buộc toàn vẹn:** PRIMARY KEY, FOREIGN KEY, UNIQUE, NOT NULL, CHECK, DEFAULT, khóa ghép và các điều kiện dữ liệu.
4. **Hiện thực quy tắc nghiệp vụ:** đặt quy tắc ở CSDL khi phù hợp; dùng Service và transaction cho quy tắc cần phối hợp nhiều bước hoặc kiểm tra theo ngữ cảnh.
5. **Script SQL:** tạo CSDL, bảng, khóa, chỉ mục, constraint, trigger và dữ liệu mẫu phục vụ chạy thử.

ERD thể hiện cấu trúc dữ liệu ở mức mô hình; lược đồ quan hệ và script SQL thể hiện cách tổ chức, triển khai cụ thể. Các phần này cần thống nhất với mô hình lớp và quy tắc nghiệp vụ.

### 8. Thiết kế kiến trúc và triển khai ứng dụng

Với các ứng dụng WinForms trong repository, cách phân tách thường gặp là:

~~~text
Windows Forms (UI)
       |
       v
    Service
       |
       v
      Data
       |
       v
   SQL Server
~~~

- **UI / Forms:** nhận thao tác, hiển thị dữ liệu và thông báo kết quả.
- **Service:** kiểm tra và điều phối nghiệp vụ, quản lý luồng xử lý và transaction khi cần.
- **Data:** quản lý kết nối, truy vấn và thao tác dữ liệu bằng ADO.NET.
- **Database:** lưu trữ dữ liệu và bảo đảm các ràng buộc toàn vẹn.

Ở mức kiến trúc, biểu đồ phân tầng thể hiện cách tổ chức phần mềm và quan hệ phụ thuộc. **Deployment Diagram** thể hiện môi trường thực thi, các nút triển khai và kết nối giữa chúng. Đây là hai góc nhìn khác nhau.

### 9. Thiết kế giao diện, kết nối dữ liệu và kiểm thử

**Thiết kế giao diện**
- Thiết kế màn hình theo chức năng và luồng nghiệp vụ.
- Xác định trường nhập, dữ liệu hiển thị, thao tác, trạng thái và thông báo.
- Giữ giao diện nhất quán và tránh để Form trực tiếp đảm nhiệm toàn bộ truy vấn SQL.

**Kết nối WinForms với SQL Server**
- Cấu hình connection string trong App.config.
- Tập trung kết nối và truy vấn ở tầng Data.
- Gọi Service từ Form để xử lý nghiệp vụ.
- Kiểm tra dữ liệu đầu vào và phản hồi lỗi rõ ràng.
- Dùng transaction cho nghiệp vụ cập nhật nhiều bảng cần bảo đảm thành công hoặc rollback đồng bộ.

**Kiểm thử**
- Kiểm tra luồng chính với dữ liệu hợp lệ.
- Kiểm tra luồng thay thế, ngoại lệ và điều kiện phát sinh.
- Kiểm tra dữ liệu thiếu, sai định dạng, trùng lặp hoặc ngoài giới hạn.
- Kiểm tra vi phạm khóa và ràng buộc CSDL.
- Kiểm tra trạng thái, thứ tự thao tác, xung đột dữ liệu và transaction/rollback.

Một test case nên có tiền điều kiện, dữ liệu đầu vào, bước thực hiện, kết quả mong đợi và kết quả thực tế. Khi phù hợp, truy vết theo chuỗi:

**Yêu cầu nghiệp vụ → Use Case → Activity / Sequence → Class → CSDL → Form / Service → Test Case**

---

## Kiến thức và kinh nghiệm rút ra

1. **Hiểu đúng bài toán trước khi thiết kế:** xác định phạm vi, Actor, dữ liệu, quy trình và quy tắc nghiệp vụ trước khi lập trình.
2. **Sử dụng đúng loại biểu đồ:** Use Case mô tả chức năng; Activity mô tả luồng công việc; Sequence mô tả tương tác; Class mô tả cấu trúc và trách nhiệm đối tượng; ERD mô tả dữ liệu.
3. **Thiết kế lớp có trách nhiệm:** quan hệ và bội số phải phản ánh nghiệp vụ; không lựa chọn kế thừa, kết hợp hay hợp thành chỉ vì hình thức sơ đồ.
4. **Bảo đảm toàn vẹn dữ liệu:** PK, FK, UNIQUE, CHECK, DEFAULT, trigger và transaction giúp ngăn dữ liệu sai và giữ tính nhất quán.
5. **Tách giao diện, nghiệp vụ và truy cập dữ liệu:** Forms – Services – Data giúp mã nguồn rõ ràng, dễ kiểm thử và bảo trì.
6. **Kết nối mô hình với sản phẩm:** thiết kế cần đủ cụ thể để triển khai thành lớp, Form, câu lệnh SQL và test case.
7. **Kiểm thử theo quy tắc nghiệp vụ:** không chỉ kiểm tra giao diện mở được hay dữ liệu hiển thị; cần kiểm tra trường hợp hợp lệ, biên, không hợp lệ và ngoại lệ.
8. **Quản lý tài liệu và mã nguồn:** tổ chức thư mục, script, ảnh minh chứng, README và lịch sử Git giúp theo dõi, bàn giao và tái hiện kết quả.

## Công nghệ và công cụ

| Nhóm | Công nghệ / công cụ |
|---|---|
| Ngôn ngữ | C#, Java |
| Nền tảng ứng dụng | Windows Forms, .NET Framework 4.7.2, Java 21 |
| Cơ sở dữ liệu | Microsoft SQL Server, SQL Server LocalDB / Express |
| Truy cập dữ liệu | ADO.NET, System.Data.SqlClient |
| Java build | Apache Maven |
| Phân tích và thiết kế | UML, Use Case, Activity, Sequence, Class, ERD |
| Công cụ mô hình hóa | PlantUML, StarUML, draw.io, dbdiagram.io (DBML) |
| IDE và quản trị CSDL | Visual Studio, IntelliJ IDEA, SQL Server Management Studio |
| Quản lý mã nguồn | Git, GitHub |

---

<p align="center">
  <strong>LÊ HOÀNG PHÚC</strong><br/>
  <sub>12_ĐH_CNPM2 · MSSV: 1250080145</sub><br/>
  <sub>Phương pháp phát triển phần mềm hướng đối tượng</sub>
</p>
