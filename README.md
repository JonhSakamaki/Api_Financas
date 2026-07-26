# 💰 API Finanças (Finance API)

Uma API RESTful desenvolvida em C# e .NET para gerenciamento de finanças pessoais. Este projeto foi construído para aplicar conceitos sólidos de back-end, arquitetura de software e persistência de dados em um banco de dados relacional.

## 🚀 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** .NET (ASP.NET Core)
* **ORM:** Entity Framework Core
* **Banco de Dados:** SQL Server
* **Documentação:** Swagger (OpenAPI)

## ⚙️ Funcionalidades e Arquitetura

* **CRUD Completo:** Operações de criação, leitura, atualização e exclusão para Transações e Categorias (Verbos HTTP `GET`, `POST`, `PUT`, `DELETE`).
* **Relacionamento 1:N:** Modelagem de dados relacional vinculando Transações às suas respectivas Categorias por meio de Chaves Estrangeiras (Foreign Keys).
* **Regras de Negócio e LINQ:** Endpoint exclusivo (`/api/transactions/resumo`) que processa dados diretamente no SQL Server de forma assíncrona para calcular o Total de Receitas, Total de Despesas e Saldo Atual.
* **Segurança e Validação:** Implementação de *Data Annotations* para garantir a integridade dos dados na entrada (ex: bloqueio de valores zerados ou campos vazios) retornando respostas `400 Bad Request` limpas.
* **Prevenção de Ciclos (Object Cycle):** Configuração global de serialização JSON para lidar com referências circulares de forma segura.

## 🛣️ Endpoints Principais

Abaixo estão as rotas principais disponíveis na aplicação (documentadas interativamente via Swagger):

* `GET /api/Categories` - Retorna todas as categorias cadastradas.
* `POST /api/Categories` - Cria uma nova categoria.
* `GET /api/Transactions` - Retorna o extrato completo com os dados da categoria embutidos.
* `POST /api/Transactions` - Registra uma nova receita ou despesa.
* `PUT /api/Transactions/{id}` - Atualiza um registro existente.
* `DELETE /api/Transactions/{id}` - Remove um registro do banco de dados.
* `GET /api/Transactions/Resumo` - Retorna o balanço financeiro calculado (Entradas, Saídas e Saldo).

## 🛠️ Como executar o projeto localmente

1. Clone este repositório em sua máquina.
2. Certifique-se de ter o **SDK do .NET** e o **SQL Server** instalados.
3. Abra o terminal na pasta raiz do projeto.
4. Restaure os pacotes da aplicação:
   `dotnet restore`
5. Crie o banco de dados e aplique as migrations do Entity Framework:
   `dotnet ef database update`
6. Inicie o servidor:
   `dotnet run`
7. Acesse o Swagger no navegador (o link exato aparecerá no terminal, geralmente em `http://localhost:5091/swagger`).

## 👨‍💻 Desenvolvedor

**Jonnyh de Aquino**
Estudante de Análise e Desenvolvimento de Sistemas (ADS). Focado no ecossistema .NET e no desenvolvimento de soluções Back-end.
