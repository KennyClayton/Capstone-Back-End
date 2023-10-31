import React, { useState, useEffect } from "react";
import {
  Card,
  CardBody,
  CardTitle,
  CardText,
  CardSubtitle,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
} from "reactstrap";
import {
  createProject,
  createProjectAssignment,
  getProjectTypes,
} from "../../managers/projectManager";
// import { useNavigate } from "react-router-dom";

export default function CreateProject({
  loggedInUser,
  project,
  projects, // pass this prop from ApplicationViews > Projects > here so we can use it
  setProjects, // pass this prop from ApplicationViews > Projects > here so we can update the list of all projects once we create a project below
  projectData,
  setProjectData,
  selectedProjectType,
  setSelectedProjectType,
  unassignedProjectAssignments,
  setUnassignedProjectAssignments,
  getAllProjectsByUserId,
}) {
  console.log({ project });
  const [projectTypes, setProjectTypes] = useState([]);
  console.log({ projectData }); //* IMPORTANT - by console logging this as an object, i can see the value of projectData in the Console without having to run anything. I can see that it is an object with three properties on it: { "projectType": "", "dateOfProject": "2023-11-10T15:25","description": "Insulate under the house"}
  // Fetch project types from the API when the component mounts
  // we imported getProjectTypes function from projectManager.js which is what does the HTTP Get request for us and returns the project types in a list. SO once this useEffect runs, the projectTypes variable State is that it holds a list of project types.
  useEffect(() => {
    getProjectTypes().then((data) => setProjectTypes(data));
  }, []);

  // the below handleSubmit function is called when the event is triggered, which is when the user clicks the "Create Project" button
  const handleSubmit = (e) => {
    e.preventDefault();
    const newProject = {
      userProfileId: loggedInUser.id,
      projectTypeId: selectedProjectType, // this updates the state of selectedProjectType variable with the user's selected type
      dateOfProject: projectData.dateOfProject, // Use the dateOfProject from projectData state
      description: projectData.description, // Use the description from projectData state
    };
    console.log({ newProject });
    // the below createProject function is defined in projectManager.js and is what makes the actual POST / http request to post the new project to the database. We hand that function the newProject object here and then navigate wherever we want, which is root directory in this case....or maybe nowhere.
    createProject(newProject).then(() => {
      //send the newProject to the database and then...
      setSelectedProjectType(""); // Reset selected project type (dropdown list with nothing selected yet)
      setProjectData({
        // Reset project data to its initial state of empty strings
        projectType: "",
        dateOfProject: "",
        description: "",
      });
      setProjects(); //! added this to update the projects variable
      getAllProjectsByUserId();
      //! Do i need to fetch the newProject back from the database in order to get the id off of it so I can reference it in creating the projectId for the newProjectAssignment below? I need those to match.
      // Now that the project has been created, create a new ProjectAssignment
      // const newProjectAssignment = {
      //   userProfileId: null, // UserProfileId should be null so that no worker is assigned yet. The worker will choose whether to assign to themselves or not.
      //   projectId: createdProject.id, //! not coming back on the object
      //   // Use the ID of the created project
      //   projectTypeId: selectedProjectType, // Use the selected project type
      // };

      // Step 4: Create the new ProjectAssignment using the createProjectAssignment function
    });
  };

  //~ DISCUSSION: I need to implement setUnassignedProjectAssignments(); somewhere so the list of unassignedProjectAssignments gets the newest projectAssignment that is created once a Customer creates a new project
  //! I want the list of projects updated once a new project is created. Why? Because I want the newest version of the project list to be available to the rest of the application. When a project is created by the customer, it sends a new project object to the database. But unless other parts of the application ask for that updated list of projects, other parts of the application (for example, our workers view of the projects list) won't see the updated list of projects. Remember, once the customer created the project, it went to the database.
  //$ NOW --------- Since there is a new ProjectAssignment now too (created contemporaneously with the new project), we need to update the list of "unassignedProjectAssignments" so that the Workers' view of available projects gets the updated list of unassigned projectAssignments. So then, we want the useEffect that triggers the  setUnassignedProjectAssignments function to watch for changes in the list of unassignedProjectAssignments. Right? If I make unassignedProjectAssignments a dependency onthe useEffect....
  //But for the worker view of the application, the project list hasn't been updated with the newly-created project....UNLESS...
  //$ ...In order for workers to see the updated list of unassigned projects, the component that renders the list of "available projects" (ie - the list of unassigned projects) for the workers must be synced with the database somehow. Since the workers should ALWAYS see projects that are unassigned (as soon as they are generated by the customers), we need to make sure that wherever the workers side of the application is getting its list of projects from, gets a fresh list of projects every time a customer creates one.
  //^ So, ideally, the most parent component for both sides of the application should manage the state of the list of projects and pass that state to all child components, including the component that renders the list of projects for workers AND customers.
  //& This means I need to keep projects (which is the variable holding all projects from the database) in the top level component, Project.js or ApplicationViews.js and then pass it down to all other components that need access to the list of all projects.
  //~ Since the workers only need access to a list of UNASSIGNED projects, how do we do that? We still keep the state of ALL projects in Projects.js...and we have a separate useState that holds a list of all projects filtered to .Where only the unassigned projects are listed. Since the list of unassigned projects depends on the list of ALL projects, we need to trigger the list of unassigned projects to run its useEffect whenever the list of ALL projects is updated. So, when a customer creates an object and it goes to the database, we need to setProjects (updating projects variable to new list of all projects) and we need useState to watch the state of projects, so that if projects (list of projects) changes, then the useEffect for unassignedProjects will run the setUnassignedProjects function to update the state of unassignedProjects and then that updated state will trickle down through the props and into any component that has that prop. Then, inside that component, whenever unassignedProjects is referenced in the code, it will have the newest version of the list of unassigned projects.

  const handleChange = (e) => {
    const { name, value } = e.target; // pull the name and value properties of this event object, because we are going to use those two properties below
    const clone = structuredClone(projectData); //clone the projectData object. This object has three properties (holding their current values for each property)
    clone[name] = value;
    setProjectData(clone); //update the value of projectData to the new property values
  };

  return (
    <div>
      <h2>Create A Project</h2>
      <Card body color="info" outline style={{ marginBottom: "1rem" }}>
        <CardBody>
          {/* <CardTitle tag="h5">Create a New Project</CardTitle> */}
          <Form onSubmit={handleSubmit}>
            <FormGroup>
              <Label for="projectType">Project Type</Label>
              <Input
                type="select"
                name="projectType"
                id="projectType"
                value={selectedProjectType}
                onChange={(e) => {
                  setSelectedProjectType(e.target.value);
                }}
              >
                <option value="">Select a project type</option>
                {projectTypes.map((projectType) => (
                  <option key={projectType.id} value={projectType.id}>
                    {projectType.name}
                  </option>
                ))}
              </Input>
            </FormGroup>
            <FormGroup>
              <Label for="dateOfProject">Date of Project</Label>
              <Input
                type="datetime-local"
                name="dateOfProject"
                id="dateOfProject"
                value={projectData.dateOfProject}
                onChange={handleChange}
              />
            </FormGroup>
            <FormGroup>
              <Label for="description">Project Description</Label>
              <Input
                type="text"
                name="description"
                id="description"
                value={projectData.description}
                onChange={handleChange}
              />
            </FormGroup>
            <Button color="info" type="submit">
              Create Project
            </Button>
          </Form>
        </CardBody>
      </Card>
    </div>
  );
}
