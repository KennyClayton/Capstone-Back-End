import { NavLink, useNavigate } from "react-router-dom";
import {
  Card,
  CardBody,
  CardTitle,
  CardText,
  CardSubtitle,
  Button,
  NavItem,
} from "reactstrap";

export default function ProjectAssignmentCard({
    project, projectAssignment,
    setprojectAssignmentsByUserId
//   setDetailsProjectId,
}) {
  const navigate = useNavigate();
console.log({projectAssignment})
  return (
    <Card body color="info" outline style={{ marginBottom: "8px" }}>
      <CardBody>
        <CardTitle tag="h5">{projectAssignment.projectType.name}</CardTitle>
        <CardText>
          <br></br>
            Project Date: {new Date(projectAssignment.project.dateOfProject).toLocaleString()}
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
            setprojectAssignmentsByUserId(projectAssignment);
            // setDetailsProjectId(project.id);
            navigate(`projectassignments/${projectAssignment.id}`);
            window.scrollTo({
              top: 0,
              left: 0,
              behavior: "smooth",
            });
          }}
        >
          Show Details
        </Button>
      </CardBody>
    </Card>
  );
}
