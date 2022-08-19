# Api de Produtos

>Status do Projeto: :heavy_check_mark:

### Indíce 

* [Descrição do projeto](#descrição-do-projeto)

* [Funcionalidades](#funcionalidades)

* [Acesso ao projeto](#acesso-ao-projeto)

* [Como rodar a aplicação](#como-rodar-a-aplicação-arrow_forward)

## :scroll: Descrição do Projeto

<p align="justify">
  Api de produtos com relacionamento de muitos para muitos com categorias, utilizando ASP .NET Core 3.1, banco de dados SQL Server, e Swagger para documentação.
</p>

## :hammer: Funcionalidades
- `Funcionalidade 1`: CRUD de Categorias
- `Funcionalidade 2`: CRUD de Produtos
- `Funcionalidade 2a`: Relacionamento muitos para muitos com categoria

## 📁 Acesso ao projeto

https://github.com/jaquemaggot/api-produto

## 🛠️ Como rodar a aplicação

Para executar o projeto siga os passos:

:memo: Clone o Projeto

:memo: Altere o arquivo appsettings.json (src/Api.Application) informando seu dados de acesso ao SQL Server em DefaultConnection

:memo: Execute os seguintes comandos (Dentro da pasta API.Application):
       
       dotnet restore
       dotnet build

:memo: Para criar o banco de dados utilize o seguinte comando (Dentro da pasta API.Application):

       dotnet ef database update

:memo: No terminal digite (Dentro da pasta API.Application): 

       dotnet run

:memo: No navegador é possível executar de duas formas:

    - Utilizando : https://localhost:5001/index.html (Para acesso com https)
    - Utilizando : http://localhost:5000/index.html (Para acesso com http)

## Desenvolvedora
[<sub>Jaqueline Santos</sub>](https://github.com/jaquemaggot)




