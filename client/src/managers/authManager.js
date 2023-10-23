const apiUrl = "/api/auth";

export const login = (email, password) => {
  return fetch(apiUrl + "/login", {
    method: "POST",
    credentials: "same-origin",
    headers: {
      Authorization: `Basic ${btoa(`${email}:${password}`)}`,
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.resolve(null);
    } else {
      return tryGetLoggedInUser();
    }
  });
}; 

export const logout = () => {
  return fetch(apiUrl + "/logout"); 
};

export const tryGetLoggedInUser = () => {
  return fetch(apiUrl + "/Me").then((res) => {
    return res.status === 401 ? Promise.resolve(null) : res.json();
  });
};


//^ Below will send the registered user's input to the database to register the new user
export const register = (userProfile) => {
  userProfile.password = btoa(userProfile.password);
  return fetch(apiUrl + "/register", {
    credentials: "same-origin",
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userProfile),
  }).then(() => fetch(apiUrl + "/me").then((res) => res.json()));
};
