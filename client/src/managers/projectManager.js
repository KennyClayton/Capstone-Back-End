const apiUrl = "/api/project";
const apiUrlTypes = "/api/projecttype";

export const getProjects = () => {
  return fetch(apiUrl).then((res) => res.json());
};

export const getProjectById = (id) => {
  return fetch(`${apiUrl}/${id}`).then((res) => res.json());
};

//~ Define a function that will fetch all project types from the database
export const getProjectTypes = () => {
  return fetch(apiUrlTypes).then((res) => res.json());
};

// at the "/user-projects" endoint, the server should give us a list of projects related to the signed-in user's id
export const getUserProjects = () => {
  return fetch(apiUrl + "/user-projects").then((res) => res.json());
};


//This is where front and back end connect.


//* ProjectManager tells the server what KIND of request (GET) and WHERE (endpoint) to fetch it from
//* ProjectController tells the server what specific data/CONTENT to get