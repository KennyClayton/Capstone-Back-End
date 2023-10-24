import { useState, useEffect } from "react";
import ProjectCard from "./ProjectCard";
import { getProjects, getUserProjects } from "../../managers/projectManager";
import { getUsers } from "../../managers/userProfileManager";

export default function ProjectList({ setDetailsProjectId }) {
  const [projects, setProjects] = useState([]); // When the page loads, the "projects" variable gets filled with a list of all projects. How? Because the useEffect below says to run the getAllProjects function. We ARE NOT displaying these projects yet. We are just getting them at the outset here and STORING them in the "projects" variable. How did "projects" variable get filled up? with the getAllProjects function below.
  const [userProfiles, setUserProfiles] = useState([]); // Same here as above. userProfiles is storing all user profiles once the useEffect below runs.
  const [projectsByUserId, setProjectsByUserId] = useState([]); 
  // IMPORTANT - This projectsByUserId variable gets filled up with a list of projects. How? when the useEffect runs, it will call the getAllProjectsByUserId function. That function is defined above the useEffect. Look at that getAllProjectsByUserId function and you will see that it calls ANOTHER function "getUserProjects" that we defined and imported from projectManager.js.
  // VERY IMPORTANT - This is where we connect front and back end. The "getUserProjects" function in projectManager.js says to GET data from the server. But where on the server? At the "/user-projects" endpoint. How do we know the server has an endpoint with that name "user-projects"? Because we defined one in ProjectController.cs



  const getAllProjects = () => { // define what happens when getAllProjects function is called. It will run the fetProjects function and then it will set the state of "projects". 
    //* IMPORTANT - The getProjects function is defined in projectManager.js. But the function is called here below. 
    getProjects().then(setProjects);
  };

  const getAllUserProfiles = () => {
    getUsers().then(setUserProfiles);
  };

  const getAllProjectsByUserId = () => { // define this function. When the function runs, what happens?
    getUserProjects().then(setProjectsByUserId) // When it runs, this function will get projects by a user's Id that matches the projects UserProfileId.
  }

// Can I get a list of all project assignments? The relationship between a Project object and a Worker is the project.Id and the projectAssignment.projectId. Garrett is not directly associated with a project assignment. Only Tyler is. So Garrett is associated with a projectassignment via his 

  // We already have "projects" and "userProfiles" as variables above. Recall that we set the initial states of those to empty arrays. We want to now run the useEffect which will call these functions and fill those variables above with all projects and users. This useEffect is called a React "hook". Again, this will update that "projects" variable when the useEffect runs. When is that? When this ProjectsList.js component mounts. Since we just want the useEffect to set state at the initial rendering of this component, we will NOT put any dependency into the empty array at the end of this useEffect. 
  useEffect(() => {
    getAllProjects();
    getAllUserProfiles();
    getAllProjectsByUserId();
  }, []);

  return (    
    <>
      <h2>Your Projects</h2>
      {projectsByUserId.map((project) => (         
            <ProjectCard
              project={project}
              // workerUserProfileId={project.workerUserProfileId} // Add workerUserProfileId prop
              setDetailsProjectId={setDetailsProjectId}
              key={`project-${project.id}`}
            >
            </ProjectCard>            
          ))}
    </>
  );
}

// //* IMPORTANT - This component is a CHILD to Projects.js component
//When ProjectList function runs, it will set the state of userProfileData to whatever is stored in userProfileDataFromAPI AND it will map over the projects list, render each project object as a ProjectCard using the props project, setDetailsProjectId etc...

// So in the browser, we signed into Cory Cotton's account and he has a UserProfile Id of 5.
// Due to having these two useStates up top:
  // The browser is now holding a PROJECT with Id of 1. It is associated with UserProfile Id 5, which is Cory Cotton.
  // So the browser is now holding a user profile object in state after this component was rendered.
// How do we know this? Open the dev tools in the browser and look at the COmponents tab and look for the ProjectList component in the list. CLick on it and it shows you the State of each useState we have in the above code.

//* IMPORTANT - We are getting ALL users and ALL projects with the useEffect which calls the getAll functions which gets all users and all projects. So how do we end up with only one user profile in our State on the ProjectList component?
  //$ Because we UPDATED the state of "setProjects" by telling it to 