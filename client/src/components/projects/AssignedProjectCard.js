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
  loggedInUser,
  projectAssignment,
  setDetailsProjectId,
  setprojectAssignmentsByUserId,
  //   setDetailsProjectId,
}) {
  const navigate = useNavigate();
  // console.log({ projectAssignment });

  const [selectedWorker, setSelectedWorker] = useState(""); // when user clicks a worker name from dropdown, the setSelectedWorker function runs and the value of selectedWorker gets set to the selected user's workerprofile Id
  // console.log(selectedWorker);
  const [workerProfiles, setWorkerProfiles] = useState([]); // State to store worker profiles (Panda and Ty)
  const [addedWorkers, setAddedWorkers] = useState([]); // Keep track of added workers

  //~ TRYING SOMETHING - ALL NEW CODE HERE - ~//
  const [availableWorkers, setAvailableWorkers] = useState([]); // State to store available workers

  useEffect(() => {
    // Fetch all worker profiles excluding the logged-in worker
    getWorkerProfiles()
      .then((data) => {
        // Assuming you have a variable to represent the logged-in worker's id
        const loggedInUserId = loggedInUser.id;
        const filteredWorkers = data.filter(
          (worker) => worker.id !== loggedInUserId
        );
        setAvailableWorkers(filteredWorkers);
      })
      .catch((error) =>
        console.error("Error fetching worker profiles: ", error)
      );
  }, [loggedInUser]); // Fetch worker profiles when the logged-in user changes

  //~ TRYING SOMETHING - ALL NEW CODE HERE - ~//

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
        projectTypeId: projectAssignment.projectTypeId,
      };
      console.log({worker})
      console.log({ newProjectAssignment });
      const response = await fetch("/api/projectAssignment", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(newProjectAssignment),
      });

      if (response.ok) {
        window.alert(`${worker.firstName} was added to this project.`);
        console.log("New projectAssignment created successfully.");
        setAvailableWorkers((prevWorkers) => prevWorkers.filter((w) => w.id !== worker.id));
        setSelectedWorker(""); // Clear the selected worker
        setAddedWorkers((prevAdded) => [...prevAdded, worker.id]); // Add the worker's ID to the list of added workers
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
              // value={selectedWorker} //the code didn't work this way, so created it in the next line of code
              onChange={(e) => {
                const selectedWorker = workerProfiles.find(
                  (wp) => wp.id === parseInt(e.target.value)
                );
                setSelectedWorker(selectedWorker);
              }}
            >
              <option value="">Select a worker</option>
              {availableWorkers.map((worker) => (
                <option key={worker.id} value={worker.id}>
                  {worker.fullName}
                </option>
              ))}
            </Input>
          </FormGroup>
          <Button color="info" onClick={() => handleWorkerSelection(selectedWorker)}>
            Add Worker
          </Button>
        </div>
      </CardBody>
    </Card>
  );
}
