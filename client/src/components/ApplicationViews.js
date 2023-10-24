import { Route, Routes } from "react-router-dom"; 

import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Projects from "./projects/Projects"; // this is a component that creates a list of projects
import ProjectList from "./projects/ProjectsList";
import ProjectDetails from "./projects/ProjectDetails";


// there are two props being passed through this function: loggedinuser and setloggedinuser
//? what is a prop?
export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Projects />
            </AuthorizedRoute>
          }
        />
      <Route
          path="login" // when the url ends with /login then display the "Login" component and run setLoggedInUser function
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="details"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <ProjectDetails />
            </AuthorizedRoute>
          }
        />
        {/* Below: 
        "The Route group create two routes for workorders. 
        The route marked index will match to workorders with no extra url segments. 
        The create route will match /workorders/create." */}
        <Route path="workorders">
          {/* <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <WorkOrderList />
              </AuthorizedRoute>
            }
          /> */}
          {/* <Route
            path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <CreateWorkOrder />
              </AuthorizedRoute>
            }
          /> */}
        </Route>
        {/* <Route
          path="employees"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <UserProfileList />
            </AuthorizedRoute>
          }
        /> */}
        
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}


//! ISSUE - RENDER PROJECT DETAILS - 10/22/2023
  //~ I need to complete the ProjectDetails.js component which I have set to render at the url ending with .details (above)