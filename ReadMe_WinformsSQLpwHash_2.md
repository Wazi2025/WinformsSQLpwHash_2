# WinformsSQLpwHash_2

A Windows Forms (.NET) application designed to demonstrate secure user authentication, data handling, and SQL Server integration. This is part of a larger series exploring the evolution from CLI/Console-based applications to GUI-based Windows Forms solutions.

> **"To remind myself of my humble beginnings—and of how far I've come, especially when the dreaded Blue Verb² looms."**

---

## 📈 Features

### 🔑 Secure Login System
- Passwords are hashed using **BCrypt** with a strong work factor (`12`).
- All login queries are **parameterized** to prevent SQL injection.
- Only authenticated users can access the `Mainform`.

### 🔢 User Management
- New users can be added via `AddUserForm`.
- Duplicate usernames are detected and blocked.
- Passwords are stored **only** as salted, hashed values.

### 📊 SQL Database Integration
- Secure `INSERT` and `SELECT` operations.
- `SQLInsert()` and `SQLSelect()` are fully parameterized.
- Data is displayed in a `DataGridView`, neatly embedded in a `TableLayoutPanel`.

### 📃 Logging
- All login attempts (not passwords) are logged in `Data/log.txt` with timestamps.
- Automatic folder and file creation if missing.

### 👁️ Role-Based UI Access (WIP)
- Currently uses a hardcoded check (`username == "Wazi"`) to toggle UI elements.
- Planned upgrade: add `role` column in DB and dynamically manage permissions.

---

## 🔎 Technologies Used
- C# (.NET 8+)
- Windows Forms (WinForms)
- Microsoft SQL Server
- BCrypt.Net (for password hashing)
- Visual Studio 2022

---

## 🔧 Setup & Run
1. Clone this repo using [this guide](CloneRepo.md).
2. Set up the required SQL Server database using the enclosed scripts in the SQL dir.
3. Update the connection string in `Program.cs > GetFreshConnection()`.
4. Build and run the project via Visual Studio.

---

## 🌟 Final Thoughts
This project reflects a sincere journey from raw console experiments to GUI-backed, secure, real-world architecture. 

---

Made with blood, sweat, caffeine, and a dash of **expletives**.

**-- TNode // Wazi2025**

