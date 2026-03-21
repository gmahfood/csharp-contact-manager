# 📋 Contact Manager

A full-stack contact manager built as a learning project to explore C#, ASP.NET Core, Entity Framework Core, xUnit testing, and React. Started as a simple console app and has evolved into a REST API with a modern frontend UI.

---

## Project Structure
```
ContactManager/
├── ContactManager/              # Core library — models and business logic
│   ├── Contact.cs               # Contact model with EF Core support
│   ├── ContactService.cs        # Service layer — add, view, search, delete
│   └── Program.cs               # Original console app entry point
│
├── ContactManager.Api/          # ASP.NET Core REST API
│   ├── Controllers/
│   │   └── ContactsController.cs  # API endpoints with validation
│   ├── Data/
│   │   └── AppDbContext.cs      # EF Core database context
│   └── Program.cs               # API entry point and configuration
│
├── ContactManager.Tests/        # xUnit test project
│   └── UnitTest1.cs             # Unit tests for ContactService
│
└── contact-manager-ui/          # React frontend (Vite)
    └── src/
        └── App.jsx              # Main UI component
```

---

## Features

### Core
- Add a contact with name, phone, and email
- View all contacts
- Search contacts by name (case-insensitive)
- Delete a contact by name
- Update a contact by ID
- Input validation with data annotations

### API
- Full REST API built with ASP.NET Core
- SQLite database via Entity Framework Core
- Swagger UI for testing endpoints
- Contacts persist across server restarts

### Frontend
- React + Vite
- Connects to the REST API
- Modern and sleek UI

### Tests
- 8 unit tests covering all ContactService methods
- Uses xUnit framework

---

## API Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/contacts` | Get all contacts |
| GET | `/api/contacts/search?name=` | Search by name |
| POST | `/api/contacts` | Create a contact |
| PUT | `/api/contacts/{id}` | Update a contact |
| DELETE | `/api/contacts/{name}` | Delete a contact |

---

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org) (for the frontend)

### Run the API
```bash
git clone https://github.com/gmahfood/csharp-contact-manager.git
cd csharp-contact-manager/ContactManager.Api
dotnet run
```

Then open `http://localhost:5006/swagger/index.html` to explore the API.

### Run the frontend
```bash
cd csharp-contact-manager/contact-manager-ui
npm install
npm run dev
```

Then open `http://localhost:5173`

### Run the tests
```bash
cd csharp-contact-manager
dotnet test
```

---

## What I Learned

- C# classes, properties, constructors, and validation
- Single Responsibility Principle (SRP)
- ASP.NET Core Web API and routing
- Entity Framework Core with SQLite
- Dependency injection
- REST API design (GET, POST, PUT, DELETE)
- xUnit testing with the Arrange/Act/Assert pattern
- Git branching and pull requests
- React components, JSX, and state management
- Connecting a frontend to a REST API

---

## Roadmap
- [x] Console app
- [x] REST API
- [x] SQLite persistence
- [x] Unit tests
- [x] React frontend (in progress)
- [ ] Authentication
- [ ] Deploy to the web

---

## License
This project is open source.
```

Copy that, paste it into your `README.md` in VS Code, save with **Cmd+S**, then commit in GitHub Desktop with:
```
docs: update README with full project overview and frontend details
