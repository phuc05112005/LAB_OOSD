# LAB 00 – Thiết lập môi trường và kiểm tra công cụ

## 1. Thông tin

* **Họ và tên:** Lê Hoàng Phúc
* **Mã sinh viên:** 1250080145
* **Môn học:** Phương pháp phát triển phần mềm hướng đối tượng
* **Lab:** LAB 00
* **Project:** `library-ooad-labs`

---

## 2. Môi trường thực hiện

| Thành phần   | Môi trường sử dụng   |
| ------------ | -------------------- |
| Hệ điều hành | Windows              |
| Kiến trúc    | x64                  |
| JDK          | JDK 21               |
| Maven        | Apache Maven         |
| Git          | Git                  |
| IDE          | IntelliJ IDEA 2026.2.0.1 |
| Plugin       | PlantUML Integration |
| Build tool   | Maven                |
| Project      | `library-ooad-labs`  |

> JDK 21 được sử dụng theo môi trường Java được giảng viên cung cấp cho môn học.

---

## 3. Kiểm tra môi trường

### 3.1. Kiểm tra Java

Lệnh:

```powershell
java -version
javac -version
```

Đầu ra xác nhận Java và Javac cùng sử dụng JDK 21.

### 3.2. Kiểm tra Maven

Lệnh:

```powershell
mvn -version
```

Đầu ra hiển thị phiên bản Maven và Java Home mà Maven đang sử dụng.

### 3.3. Kiểm tra Git

Lệnh:

```powershell
git --version
```

Đầu ra hiển thị phiên bản Git đã cài đặt.

### 3.4. Kiểm tra Git configuration

Lệnh:

```powershell
git config --global --list
```

Đầu ra hiển thị thông tin `user.name` và `user.email` đã cấu hình.

---

# 4. Cấu hình project

Project được mở bằng IntelliJ IDEA dưới dạng Maven project.

Cấu trúc chính:

```text
OOAD-Lab/
├── pom.xml
├── src/
│   └── main/
│       └── java/
│           └── com/
│               └── example/
│                   └── Main.java
├── target/
├── environment.txt
└── README.md
```

File `pom.xml` sử dụng:

```xml
<groupId>org.example</groupId>
<artifactId>library-ooad-labs</artifactId>
<version>1.0.0</version>
```

Project sử dụng Java 21:

```xml
<maven.compiler.source>21</maven.compiler.source>
<maven.compiler.target>21</maven.compiler.target>
```

---

# 5. PlantUML Integration

Plugin **PlantUML Integration** được cài đặt trong IntelliJ IDEA.

Để kiểm tra plugin, tạo file:

```text
test.puml
```

với nội dung:

```plantuml
@startuml

actor "Sinh viên" as SV

rectangle "Hệ thống quản lý thư viện" {
    usecase "Đăng nhập" as UC1
    usecase "Mượn sách" as UC2
    usecase "Trả sách" as UC3
}

SV --> UC1
SV --> UC2
SV --> UC3

@enduml
```

Kết quả mong đợi là IntelliJ IDEA hiển thị sơ đồ Use Case từ mã PlantUML.

---

# 6. Chạy chương trình bằng IntelliJ IDEA

Mở:

```text
src/main/java/com/example/Main.java
```

và chạy bằng nút **Run**.

Nội dung chương trình:

```java
public static void main(String[] args) {
    System.out.println("Library OOAD starter project is ready.");
}
```

### Đầu ra

```text
Library OOAD starter project is ready.
```

---

# 7. Build và test bằng Maven

## 7.1. Chạy test

Lệnh:

```powershell
mvn clean test
```

### Đầu ra mong đợi

```text
BUILD SUCCESS
```

Lệnh này thực hiện xóa kết quả build cũ, biên dịch source code và chạy các test.

---

## 7.2. Đóng gói project

Lệnh:

```powershell
mvn package
```

### Đầu ra

Maven tạo file JAR trong thư mục:

```text
target/
```

File JAR:

```text
library-ooad-labs-1.0.0.jar
```

---

# 8. Chạy chương trình từ file JAR

Lệnh:

```powershell
java -jar target/library-ooad-labs-1.0.0.jar
```

### Đầu ra

```text
Library OOAD starter project is ready.
```

Điều này xác nhận project đã được biên dịch, đóng gói và có thể chạy độc lập từ file JAR.

---

# 9. Các lỗi gặp phải và cách khắc phục

## Lỗi 1 – Maven không tìm thấy pom.xml

### Lỗi

Khi chạy Maven tại:

```text
D:\Exercises\Spring
```

xuất hiện:

```text
The goal you specified requires a project to execute
but there is no POM in this directory
```

### Nguyên nhân

Terminal đang đứng ở thư mục không chứa `pom.xml`.

