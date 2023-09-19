# User-Name
Nếu không được cơ sở dữ liệu, bạn vui lòng vào file AppConfig, đổi     
<add name="ModelUserName" connectionString="data source=(local);initial catalog=UserNameDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
thay đổi data source = (local) bằng tên server sql của bạn
ví dụ : tên server sql của bạn là KIETTRAN\SQLEXPRESS thì thay đổi như sau:
<add name="ModelUserName" connectionString="data source=KIETTRAN\SQLEXPRESS;initial catalog=UserNameDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />

*Note: Lần build đầu sẽ hơi lâu vì phải đợi khởi tạo cơ sở dữ liệu



