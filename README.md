# Project


## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## How to Run

### Backlog.Api (ASP.NET Core Web API)

1. Navigate to the API directory:
   ```bash
   cd src/Backlog.Api
   ```

2. Ensure the database is initialized:
   ```powershell
   .\resetdb.ps1
   ```

3. Run the API server:
   ```bash
   dotnet run
   ```

   The API will be available at `https://localhost:5001` and Swagger documentation at `https://localhost:5001/swagger`

### Backlog.App (Angular Frontend)

1. Navigate to the app directory:
   ```bash
   cd src/Backlog.App
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   npm start
   ```

   The application will be available at `http://localhost:4200`

### Backlog.Cli (Command Line Interface)

1. Navigate to the CLI directory:
   ```bash
   cd src/Backlog.Cli
   ```

2. Build the CLI application:
   ```bash
   dotnet build
   ```

3. Run CLI commands:
   ```bash
   dotnet run -- [command] [arguments]
   ```

   Example:
   ```bash
   dotnet run -- authenticate --username admin --password password
   ```

## How to test
