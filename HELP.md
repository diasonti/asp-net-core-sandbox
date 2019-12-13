### Database migrations
- Create migration: `dotnet ef migrations add [name]`
- Apply migrations: `dotnet ef database update`
- Delete migrations: `dotnet ef migrations remove`

dotnet aspnet-codegenerator controller -name "$1Controller" -actions -m "$1" -dc SandboxDbContext -outDir Controllers

dotnet aspnet-codegenerator controller -name "$1Controller" -actions -m "$1" -dc SandboxDbContext -outDir Controllers
