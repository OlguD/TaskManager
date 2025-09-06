<p align="center">
  <img src="https://github.com/OlguD/TaskManager/blob/main/assets/taskmanagerlogo.png" alt="TaskManager Logo" width="400"/>
</p>

## Overview

**TaskManager** is a lightweight, self-hosted project and task management application inspired by Trello. It helps individuals and small teams plan, track, and deliver work using a simple, familiar **Projects → Boards → Cards** hierarchy.

- **Projects** act as the top-level container for related work.
- **Boards** within a project represent workflow stages (e.g., *Todo*, *In Progress*, *Done*).
- **Cards** are actionable tasks that live inside boards and move across stages as work progresses.

The app focuses on clarity and speed: create a project, define a few boards, add cards with titles/descriptions/due dates, then **drag & drop** cards to reflect real progress. The goal is to provide a minimal setup with just the right features so you can get organized in minutes—not hours.

### Why build it?
- **Practical & portfolio-ready:** Demonstrates real-world CRUD, authentication, data modeling, and clean architecture with C#.
- **Team-friendly:** Designed to be extended with collaboration features (assignees, comments, labels, checklists).
- **Developer-first:** Clear REST endpoints, predictable responses, and a layered structure (Controllers → Repositories → Services) that’s easy to test and evolve.

### How it’s built
- **Backend:** ASP.NET Core Web API with EF Core (SQLite for development, PostgreSQL for production). Authentication uses **hashed passwords + JWT**. Migrations are included for repeatable setups.
- **Frontend:** React + Tailwind CSS for a responsive UI, with a drag-and-drop library to manage cards intuitively.
- **Extensibility (planned):** real-time updates via SignalR, reminders/notifications for upcoming due dates, multi-user project sharing, and Dockerized deployments.

Use it for personal kanban, side projects, coursework, or lightweight team workflows. Keep the core simple, then grow features as your needs evolve.
 

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

---
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


---

<details>
  <summary><h3>📂 Project Structure<h3/></summary>

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
---
