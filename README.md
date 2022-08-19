# Api de Produtos

>Status do Projeto: :heavy_check_mark:

### Indíce 

* [Descrição do projeto](#descrição-do-projeto)

* [Funcionalidades](#funcionalidades)

* [Acesso ao projeto](#acesso-ao-projeto)

* [Como rodar a aplicação](#como-rodar-a-aplicação-arrow_forward)

##Descrição do Projeto

<p align="justify">
  Api de produtos com relacionamento de muitos para muitos com categorias, utilizando ASP .NET Core 3.1, banco de dados SQL Server, e Swagger para documentação.
</p>

## :hammer: Funcionalidades
- `Funcionalidade 1`: CRUD de Categorias
- `Funcionalidade 2`: CRUD de Produtos
- `Funcionalidade 2a`: Relacionamento muitos para muitos com categoria

## 📁 Acesso ao projeto

https://github.com/jaquemaggot/ApiProdutoPrivado

## 🛠️ Como rodar a aplicação

Para executar o projeto siga os passos:

:memo: Clone o Projeto

:memo: Altere o arquivo appsettings.json (src/Api.Application), nesse arquivo informe seu usuario de acesso ao SQL Server em DefaultConnection

:memo: Para criar as Migrations utilize os comando no terminal (Dentro da pasta API.Application):

        -Executar o comando de criar migrations: dotnet ef migrations add Initial -p ..\Api.Data.SqlServer\
        -Executar comando de rodar as migrations: dotnet ef database update

:memo: No terminal digite dotnet build (Dentro da pasta API.Application)

:memo: Após o comando de dotnet build, digite dotnet run (Dentro da pasta API.Application)

:memo: No navegador é possível executar de duas formas:

    -Utilizando : https://localhost:5001/swagger/index.html (Para acesso com htts)
    -Utilizando : http://localhost:5000/swagger/index.html (Para acesso com http)

## Desenvolvedora
[<sub>Jaqueline Santos</sub>](https://github.com/jaquemaggot)




