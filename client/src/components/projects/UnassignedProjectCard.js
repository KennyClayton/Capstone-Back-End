import { Card, CardBody, CardTitle, CardText, Button } from "reactstrap";

export default function UnassignedProjectCard({
  loggedInUser,
  unassignedProjectAssignment,
  getProjectAssignmentsByUserId,
  getUnassignedProjectAssignments,
}) {
  const apiUrlAssignments = "/api/projectAssignment";
  //define a function to do the PUT request, then run the setter function to update the state of the unassignedProjectAssignments list
  const handleWorkThisProject = () => {
    // Create a new projectAssignment object with the updated UserProfile property
    const updatedUnassignedProjectAssignment = {
      // create a variable to hold the updated object
      ...unassignedProjectAssignment, // create a shallow copy of the object with its properties which makes it available to us for editing
      UserProfile: loggedInUser, // Now call out this property from the shallow copy of the object and udate its value to the loggedInUser object
    };

    //!FAILED, BUT TRIED TO DEFINE A FUNCTION IN PROJECTMANAGER FOR THIS AND THEN CALL THAT FUNCTION HERE
    // updateProjectAssignment(updatedUnassignedProjectAssignment); // where and when do I call this? I send the updated object with the function when it's called
    // Send a PUT request to update the unassignedProjectAssignment
    fetch(`${apiUrlAssignments}/${unassignedProjectAssignment.id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updatedUnassignedProjectAssignment),
    })
      .then((res) => {
        if (res.status === 204) {
          console.log("UserProfile updated successfully.");
          getUnassignedProjectAssignments();
          getProjectAssignmentsByUserId();
        } else {
          // Handle errors, if any
          console.error("Failed to update UserProfile.");
        }
      })
      .catch((error) => {
        console.error("An error occurred:", error);
      });
  };

  return (
    <Card body color="info" style={{ marginBottom: "1rem", maxWidth: "400px" }}>
      <CardBody>
        <CardTitle tag="h5">
          {unassignedProjectAssignment.projectType.name}
        </CardTitle>
        <CardText>
          <br></br>
          Project Date:{" "}
          {new Date(
            unassignedProjectAssignment.project.dateOfProject
          ).toLocaleString()}
          <br></br>
          Customer: {unassignedProjectAssignment.project.userProfile.fullName}
        </CardText>
        
        {/* <Button
        outline
          style={{
            color: "white",
            marginRight: "1rem",
            borderColor: "white", // Adjust the border color for a thicker outline
            fontWeight: "bold", // Set text to bold
          }}
          onClick={() => {
            // setprojectAssignmentsByUserId(projectAssignment);
            // setDetailsProjectId(project.id);
            // navigate(`projectassignments/${projectAssignment.id}`);
            window.scrollTo({
              top: 0,
              left: 0,
              behavior: "smooth",
            });
          }}
        >
          Show Details
        </Button> */}

        <Button
          outline
          style={{
            color: "white",
            borderColor: "white", // Adjust the border color for a thicker outline
            fontWeight: "bold", // Set text to bold
          }}
          onClick={() => {
            handleWorkThisProject();
            window.scrollTo({
              top: 0,
              left: 0,
              behavior: "smooth",
            });
          }}
        >
          Work This Project
        </Button>
      </CardBody>
    </Card>
  );
}
