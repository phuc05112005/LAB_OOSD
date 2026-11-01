# PHƯƠNG PHÁP PHÁT TRIỂN PHẦN MỀM HƯỚNG ĐỐI TƯỢNG

<p align="center">
  <strong>OBJECT-ORIENTED SOFTWARE DEVELOPMENT</strong><br/>
  Hệ thống bài thực hành và sản phẩm học tập
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Course-OOSD-1f6feb?style=flat-square" />
  <img src="https://img.shields.io/badge/Language-C%23%20%7C%20Java-239120?style=flat-square" />
  <img src="https://img.shields.io/badge/Database-SQL%20Server-cc2927?style=flat-square" />
  <img src="https://img.shields.io/badge/Modeling-UML%20%7C%20PlantUML-6f42c1?style=flat-square" />
</p>

Repository tổng hợp các bài thực hành của học phần **Phương pháp phát triển phần mềm hướng đối tượng**. Nội dung được tổ chức theo từng LAB, từ chuẩn bị môi trường, xây dựng ứng dụng quản lý có kết nối cơ sở dữ liệu đến phân tích và thiết kế hệ thống bằng UML, thiết kế dữ liệu và hiện thực các chức năng tiêu biểu.

## Thông tin học phần

| Nội dung | Thông tin |
|---|---|
| **Sinh viên** | Lê Hoàng Phúc |
| **MSSV** | 1250080145 |
| **Lớp** | 12_ĐH_CNPM2 |
| **Giảng viên hướng dẫn** | ThS. Phạm Trọng Huynh |
| **Học phần** | Phương pháp phát triển phần mềm hướng đối tượng |
| **Repository** | [phuc05112005/LAB_OOSD](https://github.com/phuc05112005/LAB_OOSD) |

## Mục lục

- [Tổng quan các bài thực hành](#tổng-quan-các-bài-thực-hành)
- [Cấu trúc repository](#cấu-trúc-repository)
- [Quy trình phân tích và phát triển hệ thống](#quy-trình-phân-tích-và-phát-triển-hệ-thống)
- [Kiến thức và kinh nghiệm tích lũy](#kiến-thức-và-kinh-nghiệm-tích-lũy)
- [Công nghệ và công cụ](#công-nghệ-và-công-cụ)

---

## Tổng quan các bài thực hành

Các LAB sử dụng những bài toán quản lý khác nhau để vận dụng tư duy hướng đối tượng. Mỗi bài có phạm vi và mức độ triển khai riêng; phần mô tả dưới đây phản ánh nội dung hiện có trong repository.

| Thư mục | Bài toán / nội dung | Nội dung chính |
|---|---|---|
| [LAB0](LAB0/README.txt) | Thiết lập môi trường phát triển | Kiểm tra Windows, JDK 21, Maven, Git, IntelliJ IDEA; cấu hình project, PlantUML, build, test và đóng gói JAR. |
| [LAB2](LAB2/README.md) | Quản lý thư viện | Ứng dụng C# Windows Forms kết nối SQL Server LocalDB; tổ chức Forms, Services, Data, Models và hiển thị dữ liệu danh mục, sách, độc giả. |
| [LAB3](LAB3/README.md) | Quản lý khách sạn | Thiết kế dữ liệu và giao diện cho các nghiệp vụ phòng, tiện nghi, đặt phòng, lưu trú, dịch vụ, trả phòng, đền bù, hóa đơn và thanh toán. |
| [LAB4](LAB4/README.md) | Cửa hàng trực tuyến e-SHOPPING | Phân tích tác nhân và Use Case; mô hình Activity, Sequence, Class; thiết kế kiến trúc, CSDL và hiện thực minh họa đăng ký khách hàng. |
| [LAB5](LAB5/README.md) | Quản lý Công ty Du lịch Văn Hóa Việt | Phân tích nghiệp vụ tour; mô hình UML; thiết kế CSDL SQL Server với khóa, ràng buộc, trigger; hiện thực WinForms theo hướng UI – Service – Data và kiểm thử kịch bản. |
| LAB6 | Quản lý bệnh án | Ứng dụng WinForms tổ chức các màn hình danh mục, đăng ký, lịch hẹn, phiếu khám, tra cứu và thống kê; có lớp Data và Service. |
| LAB7 | Quản lý nhân sự | Ứng dụng WinForms với các thành phần Forms, Services, Data; thực hành tổ chức chức năng quản lý và thao tác dữ liệu. |
| LAB8 | Quản lý nước giải khát | Ứng dụng WinForms, phân chia giao diện, dịch vụ và truy cập dữ liệu; thực hành xây dựng chương trình quản lý theo nghiệp vụ. |

> LAB1 và README riêng cho LAB6–LAB8 hiện không có trong các đường dẫn được ghi nhận ở repository. Vì vậy, phần giới thiệu các LAB này chỉ nêu theo tên dự án và cấu trúc mã nguồn đang có, không suy diễn thêm phạm vi chức năng.

### Mạch nội dung giữa các bài

- **LAB0** tạo nền tảng công cụ và quy trình làm việc với project, build, kiểm thử và quản lý mã nguồn.
- **LAB2–LAB3** rèn luyện cách xây dựng ứng dụng quản lý có giao diện, dữ liệu và xử lý nghiệp vụ.
- **LAB4** chuyển trọng tâm sang phân tích yêu cầu và mô hình hóa hệ thống bằng UML trước khi cài đặt.
- **LAB5** kết hợp nhiều công đoạn trong cùng một bài: nghiệp vụ, UML, cơ sở dữ liệu, ràng buộc, giao diện, xử lý và kiểm thử.
- **LAB6–LAB8** tiếp tục vận dụng cách tổ chức chương trình WinForms và tách các thành phần theo trách nhiệm.

---

## Cấu trúc repository

| Thư mục | Vai trò và nội dung |
|---|---|
| **LAB0/** | Tài liệu thiết lập môi trường, cấu hình công cụ, lệnh kiểm tra, project Maven và minh chứng trong thư mục evidence/. |
| **LAB2/QuanLyThuVien/** | Mã nguồn quản lý thư viện. Forms chứa màn hình; Services xử lý nghiệp vụ; Data quản lý kết nối/truy vấn; Models khai báo mô hình dữ liệu. |
| **LAB3/QuanLyKhachSan/** | Mã nguồn quản lý khách sạn, chia thành Forms, Services, Data và Models theo nhóm trách nhiệm. |
| **LAB4/** | Bài toán e-SHOPPING; gồm tài liệu phân tích, thiết kế và project QuanLyShopping minh họa đăng ký khách hàng bằng WinForms. |
| **LAB5/PTTK/** | Tài liệu phân tích và thiết kế: UseCase/, Class/, Activity/, Sequence/, CSDL/ (ERD và script SQL), Forms/ (minh chứng giao diện). |
| **LAB5/QuanLyCongTyDuLich/** | Mã nguồn WinForms; Forms là giao diện, Services xử lý nghiệp vụ, Data truy cập CSDL, DTO truyền dữ liệu. |
| **LAB6/QuanLyBenhAn/** | Mã nguồn quản lý bệnh án; gồm các nhóm Forms, Services và Data. |
| **LAB7/QuanLyNhanSu/** | Mã nguồn quản lý nhân sự; gồm các nhóm Forms, Services và Data. |
| **LAB8/QuanLyNuocGiaiKhat/** | Mã nguồn quản lý nước giải khát; gồm các nhóm Forms, Services và Data. |
| **IMAGES/** | Hình ảnh và minh chứng thực hành; hiện có minh chứng theo từng bước của LAB0. |

Một số thư mục con có thể thay đổi theo từng bài. README riêng của mỗi LAB là nơi mô tả chi tiết hơn về cách chạy, cấu trúc mã nguồn, cơ sở dữ liệu và kết quả thực hiện.

---

## Quy trình phân tích và phát triển hệ thống

Các bài thực hành giúp hình thành một quy trình làm việc có thứ tự: **hiểu đúng bài toán → mô hình hóa → thiết kế → hiện thực → kiểm thử**. Không nên bắt đầu bằng việc tạo Form hoặc viết câu lệnh SQL khi yêu cầu và quy tắc nghiệp vụ chưa rõ.

### 1. Tóm tắt bài toán và xác định yêu cầu

Bắt đầu bằng việc diễn đạt ngắn gọn vấn đề cần giải quyết, mục tiêu của hệ thống, phạm vi và đối tượng sử dụng. Từ đó phân tích yêu cầu nghiệp vụ theo ba thành phần:

| Thành phần | Câu hỏi cần làm rõ |
|---|---|
| **Đầu vào (Input)** | Ai cung cấp dữ liệu? Dữ liệu nào cần nhập hoặc tiếp nhận từ hệ thống khác? |
| **Xử lý (Process)** | Hệ thống kiểm tra, tính toán, cập nhật và phối hợp các bước nghiệp vụ như thế nào? |
| **Đầu ra (Output)** | Kết quả nào được trả về, lưu trữ, hiển thị hoặc dùng cho bước tiếp theo? |

Đồng thời xác định:
- **Tác nhân:** người dùng, vai trò hoặc hệ thống bên ngoài tương tác với hệ thống.
- **Quy tắc nghiệp vụ:** điều kiện hợp lệ, giới hạn, ngoại lệ và các trường hợp bị từ chối.
- **Quyết định triển khai:** nội dung thuộc phạm vi hệ thống, nội dung do hệ thống ngoài đảm nhiệm và cách xử lý các tình huống đề bài chưa quy định.

### 2. Giới thiệu hệ thống và đặc tả yêu cầu

- **Giới thiệu hệ thống:** mục tiêu, phạm vi, đối tượng sử dụng, môi trường và giới hạn.
- **Yêu cầu chức năng:** hệ thống phải cung cấp những nghiệp vụ nào.
- **Yêu cầu phi chức năng:** hiệu năng, bảo mật, tính dễ sử dụng, độ tin cậy, khả năng bảo trì và các ràng buộc kỹ thuật.

Yêu cầu cần rõ ràng, có thể kiểm tra và không mâu thuẫn với quy tắc nghiệp vụ.

### 3. Phân tích hệ thống bằng UML

| Mô hình | Mục đích sử dụng |
|---|---|
| **Use Case Diagram** | Xác định ranh giới hệ thống, tác nhân và chức năng ở góc nhìn người sử dụng. |
| **Đặc tả Use Case** | Mô tả tiền điều kiện, hậu điều kiện, luồng chính, luồng thay thế và ngoại lệ. |
| **Phân rã Use Case** | Chia chức năng lớn thành các nhóm chức năng con theo phạm vi nghiệp vụ hoặc phân hệ; không phân rã máy móc theo từng tác nhân. |
| **Activity Diagram** | Mô tả luồng công việc, điều kiện rẽ nhánh, xử lý song song và điểm kết thúc. |
| **Sequence Diagram** | Thể hiện thứ tự trao đổi thông điệp giữa tác nhân, giao diện, đối tượng điều khiển và các đối tượng liên quan. |
| **Class Diagram** | Xác định lớp, thuộc tính, phương thức, quan hệ, bội số và trách nhiệm của từng lớp. |

Các biểu đồ cần thống nhất với đặc tả nghiệp vụ. Một chức năng đã mô tả trong Use Case phải có cách xử lý tương ứng trong mô hình chi tiết và thiết kế.

### 4. Thiết kế lớp và trách nhiệm xử lý

Từ kết quả phân tích, xác định các lớp tham gia vào từng chức năng, dữ liệu mà lớp quản lý và hành vi mà lớp chịu trách nhiệm. Cần làm rõ:

- Lớp nào tiếp nhận yêu cầu?
- Lớp nào điều phối luồng xử lý?
- Lớp nào giữ dữ liệu và bảo đảm quy tắc?
- Lớp nào truy xuất hoặc lưu trữ dữ liệu?
- Các lớp liên hệ với nhau theo quan hệ nào và với bội số bao nhiêu?

Thiết kế tốt giúp tránh dồn toàn bộ nghiệp vụ vào Form hoặc một lớp duy nhất, đồng thời giảm phụ thuộc không cần thiết giữa các thành phần.

### 5. Thiết kế cơ sở dữ liệu

Quá trình thiết kế dữ liệu cần đi từ mô hình nghiệp vụ đến cấu trúc có thể triển khai:

1. Xác định thực thể và mối quan hệ để xây dựng **ERD**.
2. Chuyển ERD thành **lược đồ cơ sở dữ liệu quan hệ**.
3. Xác định khóa chính (PK), khóa ngoại (FK), khóa duy nhất và các thuộc tính bắt buộc.
4. Bổ sung ràng buộc dữ liệu: NOT NULL, UNIQUE, CHECK, DEFAULT, cùng các quy tắc cần xử lý bằng trigger hoặc transaction.
5. Viết **script SQL** tạo cơ sở dữ liệu, bảng, quan hệ, ràng buộc và dữ liệu kiểm thử cần thiết.

Cần phân biệt quy tắc nào nên được bảo vệ ngay tại CSDL và quy tắc nào thuộc luồng nghiệp vụ của ứng dụng. Không nên chỉ kiểm tra ở giao diện vì dữ liệu có thể được ghi từ nhiều nguồn khác nhau.

### 6. Thiết kế kiến trúc và triển khai

Sau khi xác định lớp và dữ liệu, tổ chức hệ thống thành các thành phần có trách nhiệm rõ ràng. Với các ứng dụng WinForms trong repository, cách phân chia thường gặp là:

**Presentation / Forms → Services → Data Access → Database**

- **Presentation / Forms:** tiếp nhận thao tác, hiển thị dữ liệu và thông báo kết quả.
- **Services:** điều phối nghiệp vụ, kiểm tra điều kiện và gọi các thao tác dữ liệu.
- **Data Access:** quản lý kết nối, truy vấn và cập nhật CSDL.
- **Database:** lưu trữ dữ liệu và thực thi các ràng buộc phù hợp.

Với hệ thống có nhiều thành phần, cần thể hiện thêm **biểu đồ kiến trúc phân tầng** và **biểu đồ triển khai (Deployment Diagram)** để làm rõ các thành phần phần mềm được bố trí trên môi trường chạy nào và giao tiếp ra sao.

### 7. Thiết kế giao diện và hiện thực

Thiết kế giao diện theo nghiệp vụ và luồng sử dụng đã phân tích. Mỗi màn hình cần có mục đích cụ thể, dữ liệu đầu vào rõ ràng, cách phản hồi khi thành công hoặc thất bại và quy tắc kiểm tra phù hợp.

Khi cài đặt, bảo đảm luồng xử lý của chương trình bám sát thiết kế: giao diện không tự gánh toàn bộ nghiệp vụ, câu lệnh truy vấn không rải rác trong các Form và dữ liệu nhập cần được kiểm tra ở tầng phù hợp.

### 8. Kiểm thử và đối chiếu

Kiểm thử theo luồng chính, luồng thay thế, dữ liệu biên và các trường hợp vi phạm quy tắc nghiệp vụ. Đối chiếu xuyên suốt:

**Yêu cầu → Use Case → Activity / Sequence → Class / Database → Form / Service → Test Case**

Kết quả kiểm thử cần chỉ ra dữ liệu đầu vào, bước thực hiện, kết quả mong đợi và kết quả thực tế. Khi phát hiện sai lệch, xác định lỗi nằm ở yêu cầu, mô hình, thiết kế, mã nguồn hay dữ liệu trước khi sửa.

---

## Kiến thức và kinh nghiệm tích lũy

Qua các bài thực hành, những nội dung quan trọng nhất không chỉ là sử dụng công cụ hay hoàn thành một giao diện, mà là hiểu mối liên hệ giữa các quyết định trong quá trình phát triển phần mềm:

1. **Phân tích trước khi lập trình:** yêu cầu càng rõ thì việc thiết kế chức năng, dữ liệu và kiểm thử càng ít phải sửa đổi về sau.
2. **Mô hình hóa để thống nhất cách hiểu:** Use Case mô tả hệ thống cung cấp gì; Activity mô tả quy trình diễn ra thế nào; Sequence mô tả các đối tượng phối hợp ra sao; Class mô tả cấu trúc và trách nhiệm.
3. **Thiết kế hướng đối tượng:** lớp cần có trách nhiệm rõ ràng, quan hệ hợp lý và mức phụ thuộc vừa đủ. Không nên biến sơ đồ lớp thành bản liệt kê bảng dữ liệu hoặc gom mọi xử lý vào một đối tượng.
4. **Dữ liệu phải được bảo vệ bằng ràng buộc:** PK, FK, UNIQUE, CHECK, trigger và transaction giúp duy trì tính nhất quán, kể cả khi dữ liệu không đi qua giao diện chính.
5. **Tách biệt các tầng:** Forms, Services và Data giúp mã nguồn dễ đọc, kiểm tra, thay đổi và bảo trì hơn so với cách viết giao diện gắn trực tiếp với truy vấn SQL.
6. **Kiểm thử theo quy tắc nghiệp vụ:** không chỉ kiểm tra trường hợp thành công; cần thử dữ liệu không hợp lệ, trùng lặp, vượt giới hạn, sai trạng thái và các tình huống ngoại lệ.
7. **Quản lý môi trường và mã nguồn:** cấu hình công cụ đúng, lưu minh chứng, tổ chức thư mục và sử dụng Git giúp quá trình làm việc có thể tái hiện và theo dõi.

### Kết luận

Điều quan trọng rút ra từ học phần là phát triển phần mềm hướng đối tượng không bắt đầu từ việc viết mã, mà bắt đầu từ việc hiểu bài toán và xác định đúng trách nhiệm của từng thành phần. Một sản phẩm có chất lượng cần giữ được sự nhất quán từ yêu cầu nghiệp vụ, mô hình UML, thiết kế lớp, cơ sở dữ liệu đến cài đặt và kiểm thử.

Repository này lưu lại quá trình thực hành theo từng bước, đồng thời là tài liệu tham khảo để tiếp tục vận dụng quy trình phân tích, thiết kế và xây dựng phần mềm trong các học phần và dự án tiếp theo.

---

## Công nghệ và công cụ

| Nhóm | Công cụ / công nghệ đã sử dụng trong các LAB |
|---|---|
| Ngôn ngữ | C#, Java |
| Nền tảng giao diện | Windows Forms, .NET Framework |
| Cơ sở dữ liệu | Microsoft SQL Server, SQL Server LocalDB |
| Truy cập dữ liệu | ADO.NET, System.Data.SqlClient |
| Phân tích và mô hình hóa | UML, Use Case, Activity, Sequence, Class, ERD |
| Công cụ sơ đồ | PlantUML, draw.io, StarUML, dbdiagram.io |
| Phát triển | Visual Studio, IntelliJ IDEA, JDK 21, Maven |
| Quản lý mã nguồn | Git, GitHub |

---

<p align="center">
  <sub>Học phần Phương pháp phát triển phần mềm hướng đối tượng · Lê Hoàng Phúc · 1250080145</sub>
</p>
