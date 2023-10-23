import { useState, useEffect } from "react";
import { Card, CardTitle, CardSubtitle, CardBody, CardText } from "reactstrap";
import { getProjectById } from "../../managers/projectManager";


export default function ProjectDetails({ detailsProjectId }) {
  const [project, setProject] = useState(null);

  const getProjectDetails = (id) => {
    getProjectById(id).then(setProject);
  };

  useEffect(() => {
    if (detailsProjectId) {
      getProjectDetails(detailsProjectId);
    }
  }, [detailsProjectId]);

  if (!project) {
    return (
      <>
        <h2>Project Details</h2>
        <p>Please choose a project...</p>
      </>
    );
  }
  return (
    <>
      <h2>Project Details</h2>
      <Card color="dark" inverse>
        <CardBody>
          <CardTitle tag="h4">{project.projectType}</CardTitle>
          <p>Description: {project.description}</p>
        </CardBody>
      </Card>
      <h4>Work Order History</h4>
      {/* {project.workOrders.map((wo) => (
        <Card
          outline
          color="warning"
          key={wo.id}
          style={{ marginBottom: "4px" }}
        >
          <CardBody>
            <CardTitle tag="h5">{wo.dateInitiated.split("T")[0]}</CardTitle>
            <CardSubtitle>
              Completed:{" "}
              {wo.dateCompleted ? wo.dateCompleted.split("T")[0] : "Open"}
            </CardSubtitle>
            <CardText>Description: {wo.description}</CardText>
          </CardBody>
        </Card>
      )
      )
      } */}
    </>
  );
}
