import { useEffect, useState } from "react";
import ProjectList from "./ProjectsList";
import CreateProject from "./CreateProject"; // this is a component that creates a list of projects
import {
  createProject,
  createProjectAssignment, //function to POST a new projectAssignment
  getUserProjects,
  getWorkerProjectAssignments,
  getProjectAssignments, // this gets the whole list of projectAssignment objects from the database
  getAllUnassignedProjectAssignments, // this ONLY gets projectAssignments where no UserProfile is assigned (is null)
} from "../../managers/projectManager";
import { set } from "date-fns";
import ListOfAssignedProjects from "./AssignedProjectsList";
import ListOfUnassignedProjects from "./UnassignedProjectsList";

export default function Projects({
  loggedInUser,
  project,
  setProject,
  projects,
  setProjects,
}) {
  // this function renders two child components, ProjectList and ProjectDetails. We pass the loggedInUser as an object
  const [detailsProjectId, setDetailsProjectId] = useState(null);
  const [projectsByUserId, setProjectsByUserId] = useState([]); // IMPORTANT - This will be a list of Customer projects. This projectsByUserId variable gets filled up with a list of projects (which only have Customer UserProfiles). How? when the useEffect runs, it will call the getAllProjectsByUserId function. That function is defined above the useEffect. Look at that getAllProjectsByUserId function and you will see that it calls ANOTHER function "getUserProjects" that we defined and imported from projectManager.js.
  // VERY IMPORTANT - This is where we connect front and back end. The "getUserProjects" function in projectManager.js says to GET data from the server. But where on the server? At the "/user-projects" endpoint. How do we know the server has an endpoint with that name "user-projects"? Because we defined one in ProjectController.cs

  const [selectedProjectType, setSelectedProjectType] = useState("");
  // Here, useState initializes the state of projectData with an object containing these three properties and empty string values
  const [projectData, setProjectData] = useState({
    //this will allow us to use "projectData" variable to store the new data for a project when we are creating one.
    projectType: "",
    dateOfProject: "",
    description: "",
  });

  //~ ---------- BELOW handles getting and setting ALL ProjectAssignments ---------- //~
  const [projectAssignments, setProjectAssignments] = useState([]); // manage state of the list of ALL project assignments

  const getAllProjectAssignments = () => {
    getProjectAssignments().then(setProjectAssignments);
  };
  useEffect(() => {
    getAllProjectAssignments();
  }, []);
  //~ ---------- ABOVE handles getting and setting ALL ProjectAssignments ---------- //~

  //~ ---------- BELOW handles getting and setting ProjectAssignments by Id ---------- //~
  const [projectAssignmentsByUserId, setprojectAssignmentsByUserId] = useState(
    []
  ); // manage the state of projectAssignments by Id

  const getProjectAssignmentsByUserId = () => {
    getWorkerProjectAssignments(loggedInUser.id).then(
      setprojectAssignmentsByUserId
    );
  };

  useEffect(() => {
    // set the state of the list of projectAssignments by Id
    getProjectAssignmentsByUserId();
  }, [loggedInUser.roles]);
  //~ ---------- ABOVE handles getting and setting ProjectAssignments Id ---------- //~

  //~ ---------- BELOW handles getting and setting unassigned ProjectAssignments ---------- //~
  const [unassignedProjectAssignments, setUnassignedProjectAssignments] =
    useState([]); // manage state of this list of unassigned project assignments. initialize the state of unassignedProjectAssignments as an empty array, making it ready to receive a list of projectAssignment objects (that are not yet assigned to workers)

  const getUnassignedProjectAssignments = () => {
    getAllUnassignedProjectAssignments().then(setUnassignedProjectAssignments);
  };
  useEffect(() => {
    getUnassignedProjectAssignments();
  }, []); //! i could insert a dependency to watch the list of all unassignedProjectAssignments here. But I don't need to if I call the setUnassignedProjectAssignments function once a new projectAssignment is created (which will occur simultaneously when a customer creates a new project). So what do I enter as the new projectAssignment? That will keep the application up to date with the most recent list of unassigned projectAssignments. 
  //& What about when a user assigns a projectAssignment object to himself? That will update that projectAssignment in the database but what about the unassignedProject list? 
  // Because to have the most updated list of unassigned projects from the database, we need to check the list of ALL project assignments then, when i create a project and the setUnassignedProjectAssignments function is called, it will update the setUnassignedProjectAssignments variable, so if this useEffect is watching that variable, it will run the getUnassignedProjectAssignments function. NO! Because then it will create an infinite loop of getting and setting the state of unassigned projects

  //~ ---------- ABOVE handles getting and setting unassigned ProjectAssignments ---------- //~

  const getAllProjectsByUserId = () => {
    // define this function. When the function runs, what happens?
    getUserProjects().then(setProjectsByUserId); // When it runs, this function will get projects by a user's Id that matches the projects UserProfileId.
  };

  // We already have "projects" and "userProfiles" as variables above. Recall that we set the initial states of those to empty arrays. We want to now run the useEffect which will call these functions and fill those variables above with all projects and users. This useEffect is called a React "hook". Again, this will update that "projects" variable when the useEffect runs. When is that? When this ProjectsList.js component mounts. Since we just want the useEffect to set state at the initial rendering of this component, we will NOT put any dependency into the empty array at the end of this useEffect.
  useEffect(() => {
    getAllProjectsByUserId();
  }, [loggedInUser.roles]);

  //^--------------- Conditionally render base on customer or worker role ---------------//^

  if (
    Array.isArray(loggedInUser.roles) &&
    loggedInUser.roles.includes("Customer")
  ) {
    console.log(loggedInUser);

    //~ -------------------------- CUSTOMER ROUTE DISPLAY -------------------------- //~

    return (
      <div className="container">
        <div className="row">
          <div className="col-sm-6">
            <ProjectList
              projectsByUserId={projectsByUserId}
              setProject={setProject}
              setDetailsProjectId={setDetailsProjectId}
              user={loggedInUser}
            />
          </div>
          <div className="col-sm-4">
            <CreateProject
              project={project}
              projects={projects}
              setProjects={setProjects}
              loggedInUser={loggedInUser}
              projectData={projectData}
              getAllProjectsByUserId={getAllProjectsByUserId}
              setProjectData={setProjectData}
              selectedProjectType={selectedProjectType}
              setSelectedProjectType={setSelectedProjectType}
              unassignedProjectAssignments={unassignedProjectAssignments} // pass this to CreateProject so we can refer to the current state and then push the newly created projectAssignment to that array/table
              setUnassignedProjectAssignments={setUnassignedProjectAssignments}
            />
            {/* <ProjectDetails detailsBikeId={detailsProjectId} /> */}
          </div>
        </div>
      </div>
    );
  }
  //^--------------- conditionally render based on the user ---------------//^
  //~ -------------------------- WORKER ROUTE DISPLAY -------------------------- //~
  //$ Displays a list of assigned projects on the left and a list of unassigned projects on the right
  return (
    <div className="container">
      <div className="row">
        <div className="col-sm-6">
          <ListOfAssignedProjects
            //need to generate projectAssignmentsByUserId and pass as a prop
            projectAssignmentsByUserId={projectAssignmentsByUserId}
            //need to setAssignedProjects and pass as a prop
            setprojectAssignmentsByUserId={setprojectAssignmentsByUserId}
            // //need to setDetailsAssignedProjectId
            // setDetailsProjectId={setDetailsProjectId}
            //KEEP THE USER PASSED AS A PROP
            loggedInUser={loggedInUser}
            setProject={setProject}
            project={project}
          />
        </div>
        <div className="col-sm-4">
          <ListOfUnassignedProjects
            getProjectAssignmentsByUserId={getProjectAssignmentsByUserId}
            getUnassignedProjectAssignments={getUnassignedProjectAssignments}
            unassignedProjectAssignments={unassignedProjectAssignments} //need to generate unassignedProjectAssignments and pass as a prop
            setUnassignedProjectAssignments={setUnassignedProjectAssignments} //need to set the state of unassignedProjectAssignments and pass as a prop
            loggedInUser={loggedInUser} //KEEP THE USER PASSED AS A PROP
          />
        </div>
      </div>
    </div>
  );
}

//* IMPORTANT - This component is a PARENT to ProjectsList.js component
// Line 14 where ProjectList is entered, we are passing setDetailsProjectId as a prop to the ProjectList component.
// This means that the ProjectList component can use the setDetailsProjectId function?
// Yes. As ChatGPT put it, "This makes setDetailsProjectId available in the ProjectList component, and it can be used to update the detailsProjectId state in the parent Projects component."
// So why do we need to pass setDetailsProjectId as a prop in this module?
// Because the function is CALLED in this module. We defined the function's purpose in ProjectsList, but it is imported for USE in this module.
// So in the browser, we signed into Cory Cotton's account and he has a UserProfile Id of 5.
// I am holding a user profile object in state on the ProjectList component now.
//* IMPORTANT - We could just tell ApplicationViews.js to render ProjectList.js at the root "/" directory. But instead we are rendering this component first. Why? Because we can choose to render multiple components if we want. For example, we could render the Project Details component as well. I have it commented out as of 10/23/2023 11:16am.
