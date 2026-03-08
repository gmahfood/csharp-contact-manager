# 📋 Contact Manager

A simple console-based contact manager built in C# (.NET). Supports adding, viewing, searching, and deleting contacts from an in-memory list.

---

## Features

- Add a contact with name, phone, and email
- View all contacts in a formatted table
- Search contacts by name (case-insensitive)
- Delete a contact with confirmation prompt
- Input validation and graceful error handling

---

## Project Structure

```
ContactManager/
├── Contact.cs          # Contact model — defines the shape of a contact
├── ContactService.cs   # Service layer — owns all contact logic (add, view, search, delete)
└── Program.cs          # Entry point — handles the menu loop and console I/O
```

The project follows the **Single Responsibility Principle** — each file has one clear job:
- `Contact.cs` is just a data model
- `ContactService.cs` contains all business logic
- `Program.cs` is a thin UI shell that reads input and displays output

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later

### Run the app
```bash
git clone https://github.com/YOUR_USERNAME/ContactManager.git
cd ContactManager
dotnet run
```

---

## Usage

```
==================================
      CONTACT MANAGER
==================================

Menu
1. Add Contact
2. View Contacts
3. Search
4. Delete
5. Exit
```

Enter the number of the action you want to perform and follow the prompts.

---

## Potential Improvements

- **File persistence** — save and load contacts from a JSON file so data isn't lost on exit
- **Edit contact** — update an existing contact's details
- **Input validation** — enforce phone number format and email structure
- **Sorting** — view contacts alphabetically

---

## License

This project is open source.
