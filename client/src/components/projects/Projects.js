import { useState } from "react";
import ProjectList from "./ProjectsList";
import ProjectDetails from "./ProjectDetails";
import CreateProject from "./CreateProject"; // this is a component that creates a list of projects



export default function Projects() { // this function renders two child components, ProjectList and ProjectDetails
  const [detailsProjectId, setDetailsProjectId] = useState(null); 

  return (
    <div className="container">
      <div className="row">
        <div className="col-sm-6">
          <ProjectList setDetailsProjectId={setDetailsProjectId} />
        </div>
        <div className="col-sm-4">
        <CreateProject />
          {/* <ProjectDetails detailsBikeId={detailsProjectId} /> */}
        </div>
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
//* IMPORTANT - We could just tell ApplicationViews.js to render ProjectList.js at the root "/" directory. But instead we are rendering this component first. Why? Because we can choose to render multiple components if we want. For example, we could render the Project Details component as well. I have it commented out as of 10/23/2023 11:16am.