import ProjectCard from "./ProjectCard";

export default function ProjectList({ setDetailsProjectId, setProject, user, projectsByUserId}) {

  return (    
    <>
      <h2>Your Projects</h2>
      {projectsByUserId.map((project) => (
            <ProjectCard
              project={project}
              setProject={setProject}
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