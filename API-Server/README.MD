dotnet new sln

dotnet new classlib -n ApiServer.Core

dotnet new webapi -n ApiServer.Api

dotnet sln add ApiServer.Api/

dotnet add ApiServer.Data reference ApiServer.Core/

dotnet add ApiServer.Services reference ApiServer.Core/

dotnet add ApiServer.Api reference ApiServer.Core ApiServer.Data ApiServer.Services

