## 📚 Author and Book Management API

A RESTful API developed with C# .NET and Entity Framework to manage authors and books, allowing the creation, retrieval, updating, and deletion (CRUD) of records with relationships between authors and their books.

## 🚀 Technologies Used

- **C# .NET 8.0**: Main framework for API development.  
- **Entity Framework Core**: ORM tool for database mapping and manipulation.  
- **SQL Server**: Database used for data persistence.  
- **Swagger/OpenAPI**: Interactive API documentation.  

## 📂 Features

### 🔖 Authors  

- **Add an author**: Inserts a new author into the system.  
- **List all authors**: Displays the complete list of registered authors.  
- **Update an author**: Allows editing an existing author's information.  
- **Remove an author**: Deletes an author and their book associations.  

### 📘 Books  

- **Add a book**: Inserts a new book into the system, linked to an author.  
- **List all books**: Returns the list of registered books with author details.  
- **Update a book**: Edits the details of a specific book.  
- **Remove a book**: Deletes a book from the system.  

### 🔗 Author-Book Relationship  

- An author can be associated with multiple books.  
- Each book is linked to a single author.  