import React, { useState, useEffect } from "react";
import {
  Card,
  CardBody,
  CardTitle,
  CardText,
  CardSubtitle,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
} from "reactstrap";
import { createProject, getProjectTypes } from "../../managers/projectManager";
// import { useNavigate } from "react-router-dom";

export default function CreateProject({ loggedInUser, projectData, setProjectData, handleSubmit, selectedProjectType, setSelectedProjectType }) {
  const [projectTypes, setProjectTypes] = useState([]);  

  // Fetch project types from the API when the component mounts
  // we imported getProjectTypes function from projectManager.js which is what does the HTTP Get request for us and returns the project types in a list. SO once this useEffect runs, the projectTypes variable State is that it holds a list of project types.
  useEffect(() => {
    getProjectTypes().then((data) => setProjectTypes(data));
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    const clone = structuredClone(projectData);
    clone[name] = value;
    setProjectData(clone);
  };

  return (
    <div>
      <h2>Create A Project</h2>
      <Card body color="info" outline style={{ marginBottom: "8px" }}>
        <CardBody>
          {/* <CardTitle tag="h5">Create a New Project</CardTitle> */}
          <Form onSubmit={handleSubmit}>
            <FormGroup>
              <Label for="projectType">Project Type</Label>
              <Input
                type="select"
                name="projectType"
                id="projectType"
                value={selectedProjectType}
                onChange={(e) => {
                    setSelectedProjectType(e.target.value);
                  }}
              >
                <option value="">Select a project type</option>
                {projectTypes.map((projectType) => (
                  <option key={projectType.id} value={projectType.id}>
                    {projectType.name}
                  </option>
                ))}
              </Input>
            </FormGroup>
            <FormGroup>
              <Label for="dateOfProject">Date of Project</Label>
              <Input
                type="datetime-local"
                name="dateOfProject"
                id="dateOfProject"
                value={projectData.dateOfProject}
                onChange={handleChange}
              />
            </FormGroup>
            <FormGroup>
              <Label for="description">Project Description</Label>
              <Input
                type="text"
                name="description"
                id="description"
                value={projectData.description}
                onChange={handleChange}
              />
            </FormGroup>
            <Button color="info" type="submit">
              Create Project
            </Button>
          </Form>
        </CardBody>
      </Card>
    </div>
  );
}
