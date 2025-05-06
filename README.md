# Currency Trading Monitor with Real-Time Simulation

## Description
This project simulates live currency trading by periodically updating the minimum and maximum values of currency pairs. These updates are reflected in real time on the frontend. The data is fetched from a SQL Server database, and changes are made every 2 seconds to simulate market activity.

### Key Features
- Real-time updates of currency pairs.
- Simulated changes in the minimum and maximum values.
- Data fetched from and updated in a SQL Server database.
- Simple and clean UI with dynamic table updates.

---

## Technologies Used
- **Backend:** ASP.NET Core MVC
- **Frontend:** HTML, CSS, JavaScript (jQuery)
- **Database:** SQL Server
- **Entity Framework Core** for ORM

---

## Setup and Installation

To run this project locally, follow the instructions below:

### Prerequisites:
- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a local instance of SQL Server
- [Node.js and npm](https://nodejs.org/) (for frontend dependencies)

### Steps:
1. Clone the repository:
    ```bash
    git clone <repository-url>
    cd <project-folder>
    ```

2. Install required .NET packages:
    ```bash
    dotnet restore
    ```

3. Setup the database:
    - Create a SQL Server database (if not already created) and configure the connection string in `appsettings.json`.
    - Run the migrations to create necessary tables:
    ```bash
    dotnet ef database update
    ```

4. Start the application:
    ```bash
    dotnet run
    ```

5. Open the web application:
    - Open your browser and navigate to `http://localhost:5000`.

---

## Folder Structure
