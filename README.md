## 📚 API de Gestão de Autores e Livros

Uma API RESTful desenvolvida com C# .NET e Entity Framework para gerenciar autores e livros, permitindo criar, consultar, atualizar e excluir (CRUD) registros com relacionamento entre autores e seus livros.

## 🚀 Tecnologias Utilizadas
C# .NET 8.0: Framework principal para desenvolvimento da API.
Entity Framework Core: Ferramenta ORM para mapeamento e manipulação do banco de dados.
SQL Server: Banco de dados utilizado para persistência dos dados.
Swagger/OpenAPI: Documentação interativa da API.

## 📂 Funcionalidades

🔖 Autores
Adicionar um autor: Insere um novo autor no sistema.
Listar todos os autores: Exibe a lista completa de autores cadastrados.
Atualizar autor: Permite editar informações de um autor existente.
Remover autor: Exclui um autor e os vínculos com seus livros.

📘 Livros
Adicionar um livro: Insere um novo livro no sistema, vinculado a um autor.
Listar todos os livros: Retorna a lista de livros cadastrados com informações do autor.
Atualizar livro: Edita os detalhes de um livro específico.
Remover livro: Exclui um livro do sistema.

🔗 Relacionamento Autor-Livro
Um autor pode estar associado a vários livros.
Cada livro está vinculado a um único autor.
