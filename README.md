dotnet watch run

dotnet add package Microsoft.EntityFrameworkCore --version 8.0.6
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 8.0.6
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.6

dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.6

dotnet ef migrations add <name>
dotnet ef database update
