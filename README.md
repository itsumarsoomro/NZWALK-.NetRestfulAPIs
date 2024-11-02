# NZWALK .NET RESTful APIs

A collection of .NET RESTful APIs that provides information on New Zealand's walks, trails, and natural landmarks. This project includes secure, reliable endpoints to manage and access walk data for applications featuring New Zealand's natural beauty.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Features

- **CRUD Operations:** Full Create, Read, Update, and Delete functionality for walk and trail data.
- **Secure Authentication & Authorization:** JWT-based security for protected endpoints.
- **Data Validation:** Ensures incoming data meets required structure and integrity.
- **Error Handling:** Consistent error responses for seamless client-side handling.
- **Scalability:** Designed to scale with ease for additional endpoints and data sources.

## Technologies

![image](https://github.com/user-attachments/assets/9851c864-4135-41d6-8df5-698fe819bed7)

## Setup

### Prerequisites

- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server (local or cloud instance)
- Postman or any REST client (for testing)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/itsumarsoomro/NZWALK-.NetRestfulAPIs.git
   cd NZWALK-.NetRestfulAPIs
   ```

2. **Install Dependencies:**
   ```bash
   dotnet restore
   ```

3. **Database Setup:**
   * Update the SQL Server connection string in `appsettings.json`:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER;Database=NZWalksDB;Trusted_Connection=True;"
       }
     }
     ```
   * Run migrations to create the database schema:
     ```bash
     dotnet ef database update
     ```

4. **Run the Application:**
   ```bash
   dotnet run
   ```
   The API will be running at `http://localhost:7033`.

## Usage

Use Postman or any REST client to test the API. Refer to the API Endpoints section for routes and parameters.

### Authentication

The API uses JWT tokens for secure access. Obtain a token from the login endpoint and include it as a Bearer token in your requests.

## API Endpoints

### Authentication
* `POST /api/auth/Login` - Authenticate and receive a JWT token.
* `POST /api/auth/Register` - Register

### Images
* `POST /api/Images/Upload` - Upload Images

### Student
* `GET /api/Student` - Get all student.
* 
### Walks
* `GET /api/Walks` - Get all walks.
* `GET /api/Walks/{id}` - Get details for a specific walk.
* `POST /api/Walks` - Create a new walk (requires authentication).
* `PUT /api/Walks/{id}` - Update a walk (requires authentication).
* `DELETE /api/Walks/{id}` - Delete a walk (requires authentication).

### Regions
* `GET /api/Regions` - List all regions.
* `GET /api/Regions/{id}` - Retrieve details for a specific region by id.
* `GET /api/Regions/{code}` - Retrieve details for a specific region by code.
* `POST /api/Regions` - Create a new Regions (requires authentication).
* `PUT /api/Regions/{id}` - Update a Regions (requires authentication).
* `DELETE /api/Regions/{id}` - Delete a Regions (requires authentication).

## Contributing

Contributions are welcome! To contribute:

1. **Fork the repository**
2. **Create a new feature branch:**
   ```bash
   git checkout -b feature-name
   ```
3. **Commit your changes:**
   ```bash
   git commit -m "Add feature description"
   ```
4. **Push the branch:**
   ```bash
   git push origin feature-name
   ```
5. **Open a pull request**

## License

This project is licensed under the MIT License. See the LICENSE file for details.
