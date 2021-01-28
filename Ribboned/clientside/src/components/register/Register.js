import React, { useContext, useState } from "react";
import { Redirect } from "react-router-dom";
import { useHistory } from "react-router-dom";
import { Button, Input } from "reactstrap";
import { Link } from "react-router-dom";
import { UserProfileContext } from "../../providers/UserProfileProvider";
import Logo from "../../img/RibbonedFinger.png";
import LogoWords from "../../img/RibbonedWordOnly.png";
import "../login/Login.css";

export const Register = () => {
  const { register } = useContext(UserProfileContext);
  const [loading, setLoading] = useState(false);
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirm, setConfirm] = useState("");
  const history = useHistory();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirm) {
      // toast.error("Passwords do not match");
      return;
    }

    setLoading(true);
    const profile = {
      username,
      email,
    };
    register(profile, password)
      .then((user) => {
        setLoading(false);
        history.push("/");
      })
      .catch((err) => {
        setLoading(false);
      });
  };

  return (
    <div className="login-form">
      <div>
        <img className="full-logo" src={LogoWords} alt="main-logo" />
      </div>
      <form onSubmit={handleSubmit} className="bg-primary m-5">
        <div className="avatar bg-white">
          <img src={Logo} alt="Avatar" />
        </div>
        <h2 className="text-center text-white">Register</h2>
        <div className="form-group">
          <Input
            onChange={(e) => setUsername(e.target.value)}
            type="text"
            className="form-control"
            name="username"
            placeholder="username"
            required="required"
          />
        </div>
        <div className="form-group">
          <Input
            onChange={(e) => setEmail(e.target.value)}
            type="email"
            className="form-control"
            name="email"
            placeholder="Email"
            required="required"
          />
        </div>
        <div className="form-group">
          <Input
            onChange={(e) => setPassword(e.target.value)}
            type="password"
            className="form-control"
            name="password"
            placeholder="Password"
            required="required"
          />
        </div>
        <div className="form-group">
          <Input
            onChange={(e) => setConfirm(e.target.value)}
            type="password"
            className="form-control"
            name="confirmPassword"
            placeholder="Confirm Password"
            required="required"
          />
        </div>
        <div className="form-group">
          <Button type="submit" block color="dark" disabled={loading}>
            Sign Up
          </Button>
        </div>
        <div className="text-center small">
          Already have an account?
          <div>
            <Link className="text-white" to="/login">
              Log in here
            </Link>
          </div>
        </div>
      </form>
    </div>
  );
};
