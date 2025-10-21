\<h1 align="center"\>Hệ thống Quản lý Quán ăn (QuanLyQuanAn) 🍽️\</h1\>

\<p align="center"\>
Một dự án phần mềm Quản lý Nhà hàng/Quán ăn chuyên nghiệp được xây dựng bằng C\# .NET (Windows Forms) và SQL Server, mô phỏng đầy đủ các nghiệp vụ thực tế.
\</p\>

\<p align="center"\>
\<img src="[https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge](https://www.google.com/search?q=https://img.shields.io/badge/.NET-8.0-blueviolet%3Fstyle%3Dfor-the-badge)" /\>
\<img src="[https://img.shields.io/badge/C%23-blue?style=for-the-badge\&logo=csharp\&logoColor=white](https://www.google.com/search?q=https://img.shields.io/badge/C%2523-blue%3Fstyle%3Dfor-the-badge%26logo%3Dcsharp%26logoColor%3Dwhite)" /\>
\<img src="[https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge\&logo=microsoftsqlserver\&logoColor=white](https://www.google.com/search?q=https://img.shields.io/badge/SQL%2520Server-CC2927%3Fstyle%3Dfor-the-badge%26logo%3Dmicrosoftsqlserver%26logoColor%3Dwhite)" /\>
\<img src="[https://img.shields.io/badge/Windows%20Forms-0F73C1?style=for-the-badge\&logo=windows\&logoColor=white](https://www.google.com/search?q=https://img.shields.io/badge/Windows%2520Forms-0F73C1%3Fstyle%3Dfor-the-badge%26logo%3Dwindows%26logoColor%3Dwhite)" /\>
\</p\>

-----

## 🚀 Tổng quan Dự án

`QuanLyQuanAn` là một ứng dụng Desktop (Windows Forms) được thiết kế để giải quyết bài toán quản lý toàn diện cho một nhà hàng hoặc quán ăn. Hệ thống bao gồm các chức năng từ order tại bàn, quản lý kho nguyên vật liệu, quản lý nhân sự đến thống kê doanh thu.

Hệ thống được xây dựng kiên cố theo **mô hình 3 lớp (3-Layer Architecture)**:

  * 📂 **GUI (Giao diện):** Lớp giao diện người dùng, sử dụng Windows Forms và các thư viện UI (Guna/SunnyUI) để mang lại trải nghiệm trực quan.
  * 📂 **BLL (Business Logic Layer):** Lớp xử lý các logic nghiệp vụ, tính toán và xác thực dữ liệu.
  * 📂 **DAL (Data Access Layer):** Lớp truy xuất cơ sở dữ liệu (SQL Server), thực thi các truy vấn.
  * 📂 **DTO (Data Transfer Object):** Các đối tượng dùng để vận chuyển dữ liệu giữa các lớp.

## ✨ Tính năng Nổi bật

Hệ thống được phân quyền chi tiết cho 3 vai trò chính: **Quản lý**, **Thu ngân**, và **Bếp**.

| STT | Tính năng | 👑 Quản lý | 💵 Thu ngân | 🍳 Bếp |
| :--- | :--- | :---: | :---: | :---: |
| 1 | 🔐 **Đăng nhập & Phân quyền** | ✅ | ✅ | ✅ |
| 2 | 📊 **Thống kê Doanh thu** (Theo ngày/tháng, món bán chạy...) | ✅ | | |
| 3 | 🧑‍💼 **Quản lý Nhân viên** (Thêm/sửa/xóa, cấp tài khoản) | ✅ | | |
| 4 | 🍽️ **Quản lý Thực đơn (Menu)** (Món ăn, Loại món) | ✅ | | |
| 5 | 📦 **Quản lý Kho** (Nguyên vật liệu, Nhà cung cấp) | ✅ | | |
| 6 | 🧾 **Quản lý Nhập hàng** (Tạo phiếu nhập, Lịch sử nhập) | ✅ | | |
| 7 | 📝 **Quản lý Công thức Món ăn** (Định lượng kho) | ✅ | | |
| 8 | 🪑 **Quản lý Sơ đồ Bàn ăn** | ✅ | | |
| 9 | 💵 **Order & Thanh toán** (Tạo đơn, In hóa đơn) | ✅ | ✅ | |
| 10 | 🍳 **Màn hình hiển thị Bếp** (Nhận order mới) | | | ✅ |
| 11 | ⏰ **Chấm công Nhân viên** | ✅ | | |

## 📸 Hình ảnh Giao diện

