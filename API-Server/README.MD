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


note: 如果没有特殊的操作，如handle foreign key，只要Repository就行了，不需要IProblemRepository。IProblemRepository是为了一些customized behavior，如一对多关系中是否带关联table中的值。在本例中确实没有必要，实际的使用见https://github.com/alopes2/Medium-MyMusic/blob/master/MyMusic.Data/Repositories/ArtistRepository.cs


Swagger UI: https://localhost:5001/swagger-ui


dotnet publish -c Release

docker build -t zmyzheng/api-server:latest -f Dockerfile .

The . in the docker build command tells Docker to use the current folder to find a Dockerfile. 

docker push zmyzheng/api-server:latest