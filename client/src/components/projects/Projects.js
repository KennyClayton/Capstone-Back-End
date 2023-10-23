import { useState } from "react";
import ProjectList from "./ProjectsList";
import ProjectDetails from "./ProjectDetails";



export default function Projects() {
  const [detailsProjectId, setDetailsProjectId] = useState(null); 

  return (
    <div className="container">
      <div className="row">
        <div className="col-sm-8">
          <ProjectList setDetailsProjectId={setDetailsProjectId} />
        </div>
        {/* <div className="col-sm-4">
          <ProjectDetails detailsBikeId={detailsProjectId} />
        </div> */}
      </div>
    </div>
  );
}


//* IMPORTANT - This component is a PARENT to ProjectsList.js component
// Line 14 where ProjectList is entered, we are passing setDetailsProjectId as a prop to the ProjectList component.
// This means that the ProjectList component can use the setDetailsProjectId function?
// Yes. As ChatGPT put it, "This makes setDetailsProjectId available in the ProjectList component, and it can be used to update the detailsProjectId state in the parent Projects component."
// So why do we need to pass setDetailsProjectId as a prop in this module?
// Because the function is CALLED in this module. We defined the function's purpose in ProjectsList, but it is imported for USE in this module.
// So in the browser, we signed into Cory Cotton's account and he has a UserProfile Id of 5.
// I am holding a user profile object in state on the ProjectList component now.
// 