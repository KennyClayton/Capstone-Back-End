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

export default function ProjectCard({
  project,
  setProject,
  setDetailsProjectId,
}) {
  const navigate = useNavigate();

  return (
    <Card body color="info" outline style={{ marginBottom: "1rem" }}>
      <CardBody>
        <CardTitle tag="h5">{project.projectType.name}</CardTitle>
        <CardText>
          <br></br>
            Project Date: {new Date(project.dateOfProject).toLocaleString()}
          <br></br>    
          Worker: {project.workerFullName ? project.workerFullName : "Unassigned"}

        </CardText>

        <Button
        outline
          color="black"
          style={{
            borderColor: "black", // Adjust the border color for a thicker outline
            fontWeight: "bold", // Set text to bold
          }}
          onClick={() => {
            setProject(project);
            setDetailsProjectId(project.id);
            navigate(`/dashboard/projects/${project.id}`);
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
