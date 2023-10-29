import { useEffect, useState } from "react";
import ProjectList from "./ProjectsList";
import CreateProject from "./CreateProject"; // this is a component that creates a list of projects
import {
  createProject,
  getUserProjects,
  getWorkerProjectAssignments,
  getProjectAssignments,
} from "../../managers/projectManager";
import { set } from "date-fns";
import ListOfAssignedProjects from "./AssignedProjectsList";

export default function Projects({ loggedInUser, setProject, project }) {
  // this function renders two child components, ProjectList and ProjectDetails. We pass the loggedInUser as an object
  const [detailsProjectId, setDetailsProjectId] = useState(null);
  const [projectsByUserId, setProjectsByUserId] = useState([]); // IMPORTANT - This will be a list of Customer projects. This projectsByUserId variable gets filled up with a list of projects (which only have Customer UserProfiles). How? when the useEffect runs, it will call the getAllProjectsByUserId function. That function is defined above the useEffect. Look at that getAllProjectsByUserId function and you will see that it calls ANOTHER function "getUserProjects" that we defined and imported from projectManager.js.
  // VERY IMPORTANT - This is where we connect front and back end. The "getUserProjects" function in projectManager.js says to GET data from the server. But where on the server? At the "/user-projects" endpoint. How do we know the server has an endpoint with that name "user-projects"? Because we defined one in ProjectController.cs

  const [selectedProjectType, setSelectedProjectType] = useState("");
  // Here, useState initializes the state of projectData with these three properties and values
  const [projectData, setProjectData] = useState({
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
  const [projectAssignmentsByUserId, setprojectAssignmentsByUserId] = useState([]); // manage the state of projectAssignments by Id

  const getProjectAssignmentsByUserId = () => {
    getWorkerProjectAssignments(loggedInUser.id).then(setprojectAssignmentsByUserId);
  };

  useEffect(() => { // set the state of the list of projectAssignments by Id
    getProjectAssignmentsByUserId();
  }, [loggedInUser.roles]);
  //~ ---------- ABOVE handles getting and setting ProjectAssignments by Id ---------- //~

  const getAllProjectsByUserId = () => {
    // define this function. When the function runs, what happens?
    getUserProjects().then(setProjectsByUserId); // When it runs, this function will get projects by a user's Id that matches the projects UserProfileId.
  };

  // the below handleSubmit button is called when the user clicks the submit button
  const handleSubmit = (e) => {
    e.preventDefault();
    const newProject = {
      userProfileId: loggedInUser.id,
      projectTypeId: selectedProjectType, // this updates the state of selectedProjectType variable with the user's selected type
      dateOfProject: projectData.dateOfProject, // Use the dateOfProject from projectData state
      description: projectData.description, // Use the description from projectData state
    };
    // console.log(newProject);
    // the below createProject function is defined in projectManager.js and is what makes the actual POST / http request to post the new project to the database. We hand that function the newProject object here and then navigate wherever we want, which is root directory in this case....or maybe nowhere.
    createProject(newProject).then(() => {
      setSelectedProjectType(""); // Reset selected project type (dropdown list with nothing selected yet)
      setProjectData({
        // Reset project data to its initial state of empty strings
        projectType: "",
        dateOfProject: "",
        description: "",
        // navigate("/"); //not needed bc i am already on the root directory
      });
      getAllProjectsByUserId();
    });
  };

  // We already have "projects" and "userProfiles" as variables above. Recall that we set the initial states of those to empty arrays. We want to now run the useEffect which will call these functions and fill those variables above with all projects and users. This useEffect is called a React "hook". Again, this will update that "projects" variable when the useEffect runs. When is that? When this ProjectsList.js component mounts. Since we just want the useEffect to set state at the initial rendering of this component, we will NOT put any dependency into the empty array at the end of this useEffect.
  useEffect(() => {
    getAllProjectsByUserId();
  }, [loggedInUser.roles]);

  //^--------------- conditionally render based on the user ---------------//^

  if (
    Array.isArray(loggedInUser.roles) &&
    loggedInUser.roles.includes("Customer")
  ) {
    console.log(loggedInUser);

    //~ -------------------------- CUSTOMER ROUTE -------------------------- //~

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
              loggedInUser={loggedInUser}
              projectData={projectData}
              setProjectData={setProjectData}
              handleSubmit={handleSubmit}
              selectedProjectType={selectedProjectType}
              setSelectedProjectType={setSelectedProjectType}
            />
            {/* <ProjectDetails detailsBikeId={detailsProjectId} /> */}
          </div>
        </div>
      </div>
    );
  }
  //^--------------- conditionally render based on the user ---------------//^
  //~ -------------------------- WORKER ROUTE -------------------------- //~
  return (
    <div className="container">
      <div className="row">
        <div className="col-sm-6">
          <ListOfAssignedProjects
            //need to generate projectAssignmentsByUserId and pass as a prop
            projectAssignmentsByUserId={projectAssignmentsByUserId}
            //need to setAssignedProjects and pass as a prop
            setprojectAssignmentsByUserId={setprojectAssignmentsByUserId}
            //need to setDetailsAssignedProjectId
            setDetailsProjectId={setDetailsProjectId}
            //KEEP THE USER PASSED AS A PROP
            loggedInUser={loggedInUser}
            project={project}
          />
        </div>
        {/* <div className="col-sm-4">
          <ListOfUnAssignedProjects
            loggedInUser={loggedInUser}
            projectData={projectData}
            setProjectData={setProjectData}
            handleSubmit={handleSubmit}
            selectedProjectType={selectedProjectType}
            setSelectedProjectType={setSelectedProjectType}
          />
        </div> */}
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
