# 🐾 PetShop API

API desenvolvida em .NET para gerenciamento de animais em um Pet Shop. Utiliza Entity Framework Core com Oracle, estrutura em múltiplos projetos e segue boas práticas de desenvolvimento com separação de responsabilidades.

## 📁 Estrutura do Projeto

O projeto está dividido em 4 camadas principais:

- `PetShop.Domain`: Contém as entidades e interfaces de domínio.
- `PetShop.Application`: Contém as regras de negócio (serviços).
- `PetShop.Infrastructure`: Contém a implementação do Entity Framework Core e acesso ao banco Oracle.
- `PetShopAPI`: Camada WebAPI que expõe os endpoints HTTP.

## 📦 Funcionalidades

A API permite operações CRUD para animais:

- `GET /api/animais`: Lista todos os animais.
- `GET /api/animais/{id}`: Retorna um animal específico.
- `POST /api/animais`: Cadastra um novo animal.
- `PUT /api/animais/{id}`: Atualiza um animal existente.
- `DELETE /api/animais/{id}`: Remove um animal.

## 📌 Exemplo de Entidade
- ASP.NET Core 7 ou superior
- Entity Framework Core (com provider Oracle)
- Injeção de dependência
- Migrations com suporte a design-time (IDesignTimeDbContextFactory)
- Visual Studio 2022 ou VS Code

## ⚙️ Como Executar
- Configurar o banco de dados Oracle com a string de conexão apropriada no appsettings.json:

- "ConnectionStrings": {
  "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_DATA_SOURCE"
}
- Executar migrations (se necessário):

- dotnet ef migrations add InitialCreate -p PetShop.Infrastructure -s PetShopAPI
- dotnet ef database update -p PetShop.Infrastructure -s PetShopAPI

- Executar a aplicação:

- "dotnet run --project PetShopAPI"


## 🔧 Tecnologias Utilizadas
```csharp
public class Animal
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; } // Ex: "Cachorro", "Gato"
    public int Idade { get; set; }
};