*(Gợi ý: Bạn nên chụp ảnh các màn hình chính và dán vào đây để README thêm trực quan\!)*

| Màn hình Đăng nhập | Màn hình Order (Thu ngân) |
| :---: | :---: |
| \<img src="" alt="frmLogin" width="400"/\> | \<img src="" alt="frmOrder" width="400"/\> |

| Màn hình Quản lý Nhân viên | Màn hình Thống kê |
| :---: | :---: |
| \<img src="" alt="frmNhanvien" width="400"/\> | \<img src="" alt="frmthongkedoanhthu" width="400"/\> |

## 🔧 Cài đặt & Cấu hình

Để chạy dự án trên máy của bạn, hãy làm theo các bước sau:

**1. Yêu cầu Hệ thống:**

  * Visual Studio 2022 (hoặc mới hơn).
  * .NET 8.0 SDK.
  * Microsoft SQL Server (phiên bản 2012 trở lên) và SSMS.

**2. Clone Repository:**

```bash
git clone https://github.com/quanptatb/QuanLyQuanAn.git
cd QuanLyQuanAn
```

**3. Cấu hình Cơ sở dữ liệu (Database):**

  * **Phục hồi CSDL:**

      * Mở SQL Server Management Studio (SSMS).
      * Tìm tệp `.bak` (nếu có) trong thư mục dự án và Restore.
      * *Nếu không có tệp .bak, bạn cần chạy script SQL để tạo CSDL (thường nằm trong thư mục `Database` hoặc tương tự).*

  * **Cập nhật Chuỗi kết nối (Connection String):**

    > ⚠️ **Rất quan trọng:** Bạn **PHẢI** cập nhật chuỗi kết nối để trỏ đến instance SQL Server của bạn.

    Mở tệp: `DAL_QLQA/DBUtil.cs`
    Tìm và sửa đổi biến `strConnection`:

    ```csharp
    // Ví dụ:
    // Sửa 'TEN_MAY_CHU' thành tên Server SQL của bạn (vd: DESKTOP-ABC\SQLEXPRESS)
    // Sửa 'TEN_DATABASE' thành tên Database của bạn (vd: QLQA)
    // Nếu dùng SQL Authentication, thay "Integrated Security=True" bằng "User Id=sa;Password=yourpassword"

    private string strConnection = "Data Source=TEN_MAY_CHU;Initial Catalog=TEN_DATABASE;Integrated Security=True;TrustServerCertificate=true";
    ```

**4. Chạy Dự án:**

1.  Mở tệp `GUI_QuanLyQuanAN.sln` bằng Visual Studio.
2.  Chờ Visual Studio khôi phục các gói NuGet cần thiết.
3.  Build Solution (F6 hoặc `Ctrl+Shift+B`).
4.  Nhấn chuột phải vào dự án `GUI_QuanLyQuanAN` trong Solution Explorer và chọn `Set as Startup Project`.
5.  Nhấn `F5` để bắt đầu chạy ứng dụng.

**5. Tài khoản Đăng nhập (Mặc định):**

  * **Email (Quản lý):** `admin@example.com` (Vui lòng kiểm tra CSDL để biết tài khoản chính xác)
  * **Mật khẩu:** `123456`

## 🛠️ Công nghệ Sử dụng

  * [\<img src="https://img.shields.io/badge/C%23-blue?style=flat\&logo=csharp\&logoColor=white" /\>](https://docs.microsoft.com/en-us/dotnet/csharp/) - Ngôn ngữ lập trình chính.
  * [\<img src="https://img.shields.io/badge/.NET%208-blueviolet?style=flat\&logo=dotnet" /\>](https://dotnet.microsoft.com/en-us/) - Framework phát triển ứng dụng.
  * [\<img src="https://img.shields.io/badge/Windows%20Forms-0F73C1?style=flat\&logo=windows\&logoColor=white" /\>](https://www.google.com/search?q=https://docs.microsoft.com/en-us/dotnet/desktop/winforms/) - Công nghệ xây dựng giao diện người dùng (GUI).
  * [\<img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=flat\&logo=microsoftsqlserver\&logoColor=white" /\>](https://www.microsoft.com/en-us/sql-server/) - Hệ quản trị cơ sở dữ liệu.
  * **Guna UI / SunnyUI** - Bộ công cụ UI tùy chỉnh để làm đẹp giao diện Windows Forms.

## 🧑‍💻 Tác giả

  * **GitHub:** [quanptatb](https://www.google.com/search?q=https://github.com/quanptatb)

-----

\<p align="center"\>Made with ❤️ for a restaurant management project.\</p\>
