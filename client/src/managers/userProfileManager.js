const apiUrl = "/api/userProfile";

export const getUsers = () =>
{
    return fetch(apiUrl).then((res) => res.json())
};

export const getUserById = (id) => 
{
    return fetch(`${apiUrl}/${id}`).then((res) => res.json());
}

export const createUser =  (user) => {
    const res = fetch(apiUrl, {
      method: "POST",
          headers: {
          "Content-Type": "application/json",
          },
          body: JSON.stringify(user),
    });
    return res.json();
};

export const getUserProfiles = () => {
    return fetch(apiUrl).then((res) => res.json());
  };


  //^ This will hit the endpoint to get worker user profiles
export const getWorkerProfiles = () => {
    return fetch(`${apiUrl}/withworkerroles`).then((res) => res.json());
}

  //^ This will hit the endpoint to get customer user profiles
  export const getCustomerProfiles = () => {
    return fetch(`${apiUrl}/withcustomerroles`).then((res) => res.json());
}