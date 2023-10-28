const apiUrl = "/api/project";
const apiUrlTypes = "/api/projecttype";

export const getProjects = () => {
  return fetch(apiUrl).then((res) => res.json());
};

export const getProjectById = (id) => {
  return fetch(`${apiUrl}/${id}`).then((res) => res.json());
};

//^GET - Define a function that will fetch all project types from the database
export const getProjectTypes = () => {
  return fetch(apiUrlTypes).then((res) => res.json());
};

//^ GET - at the "/user-projects" endoint, the server should give us a list of projects related to the signed-in user's id
export const getUserProjects = () => {
  return fetch(`${apiUrl}/user-projects`).then((res) => res.json());
};


export const getWorkerProjects = (id) => {
  return fetch(`${apiUrl}/worker-projects/${id}`).then((res) => res.json());
};

//^ POST - Create a new project
export const createProject = (project) => {
  return fetch(apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(project),
  }).then((res) => res.json);
};

//^ DELETE - Function to delete a project by Id
export const deleteProjectById = (id) => {
  return fetch(`${apiUrl}/${id}`, {
    method: "DELETE",
  });
};

//^ UPDATE - Function to update a project
export const updateProject = (project) => {
  return fetch(`${apiUrl}/${project.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(project),
  }).then((res) => res.json());
}

//This is where front and back end connect.


//* ProjectManager tells the server what KIND of request (GET) and WHERE (endpoint) to fetch it from
//* ProjectController tells the server what specific data/CONTENT to get