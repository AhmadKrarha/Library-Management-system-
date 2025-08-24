# Library Management System

This project is a Library Management System built with Blazor and ASP.NET Core (.NET 8). It demonstrates how to manage books and shelves in a library using a modern web application framework.

## Features

- **View Shelves:** List all library shelves and view their details.
- **Add/Edit/Delete Shelves:** Manage library shelves with create, update, and delete operations.
- **View Books by Shelf:** Display all books stored on a specific shelf.
- **Add/Edit/Delete Books:** Manage books, including assigning them to shelves and updating their details.
- **Validation:** Server-side validation for book and shelf data.
- **Modal Dialogs:** User-friendly confirmation dialogs for delete actions.

# Technologies Used

- **Blazor** (for UI and component-based development)
- **ASP.NET Core MVC** (for controllers and backend logic)
- **Entity Framework Core** (for data access)
- **Bootstrap** (for responsive UI)
- **C# 12 / .NET 8**

# Project Structure

- `Controllers/` - Handles HTTP requests for books and shelves.
- `Models/` - Contains the data models (`Book`, `Shelf`).
- `Repository/` - Data access logic using repository pattern.
- `Views/` - Razor views for displaying and managing data.

# How It Works

- **Shelves** can be created, edited, and deleted. Each shelf can contain multiple books.
- **Books** are associated with shelves and can be managed (added, updated, deleted) from the UI.
- The application uses forms with validation to ensure correct data entry.
- Modal dialogs are used for confirming delete actions, improving user experience.

   
