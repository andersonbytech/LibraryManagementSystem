# Library Management System

Este projeto é uma aplicação de gerenciamento de biblioteca que utiliza a arquitetura **CQRS (Command Query Responsibility Segregation)**. A aplicação é composta por uma **API** para gerenciamento de dados e uma interface de usuário desenvolvida em **Blazor WebAssembly**.

## Tecnologias Utilizadas

- **ASP.NET Core 6** - Framework para construção da API e lógica de negócio.
- **Blazor WebAssembly** - Framework para construção da interface de usuário SPA.
- **Dapper** - Micro ORM utilizado para consultas rápidas e eficientes.
- **Entity Framework Core** - ORM utilizado para persistência de dados.
- **SQL Server** - Banco de dados relacional utilizado para armazenar e replicar os dados entre as bases de leitura e escrita.

## Arquitetura

### CQRS (Command Query Responsibility Segregation)

O projeto segue a arquitetura CQRS, separando as responsabilidades de leitura e escrita:

- **Comandos (Commands)** - Operações que modificam o estado da aplicação (por exemplo, adicionar um livro).
- **Consultas (Queries)** - Operações que leem dados da aplicação (por exemplo, listar livros, buscar um livro por ID).

### Replicação de Banco de Dados

Para melhorar a escalabilidade e o desempenho da aplicação, foram configuradas duas bases de dados separadas no SQL Server:

- **LibraryWriteDb**: Base de dados utilizada para operações de escrita (inserção, atualização e exclusão de registros).
- **LibraryReadDb**: Base de dados utilizada para operações de leitura, garantindo que consultas intensas não impactem a performance das operações de escrita.

Essas duas bases de dados estão sincronizadas através de um processo de replicação do SQL Server. A replicação garante que todos os dados inseridos ou modificados na base de escrita (`LibraryWriteDb`) sejam automaticamente replicados para a base de leitura (`LibraryReadDb`), permitindo que a aplicação siga o princípio da separação de responsabilidades da arquitetura CQRS.

## Estrutura do Projeto

```plaintext
LibraryManagementSystem/
│
├── Library.API/                      # Projeto da API ASP.NET Core
│   ├── Controllers/
│   │   └── BooksController.cs        # Controlador para operações de livros
│   ├── Migrations/                   # Arquivos de migração do Entity Framework Core
│   ├── Properties/
│   │   └── launchSettings.json       # Configurações de lançamento
│   ├── appsettings.json              # Configurações da aplicação
│   └── Program.cs                    # Configurações e inicialização da API
│
├── Library.BlazorApp/                # Projeto Blazor WebAssembly
│   ├── Client/                       # Configuração de cliente para comunicação com API
│   │   └── Program.cs                # Configuração principal do Blazor WebAssembly
│   ├── Pages/                        # Páginas da aplicação
│   │   ├── Properties/
│   │   │   └── AddBook.razor         # Página para adicionar novo livro
│   │   │   └── Books.razor           # Página de listagem de livros
│   │   │   └── Index.razor           # Página inicial
│   ├── Shared/                       # Componentes compartilhados
│   │   ├── MainLayout.razor          # Layout principal da aplicação
│   │   ├── NavMenu.razor             # Menu de navegação
│   │   ├── SurveyPrompt.razor        # Componente de exemplo
│   │   └── _Imports.razor            # Importações comuns
│   ├── wwwroot/                      # Recursos estáticos
│   ├── appsettings.json              # Configurações específicas do Blazor
│   └── App.razor                     # Componente raiz da aplicação
│
├── Library.Infrastructure/           # Projeto de infraestrutura
│   ├── Commands/                     # Comandos da arquitetura CQRS
│   │   ├── AddBookCommandHandler.cs  # Handler para adicionar novo livro
│   │   └── DeleteBookCommandHandler.cs # Handler para deletar livro
│   ├── Data/
│   │   ├── ReadContext.cs            # Contexto de leitura para CQRS
│   │   └── WriteContext.cs           # Contexto de escrita para CQRS
│   ├── Migrations/                   # Migrações do Entity Framework Core
│   └── Queries/                      # Consultas da arquitetura CQRS
│       ├── GetAllBooksQueryHandler.cs  # Handler para listar todos os livros
│       └── GetBookIdQueryHandler.cs  # Handler para buscar livro por ID
│
└── Library.Shared/                   # Projeto compartilhado
    ├── AddBookCommand.cs             # Comando para adicionar novo livro
    └── Book.cs                       # Modelo de dados para livros

## Funcionalidades

- **Listar Livros:** A página principal da aplicação permite listar todos os livros disponíveis na biblioteca.
- **Adicionar Livro:** Através da interface Blazor, é possível adicionar novos livros à biblioteca.
- **Buscar Livro por ID:** A API permite buscar detalhes de um livro específico utilizando seu ID.
- **Excluir Livro:** A funcionalidade para excluir livros também está implementada.

## Configuração e Execução

### Requisitos

- **.NET 6 SDK** - Para compilar e executar a aplicação.
- **SQL Server** - Para o banco de dados (ou outro banco de dados suportado pelo Entity Framework Core).

### Passos para Configuração

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/seuusuario/LibraryManagementSystem.git




Você pode copiar este trecho diretamente para a seção "Configuração e Execução" do seu `README.md`. Se precisar de mais ajustes ou tiver outras dúvidas, estou à disposição para ajudar!
