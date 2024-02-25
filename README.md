# Capstone Project
Full Stack Application

## Table of Contents
- [Description](#description)
- [Technologies](#technologies)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)


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


## Installations

**To run this application on your device, you'll need to install Git and Node.js from https://git-scm.com/ and https://nodejs.org/en/download**

1. Next, clone the repository by opening Git Bash and running this command:
    ```bash
    git clone https://github.com/KennyClayton/Capstone-Back-End.git
    ```

2. Then navigate to the project directory with this command:
    ```bash
    cd Capstone-Back-End/client
    ```

3. Finally, download and install all dependencies:
    ```bash
    npm install
    ```

## Usage

**To start the application:**
1. From the client folder, run this command to locate the package.json file and start the server:
    
   ```bash
   npm start
   ```
2. From VSCode, Click the "Run and Debug" button on the Activity Bar to "Start Debugging"
3. The application should open in your default browser at `http://localhost:3000/login`

## Contributing
Guidelines for others who may want to contribute to this project. Include information about how they can submit bug reports, suggest improvements, or contribute code.

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature/your-feature`).
6. Create a new Pull Request.

## License
    No license.
