# Clothes Selling Web Application

## Overview

This project is a web-based e-commerce platform for selling clothes. It is built using **ASP.NET Core MVC** and integrates with **SQL Server** for data management. The application allows users to browse, search, and purchase clothing items, while administrators can manage products, orders, and users.

## Features

### Customer Features:

- Browse clothing items by category.
- Search for products using keywords.
- Add items to the shopping cart and place orders.
- User account management (register, login, update profile).
- Order history tracking.

### Admin Features:

Manage product catalog (add, edit, delete items).
View and manage customer orders.
Manage user accounts.

### General Features:

Responsive design for desktop device.
Secure authentication and authorization using **ASP.NET Identity**.

## Prerequisites

- **Microsoft Visual Studio 2022** (Community, Professional, or Enterprise edition).
- **.NET 9.0 SDK**.
- **SQL Server** (Express, Developer, or Enterprise edition).
- **SQL Server Management Studio (SSMS)** (optional, for database management).

## Installation Steps

1. Clone the Repository
   ```
   git clone https://github.com/HaLong2002/Website-ASP.NET-Core-MVC.git
   cd Website-ASP.NET-Core-MVC
   ```
2. Open in Visual Studio
   - Launch **Microsoft Visual Studio 2022**.
   - Open the project folder using **File > Open > Project/Solution**.
3. Configure Database
   - Open the `appsettings.json` file.
   - Update the connection string in the `ConnectionStrings` section:
     ```
     "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;TrustServerCertificate=True;Connection Timeout=30;MultipleActiveResultSets=True;"
         }
     ```
4. Apply Migrations
   - Open the **Package Manager Console** (Tools > NuGet Package Manager > Package Manager Console).
   - Run the following commands:
     `Update-Database`
     This will create the database and apply all migrations.
5. Run the Project
   Press `Ctrl + F5` or click on the **Run** button in Visual Studio.
   The application will launch in your default browser.

## Folder Structure

- **Controllers**: Manages application logic and handles user requests.
- **Models**: Represents the data structure and database schema.
- **Views**: Contains Razor views for rendering the user interface.
- **wwwroot**: Includes static files like CSS, JavaScript, and images.
- **Areas**: Admin section for managing the website.

## Technologies Used

- **ASP.NET Core MVC**: Web framework for building the application.
- **Entity Framework Core**: ORM for database operations.
- **SQL Server**: Relational database management.
- **Bootstrap**: For responsive front-end design.
- **jQuery**: For client-side interactivity.
- **ASP.NET Identity**: For secure authentication and authorization.

## Key Models

- **Product**: Represents clothing items (e.g., name, price, description, category, stock, image).
- **User**: Represents customers and admins.
- **Order**: Tracks customer orders (e.g., order details, payment status, shipping address).
- **Category**: Represents clothing categories (e.g., Men, Women, Kids).

## Key Features in Detail

**1. Product Management:**

- Admins can add new products with details like name, price, description, stock, and images.
- Categories and product filtering for easy navigation.

**2. Order Management:**

- Customers can view order history and track their purchases.
- Admins can manage order status (pending, shipped, completed, canceled).

**3. Authentication and Authorization:**

- Secure login and registration.
- Role-based access (customers, admin, superadmin).

## Troubleshooting

- **Database Connection Issues**: Verify the connection string in `appsettings.json` and ensure SQL Server is running.
- **Missing Dependencies**: Run `dotnet restore` to install required NuGet packages.
- **Migrations Not Applied**: Ensure the correct database is specified and run `Update-Database` again.
