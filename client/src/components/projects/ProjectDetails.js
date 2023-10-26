import { Card, CardTitle, CardSubtitle, CardBody, CardText, Button } from "reactstrap";
import { deleteProjectById, getProjectById, getProjects } from "../../managers/projectManager";
import { useParams, useNavigate } from "react-router-dom";
import { format } from 'date-fns';



export default function ProjectDetails({project, setProject}) {
  // const [project, setProject] = useState({}); //set initial state of "project" to an empty object. We will place the selected project object in there with useEffect
  const { id } = useParams(); //capture the project id from the URL
  // const formattedDate = format(new Date(project.dateOfProject), 'MMMM d, yyyy p');
  const navigate = useNavigate();
  // this will go to the server and get a project and set the state of "project" so it holds the matching project we retrieved from the database 


  // this fucntion will do two things: It will call the deleteProjectById function and it will then get all projects
  const deleteProject = (id) => {
    // Send an HTTP DELETE request to delete the work order
    deleteProjectById(id) // this says, run the deleteThisWorkOrder function on the selected OrderId, which will run the DELETE method on that object in the database
      .then(() => {
        getProjects();
        navigate("/");
      })
  };


  //Now that we have the project object that matches the one the user clicked on.... we can reference the "project" variable from the UseState...we can use the state of the project variable to do something with that project object. What do we want to do? We want to display the details of that project in our jsx that renders to the project's details page 
console.log({project})
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
      {/* <h2>Project Details</h2> */}
      <br></br>
      <Card body color="info" outline style={{ marginBottom: "8px" }}>
        <CardBody>
          <CardTitle tag="h5">Project Details</CardTitle>
          <CardSubtitle>Project Id: {project.id}</CardSubtitle>
          <CardSubtitle>Worker: {project.workerFullName ? project.workerFullName : "Unassigned"} </CardSubtitle>
          <CardText>Project Date: {(new Date (project.dateOfProject)).toLocaleString()}</CardText>
          <CardText>Project Description: {project.description}</CardText>
        </CardBody>
        <div className="d-flex justify-content-between">

        <Button>Edit Project</Button>
        <Button
        onClick={() => deleteProject(id)}
          color="danger"
          style={{ marginLeft: "8px" }} // Add left margin for spacing
        >
          Delete Project</Button>
      </div>
      </Card>
    </>
  );
}
