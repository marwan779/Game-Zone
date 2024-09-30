Game Zone
---------
Project Name: Game Zone

Description
Game Zone is a web application designed to manage a collection of games. The application provides full CRUD 
(Create, Read, Update, Delete) operations for managing games in the system. It also supports features like 
adding cover images for each game, categorizing games, and associating games with different devices.

Prerequisites
-------------

.NET Core SDK 6.0 or higher
SQL Server (or any other supported database)
A suitable IDE like Visual Studio or VS Code


json
----

Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=yourserver;Database=GameZoneDB;User Id=youruser;Password=yourpassword;"
}


Features
--------

CRUD Operations for Games: Add, edit, delete, and view details of games.
Game Cover Upload: Upload a cover image for each game.
Game Categories: Assign categories to games (e.g., Action, RPG, Puzzle).
Device Support: Associate games with devices like PC, PlayStation, Xbox, etc.
Responsive UI: Built with Bootstrap to ensure a responsive and modern design.

Technologies
------------
ASP.NET Core MVC for the application framework
Entity Framework Core for database operations
SQL Server as the database (or any other supported database)
Bootstrap for styling and responsive design
IFormFile for handling file uploads (game cover images)
LINQ for data querying
JavaScript for frontend interactivity (optional)
Project Structure
The project follows the standard ASP.NET Core MVC structure:

scss
----
Copy code
/Controllers      - Contains the MVC controllers (e.g., GamesController)
/Models           - Entity models (e.g., Game, Category, Device) and ViewModels (e.g., CreateGameFormViewModel)
/Views            - Razor views for game management (CRUD views)
/Services         - Business logic for handling CRUD operations and file uploads
/wwwroot          - Static files such as CSS, JavaScript, images (including uploaded game covers)
/Migrations       - Entity Framework Core migration files for database setup

Screenshots
-----------
![Screenshot (256)](https://github.com/user-attachments/assets/abcd7067-4b77-42dd-b155-7802d60545cc)
![Screenshot (255)](https://github.com/user-attachments/assets/a2e38c7b-0c2d-459e-bd6a-98c9cf8c3f84)
![Screenshot (254)](https://github.com/user-attachments/assets/1ee2b771-d5b8-48b7-a889-347cd6078f24)
![Screenshot (253)](https://github.com/user-attachments/assets/d0dc4bca-960a-41f0-8072-703c4a0355f1)
![Screenshot (252)](https://github.com/user-attachments/assets/fa6ab262-f5d3-48b3-b229-696477ce0cf7)
![Screenshot (251)](https://github.com/user-attachments/assets/0ea55850-a5af-4db7-bb60-fb162ab33b32)
