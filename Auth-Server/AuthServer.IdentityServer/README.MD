dotnet ef migrations add "updateDB3" -c ApplicationDbContext -s AuthServer.IdentityServer/ -p AuthServer.IdentityServer/ -o Data/Migrations/ApplicationDb

dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -s AuthServer.IdentityServer/ -p AuthServer.IdentityServer/ -o Data/Migrations/PersistedGrantDb

dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -s AuthServer.IdentityServer/ -p AuthServer.IdentityServer/ -o Data/Migrations/ConfigurationDb


dotnet run -p AuthServer.IdentityServer/ /seed


持久化的有两类data：一类是config，另一类是user