import React, { useEffect, useState } from "react";
import {
  Card,
  CardTitle,
  CardSubtitle,
  CardBody,
  CardText,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
} from "reactstrap";
import {
  deleteProjectById,
  getProjectById,
  getProjectTypes,
  getProjects,
  updateProject,
} from "../../managers/projectManager";
import { useParams, useNavigate } from "react-router-dom";
import { format } from "date-fns";

export default function ProjectDetails({ project, setProject }) {
  // use the project and setProject as props from ApplicationViews so any changes there and here don't conflict.
  const { id } = useParams();
  const navigate = useNavigate();
  const [isEditing, setIsEditing] = useState(false);
  const [editedProject, setEditedProject] = useState({ ...project }); // initially set "editedProject" to a shallow copy of the "project" object with all its properties. A shallow copy is like a new object exactly the same as the original one from the database, just a COPY of it though. So any changes made to editedProject won't directly affect the original project prop.
  const [projectTypes, setProjectTypes] = useState([]);

  useEffect(() => {
    // we have access to all the project types objects in the "projectTypes" variable
    getProjectTypes().then((data) => setProjectTypes(data));
  }, []);

  const handleEditClick = () => {
    // when edit button is clicked, this sets it to true, which switches the user's view to the edititable fields
    setIsEditing(true);
  };

  const handleCancelClick = () => {
    // when cancel button is clicked, this sets to false, which switches the view back to viewMode (by running the renderViewMode function below)
    setIsEditing(false);
    setEditedProject({ ...project }); // resets the project object back to original state before the user started trying to edit it.
  };

  const handleSaveClick = () => {
    // Send an HTTP request to update the old project object in the database with the newly minted `editedProject`
    console.log(editedProject)

    updateProject(editedProject) // assuming user made changes, this updateProject function is called and sends the editedProject object to the database
      .then(() => {
        // ...then...with the response data in hand...yes, this new object returned to us FROM THE DATABASE is held in the updatedProject variable here...which we need for the next step...
        getProjectById(id)})
        .then((updatedProject) => {
          setProject(updatedProject); // ...now update the state of our "project" variable with the freshly minted project object we saved and got back from the database a moment ago.
        setIsEditing(false); // Switch back to view mode
      })
  };

  const handleDeleteClick = () => {
    // Perform the deletion operation here
    deleteProjectById(project.id)
      .then((response) => {
        if (response.status === 204) {
          // Deletion was successful, navigate to the root or home page
          navigate('/'); // Replace with the correct route
        } else {
          // Handle errors if needed
        }
      })
      .catch((error) => {
        console.error('Error deleting project:', error);
      });
  };

  const handleInputChange = (e) => {
    // as the user is typing, watch for changes in the editable fields below
    // Extract the 'name' and 'value' properties from the event target (the input field)
    
    const { name, value } = e.target;
    //store the id of the project's property.id
//     if (name === "projectType")
//     // store the user-entered value of the property type.id as an integer by parsing it into an integer
//   {
//     setEditedProject({ ...editedProject, [name]: parseInt(value) });
//     console.log(editedProject)
    
//  }    // below, take each updated property's value from the user's input and store it in the editedProject shallow copy variable and then set the state of editedProject with those new property values
//     else {
      setEditedProject({ ...editedProject, [name]: value });
      console.log(editedProject)
      console.log("name did not equal projectType")

    // };
  };

//^ ----------- VIEW MODE -----------//^

  const renderViewMode = (
    <>
      <Card
        body
        color="info"
        outline
        style={{ marginBottom: "8px", maxWidth: "600px" }}
        className="m-4"
      >
        <CardBody>
          <CardTitle tag="h4">Project Details</CardTitle>
          <CardTitle tag="h6" style={{borderColor: "black", fontWeight: "bold",}}>{project.projectType.name}</CardTitle>
          <CardSubtitle>
            Worker:
            {" "}
            {project.workerFullName ? project.workerFullName : "Unassigned"}
          </CardSubtitle>
          <CardSubtitle>
            Project Date:
            {" "}
            {format(new Date(project.dateOfProject), "MMMM d, yyyy p")}
          </CardSubtitle>
          <CardSubtitle>
            Date Completed:
            {" "}
            {project.completedOn ? (
              project.completedOn
            ) : (
              <span className="text-muted">Not yet completed</span>
            )}
          </CardSubtitle>
          <CardSubtitle>
            Project Description: 
            {" "}
            {project.description}
          </CardSubtitle>
        </CardBody>
        <div className="justify-content-between">
          <Button onClick={handleEditClick} color="info">
            Edit Project
          </Button>
          <Button
            onClick={() => handleDeleteClick(id)}
            color="danger"
            style={{ marginLeft: "8px" }}
          >
            Delete Project
          </Button>
        </div>
      </Card>
    </>
  );


//^ ----------- EDIT MODE -----------//^

  const renderEditMode = (
    <div>
      <Card
        body
        color="info"
        outline
        style={{ marginBottom: "8px", maxWidth: "600px" }}
        className="m-4"
      >
        <CardBody>
          <Form>
            <FormGroup>
              <Label for="projectType">Project Type</Label>
              <Input
                type="select"
                name="projectType"
                id="projectType"
                value={editedProject.projectType.id}
                onChange={handleInputChange}
              >
                <option value="">Select a project type</option>
                {projectTypes.map((projectType) => (
                  <option key={projectType.id} value={projectType.id}>
                    {projectType?.name}
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
                value={editedProject.dateOfProject}
                onChange={handleInputChange}
              />
            </FormGroup>

            <Label for="description">Project Description</Label>
            <Input
              type="text"
              name="description"
              id="description"
              value={editedProject.description}
              onChange={handleInputChange}
            />
          </Form>
          <div className="justify-content-between">
            <Button
              onClick={handleSaveClick}
              color="info"
              outline
              style={{ marginTop: "1rem" }}
            >
              Save
            </Button>
            <Button
              onClick={handleCancelClick}
              color="danger"
              outline
              style={{ marginTop: "1rem", marginLeft: "1rem" }}
            >
              Cancel
            </Button>
          </div>
        </CardBody>
      </Card>
    </div>
  );

  return <div>{isEditing ? renderEditMode : renderViewMode}</div>;
}
