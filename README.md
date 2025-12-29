# TaskForge

A simple task management web app built with ASP.NET Core 8.0 Razor Pages, Entity Framework Core, and ASP.NET Core Identity.

**Status:** Active development

---

## 🔎 Overview
TaskForge is a lightweight, opinionated task tracker that demonstrates a minimal but complete stack for authentication, data persistence, and server-rendered UI using Razor Pages.

Key features:
- Razor Pages UI
- ASP.NET Core Identity for authentication
- Entity Framework Core for data access and migrations
- Simple task create/edit/delete workflows

---

## 🧰 Tech stack
- .NET 8.0 (SDK)
- ASP.NET Core Razor Pages
- Entity Framework Core (Migrations included)
- Bootstrap and jQuery for basic UI

---

## ⚙️ Prerequisites
- .NET 8.0 SDK (https://dotnet.microsoft.com)
- A relational database (SQLite, SQL Server, PostgreSQL, etc.)

---

## 🚀 Quick start
1. Clone the repo

```bash
git clone <repo-url>
cd TaskForge
```

2. Set your database connection string in `appsettings.Development.json` or `appsettings.json` (update `ConnectionStrings.DefaultConnection`).

3. Restore and build:

```bash
dotnet restore
dotnet build
```

4. Apply EF Core migrations and update the database:

```bash
dotnet ef database update
```

5. Run the app:

```bash
dotnet run
```

Then open https://localhost:5001 (or the URL printed in the console).

---

## 🗄️ Database & Migrations
This project includes an initial set of EF Core migrations under the `Migrations/` folder. To add a new migration:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

If you use a different provider (e.g., PostgreSQL or SQL Server), ensure the connection string and provider packages are configured before running migrations.

---

## 🔐 Identity
The app uses ASP.NET Core Identity for user registration and login. A shared partial (`Pages/Shared/_LoginPartial.cshtml`) provides Login/Register/Logout UI in the layout.

---

## 🧪 Testing & Validation
- Build with `dotnet build` to see compilation warnings/errors.
- There are no automated tests included by default; consider adding xUnit/NUnit tests and CI integration.

---

## 🤝 Contributing
Contributions are welcome. Please open issues for bugs or feature requests, and submit pull requests for fixes or enhancements.

Guidelines:
- Follow clear, small, focused commits
- Add migrations and tests where applicable
- Run `dotnet build` and verify the solution builds cleanly before submitting

**Note:** The project will continue to receive occasional updates — sometimes simply when the developer gets bored and decides to tinker.

---

## 📄 License
Add a `LICENSE` file or update this section with the appropriate license for this project.

---

## ✉️ Contact
Questions? Open an issue or reach out to the project maintainer in the repository.
