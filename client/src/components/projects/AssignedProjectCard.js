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

  const [selectedWorker, setSelectedWorker] = useState(""); // when user clicks a worker name from dropdown, the setSelectedWorker function runs and the value of selectedWorker gets set to the selected user's workerprofile Id
  const [workerProfiles, setWorkerProfiles] = useState([]); // State to store worker profiles (Panda and Ty)

  console.log(selectedWorker);

  useEffect(() => {
    // Fetch worker profiles when the component mounts
    getWorkerProfiles()
      .then((data) => setWorkerProfiles(data))
      .catch((error) =>
        console.error("Error fetching worker profiles: ", error)
      );
  }, []);

  // console.log({ workerProfiles });

  //^ Handle the user's selection by posting a new projectAssignment object
  const handleWorkerSelection = async (worker) => {
    try {
      // Perform a POST request to create a new projectAssignment
      const newProjectAssignment = {
        userProfileId: worker.id, // Set the selected worker's UserProfileId
        projectId: projectAssignment.projectId, // Set the current project's Id
        projectTypeId: projectAssignment.projectTypeId
      };
console.log({projectAssignment})
      const response = await fetch("/api/projectAssignment", {
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
      console.error(
        "An error occurred while creating a new projectAssignment.",
        error
      );
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
            borderColor: "black",
            fontWeight: "bold", 
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
        <div>
          <FormGroup>
            <Label for="worker">Add Worker</Label>
            <Input
              type="select"
              name="worker"
              id="worker"
              onChange={(e) => {
                const selectedWorker = workerProfiles.find(
                  (wp) => wp.id === parseInt(e.target.value)
                );
                setSelectedWorker(selectedWorker);
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
          <Button
            color="info"
            onClick={() => handleWorkerSelection(selectedWorker)}
          >
            Add Worker
          </Button>
        </div>
      </CardBody>
    </Card>
  );
}
