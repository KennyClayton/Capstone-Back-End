import { useState, useEffect } from "react";
import ProjectCard from "./ProjectCard";
import { getProjects } from "../../managers/projectManager";
import { getUsers } from "../../managers/userProfileManager";

export default function ProjectList({ setDetailsProjectId }) {
  const [projects, setProjects] = useState([]); // When the page loads, the "projects" variable gets filled with a list of all projects. How? Because the useEffect below says to run the getAllProjects function. We ARE NOT displaying these projects yet. We are just getting them at the outset here and STORING them in the "projects" variable. How did "projects" variable get filled up? with the getAllProjects function below.
  const [userProfiles, setUserProfiles] = useState([]); // Same here as above. userProfiles is storing all user profiles right now.
  
  const getAllProjects = () => {
    getProjects().then(setProjects);
  };

  const getAllUserProfiles = () => {
    getUsers().then(setUserProfiles);
  };

  // We already have "projects" and "userProfiles" as variables above, holding all projects and users. But now we can implement a hook (a useEffect) to update that "projects" variable at any time, or just when this ProjectsList.js component mounts. Since we just want the useEffect to set 
  useEffect(() => {
    getAllProjects();
    getAllUserProfiles();
  }, []);

  return (
    
    <>
      <h2>Your Projects</h2>
      {projects.map((project) => {
        // Find the user profile corresponding to this project
        const userProfile = userProfiles.find(up => up.Id === project.UserProfileId);
        if (userProfile) {
          // console.log("UserProfile:", userProfile);

          return (
            
            <ProjectCard
              project={project}
              setDetailsProjectId={setDetailsProjectId}
              key={`project-${project.id}`}
            >
            </ProjectCard>
            
          );
        }
        return null; // Handle the case when no matching user profile is found
      })}
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