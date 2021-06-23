[![.NET](https://github.com/cvti2018/devtest-2021/actions/workflows/dotnet.yml/badge.svg)](https://github.com/cvti2018/devtest-2021/actions/workflows/dotnet.yml)

# DevTest - Cadastro de EPI

Escolha um dos projetos de frontend de acordo com a sua preferência. As opções são:
- AspNetCoreBlazor - [Usando Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-5.0)
- AspNetCoreMVC - [Usando MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0)
- AspNetCorePages - [Usando Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-5.0&tabs=visual-studio)
- AspNetCoreReact - [Usando React](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-5.0&tabs=visual-studio)

Implemente o seguinte cadastro:

- Associar um ou vários EPIs a um funcionário

No cadastro de funcionários mostrar os EPIs associados a esse funcionário.

Desejável para o desenvolvimento:
- Injeção de dependência
- TDD
- Persistência dos dados e regras de negócio devem ser feitas no projeto Domain

## Dicas
- Use os templates do Visual Studio para gerar as tela de CRUD de forma mais rápida
- Projetos testados usando Visual Studio 2019
- Para "ver" o banco de dados use Sql Server Object Explorer (não é necessário para fazer o teste)

---
## Informações gerais

1. Crie um branch e o utilize para enviar o código ao finalizar. Favor enviar um email para avisar que o código está disponível.
2. O banco de dados já possui o cadastro de EPIs, não é necessário fazer o cadastro
3. Na tabela Funcionário EPI, a data de troca é a data que um EPI já cadastrado foi substituído por outro do mesmo tipo (mesmo CA)

---
## Referências
- [TDD](https://en.wikipedia.org/wiki/Test-driven_development)
- Injeção de dependência
    - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0
- [EF Core with MVC](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0)
- [	EF Core with Razor Pages ](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-5.0&tabs=visual-studio)
