# Full Stack Application for my Capstone Project
Name of Project: DudeWorkIt

## Description
This project is designed to be used by two types of users: workers and customers.

_Worker users_

> Workers are able to view projects created by customers. //READ

> Workers can claim the projects created by customers, which places that project in the list of projects assigned to that worker. That claimed project is no longer available for other workers. //UPDATE

> Workers can assign a claimed project to another worker, however. //CREATE and UPDATE

_Question: It sounds like we are updating; are you sure this is really creating? Yes. When a worker assigns an existing project to himself, a new object is created and stored in the database as a new ProjectAssignment object in the ProjectAssignment table._


_Customer users_

> Customers are able to view a list of their created projects.

> Customers can also delete their own projects.

> Customers are able to create new projects for workers to see and claim as their own.

## Table of Contents
- [Technologies](#technologies)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)

## Technologies
- .NET
- C#
- Javascript (React)
- CSS
- HTML

## Installation
How to install and set up the project. Include any prerequisites or dependencies that need to be installed beforehand.

1. Download and install Node.js from
    ```bash
   https://nodejs.org/en/download.
   ```
2. Clone the repository by running this command:
    ```bash
    git clone https://github.com/KennyClayton/Capstone-Back-End.git
    ```

3. Navigate to the project directory DOUBLE CHECK TO SEE HOW IT IS CLONED AND WHERE TO SEE CHANGE DIRECTORY INTO...CAPSTONE-BACK-END???? OR NO?:
    ```bash
    cd Capstone-Back-End/client
    ```

4. Install dependencies. This command will download and install all dependencies listed in the package.json file:
    ```bash
    npm install
    ```

## Usage
Explain how to use your application. Provide examples and describe any commands or inputs users need to know.

**To start the application:**
   From Bash:
       navigate to the client folder
       Run this command, which will locate the package.json file and start the server:
   ```bash
   _npm start_
   ```
   
   From VSCode:
       navigate to the "Run and Debug" button
       click the play button to "Start Debugging"
       The application should open in your default browser at `http://localhost:3000/login`

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
