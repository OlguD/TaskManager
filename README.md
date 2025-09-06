<p align="center">
  <img src="https://github.com/OlguD/TaskManager/blob/main/assets/taskmanagerlogo.png" alt="TaskManager Logo" width="200"/>
</p>

This project allows users to manage tasks and projects efficiently. 

## 🚀 Supported Features

- ✅ User registration and login (JWT Authentication)
- ✅ Create, list, and delete projects
- ✅ Add boards per project (Todo, In Progress, Done, etc.)
- ✅ Add cards (tasks) inside boards
- ✅ Move cards between boards (drag & drop)
- ✅ Deadlines, descriptions, and task details

## 🚀 Features In Progress
- ✅ Responsive UI (web) 


## 🛠️ Tech Stack

- **Backend**
  - C# / ASP.NET Core Web API
  - Entity Framework Core
  - SQLite (initial) → PostgreSQL (production)
  - Password Hashing
  - JWT Authentication

- **Frontend**
  - React.js
  - TailwindCSS (for styling)
  - Drag & Drop libraries

- **Others**
  - Docker (for deployment)
  - GitHub Actions (CI/CD)

<details>
    <summary>## 📂 Project Structure</summary>
```text
├── .idea/
│   └── .idea.TaskManagerBackend/
│       └── .idea/
│           ├── .gitignore
│           ├── dataSources.xml
│           └── indexLayout.xml
├── TaskManagerBackend.sln
└── TaskManagerBackend/
    ├── .gitignore
    ├── Controllers/
    │   ├── AuthController.cs
    │   ├── BoardController.cs
    │   ├── CardController.cs
    │   └── ProjectController.cs
    ├── Data/
    │   └── AppDbContext.cs
    ├── Exceptions/
    │   ├── UserNotFoundException.cs
    │   └── ValidationException.cs
    ├── Helpers/
    │   └── JwtHelper.cs
    ├── Migrations/
    │   ├── 20250905002914_InitialCreate.Designer.cs
    │   ├── 20250905002914_InitialCreate.cs
    │   └── AppDbContextModelSnapshot.cs
    ├── Models/
    │   ├── Board.cs
    │   ├── BoardCreateRequest.cs
    │   ├── Card.cs
    │   ├── LoginRequestModel.cs
    │   ├── Project.cs
    │   ├── RegisterRequestModel.cs
    │   └── User.cs
    ├── Program.cs
    ├── Properties/
    │   └── launchSettings.json
    ├── Repositories/
    │   ├── BoardRepository.cs
    │   ├── CardRepository.cs
    │   ├── IBoardRepository.cs
    │   ├── ICardRepository.cs
    │   ├── IProjectRepository.cs
    │   ├── IUserRepository.cs
    │   ├── ProjectRepository.cs
    │   └── UserRepository.cs
    ├── Services/
    │   ├── BoardService.cs
    │   ├── CardService.cs
    │   ├── ProjectService.cs
    │   └── UserService.cs
    ├── TaskManagerBackend.csproj
    ├── TaskManagerBackend.http
    ├── Utils/
    │   └── PasswordHash.cs
    ├── appsettings.Development.json
    ├── appsettings.json
    └── taskmanager.db
```
</details>

## 📌 Roadmap
### Phase 1 – Backend
- [x] User authentication (JWT)
- [x] Entity models (User, Project, Board, Card)
- [x] CRUD endpoints
- [ ] Unit tests

### Phase 2 – Frontend
- [ ] Login/Register screens
- [ ] Project listing & creation
- [ ] Board & card screens
- [ ] Drag & Drop support

### Phase 3 – Advanced Features
- [ ] Deadline reminder notifications
- [ ] Project sharing (multi-user support)
- [ ] Docker deployment  
