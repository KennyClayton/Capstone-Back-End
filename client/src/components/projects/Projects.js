import { useEffect, useState } from "react";
import ProjectList from "./ProjectsList";
import ProjectDetails from "./ProjectDetails";
import CreateProject from "./CreateProject"; // this is a component that creates a list of projects
import {
  createProject,
  getUserProjects,
  getWorkerProjects,
} from "../../managers/projectManager";
import { set } from "date-fns";

export default function Projects({ loggedInUser, setProject }) {
  // this function renders two child components, ProjectList and ProjectDetails. We pass the loggedInUser as an object
  const [detailsProjectId, setDetailsProjectId] = useState(null);
  const [projectsByUserId, setProjectsByUserId] = useState([]);
  const [selectedProjectType, setSelectedProjectType] = useState("");
  // Here, useState initializes the state of projectData with these three properties and values
  const [projectData, setProjectData] = useState({
    projectType: "",
    dateOfProject: "",
    description: "",
  });

  const getAllProjectsByWorkerId = () => {
    getWorkerProjects(loggedInUser.id).then(setProjectsByUserId);
  };
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
    // if (user.roles && user.roles.includes("Worker")) { //make sure user.roles exists AND the user is a worker, then do ....
    //   console.log("isworker")
    //   getAllProjectsByWorkerId();
    // }
    getAllProjectsByUserId();
  }, [loggedInUser.roles]);

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

//* IMPORTANT - This component is a PARENT to ProjectsList.js component
// Line 14 where ProjectList is entered, we are passing setDetailsProjectId as a prop to the ProjectList component.
// This means that the ProjectList component can use the setDetailsProjectId function?
// Yes. As ChatGPT put it, "This makes setDetailsProjectId available in the ProjectList component, and it can be used to update the detailsProjectId state in the parent Projects component."
// So why do we need to pass setDetailsProjectId as a prop in this module?
// Because the function is CALLED in this module. We defined the function's purpose in ProjectsList, but it is imported for USE in this module.
// So in the browser, we signed into Cory Cotton's account and he has a UserProfile Id of 5.
// I am holding a user profile object in state on the ProjectList component now.
//* IMPORTANT - We could just tell ApplicationViews.js to render ProjectList.js at the root "/" directory. But instead we are rendering this component first. Why? Because we can choose to render multiple components if we want. For example, we could render the Project Details component as well. I have it commented out as of 10/23/2023 11:16am.
