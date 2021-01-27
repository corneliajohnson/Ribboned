import React, { useContext, useState } from "react";
import { useHistory } from "react-router-dom";
import { Button, Input } from "reactstrap";
import { Link } from "react-router-dom";
import { UserProfileContext } from "../../providers/UserProfileProvider";
import Logo from "../../img/RibbonedFinger.png";
import LogoWords from "../../img/RibbonedWordOnly.png";
import "./Login.css";

export const Login = () => {
  const { login } = useContext(UserProfileContext);
  const [loading, setLoading] = useState(false);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const history = useHistory();

  const handleSubmit = (e) => {
    e.preventDefault();
    setLoading(true);
    login(email, password)
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
        <h2 className="text-center text-white">Login</h2>
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
          <Button type="submit" block color="dark" disabled={loading}>
            Sign in
          </Button>
        </div>
        <div className="text-center small">
          Don't have an account?
          <div>
            <Link className="text-white" to="/register">
              Sign up here
            </Link>
          </div>
        </div>
      </form>
    </div>
  );
};
