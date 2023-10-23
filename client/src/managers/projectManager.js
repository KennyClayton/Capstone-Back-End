const apiUrl = "/api/project";
const apiUrlTypes = "/api/projecttype";

export const getProjects = () => {
  return fetch(apiUrl).then((res) => res.json());
};

export const getProjectById = (id) => {
  return fetch(`${apiUrl}/${id}`).then((res) => res.json());
};

export const getProjectTypes = () => {
  return fetch(apiUrlTypes).then((res) => res.json());
};