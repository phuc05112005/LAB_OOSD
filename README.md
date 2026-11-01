# PHƯƠNG PHÁP PHÁT TRIỂN PHẦN MỀM HƯỚNG ĐỐI TƯỢNG

<p align="center">
  <strong>OBJECT-ORIENTED SOFTWARE DEVELOPMENT (OOSD)</strong><br/>
  Tổng hợp bài thực hành · Phân tích · Thiết kế · Lập trình ứng dụng
</p>

<p align="center">
  <img src="https://img.shields.io/badge/COURSE-OOSD-2457A7?style=flat-square" />
  <img src="https://img.shields.io/badge/C%23-Windows%20Forms-512BD4?style=flat-square" />
  <img src="https://img.shields.io/badge/DATABASE-SQL%20Server-CC2927?style=flat-square" />
  <img src="https://img.shields.io/badge/MODELING-UML%20%7C%20PlantUML-6F42C1?style=flat-square" />
</p>

Repository lưu trữ các bài thực hành của học phần **Phương pháp phát triển phần mềm hướng đối tượng**. Mỗi LAB là một bài toán hoặc nội dung thực hành riêng theo buổi học, có yêu cầu, phạm vi và sản phẩm đầu ra độc lập. Tùy từng bài, nội dung thực hiện bao gồm làm quen môi trường phát triển, xây dựng giao diện WinForms, kết nối cơ sở dữ liệu, phân tích nghiệp vụ, mô hình hóa UML, thiết kế dữ liệu, cài đặt và kiểm thử.

## Thông tin học phần

