dotnet new sln

dotnet new classlib -n ApiServer.Core

dotnet new webapi -n ApiServer.Api

dotnet sln add ApiServer.Api/

dotnet add ApiServer.Data reference ApiServer.Core/

dotnet add ApiServer.Services reference ApiServer.Core/

dotnet add ApiServer.Api reference ApiServer.Core ApiServer.Data ApiServer.Services

dotnet add ApiServer.Data package Microsoft.EntityFrameworkCore

dotnet ef migrations add InitialModel -s ApiServer.Api -p ApiServer.Data

dotnet ef database update -s ApiServer.Api   (也可以用code的形式，见https://github.com/zmyzheng/Reactivities/blob/master/API/Program.cs#L31)


