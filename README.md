NZWALK .NET RESTful APIs
This repository contains the NZWALK project, a collection of .NET RESTful APIs designed to provide information on walks, trails, and natural landmarks across New Zealand. Built using .NET, this project serves as a robust backend for applications needing access to New Zealand’s rich walk data, complete with CRUD operations and secure authentication.

Table of Contents
Features
Technologies
Setup
Usage
API Endpoints
Contributing
License
Features
CRUD Operations: Fully implemented CRUD functionality for managing walk data.
Authentication & Authorization: Secure access using JWT for API endpoints.
Data Validation: Validates incoming data for API endpoints to ensure data integrity.
Error Handling: Consistent error handling for predictable API responses.
Scalability: Designed for scalability and extensibility.
Technologies
.NET Core 6.0 – Backend framework
Entity Framework Core – ORM for database interactions
SQL Server – Primary database for storing walk information
JWT – JSON Web Tokens for secure access control
Setup
Prerequisites
.NET SDK 6.0
SQL Server
Postman or any REST API client (for testing)
Installation
Clone the repository:

bash
Copy code
git clone https://github.com/itsumarsoomro/NZWALK-.NetRestfulAPIs.git
cd NZWALK-.NetRestfulAPIs
Install Dependencies: Restore NuGet packages by running:

bash
Copy code
dotnet restore
Database Setup:

Configure your SQL Server connection string in appsettings.json:
json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=NZWalksDB;Trusted_Connection=True;"
}
Run the migrations to create the database schema:
bash
Copy code
dotnet ef database update
Run the Application:

bash
Copy code
dotnet run
The API should now be running on http://localhost:5000.

Usage
Test the API using Postman or any REST client. You can use the API Endpoints section as a guide to the available routes and parameters.

Authentication
The API uses JWT tokens for authentication. You’ll need to obtain a token by sending a login request to the authentication endpoint and including it in your requests as a Bearer token.

API Endpoints
Here’s a quick overview of the main endpoints. Please note that paths may require authentication.

Authentication
POST /api/auth/login – Authenticate a user and receive a JWT token.
Walks
GET /api/walks – Retrieve a list of all walks.
GET /api/walks/{id} – Retrieve details for a specific walk by ID.
POST /api/walks – Create a new walk (requires authentication).
PUT /api/walks/{id} – Update an existing walk (requires authentication).
DELETE /api/walks/{id} – Delete a walk by ID (requires authentication).
Trails
GET /api/trails – List all trails.
GET /api/trails/{id} – Retrieve details for a specific trail.
POST /api/trails – Create a new trail (requires authentication).
PUT /api/trails/{id} – Update an existing trail (requires authentication).
DELETE /api/trails/{id} – Delete a trail by ID (requires authentication).
Regions
GET /api/regions – List all regions.
GET /api/regions/{id} – Retrieve details for a specific region.
Contributing
Contributions are welcome! Please follow these steps:

Fork the repository.
Create a feature branch (git checkout -b feature-name).
Commit your changes (git commit -m "Add feature").
Push to the branch (git push origin feature-name).
Open a pull request.
License
This project is licensed under the MIT License.

