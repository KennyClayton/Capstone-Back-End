// import React, { useState, useEffect } from 'react';
// import { useHistory, useParams } from 'react-router-dom';
// import { Card, CardBody, CardTitle, Form, FormGroup, Label, Input, Button } from 'reactstrap';
// import { updateProject } from '../managers/projectManager';

// const EditProject = () => {
//   const { id } = useParams(); // Get the project ID from the URL
//   const history = useHistory();
//   const [project, setProject] = useState({
//     id: id,
//     projectType: '',
//     dateOfProject: new Date().toISOString().split('T')[0], // Format as 'YYYY-MM-DD'
//     description: '',
//   });

//   useEffect(() => {
//     // Fetch project details when the component mounts
//     // You can implement this logic to populate the form fields with the existing project data
//     // You can use the `getProjectById` function here
//   }, [id]);

//   const handleInputChange = (e) => {
//     const { name, value } = e.target;
//     setProject({
//       ...project,
//       [name]: value,
//     });
//   };

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     try {
//       // Call the updateProject function to send the updated project data to the server
//       await updateProject(project);

//       // Redirect to the project details page after the update
//       history.push(`/projects/${id}`);
//     } catch (error) {
//       // Handle any errors that occur during the update
//       console.error('Error updating project:', error);
//     }
//   };

//   return (
//     <div>
//       <Card color="info">
//         <CardBody>
//           <CardTitle>Edit Project</CardTitle>
//           <Form onSubmit={handleSubmit}>
//             <FormGroup>
//               <Label for="projectType">Project Type</Label>
//               <Input
//                 type="text"
//                 name="projectType"
//                 value={project.projectType}
//                 onChange={handleInputChange}
//               />
//             </FormGroup>
//             <FormGroup>
//               <Label for="dateOfProject">Date of Project</Label>
//               <Input
//                 type="date"
//                 name="dateOfProject"
//                 value={project.dateOfProject}
//                 onChange={handleInputChange}
//               />
//             </FormGroup>
//             <FormGroup>
//               <Label for="description">Description</Label>
//               <Input
//                 type="textarea"
//                 name="description"
//                 value={project.description}
//                 onChange={handleInputChange}
//               />
//             </FormGroup>
//             <Button color="info" type="submit">
//               Update Project
//             </Button>
//           </Form>
//         </CardBody>
//       </Card>
//     </div>
//   );
// };
