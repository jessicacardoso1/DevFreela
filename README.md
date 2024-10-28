# DevFreela

## 📑 Descrição
**DevFreela** é uma API desenvolvida em ASP.NET Core para conectar clientes e freelancers no gerenciamento de projetos. A API oferece uma plataforma escalável para criação e administração de projetos. Este projeto faz parte de um desafio da mentoria conduzida por Luis Felipe em parceria com a Next Wave Education. 🚀

---

## 🚀 Funcionalidades

### 📌 Principais Entidades
- **Projects**: Gerenciamento de projetos com detalhes, status e progresso.
- **Skills**: Habilidades específicas relacionadas aos usuários e projetos.
- **Users**: Gestão de perfis de clientes e freelancers.

### ⚙️ Funcionalidades Disponíveis
- **Gerenciamento de Projetos**: Criação, edição, exclusão, início e conclusão de projetos.
- **Comentários**: Controle e monitoramento de comentários nos projetos.
- **Atribuição de Habilidades**: Habilidades específicas para cada usuário.

### 📝 Documentação
- A API está documentada e acessível via **Swagger**, facilitando a integração e o entendimento das rotas e operações disponíveis.

---

## 🛠️ Implementações Técnicas

- **Entity Framework Core**: Configuração da camada de persistência com o Entity Framework Core, utilizando um banco de dados MS SQL Server no Docker.
- **Padrão Clean Code**: Estruturação do código seguindo boas práticas para tornar o projeto claro e de fácil manutenção.
- **CQRS (Command Query Responsibility Segregation)**: Separação de responsabilidades para leitura e escrita de dados, implementando o padrão CQRS para maior eficiência e clareza.

---

## 📈 Próximos Passos

### Em Desenvolvimento
- **Padrão Repository**: Implementação de repositórios para gerenciar as operações de dados das entidades `Projects`, `Skills` e `Users`.
- **Validação com FluentValidation**: Adição de validações de entrada utilizando o FluentValidation para garantir integridade e consistência de dados.

### Futuras Melhorias
- **Testes Unitários e de Integração**: Criação de testes para garantir a qualidade e robustez do código.
- **Autenticação e Autorização**: Implementação de autenticação e autorização com JWT (JSON Web Tokens) para controle de acesso seguro.

---

## 🧰 Tecnologias e Ferramentas

- **ASP.NET Core**: Framework para a construção da API.
- **Entity Framework Core**: ORM para gerenciamento de dados.
- **Docker**: Contêiner para execução do banco de dados SQL Server.
- **Swagger**: Documentação da API.
- **IDE**: Visual Studio (experiência também com VS Code).

---

## 👨‍💻 Sobre o Projeto
Este é um desafio empolgante que possibilita a prática de conceitos fundamentais em desenvolvimento backend e arquitetura de APIs. O projeto está em constante evolução, com foco em aprendizado e aprimoramento contínuo!

---

💡 Fique à vontade para contribuir com sugestões, ideias ou relatórios de bugs! Vamos continuar crescendo juntos. 🚀
