import { useEffect, useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import {
  Card, 
  CardBody,
  CardTitle,
  CardText,
  CardSubtitle,
  Button,
  NavItem,
  FormGroup,
  Label,
  Input,
} from "reactstrap";
import { getWorkerProfiles } from "../../managers/userProfileManager";

//^ This module renders AssignedProjectDetails (inside of AssignedProjectDetails.js) when "Show Details" button is clicked which navigates to assignedProjects/${projectAssignment.id}


export default function ProjectAssignmentCard({
  project,
  setProject,
  projectAssignment,
  setDetailsProjectId,
  setprojectAssignmentsByUserId,
  //   setDetailsProjectId,
}) {
  const navigate = useNavigate();
  // console.log({ projectAssignment });



  const [selectedWorker, setSelectedWorker] = useState("");
  const [workerProfiles, setWorkerProfiles] = useState([]); // State to store worker profiles (Panda and Ty)

  useEffect(() => {
    // Fetch worker profiles when the component mounts
    getWorkerProfiles()
      .then((data) => setWorkerProfiles(data))
      .catch((error) => console.error("Error fetching worker profiles: ", error));
  }, []);

  console.log({ workerProfiles });



//^ Handle the user's selection by posting a new projectAssignment object
const handleWorkerSelection = async (worker) => {
  try {
    // Perform a POST request to create a new projectAssignment
    const newProjectAssignment = {
      userProfileId: worker, // Set the selected worker's UserProfileId
      projectId: projectAssignment.project.Id, // Set the current project's Id
    };

    const response = await fetch("/api/projectAssignments", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newProjectAssignment),
    });

    if (response.ok) {
      console.log("New projectAssignment created successfully.");
    } else {
      console.error("Failed to create a new projectAssignment.");
    }
  } catch (error) {
    console.error("An error occurred while creating a new projectAssignment.", error);
  }
};





  return (
    <Card body color="info" outline style={{ marginBottom: "8px" }}>
      <CardBody>
        <CardTitle tag="h5">{projectAssignment.projectType.name}</CardTitle>
        <CardText>
          <br></br>
          Project Date:{" "}
          {new Date(projectAssignment.project.dateOfProject).toLocaleString()}
          <br></br>
          Customer: {projectAssignment.project.userProfile.fullName}
        </CardText>

        <Button
          outline
          color="black"
          style={{
            borderColor: "black", // Adjust the border color for a thicker outline
            fontWeight: "bold", // Set text to bold
          }}
          onClick={() => {
            setProject(projectAssignment);
            navigate(`assignedProjects/${projectAssignment.id}`);
            window.scrollTo({
              top: 0,
              left: 0,
              behavior: "smooth",
            });
          }}
        >
          Show Details
        </Button>

        <FormGroup>
          <Label for="worker">Add Worker</Label>
          <Input
            type="select"
            name="worker"
            id="worker"
            value={selectedWorker}
            onChange={(e) => {
              setSelectedWorker(e.target.value);
              handleWorkerSelection(e.target.value);
            }}
          >
            <option value="">Select a worker</option>
            {workerProfiles.map((wp) => (
              <option key={wp.id} value={wp.id}>
                {wp.fullName}
              </option>
            ))}
          </Input>
        </FormGroup>


      </CardBody>
    </Card>
  );
}
