const apiUrl = "/api/project";
const apiUrlAssignments = "/api/projectAssignment";
const apiUrlTypes = "/api/projecttype";

//^1 GET - Get all projects
export const getProjects = () => {
  return fetch(apiUrl).then((res) => res.json());
};

//^2 GET - Get projects by id
export const getProjectById = (id) => {
  return fetch(`${apiUrl}/${id}`).then((res) => res.json());
};

//^3 GET - Define a function that will fetch a list of projects related to the logged-in user's Id
export const getUserProjects = () => {
  return fetch(`${apiUrl}/user-projects`).then((res) => res.json());
};

//^4 POST - Create a new project
export const createProject = (project) => {
  return fetch(apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(project),
  }).then((res) => res.json);
};

//^5 DELETE - Function to delete a project by Id
export const deleteProjectById = (id) => {
  return fetch(`${apiUrl}/${id}`, {
    method: "DELETE",
  });
};

//^6 PUT - Function to update the details of a project
export const updateProject = (project) => {
  return fetch(`${apiUrl}/${project.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(project),
  }).then((res) => {
    //go back here 3 more undos if this doesn't work
    if (res.status === 204) {
      // Successful response, no content
      return;
    }
    if (!res.ok) {
      // Handle non-OK status codes
      throw new Error(`Request failed with status: ${res.status}`);
    }
    return res.json();
  })
  .catch((error) => {
    console.error('Error in updateProject:', error);
  });
}

//^ ---------- FUNCTIONS for ProjectTypes ---------- //^
//$ ---------- FUNCTIONS for ProjectTypes ---------- //$
//~ ---------- FUNCTIONS for ProjectTypes ---------- //~

//^7 GET - Define a function that will fetch all project types from the database
export const getProjectTypes = () => {
  return fetch(apiUrlTypes).then((res) => res.json());
};



//^ ---------- FUNCTIONS for ProjectAssignments ---------- //^
//$ ---------- FUNCTIONS for ProjectAssignments ---------- //$
//~ ---------- FUNCTIONS for ProjectAssignments ---------- //~

//^8 GET - Define a function that will fetch a list of all projectAssignments from the database
export const getProjectAssignments = () => {
  return fetch(apiUrlAssignments).then((res) => res.json());
};


//^9 GET - Define a function that will fetch a list of projectAssignments where the workers are assigned
//* Note that we will search by id in the database because we will have the UserProfileId which is unique to workers and customers alike. Looking at the projectassignment table, we compare the passed id and to the UserProfileId coulmn of the ProjectAssignment table in the database
export const getWorkerProjectAssignments = (id) => {
  return fetch(`${apiUrlAssignments}/worker-projects/${id}`).then((res) => res.json());
};

//^10 GET - Define a function that will fetch a list of projectAssignments where there is NO worker assigned
export const getAllUnassignedProjectAssignments = () => {
  return fetch(`${apiUrlAssignments}/unassigned-worker-projects`).then((res) => res.json());
}

//^11 PUT - Define a function that will update the UserProfile property on a ProjectAssignment object
//! Not sure how to setUnassignedProjectAssignments from projectManager 
// export const updateProjectAssignment = (projectAssignment) => {
//   return fetch(`${apiUrlAssignments}/${projectAssignment.id}`, {
//     method: "PUT",
//     headers: {
//       "Content-Type": "application/json",
//     },
//     body: JSON.stringify(projectAssignment), //parse into JSON
//   }).then((res) => {
//     //go back here 3 more undos if this doesn't work
//     if (res.status === 204) {
//       return console.log("UserProfile updated successfully.");
//         setUnassignedProjectAssignments(updatedUnassignedProjectAssignment); // Update the state;
//     }
//     if (!res.ok) {
//       // Handle non-OK status codes
//       throw new Error(`Request failed with status: ${res.status}`);
//     }
//     return res.json();
//   })
//   .catch((error) => {
//     console.error('Error in updateProject:', error);
//   });
// }

//^12 POST - Create a new projectAssignment
export const createProjectAssignment = (projectAssignment) => {
  return fetch(apiUrlAssignments, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(projectAssignment),
  }).then((res) => res.json);
};







//This is where front and back end connect.


//* ProjectManager tells the server what KIND of request (GET) and WHERE (endpoint) to fetch it from
//* ProjectController tells the server what specific data/CONTENT to get