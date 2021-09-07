<h1 align="center">Game Catalogue</h1>

Repositório de uma WebAPI desenvolvida para fins acadêmicos, o seu propósito de simular um catálogo pessoal de jogos aplicando conceitos do 
[Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html), 
esse projeto está sujeito a futuras implemtações de acordo com suas necessidades.

Essa API dispõe de um catálago com funcionalidades para inserir, buscar, atualizar e excluir registros em um relacionamento do tipo 1:N (um para muitos)
onde uma plataforma possui vários jogos, mas um jogo só pertence a uma plataforma dentro desse cenário, já para a criação do banco de dados foram usados o 
[Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) e os recursos
do [Code First Migrations](https://docs.microsoft.com/pt-br/ef/ef6/modeling/code-first/migrations/) para essas implementações no
[SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).

Foram adicionados recursos para autenticação e autorização de usuários na aplicação com o 
[ASP .NET Core Identity](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio) e o 
[JWT](https://jwt.io/)
onde é possível adicionar novos usuários para realizar seus respectivos acessos através de credenciais.

## :wrench: Recursos Utilizados

- [Visual Studio v16.9.5](https://visualstudio.microsoft.com/pt-br/)
- [ASP.NET Core WebAPI](https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio)
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/getting-started/)
- [Entity Framework Core v5.0.7](https://docs.microsoft.com/pt-br/ef/core/)
- [SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [AutoMapper v10.1.1](https://automapper.org/)
- [Identity v2.2.0](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)
- [JWT v5.0.9](https://jwt.io/)
- [XUnit v2.4.1](https://xunit.net/)
- [FluentAssertions v5.10.3](https://fluentassertions.com/)
- [Swagger v6.1.5](https://swagger.io/)

## :floppy_disk: Clonar Repositório

`git clone https://github.com/PauloAlves8039/dotnet-core-game-catalogue-api.git`

## :camera: Diagrama do Banco de Dados

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-core-game-catalogue-api/blob/master/src/GameCatalogue.API/assets/img/diagrama-game-catalogue.png" 
   title="Diagrama do Banco de Dados" /></p>
Diagrama gerado no Microsoft SQL Server Management Studio, o seu objetivo é exibir a estrutura da base de dados criada no projeto.

## :camera: API

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-core-game-catalogue-api/blob/master/src/GameCatalogue.API/assets/img/api.png" /></p>
Página para a exibição dos endpoints da API utilizando o Swagger.

## Author

:boy: [Paulo Alves](https://github.com/PauloAlves8039)
