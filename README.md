# Capstone Project
Full Stack Application

## Table of Contents
- [Description](#description)
- [Technologies](#technologies)
- [Try It Out!](#try-it-out)


## Description
**Name of Project: DudeWorkIt**

This project is designed to be used by two types of users: customers and workers.

_Customer users_

> Customers can create new projects. //CREATE
> 
> Customers can view a list of their own projects. //READ
> 
> Customers can update their own projects' type, date and description fields. //UPDATE
> 
> Customers can delete their own projects. //DELETE


_Worker users_

> Workers can assign a claimed project to another worker. //CREATE and UPDATE

_Question: It sounds like we are updating a project entity; how is this creating?_

_Answer: When a worker assigns an existing project to himself, a new _ProjectAssignment_ object is created and stored in the database in the ProjectAssignment table._

> Workers can view a list of projects created by customers (until a project is claimed by a worker). //READ

> Workers can claim projects created by customers, which moves that project to the worker's list of claimed projects. That claimed project is no longer available for other workers. //UPDATE

> Workers will be able to complete projects. //FUTURE FEATURE




## Technologies
- .NET
- C#
- Javascript (React)
- CSS
- HTML


## Try it out!

**Installations:**

1. Install Git from https://git-scm.com/

2. Install Node.js from https://nodejs.org/en/download

3. Install .NET Runtime 8.0.2 or later from https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime?cid=getdotnetcore&os=windows&arch=x64

4. Clone the repository by opening Git Bash and running this command:
    ```bash
    git clone https://github.com/KennyClayton/Capstone-Back-End.git
    ```

5. Then navigate to the client folder within the project directory with this command:
    ```bash
    cd Capstone-Back-End/client
    ```

6. Run this command to download and install all dependencies:
    ```bash
    npm install
    ```

7. From VS Code's Activity Bar on the left, click Extensions and install the C# extension: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp



**To start the application:**

8. Navigate up to the top-level directory (Capstone-back-end) and run each of these commands:

    ```bash
    dotnet tool install --global dotnet-ef --version 8.0.2
    ```
    
    ```bash
    dotnet user-secrets init
    ```
    
    ```bash
    dotnet user-secrets set AdminPassword password
    ```
    
    ```bash
    dotnet user-secrets set DudeWorkItDbConnectionString 'Host=localhost;Port=5432;Username=postgres;Password=password;Database=DudeWorkIt'
    ```

   ```bash
    dotnet restore
    ```

    ```bash
    dotnet build
    ```

    ```bash
    dotnet ef migrations add InitialCreate
    ```

    ```bash
    dotnet ef database update
    ```

    ```bash
    cd client
    ```

    ```bash
    npm install (MAY NOT NEED THIS LINE SINCE ALREADY INSTALLED ABOVE)
    ```

**Test the Setup**

1. In VSCode, Click the "Run and Debug" button on the Activity Bar to "Start Debugging"

2. From the client folder run this command to locate the package.json file and start the server:
    ```bash
    run npm start
    ``` 

You should see the login view when the UI opens.

Attempt to login with cody@jones.com and "password" for the password

If the setup succeeded, the application should open in your default browser at `http://localhost:3000/dashboard` and you should see navbar links and logout button.

