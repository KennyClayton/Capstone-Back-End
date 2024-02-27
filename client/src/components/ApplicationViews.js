import { Route, Routes, useParams } from "react-router-dom";

import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Projects from "./projects/Projects"; // this is a component that creates a list of projects
import ProjectDetails from "./projects/ProjectDetails";
import { useEffect, useState } from "react";
import { getProjects, getProjectById } from "../managers/projectManager";
import AssignedProjectDetails from "./projects/AssignedProjectDetails";

//*IMPORTANT - In short, this ApplicationViews function gets data using two functions: getAllProjects and getProjectDetails. This function then stores that data in the useState variables for use by the return statement at the bottom. But this function is not called here. It is exported and used (called) in App.js.
//? Further explanation: What is the purpose of ApplicationViews function? To define useStates, useParams and to retrieve a list of all projects at the outset of this component before it renders (via the return statement at the bottom).
// there are two props being passed through this function: loggedinuser and setloggedinuser
//? what is a prop? it is carrying over data or functions from a parent component to a child component
export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  const [projects, setProjects] = useState([]); // When the page loads, the "projects" variable gets filled with a list of all projects. How? When this code is read by the browser, it will run all useEffects on this page. And because the useEffect below says to run the getAllProjects function. We ARE NOT displaying these projects yet. We are just getting them at the outset here and STORING them in the "projects" variable. How did "projects" variable get filled up? with the getAllProjects function below.
  const [project, setProject] = useState(null); // unlike above, this one is used for holding a single project (the one we found by Id) in the project variable (see it used on line 26 or so when setProject is called, which sets the state of project with a single project)
  const { id } = useParams(); // Get the project Id from the URL using the useParams hook here.

  const getAllProjects = () => {
    //this function calls getProjects in projectManager.js which fetches all projects from the database and the sets the value of "projects" variable above to that list of projects
    getProjects().then(setProjects);
  };

  //? What ID are we grabbing in the useParams? a single project Id.
  // Now let's fetch the project details based on the Id from the URL, which we already retrieved from line 17 useParams hook
  // Notice we defined this getProjectDetails function here instead of in projectManager.js; but why? Because we already have the list of projects from the database, we just need to grab the DETAILS of all those projects now. Which project though?
  //*IMPORTANT - The whole purpose of this "getProjectDetails" function below is to set the state of the "project" variable above so the code in our return statement can use "project" variable in the return statement below for the relevant project. That's why we use state, to give the return code the correct project (data) to work with. If project 4 is being viewed, then we grab the 4 from the url and that starts the cascade of code that informs our return statement to use project 4 details.
  const getProjectDetails = () => {
    if (id) {
      // if the id integer (example: 4) from the browser url is 4...
      getProjectById(id).then((data) => {
        // ...then call the getProjectById function here, hand it an id to work with and then that function will run to find a matching project
        setProject(data); //...then set the state of "project" variable above (on line 16) to that particular project object from the database
      });
    }
  };

  useEffect(() => {
    getAllProjects();
    getProjectDetails(); // Fetch project details when the ID changes
  }, [id]); // Placing "id" inside the dependency array [] ensures this useEffect will run again anytime the id changes. The id will change when a particular project is selected.

  //~ AT THIS POINT, AFTER THE USEEFFECT HAS BEEN EXECUTED, THE CODE HAS RETRIEVED TWO THINGS:
  // A LIST OF ALL PROJECTS which was then stored in "projects" variable (ie - the state of the "projects" variable is now a list of all projects)
  // A SINGLE PROJECT which was then stored in the "project"variable aboce. ie - project 4 as an example.
  //*IMPORTANT - NOW, THE RETURN STATEMENT BELOW HAS TWO VARIABLES WITH DATA IN THEM THAT THE RETURN STATEMENT'S CODE CAN REFERENCE IN ORDER TO DISPLAY THE ACCURATE DATA (IE - PROJECT 4 AND ALL PROJECTS)

  return (
    <Routes>
      <Route path="/">
        <Route index element={<Login setLoggedInUser={setLoggedInUser} />} />
        <Route path="/login" element={<Login setLoggedInUser={setLoggedInUser} />} />
        <Route path="/dashboard" // when the url ends with /dashboard then display the "Projects" component // and run setLoggedInUser function?
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Projects
                projects={projects}
                setProjects={setProjects}
                project={project}
                setProject={setProject}
                loggedInUser={loggedInUser}
              />
            </AuthorizedRoute>
          }
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="/dashboard/projects/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              {project ? (
                <ProjectDetails
                  project={project}
                  setProjects={setProjects}
                  setProject={setProject}
                  loggedInUser={loggedInUser}
                />
              ) : (
                <p>Loading...</p>
              )}
            </AuthorizedRoute>
          }
        />
        <Route
          path="/dashboard/assignedProjects/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              {project ? (
                <AssignedProjectDetails
                  project={project}
                  setProject={setProject}
                  loggedInUser={loggedInUser}
                />
              ) : (
                <p>Loading...</p>
              )}
            </AuthorizedRoute>
          }
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
