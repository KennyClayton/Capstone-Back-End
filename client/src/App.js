import { useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { tryGetLoggedInUser } from "./managers/authManager";
import { Spinner } from "reactstrap";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews"; 


//*IMPORTANT - In short, this App function gets data and stores it for use by the return statement at the bottom. But this function is not called here. It is exported and used (called) in index.js.
function App() {
  
  const [loggedInUser, setLoggedInUser] = useState(null);

  // // This useEffect fetches user data only once, when the component mounts. If we inserted a dependency array then the useEffect would run each time that dependency array changed
  // useEffect(() => {
  //   // user will be null if not authenticated
  //   tryGetLoggedInUser().then((user) => { 
  //     setLoggedInUser(user); 
  //   });
  // }, []);

  // // wait to get a definite logged-in state before rendering
  // if (loggedInUser === undefined) {
  //   return <Spinner />;
  // }

  return (
    <>
      <NavBar 
      loggedInUser={loggedInUser} 
      setLoggedInUser={setLoggedInUser} 
      />
      <ApplicationViews
        loggedInUser={loggedInUser}   //* IMPORTANT - We can pass this loddegInUser as a prop to ApplicationViews....AND....we can continue passing it as a prop to any other modules. In other words, from any parent module to any child module
        setLoggedInUser={setLoggedInUser}
      />
    </>
  );
}

export default App;


//~ NOTES:
  //$ The browser will read the code top to bottom. It reads index.html first, which refers to index.js "root" which refers to this file App.js which is the "entry point" for the whole application. This App.js file starts the cascade of all other files used in building the application and rendering its components to the DOM.
  //$ The first function here in App.js is tryGetLoggedInUser
      //^ tryGetLoggedInUser function is called by the useEffect hook, which "attempts to get the currently logged-in user by calling tryGetLoggedInUser() and sets the loggedInUser state based on the result. This ensures that the user's authentication status is checked when the component is mounted."
    //@ MODULE JUMP to authManager.js where the tryGetLoggedInUser function is defined. It makes a fetch call to the API (back end).
    //* IMPORTANT - this tryGetLoggedInUser function is making the fetch call NOW, when App.js runs into the useEffect that calls tryGetLoggedInUser. All useEffects run once when the page is first rendered (when App.js component "mounts"). Side note: All useStates also run initially on mount.
  //$ It fetches user profile data from the "/me" URL path which "typically represents an endpoint on your server where user-related data is retrieved based on the user's authentication status."
    //@ MODULE JUMP to AuthController.cs where the fetch call from authManager.js is received and handled (controlled). This is now the back end. Inside the AuthController.cs code, we have already defined the "/me" endpoint (location in the server) so that when the HTTP request arrives to the server (from the tryGetLoggedInUser function in App.js), the HTTP request knows exactly where to go. All the HTTP request has to do is show the server the "/me" endpoint, it goes to it and finds the instructions for what to do at that endpoint.
    //* IMPORTANT - this tryGetLoggedInUser function sent the HTTP request to the back end server at the "/me" endpoint where it finds a block of code saying what to do (in this case, it says to return the username, email and role data for that user trying to log in i think)
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 
  //$ 