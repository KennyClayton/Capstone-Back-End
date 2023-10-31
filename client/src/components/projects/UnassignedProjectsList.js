// This module renders a list of projects that HAVE NOT been assigned to any workers yet
import UnassignedProjectCard from "./UnassignedProjectCard";

// Function that maps over projectAssignments list and renders a new card for each projectAssignment
// we need a list of projectAssignments, so we pass in projectAssignmentsByUserId as a prop that we can reference and .map over
export default function ListOfUnassignedProjects({
  loggedInUser,
  unassignedProjectAssignments,
  getProjectAssignmentsByUserId,
  getUnassignedProjectAssignments,
}) {
  return (
    <>
      <h2>Available Projects</h2>
      {unassignedProjectAssignments?.map((unassignedProjectAssignment) => (
        <UnassignedProjectCard
          getUnassignedProjectAssignments={getUnassignedProjectAssignments}
          getProjectAssignmentsByUserId={getProjectAssignmentsByUserId}
          loggedInUser={loggedInUser}
          unassignedProjectAssignment={unassignedProjectAssignment}
          key={`unassigned-project-assignment-${unassignedProjectAssignment.id}`}
        ></UnassignedProjectCard>
      ))}
    </>
  );
}

//* MUY IMPORTANTE AGAIN - I had gotten a list of all projectAssignments with no worker assigned yet (back in Project.js)
//* I needed the entire list accessible on this component because I wanted to render that list
//* Which means I needed to map over the whole list and display a project card for each individual unassignedProjectAssignment
//* BAM! I now have access to the individual unassignedProjectAssignment.
//* I thought I would have to go back to Project.js and fetch projectAssignments by Id and pass that all the way here as a prop, but no need.
//* Instead, I took the single instance of unassignedProjectAssignment (referenced in the function above) and entered it here to pass it on to UnassignedProjectCard.js as a prop
