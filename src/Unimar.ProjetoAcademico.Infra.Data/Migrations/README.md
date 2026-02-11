Verifique a Instalação do dotnet-ef:
````shell
dotnet tool install --global dotnet-ef
````

CREATE MIGRATION:
````shell
dotnet ef migrations add Initial --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
````

UPDATE DATABASE:
````shell
dotnet ef database update --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
````

GERAR SCRIPT DE MIGRATION:
````shell
dotnet ef migrations script --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
````

GERAR PARTE SCRIPT DE MIGRATION:
````shell
dotnet ef migrations script **MIGRATION_DE** **MIGRATION_PARA**  --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
````