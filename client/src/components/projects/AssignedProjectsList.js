// This module renders a list of projects assigned to the loggedIn Worker
import ProjectAssignmentCard from "./ProjectAssignmentCard";

// Function that maps over projectAssignments list and renders a new card for each projectAssignment
  // we need a list of projectAssignments, so we pass in projectAssignmentsByUserId as a prop that we can reference and .map over
export default function ListOfAssignedProjects ({ loggedInUser, project, projectAssignmentsByUserId, setprojectAssignmentsByUserId}) {
    return (    
        <>
          <h2>{loggedInUser.fullName}'s Projects</h2>
          {projectAssignmentsByUserId.map((projectAssignment) => (
                <ProjectAssignmentCard
                project={project} // passing this all the way from ApplicationViews because I want access to the Customer's UserProfile properties, like fullName
                  projectAssignment={projectAssignment}
                  setprojectAssignmentsByUserId={setprojectAssignmentsByUserId}
                  // setDetailsProjectAssignmentId={setDetailsProjectAssignmentId}
                  key={`projectAssignment-${projectAssignment.id}`}
                >
                </ProjectAssignmentCard>          
              ))}
        </>
      );
    }
