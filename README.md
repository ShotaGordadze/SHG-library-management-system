# SHG-library-management-system

**EFCore *connection-string***: `User ID={dbUser};Password={pass};Host={host};Port={port};Database={dbName};Pooling=true;`

* Add EFCore Migration cmd: `dotnet ef migrations add Init -p ./SHG.Infrastructure/SHG.Infrastructure.csproj -s ./SHG.Api/SHG.Api.csproj -c LibraryDbContext`
* Update DB EFCore cmd: `dotnet ef database update -p ./SHG.Infrastructure/SHG.Infrastructure.csproj -s ./SHG.Api/SHG.Api.csproj -c LibraryDbContext`