| | |
|---|---|
| **Sinh viên** | Lê Hoàng Phúc |
| **Mã số sinh viên** | 1250080145 |
| **Lớp** | 12_ĐH_CNPM2 |
| **Giảng viên hướng dẫn** | ThS. Phạm Trọng Huynh |
| **Học phần** | Phương pháp phát triển phần mềm hướng đối tượng |
| **Repository** | [phuc05112005/LAB_OOSD](https://github.com/phuc05112005/LAB_OOSD) |

## Danh mục bài thực hành

Các bài dưới đây là những bài thực hành độc lập, không phải các giai đoạn nối tiếp của cùng một hệ thống.

| LAB | Bài toán / chủ đề | Nội dung và kết quả thực hiện |
|---|---|---|
| [LAB 00](LAB0/README.txt) | **Thiết lập môi trường và kiểm tra công cụ** | Cấu hình Windows, JDK 21, Maven, Git, IntelliJ IDEA và PlantUML Integration; tạo Maven project Java, chạy chương trình, kiểm thử, đóng gói và thực thi file JAR. |
| [LAB 02](LAB2/README.md) | **Hệ thống quản lý thư viện** | Xây dựng ứng dụng C# WinForms kết nối SQL Server LocalDB; tổ chức Forms – Services – Data – Models; thiết kế màn hình danh mục, đầu sách, độc giả và thực hiện đọc, hiển thị dữ liệu từ CSDL. Bài làm tập trung vào giao diện và kết nối dữ liệu ở phạm vi hiện tại. |
| [LAB 03](LAB3/README.md) | **Hệ thống quản lý khách sạn** | Thiết kế CSDL SQL Server và giao diện WinForms cho quản lý phòng, tiện nghi, đặt/nhận phòng, người lưu trú, dịch vụ, đền bù, hóa đơn, thanh toán và trả phòng; xây dựng lớp kết nối, tầng Service và kiểm tra kết nối ứng dụng với CSDL. |
| [LAB 04](LAB4/README.md) | **Hệ thống cửa hàng trực tuyến e-SHOPPING** | Phân tích tác nhân, 15 Use Case, đặc tả và phân rã chức năng; xây dựng Activity, Sequence, Class, kiến trúc phân tầng và thiết kế CSDL. Phần cài đặt minh họa bằng WinForms kết nối SQL Server với chức năng đăng ký khách hàng, đọc và ghi dữ liệu. |
| [LAB 05](LAB5/README.md) | **Quản lý Công ty Du lịch Văn Hóa Việt** | Phân tích nghiệp vụ tour, 11 Use Case và 18 lớp; thiết kế Activity, Sequence, Class, ERD và CSDL 18 bảng; hiện thực WinForms theo UI – Service – Data cho nghiệp vụ đăng ký tour theo đoàn; áp dụng khóa, CHECK, trigger và kiểm thử kịch bản. |
| [LAB 06](LAB6/README.md) | **Quản lý hồ sơ bệnh án của bệnh nhân** | Phân tích quy trình đăng ký khám, cấp/gia hạn hồ sơ, lịch khám định kỳ, phiếu khám, tra cứu và thống kê; xây dựng UML, CSDL SQL Server và ứng dụng WinForms theo UI – Service – Data; xác định quy tắc nghiệp vụ ở Service và CSDL. |
| [LAB 07](LAB7/README.md) | **Quản lý nhân sự Công ty Sơn Đông Á** | Phân tích tuyển dụng, thử việc, hợp đồng, bảo hiểm, quyết định, phân công, chấm công, phụ trội, tính lương, khen thưởng và kỷ luật; thiết kế UML, CSDL 22 bảng theo mô hình table-per-type; hiện thực WinForms và kiểm thử các ràng buộc nghiệp vụ. |
| [LAB 08](LAB8/README.md) | **Quản lý cửa hàng nước giải khát** | Phân tích nhập hàng, bán hàng, giao hàng nhiều đợt và ghi nợ; xây dựng UML, ERD/DBML và CSDL 14 bảng; hiện thực WinForms theo UI – Service – Data, xử lý tồn kho bằng transaction và kiểm thử quy tắc bán hàng, nhập hàng, công nợ. |

## Cấu trúc repository

```text
LAB_OOSD/
├── LAB0/                         # Thiết lập môi trường Java, Maven, Git, PlantUML
│   ├── evidence/                 # Minh chứng theo từng bước thực hiện
│   └── README.txt
├── LAB2/                         # Ứng dụng quản lý thư viện
│   ├── QuanLyThuVien/
│   │   ├── Forms/                # Màn hình WinForms
│   │   ├── Services/             # Xử lý và điều phối chức năng
│   │   ├── Data/                 # Kết nối, truy vấn dữ liệu
│   │   └── Models.cs             # Các lớp mô hình
│   └── README.md
├── LAB3/                         # Ứng dụng quản lý khách sạn
│   ├── QuanLyKhachSan/
│   │   ├── Forms/
│   │   ├── Services/
│   │   ├── Data/
│   │   └── Models/
│   └── README.md
├── LAB4/                         # Phân tích, thiết kế và minh họa e-SHOPPING
│   ├── QuanLyShopping/           # WinForms đăng ký khách hàng
│   │   ├── Forms/
│   │   ├── Services/
│   │   └── Data/
│   └── README.md
├── LAB5/                         # Quản lý Công ty Du lịch Văn Hóa Việt
│   ├── PTTK/                     # Use Case, Class, Activity, Sequence, CSDL, Forms
│   ├── QuanLyCongTyDuLich/       # Mã nguồn WinForms
│   │   ├── Forms/
│   │   ├── Services/
│   │   ├── Data/
│   │   └── DTO/
│   ├── LAB6_QuanLyCongTyDuLich.docx
│   └── README.md
├── LAB6/                         # Quản lý hồ sơ bệnh án
│   ├── PTTK/                     # UML, ERD, script SQL, ảnh giao diện
│   ├── QuanLyHoSoBenhAn/         # Mã nguồn WinForms
│   │   ├── Forms/
│   │   ├── Services/
│   │   ├── Data/
│   │   └── DTO/
│   ├── LAB6_QuanLyHoSoBenhAn.docx
│   └── README.md
├── LAB7/                         # Quản lý nhân sự Công ty Sơn Đông Á
│   ├── PTTK/                     # UML, ERD, script SQL, ảnh giao diện
│   ├── QuanLyNhanSu/             # Mã nguồn WinForms
│   │   ├── Forms/
│   │   ├── Services/
│   │   ├── Data/
│   │   └── DTO/
│   ├── LAB7_QuanLyNhanSu.docx
│   └── README.md
├── LAB8/                         # Quản lý cửa hàng nước giải khát
│   ├── PTTK/                     # UML, ERD/DBML, script SQL, ảnh giao diện
│   ├── QuanLyCuaHangNuocGiaiKhat/ # Mã nguồn WinForms
│   │   ├── Forms/
│   │   ├── Services/
│   │   ├── Data/
│   │   └── DTO/
│   ├── LAB8_QuanLyCuaHangNuocGiaiKhat.docx
│   └── README.md
└── IMAGES/                       # Hình ảnh minh chứng thực hành
```

Trong các LAB có phần phân tích – thiết kế, thư mục **PTTK** tập hợp tài liệu UML, ERD, script SQL và ảnh giao diện. Thư mục project chứa mã nguồn ứng dụng; các nhóm **Forms**, **Services**, **Data** và **DTO/Models** được sử dụng tùy theo cách tổ chức của từng bài. README riêng của mỗi LAB trình bày chi tiết cấu trúc và cách chạy.

---

## Quy trình phân tích, thiết kế và hiện thực phần mềm

Đây là quy trình phương pháp luận tổng quát được vận dụng trong các bài phân tích – thiết kế và xây dựng ứng dụng. **Không phải LAB nào cũng yêu cầu hoặc triển khai đầy đủ tất cả các bước**; phạm vi tài liệu và mã nguồn phụ thuộc đề bài của từng buổi.

### 1. Tóm tắt bài toán và xác định yêu cầu nghiệp vụ

Trước tiên cần diễn đạt vấn đề cần giải quyết, mục tiêu, phạm vi và kết quả mà hệ thống cần hỗ trợ. Từ đề bài, phân tích nghiệp vụ theo các khía cạnh:

| Thành phần | Nội dung cần xác định |
|---|---|
| **Đầu vào (Input)** | Dữ liệu do người dùng nhập, dữ liệu lấy từ CSDL hoặc hệ thống bên ngoài; nguồn cung cấp và điều kiện hợp lệ. |
| **Xử lý (Process)** | Các bước nghiệp vụ, phép kiểm tra, tính toán, thay đổi trạng thái và quy trình phối hợp. |
| **Đầu ra (Output)** | Kết quả trả về, chứng từ, thông báo, báo cáo hoặc dữ liệu được cập nhật. |
| **Tác nhân (Actor)** | Vai trò hoặc hệ thống bên ngoài trực tiếp tương tác với hệ thống. |
| **Quy tắc nghiệp vụ** | Điều kiện, giới hạn, công thức, trạng thái, ngoại lệ và các trường hợp không được phép. |
| **Quyết định triển khai** | Cách cụ thể hóa những điểm đề bài chưa quy định: dữ liệu bổ sung, cách sinh mã, phân quyền, trạng thái, xử lý ngoại lệ và phạm vi tích hợp. |

Các quyết định triển khai cần có lý do, nhất quán với nghiệp vụ và được ghi nhận để tránh tự ý thay đổi quy tắc trong quá trình lập trình.

### 2. Giới thiệu hệ thống và đặc tả yêu cầu

- **Giới thiệu hệ thống:** mục tiêu, phạm vi, đối tượng sử dụng, môi trường vận hành và giới hạn.
- **Yêu cầu chức năng:** những nghiệp vụ hệ thống phải cung cấp, diễn đạt theo hành động và kết quả có thể kiểm tra.
- **Yêu cầu phi chức năng:** bảo mật, hiệu năng, độ tin cậy, khả năng sử dụng, bảo trì, tương thích và các ràng buộc kỹ thuật.

Yêu cầu cần rõ nghĩa, không mâu thuẫn và đủ cụ thể để làm căn cứ cho mô hình, thiết kế và kiểm thử.

### 3. Phân tích chức năng bằng Use Case

Use Case xác định hệ thống cung cấp chức năng gì và tương tác với những tác nhân nào.

- Xác định ranh giới hệ thống và các Actor thực sự tương tác trực tiếp.
- Xây dựng biểu đồ Use Case tổng quát theo nghiệp vụ.
- Đặc tả từng Use Case: mục tiêu, tác nhân, tiền điều kiện, hậu điều kiện, luồng chính, luồng thay thế và ngoại lệ.
- Phân rã các Use Case phức tạp theo **phân hệ hoặc nhóm chức năng nghiệp vụ**. Việc phân rã nhằm làm rõ phạm vi chức năng, không chia sơ đồ máy móc theo từng Actor.
- Sử dụng quan hệ `include` và `extend` đúng ý nghĩa: hành vi bắt buộc được tái sử dụng và hành vi mở rộng chỉ phát sinh khi có điều kiện.

### 4. Mô hình hóa luồng nghiệp vụ và tương tác

| Biểu đồ | Vai trò |
|---|---|
| **Activity Diagram** | Mô tả quy trình nghiệp vụ từ điểm bắt đầu đến kết thúc; thể hiện hành động, điều kiện, nhánh rẽ và luồng song song khi có. |
| **Sequence Diagram** | Mô tả trình tự thông điệp giữa Actor và các đối tượng tham gia xử lý một kịch bản; làm rõ đối tượng gọi, phương thức và thứ tự thực thi. |

Activity tập trung vào luồng công việc; Sequence tập trung vào sự phối hợp và thứ tự tương tác giữa các đối tượng. Hai biểu đồ bổ sung cho nhau, không thay thế nhau.

### 5. Phân tích và thiết kế lớp

Class Diagram mô tả cấu trúc tĩnh của hệ thống và trách nhiệm của từng lớp:

- Xác định lớp nghiệp vụ, thuộc tính và phương thức.
- Xác định quan hệ kết hợp, kết tập, hợp thành, kế thừa và phụ thuộc khi phù hợp.
- Ghi rõ bội số, vai trò quan hệ và các ràng buộc quan trọng.
- Phân biệt lớp phân tích với lớp thiết kế/cài đặt; bổ sung kiểu dữ liệu, chữ ký phương thức và trách nhiệm xử lý ở mức chi tiết phù hợp.
- Thiết kế chức năng bằng cách xác định lớp nào tiếp nhận yêu cầu, lớp nào điều phối nghiệp vụ, lớp nào quản lý dữ liệu và lớp nào thực hiện truy cập CSDL.

Mỗi lớp cần có trách nhiệm rõ ràng. Không nên đưa toàn bộ nghiệp vụ vào Form hoặc tạo lớp chỉ để sao chép nguyên trạng cấu trúc bảng dữ liệu.

### 6. Thiết kế cơ sở dữ liệu

Quá trình thiết kế dữ liệu chuyển các khái niệm và quan hệ nghiệp vụ thành cấu trúc lưu trữ:

1. **ERD (Entity Relationship Diagram):** xác định thực thể, thuộc tính, quan hệ và lực lượng kết hợp.
2. **Lược đồ cơ sở dữ liệu quan hệ:** chuyển thực thể thành bảng, xác định cột, khóa chính và khóa ngoại; xử lý quan hệ nhiều – nhiều bằng bảng kết hợp khi cần.
3. **Ràng buộc dữ liệu:** xác định PRIMARY KEY, FOREIGN KEY, UNIQUE, NOT NULL, CHECK, DEFAULT, khóa ghép và các quy tắc toàn vẹn.
4. **Hiện thực quy tắc nghiệp vụ:** đặt ràng buộc tại CSDL khi có thể; dùng Service hoặc transaction cho quy tắc cần phối hợp nhiều dữ liệu, nhiều bước hoặc kiểm tra theo ngữ cảnh.
5. **Script SQL:** tạo CSDL, bảng, khóa, chỉ mục, constraint, trigger và dữ liệu mẫu phục vụ chạy thử.

ERD thể hiện cấu trúc và quan hệ ở mức khái niệm; lược đồ quan hệ và script SQL thể hiện cách tổ chức, triển khai dữ liệu cụ thể. Ba thành phần cần thống nhất với mô hình lớp và quy tắc nghiệp vụ.

### 7. Thiết kế kiến trúc và triển khai

Với các ứng dụng WinForms trong repository, mô hình tổ chức thường được áp dụng là:

```text
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
```

- **UI / Forms:** tiếp nhận thao tác, hiển thị dữ liệu và phản hồi cho người dùng.
- **Service:** kiểm tra và điều phối nghiệp vụ, quản lý luồng xử lý và transaction khi cần.
- **Data:** quản lý kết nối, câu lệnh truy vấn và thao tác dữ liệu bằng ADO.NET.
- **Database:** lưu trữ dữ liệu, bảo đảm khóa và các ràng buộc toàn vẹn.

Ở mức thiết kế hệ thống, **biểu đồ kiến trúc phân tầng** mô tả cách chia phần mềm thành các tầng/thành phần và quan hệ phụ thuộc; **Deployment Diagram** mô tả môi trường thực thi, nút triển khai và kết nối giữa chúng. Hai biểu đồ trả lời hai câu hỏi khác nhau: phần mềm được tổ chức ra sao và được triển khai ở đâu.

### 8. Thiết kế giao diện và kết nối CSDL

Thiết kế Form dựa trên chức năng và luồng nghiệp vụ đã xác định. Mỗi màn hình cần có mục đích rõ ràng, trường nhập phù hợp, cách hiển thị dữ liệu, thao tác và thông báo kết quả.

Khi hiện thực WinForms kết nối SQL Server:
- Cấu hình chuỗi kết nối trong App.config.
- Tập trung thao tác kết nối và truy vấn ở tầng Data.
- Gọi Service từ Form thay vì viết SQL trực tiếp trong sự kiện giao diện.
- Kiểm tra dữ liệu đầu vào và phản hồi lỗi dễ hiểu.
- Sử dụng transaction cho nghiệp vụ cập nhật nhiều bảng cần bảo đảm thành công hoặc rollback đồng bộ.

### 9. Kiểm thử và đối chiếu kết quả

Kiểm thử dựa trên yêu cầu và quy tắc nghiệp vụ, không chỉ kiểm tra Form có mở được hay dữ liệu có hiển thị hay không.

Các nhóm tình huống cần xem xét:
- Luồng chính với dữ liệu hợp lệ.
- Luồng thay thế và điều kiện phát sinh.
- Dữ liệu thiếu, sai định dạng, trùng lặp hoặc ngoài giới hạn.
- Vi phạm khóa và ràng buộc CSDL.
- Sai trạng thái, sai thứ tự thao tác hoặc xung đột dữ liệu.
- Nghiệp vụ nhiều bước cần transaction và rollback.

Mỗi test case cần có điều kiện/dữ liệu đầu vào, các bước thực hiện, kết quả mong đợi và kết quả thực tế. Khi phù hợp, có thể truy vết theo chuỗi:

**Yêu cầu nghiệp vụ → Use Case → Activity / Sequence → Class → CSDL → Form / Service → Test Case**

---

## Kiến thức và kinh nghiệm rút ra

Qua các bài thực hành với nhiều bài toán quản lý khác nhau, những kiến thức có thể tổng kết gồm:

1. **Hiểu bài toán trước khi chọn cách làm:** cần xác định đúng phạm vi, Actor, dữ liệu, quy trình và quy tắc nghiệp vụ trước khi thiết kế hoặc lập trình.
2. **Phân biệt các mô hình UML:** Use Case mô tả chức năng từ góc nhìn bên ngoài; Activity mô tả luồng công việc; Sequence mô tả tương tác theo thời gian; Class mô tả cấu trúc và trách nhiệm của đối tượng.
3. **Thiết kế lớp có trách nhiệm:** quan hệ và bội số phải phản ánh đúng nghiệp vụ; kế thừa, kết hợp và hợp thành cần được lựa chọn theo ý nghĩa thực tế, không chỉ theo hình thức sơ đồ.
4. **Thiết kế dữ liệu có tính toàn vẹn:** PK, FK, UNIQUE, CHECK, DEFAULT, trigger và transaction giúp ngăn dữ liệu sai và bảo đảm các thao tác nhiều bước được thực hiện nhất quán.
5. **Tách giao diện khỏi xử lý và truy cập dữ liệu:** mô hình Forms – Services – Data làm rõ trách nhiệm, hạn chế phụ thuộc và giúp sửa lỗi thuận tiện hơn.
6. **Kết nối mô hình với sản phẩm:** sơ đồ không chỉ để minh họa; thiết kế cần đủ cụ thể để triển khai thành lớp, Form, câu lệnh SQL và kịch bản kiểm thử.
7. **Kiểm thử từ quy tắc nghiệp vụ:** cần kiểm tra cả trường hợp hợp lệ, không hợp lệ, biên và ngoại lệ; đồng thời xác định rõ quy tắc được bảo vệ ở Service hay CSDL.
8. **Làm việc có tổ chức:** quản lý cấu hình, cấu trúc thư mục, script, tài liệu, minh chứng và lịch sử Git giúp việc phát triển dễ theo dõi và tái hiện.

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
