//What does this module do? 

//We defined a variable and initialized it with a string. The string is the beginning part of the url path we need for each function's fetch request below. Just a shorter way to code below because we can just reference this variable instead of re-typing /api/auth for each finction below.
const apiUrl = "/api/auth";

//What does this login function do?
//A: initiates a login request to the server.
export const login = (email, password) => {
  return fetch(apiUrl + "/login", {
    method: "POST",
    credentials: "same-origin",
    headers: {
      Authorization: `Basic ${btoa(`${email}:${password}`)}`,
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.resolve(null);
    } else {
      return tryGetLoggedInUser();
    }
  });
}; 

export const logout = () => {
  return fetch(apiUrl + "/logout"); 
};


// THE PROBLEM: 
  // When I start the debugger and my application runs in the browser, i get a runtime error overlay in the browser instead of my application. 
  // Notice that the page loads for a split-second before the runtime error pops up
// STEPS TO RESOLVE:
  //1. Review the overlay error message which says "Uncaught runtime errors: × ERROR projectAssignmentsByUserId.map is not a function TypeError: projectAssignmentsByUserId.map is not a function"
  //2. Review the console for errors. Right click and choose "Inspect" in Chrome to view the console for any errors. 
  //3. We do have an error: "GET http://localhost:3000/api/auth/Me 404 (Not Found)" and it referenced authManager.js:41 as the file and code line as the problem. 
  //4. So we have two errors to look at. We also have the line of code where it fails. Look at those lines of code.
    // RUNTIME ERROR: this one references projectAssignmentsByUserId.map is not a function. So I global search VSCode project for "projectAssignmentsByUserId"
    // CONSOLE ERROR: this one references authManager.js: 41, so we can look at line 41 of that file.
  //5. Let's start with the Console error and what the authManger file does. It's important to understand the job of this file.
      // If you're not sure, feed the authManager.js code to ChatGPT and ask for its explanation. Essentially, this file houses some login functions that return fetch calls to the server...including retrieving the current user's information. (This is actually our first hint to the problem). 
      // Next, look at what the function referenced by the error (tryGetLoggedInUser) is supposed to do. The error tells you what line the code fails on. We see the tryGetLoggedInUser function and see that it is supposed to retrieve something from the url ending with "/api/auth/Me". Since the error is 404 Not Found, we know that that url ending in "/api/auth/Me" cannot be found. 
  //6. Why can't it be found though? 
    // The url ending in "/api/auth/Me" is not found because it is looking for a specific logged in user's information so the browser can display that user's list of projects from the database. But no one is logged in yet. So when the application tries to start up and display a user's projects list, it cannot find any user, and therefore it cannot find any projects.
  //SUMMARY EXPLANATION: When we run npm start and then click the debugger, the browser will read and execute our code. The app will "start up", which means once the code is compiled, the browser opens the url "http://localhost:3000/" which is the address for the home page of any logged in user. That url is the same, regardless of who is logged in. But what if nobody is logged in? Then the server cannot provide a list of projects. If no one is logged in, there is no list of projects to map over.
  // This is also why we see the runtime error about "projectAssignmentsByUserId.map" overlayed on the web page. 
    // For example, when a worker tries to log in, the worker should have a list of assigned projects showing up for them, which is a list that is retrived by mapping over the list of projectAssignments in the database (for that user, which is by that user's Id associated with each projectAssignment). Well, again, if no one is logged in, then the .map method does not have a user whose list of assignments it can map over.
//SOLUTION:
    // Make sure our code tells the application go to the login screen at "http://localhost:3000/login" when it starts instead of the address "http://localhost:3000/"
      //1. Stop the debugger first.
      //2. 


export const tryGetLoggedInUser = () => {
  return fetch(apiUrl + "/Me").then((res) => {
    return res.status === 401 ? Promise.resolve(null) : res.json();
  });
};


//^ Below will send the registered user's input to the database to register the new user
export const register = (userProfile) => {
  userProfile.password = btoa(userProfile.password);
  return fetch(apiUrl + "/register", {
    credentials: "same-origin",
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userProfile),
  }).then(() => fetch(apiUrl + "/me").then((res) => res.json()));
};

// utils/auth.js

// // Function to check if the user is logged in...I got this from ChatGPT but I dont see any tokens in the dev tools
// export const isLoggedIn = () => {
//   // Check if the authentication token is present in local storage
//   return localStorage.getItem('authToken') !== null;
// };
