# Unimar.ProjetoAcademico

Projeto acadêmico desenvolvido em .NET 10 seguindo os princípios de Clean Architecture e Domain-Driven Design (DDD).

## 📋 Sobre o Projeto

Sistema de gerenciamento acadêmico com API REST desenvolvida com ASP.NET Core, estruturada em camadas para garantir separação de responsabilidades e manutenibilidade.

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:

- **API**: Camada de apresentação com controllers REST
- **Application Service**: Camada de aplicação com comandos e handlers
- **Domain**: Camada de domínio com entidades e regras de negócio
- **Infrastructure**: Camada de infraestrutura
  - **Data**: Acesso a dados e migrations
  - **CrossCutting**: Recursos transversais (IoC, FluentValidation, MediatR, Swagger)

## 🚀 Tecnologias Utilizadas

- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core 10.0.2**
- **MediatR** - Padrão Mediator
- **FluentValidation** - Validações
- **Swagger/OpenAPI** - Documentação da API
- **PostgreSQL** (via Entity Framework)

## ⚙️ Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- PostgreSQL (Local ou Docker)
- Visual Studio 2022/2026 ou VS Code

## 🔧 Configuração e Instalação

### 1. Clone o repositório

```bash
git clone <url-do-repositorio>
cd Unimar.ProjetoAcademico
```

### 2. Instale o EF Core Tools

```bash
dotnet tool install --global dotnet-ef
```

### 3. Configure a Connection String

Edite o arquivo `appsettings.json` no projeto `Unimar.ProjetoAcademico.Api` com sua connection string do PostgreSQL.

Exemplo de connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ProjetoAcademico;Username=seu_usuario;Password=sua_senha"
}
```

### 4. Execute as Migrations

```bash
dotnet ef database update --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
```

### 5. Execute a aplicação

```bash
dotnet run --project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj
```

A API estará disponível em `https://localhost:<porta>` e a documentação Swagger em `https://localhost:<porta>/swagger`.

## 📚 Migrations

### Criar nova migration

```bash
dotnet ef migrations add <NomeDaMigration> --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
```

### Atualizar banco de dados

```bash
dotnet ef database update --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
```

### Gerar script SQL

```bash
dotnet ef migrations script --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
```

### Gerar script entre migrations específicas

```bash
dotnet ef migrations script <MIGRATION_DE> <MIGRATION_PARA> --project ./src/Unimar.ProjetoAcademico.Infra.Data/Unimar.ProjetoAcademico.Infra.Data.csproj --startup-project ./src/Unimar.ProjetoAcademico.Api/Unimar.ProjetoAcademico.Api.csproj -c ProjetoAcademicoContext
```

## 🎯 Funcionalidades

### API de Cursos

- **GET** `/api/Curso/obter/{id}` - Obter curso por ID
- **GET** `/api/Curso/listar` - Listar todos os cursos
- **POST** `/api/Curso/adicionar` - Adicionar novo curso
- **PUT** `/api/Curso/atualizar` - Atualizar curso existente
- **DELETE** `/api/Curso/excluir/{id}` - Excluir curso

## 📁 Estrutura de Pastas

```
src/
├── Unimar.ProjetoAcademico.Api/
│   └── Controllers/
├── Unimar.ProjetoAcademico.ApplicationService/
│   ├── Commands/
│   ├── DTOs/
│   └── Interfaces/
├── Unimar.ProjetoAcademico.Domain/
│   └── Entities/
├── Unimar.ProjetoAcademico.Infra.Data/
│   ├── Context/
│   ├── Migrations/
│   └── Repositories/
├── Unimar.ProjetoAcademico.Infra.CrossCutting.FluentValidation/
├── Unimar.ProjetoAcademico.Infra.CrossCutting.IoC/
├── Unimar.ProjetoAcademico.Infra.CrossCutting.MediatoR/
└── Unimar.ProjetoAcademico.Infra.CrossCutting.Swagger/
```

## 🧪 Testes

Para executar os testes do projeto:

```bash
dotnet test
```

## 🤝 Contribuindo

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

## 📝 Padrões do Projeto

### CQRS (Command Query Responsibility Segregation)

O projeto utiliza o padrão CQRS através do MediatR, separando comandos de leitura e escrita.

### Clean Architecture

- **Camada de Domínio**: Independente de frameworks e infraestrutura
- **Camada de Aplicação**: Orquestra o fluxo de dados
- **Camada de Infraestrutura**: Implementa detalhes técnicos
- **Camada de Apresentação**: Interface com o usuário (API)

### Validações

Utiliza FluentValidation para validação de dados de entrada, garantindo integridade e consistência.

## 📄 Licença

Este é um projeto acadêmico desenvolvido para fins educacionais.

## 👥 Autores

Projeto desenvolvido por alunos da UNIMAR - Universidade de Marília.

---

⌨️ Desenvolvido com .NET 10 | ASP.NET Core | Entity Framework Core