### Khắc phục

Di chuyển đến đúng thư mục Maven project:

```powershell
cd "D:\Class\OOP_PTPM\Lab00_1250080145_LeHoangPhuc\OOAD-Lab"
```

Sau đó chạy lại:

```powershell
mvn clean test
```

---

## Lỗi 2 – Không tìm thấy file JAR

### Lỗi

```text
Error: Unable to access jarfile target/library-ooad-labs-1.0.0.jar
```

### Nguyên nhân

Project chưa được `mvn package` thành công hoặc file JAR chưa được tạo.

### Khắc phục

Chạy:

```powershell
mvn clean package
```

Sau đó kiểm tra:

```powershell
dir target
```

---

## Lỗi 3 – Sai tên file JAR

### Lỗi

JAR ban đầu được tạo với tên:

```text
OOAD-Lab-1.0-SNAPSHOT.jar
```

trong khi yêu cầu của LAB là:

```text
library-ooad-labs-1.0.0.jar
```

### Nguyên nhân

`artifactId` và `version` trong `pom.xml` chưa đúng.

### Khắc phục

Cấu hình:

```xml
<artifactId>library-ooad-labs</artifactId>
<version>1.0.0</version>
```

Sau đó chạy:

```powershell
mvn clean package
```

---

## Lỗi 4 – `no main manifest attribute`

### Lỗi

```text
no main manifest attribute, in target/library-ooad-labs-1.0.0.jar
```

### Nguyên nhân

File JAR chưa khai báo class chứa phương thức `main` trong manifest.

### Khắc phục

Thêm `maven-jar-plugin` vào `pom.xml`:

```xml
<build>
    <plugins>
        <plugin>
            <groupId>org.apache.maven.plugins</groupId>
            <artifactId>maven-jar-plugin</artifactId>
            <version>3.4.2</version>
            <configuration>
                <archive>
                    <manifest>
                        <mainClass>com.example.Main</mainClass>
                    </manifest>
                </archive>
            </configuration>
        </plugin>
    </plugins>
</build>
```

Sau đó build lại:

```powershell
mvn clean package
```

và chạy:

```powershell
java -jar target/library-ooad-labs-1.0.0.jar
```

---

## Lỗi 5 – `invalid target release: 25`

### Lỗi

```text
error: invalid target release: 25
```

### Nguyên nhân

`pom.xml` được cấu hình target Java 25 trong khi môi trường thực tế sử dụng JDK 21.

### Khắc phục

Do môi trường môn học sử dụng JDK 21, cấu hình lại:

```xml
<maven.compiler.source>21</maven.compiler.source>
<maven.compiler.target>21</maven.compiler.target>
```

Sau đó chạy lại:

```powershell
mvn clean package
```

---

# 10. Git repository

Khởi tạo repository:

```powershell
git init
```

Thêm file:

```powershell
git add .
```

Commit lần đầu:

```powershell
git commit -m "chore: initialize OOAD lab project"
```

Kiểm tra:

```powershell
git log --oneline
```

### Đầu ra

Lịch sử Git hiển thị commit đầu tiên:

```text
chore: initialize OOAD lab project
```

---

# 11. File environment.txt

File `environment.txt` lưu kết quả kiểm tra môi trường:

```text
java -version
javac -version
mvn -version
git --version
```

Mục đích là lưu lại thông tin phiên bản công cụ đã sử dụng trong LAB.

---

# 12. Minh chứng

Các minh chứng được lưu trong thư mục `evidence/`.

```text
evidence/
├── step-01/
├── step-02/
├── step-03/
├── step-04/
├── step-05/
├── step-06/
├── step-07/
├── step-08/
├── step-09/
├── step-10/
├── step-11/
└── step-12/
```

Mỗi bước gồm ảnh chụp màn hình hoặc log thể hiện:

* Kết quả thực hiện.
* Cách kiểm tra.
* Đầu ra thành công hoặc lỗi.
* Minh chứng tương ứng.

---

# 13. Kết luận

LAB 00 đã hoàn thành các nội dung chính:

* Kiểm tra môi trường Windows x64.
* Kiểm tra JDK 21.
* Cấu hình Maven.
* Cài đặt và cấu hình Git.
* Cài đặt IntelliJ IDEA.
* Cài đặt PlantUML Integration.
* Mở Maven project.
* Chạy chương trình bằng IntelliJ IDEA.
* Chạy `mvn clean test`.
* Chạy `mvn package`.
* Tạo file JAR.
* Chạy chương trình từ file JAR.
* Khởi tạo Git repository và commit đầu tiên.

Kết quả cuối cùng:

```text
Library OOAD starter project is ready.
```

cho thấy project đã được build và chạy thành công.
