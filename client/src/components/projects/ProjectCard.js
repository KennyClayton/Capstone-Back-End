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
  
  
  export default function ProjectCard({ project, setDetailsProjectId }) {
    const navigate = useNavigate();
    
    return (
      <Card body color="info" outline style={{ marginBottom: "8px" }}>
        <CardBody>
          <CardTitle tag="h5">Placeholder Text</CardTitle>
          <CardSubtitle className="mb-2 text-muted" tag="h6">
            Project Date: {(new Date (project.dateOfProject)).toLocaleString()}
            <br></br>
            Worker: {}Pending: how to grab the worker FullName
          </CardSubtitle>
          <CardText>Project Description: "{project.description}"</CardText>
            
          <Button
            color="info"
            onClick={() => {
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
  