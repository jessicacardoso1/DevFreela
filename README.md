# DevFreela

## 📑 Description
**DevFreela** is an API built with ASP.NET Core to connect clients and freelancers for project management. The API provides a scalable platform for creating and managing projects. This project is part of a challenge from the mentorship program led by Luis Felipe in partnership with Next Wave Education. 🚀

---

## 🚀 Features

### 📌 Key Entities
- **Projects**: Manage projects with details, status, and progress tracking.
- **Skills**: Specific skills associated with users and projects.
- **Users**: Manage profiles for clients and freelancers.

### ⚙️ Available Functionalities
- **Project Management**: Create, edit, delete, start, and complete projects.
- **Comments**: Control and monitor comments on projects.
- **Skill Assignment**: Assign specific skills to each user.

### 📝 Documentation
- API documentation is available through **Swagger**, making it easy to integrate and understand the available routes and operations.

---

## 🛠️ Technical Implementations

- **Entity Framework Core**: Configuring the persistence layer with Entity Framework Core, using an MS SQL Server database running on Docker.
- **Clean Code Principles**: Structuring code with best practices for clear, maintainable projects.
- **CQRS (Command Query Responsibility Segregation)**: Separating responsibilities for reading and writing data by implementing the CQRS pattern for improved efficiency and clarity.

---

## 📈 Next Steps

### In Development
- **Repository Pattern**: Implement repositories to manage data operations for the `Projects`, `Skills`, and `Users` entities.
- **Validation with FluentValidation**: Add data entry validation using FluentValidation to ensure data integrity and consistency.

### Future Enhancements
- **Unit and Integration Testing**: Develop tests to ensure code quality and robustness.
- **Authentication and Authorization**: Implement authentication and authorization with JWT (JSON Web Tokens) for secure access control.

---

## 🧰 Technologies and Tools

- **ASP.NET Core**: Framework for building the API.
- **Entity Framework Core**: ORM for data management.
- **Docker**: Container for running the SQL Server database.
- **Swagger**: API documentation.
- **IDE**: Visual Studio (experience with VS Code as well).

---

## 👨‍💻 About the Project
This is an exciting challenge that allows for hands-on practice with essential backend development concepts and API architecture. The project is constantly evolving, with a focus on continuous learning and improvement!

---

💡 Feel free to contribute with suggestions, ideas, or bug reports! Let's keep growing together. 🚀
