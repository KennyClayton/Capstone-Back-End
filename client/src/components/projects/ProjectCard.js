import {
    Card,
    CardBody,
    CardTitle,
    CardText,
    CardSubtitle,
    Button,
  } from "reactstrap";
  
//! The Card Title is not showing up. 



  export default function ProjectCard({ project, FullName, setDetailsProjectId }) {
    return (
      <Card body color="info" outline style={{ marginBottom: "8px" }}>
        <CardBody>
          <CardTitle tag="h5">Placeholder Text</CardTitle>
          <CardSubtitle className="mb-2 text-muted" tag="h6">
            Project Date: {project.dateOfProject}
            <br></br>
            Worker: {project.userProfile.fullName}
          </CardSubtitle>
          <CardText>Project Description: "{project.description}"</CardText>
          <Button
            color="info"
            onClick={() => {
                setDetailsProjectId(project.id);
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
  