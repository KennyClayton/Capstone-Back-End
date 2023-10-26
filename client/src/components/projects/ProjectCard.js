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
    <Card body color="info" outline style={{ marginBottom: "8px" }}>
      <CardBody>
        <CardTitle tag="h5">{project.projectType.name}</CardTitle>
        <CardText>
          <div>
            Project Date: {new Date(project.dateOfProject).toLocaleString()}
          </div>
          <div>Worker: {project.workerFullName ? project.workerFullName : "Unassigned"}</div>
          <div>Project Description: "{project.description}"</div>
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
            navigate(`projects/${project.id}`);
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
