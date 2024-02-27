import {
  Card,
  CardTitle,
  CardSubtitle,
  CardBody,
  Button,
} from "reactstrap";
import { useParams, useNavigate } from "react-router-dom";
import { format } from "date-fns";

//^ This should be the assignedProject card showing details about the worker's already-assigned project

export default function AssignedProjectDetails({ project, setProject, projectAssignment }) 

{
  // use the project and setProject as props from ApplicationViews so any changes there and here don't conflict.
  const { id } = useParams();
  const navigate = useNavigate();
  const handleMyProjectsButton = () => {
    navigate("/dashboard");
  };

return (

    <>
      <Card
        body
        color="info"
        outline
        style={{ marginBottom: "1rem", maxWidth: "600px" }}
        className="m-4"
      >
        <CardBody>
          <CardTitle tag="h4">Project Details</CardTitle>
          <CardTitle
            tag="h6"
            style={{ borderColor: "black", fontWeight: "bold" }}
          >
            {project.projectType.name}
          </CardTitle>
          <CardSubtitle>
            Worker:{" "}
            {project.userProfile.fullName ? project.userProfile.fullName : "Unassigned"}
          </CardSubtitle>
          <CardSubtitle>
            Project Date:{" "}
            {format(new Date(project.project.dateOfProject), "MMMM d, yyyy p")}
          </CardSubtitle>
          <CardSubtitle>
            Date Completed:{" "}
            {project.project.completedOn ? (
              project.project.completedOn
            ) : (
              <span className="text-muted">Not yet completed</span>
            )}
          </CardSubtitle>
          <CardSubtitle>
            Project Description: {project.project.description}
          </CardSubtitle>
        </CardBody>
        <div className="justify-content-between">

          
          <Button
            onClick={handleMyProjectsButton}
            outline
            color="secondary"
            style={{ marginLeft: "1rem" }}
          >
            My Projects
          </Button>
        </div>
      </Card>
    </>
  );


}
