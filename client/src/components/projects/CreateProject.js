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
import { getProjectTypes } from "../../managers/projectManager";

export default function CreateProject() {
  const [projectTypes, setProjectTypes] = useState([]);
  const [selectedProjectType, setSelectedProjectType] = useState("");

  // Fetch project types from your API when the component mounts
  useEffect(() => {
    getProjectTypes().then((data) => setProjectTypes(data));
  }, []);

  const [projectData, setProjectData] = useState({
    projectType: "",
    dateOfProject: "",
    description: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProjectData({
      ...projectData,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Handle form submission, e.g., send projectData to your API
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
              value={projectData.projectType}
              onChange={handleChange}
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
              type="date"
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
