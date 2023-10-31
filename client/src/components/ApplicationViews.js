import { Route, Routes, useParams } from "react-router-dom";

import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Projects from "./projects/Projects"; // this is a component that creates a list of projects
import ProjectDetails from "./projects/ProjectDetails";
import { useEffect, useState } from "react";
import { getProjects, getProjectById } from "../managers/projectManager";

// there are two props being passed through this function: loggedinuser and setloggedinuser
//? what is a prop?
export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  const [projects, setProjects] = useState([]); // When the page loads, the "projects" variable gets filled with a list of all projects. How? Because the useEffect below says to run the getAllProjects function. We ARE NOT displaying these projects yet. We are just getting them at the outset here and STORING them in the "projects" variable. How did "projects" variable get filled up? with the getAllProjects function below.
  const [project, setProject] = useState(null); // unlike above, this one is used for holding a single project (the one we found by Id) in the project variable (see it used on line 26 or so when setProject is called, which sets the state of project with a single project)
  const { id } = useParams(); // Get the project ID from the URL

  const getAllProjects = () => {
    getProjects().then(setProjects);
  };

  // Fetch the project details based on the ID from the URL
  const getProjectDetails = () => {
    if (id) {
      getProjectById(id).then((data) => { //call the getProjectById function and hand it an id to work with and then that function will run to find a matching project
        setProject(data);
      });
    }
  };

  useEffect(() => {
    getAllProjects();
    getProjectDetails(); // Fetch project details when the ID changes
  }, [id]);

  return (
    <Routes>
      <Route path="/">
        <Route 
          index
          element={ 
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Projects
              projects={projects}
              setProjects={setProjects}
              project={project}
              setProject={setProject} 
              loggedInUser={loggedInUser} />
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
          path="projects/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              {project ? (
                <ProjectDetails
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
        {/* Below: 
        "The Route group create two routes for workorders. 
        The route marked index will match to workorders with no extra url segments. 
        The create route will match /workorders/create." */}
        {/* <Route path="workorders"> */}
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
        {/* </Route> */}
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
