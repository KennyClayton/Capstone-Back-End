import React, { useEffect, useState } from "react";
import {
  Card,
  CardTitle,
  CardSubtitle,
  CardBody,
  CardText,
  Button,
} from "reactstrap";
import { getProjectTypes } from "../../managers/projectManager";
import { useParams, useNavigate } from "react-router-dom";
import { format } from "date-fns";

export default function AssignedProjectDetails({ project, setProject }) {
  // use the project and setProject as props from ApplicationViews so any changes there and here don't conflict.
  const { id } = useParams();
  const navigate = useNavigate();


//   useEffect(() => {
//     // we have access to all the project types objects in the "projectTypes" variable
//     getProjectTypes().then((data) => setProjectTypes(data));
//   }, []);

  const handleMyProjectsButton = () => {
    navigate("/");
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
            {project.workerFullName ? project.workerFullName : "Unassigned"}
          </CardSubtitle>
          <CardSubtitle>
            Project Date:{" "}
            {format(new Date(project.dateOfProject), "MMMM d, yyyy p")}
          </CardSubtitle>
          <CardSubtitle>
            Date Completed:{" "}
            {project.completedOn ? (
              project.completedOn
            ) : (
              <span className="text-muted">Not yet completed</span>
            )}
          </CardSubtitle>
          <CardSubtitle>
            Project Description: {project.description}
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
