# Demo Server - Client

Client sử dụng Winform, Server sử dụng .NET 6.0 làm API

## Bắt Đầu

Hướng dẫn cài đặt

### Yêu Cầu
- MSSQL Server
- Visual Studio 2022 (chạy project API)
- .NET SDK 6+

### Cài Đặt

1. Tạo database bằng MSSQL sử dụng file **\Server\Database\CreateDb.sql**

2. Server chỉnh file **appsettings.json** cấu hình chuỗi kết nối đến database vừa tạo
~~~
...
"ConnectionStrings": {
    "DefaultConnection": "..."
  }
...
~~~

3. Client file **App.config** cấu hình địa chỉ gọi API của Server (apiUrl dùng cho trò chơi, apiUrlHub dùng cho Monitoring)
~~~
...
<appSettings>
    <add key="apiUrl" value="..." />
    <add key="apiUrlHub" value="..." />
...
~~~

### Chạy project Server, Client
Cấu hình Solution để chạy debug cùng lúc cả hai, hoặc publish Server để chạy nhiều Client

### Chạy project Client.Test để test cơ bản

Cấu hình **app.config** như project Client
~~~
...
<appSettings>
    <add key="apiUrl" value="..." />
...
~~~