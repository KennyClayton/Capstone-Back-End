import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { login } from "../../managers/authManager";
import { Button, FormFeedback, FormGroup, Input, Label } from "reactstrap";
import "./Login.css"
import DudeWorkItLogo from "../DudeWorkIt.png"

export default function Login({ setLoggedInUser }) {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [failedLogin, setFailedLogin] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    login(email, password).then((user) => {
      if (!user) {
        setFailedLogin(true);
      } else {
        setLoggedInUser(user);
        navigate("/dashboard");
      }
    });
  };

  return (
    <div className="container" style={{ maxWidth: "500px" }}>
      {/* <img className= "sizeDownLogo" src={DudeWorkItLogo} alt="Logo" /> */}
      <br></br>
      <br></br>
      <h3>Login</h3>
      <br></br>
      <FormGroup>
        <Label>Email</Label>
        <Input
          invalid={failedLogin}
          type="text"
          value={email}
          onChange={(e) => {
            setFailedLogin(false);
            setEmail(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Password</Label>
        <Input
          invalid={failedLogin}
          type="password"
          value={password}
          onChange={(e) => {
            setFailedLogin(false);
            setPassword(e.target.value);
          }}
        />
        <FormFeedback>Login failed.</FormFeedback>
      </FormGroup>

      <Button color="info" onClick={handleSubmit}>
        Login
      </Button>
      <p>
        Not signed up? Register <Link to="/register">here</Link>
      </p>
    </div>
  );
}
