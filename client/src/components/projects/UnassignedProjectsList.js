// This module renders a list of projects that HAVE NOT been assigned to any workers yet
import UnassignedProjectCard from "./UnassignedProjectCard";

// Function that maps over projectAssignments list and renders a new card for each projectAssignment
// we need a list of projectAssignments, so we pass in projectAssignmentsByUserId as a prop that we can reference and .map over
export default function ListOfUnassignedProjects({
  loggedInUser,
  project,
  unassignedProjectAssignments,
  setUnassignedProjectAssignments,
}) {
  return (
    <>
      <h2>Available Projects</h2>
      {unassignedProjectAssignments.map((projectAssignment) => (
        <UnassignedProjectCard
          project={project} // passing this all the way from ApplicationViews because I want access to the Customer's UserProfile properties, like fullName
          projectAssignment={projectAssignment}
          setUnassignedProjectAssignments={setUnassignedProjectAssignments}
          key={`unassigned-project-assignment-${projectAssignment.id}`}
        ></UnassignedProjectCard>
      ))}
    </>
  );
}
