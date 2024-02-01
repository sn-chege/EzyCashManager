import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import useIsAuthenticated from 'react-auth-kit/hooks/useIsAuthenticated';
import axios from "axios";
import {
  Button,
  Card,
  CardBody,
  FormGroup,
  Form,
  Input,
  InputGroupAddon,
  InputGroupText,
  InputGroup,
  Row,
  Col,
} from "reactstrap";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();
  const signIn = useSignIn();
  const isAuthenticated = useIsAuthenticated();

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post("http://52.28.234.192:81/api/user/login", {
        email: email,
        password: password
      });

      if (response.status === 200) {
        const authData = {
          auth: {
            token: response.data.jwtToken,
            type: 'Bearer'
          },
          userState: {
              name: response.data.name,
              email: response.data.name
          }
        };

        // Use the signIn hook to store authentication data
        signIn(authData);

        // Redirect to the dashboard upon successful login
        navigate("/admin/index");
      }

      // Handle the response as needed
      console.log("Login successful!", response.data);
    } catch (error) {
      // Handle errors, show error messages, etc.
      console.error("Error during login:", error.message);
    }
  };

  useEffect(() => {
    // Check if the user is authenticated on component mount
    if (isAuthenticated()) {
      // Redirect to Dashboard
      navigate("/admin/index");
    }
  }, [isAuthenticated, navigate]);

  return (
    <Col lg="5" md="7">
    <Card className="bg-secondary shadow border-0">
      <CardBody className="px-lg-5 py-lg-5">
        <div className="text-center text-muted mb-4">
          <small>Sign in with your credentials</small>
        </div>
        <Form role="form" onSubmit={handleLogin}>
          <FormGroup className="mb-3">
            <InputGroup className="input-group-alternative">
              <InputGroupAddon addonType="prepend">
                <InputGroupText>
                  <i className="ni ni-email-83" />
                </InputGroupText>
              </InputGroupAddon>
              <Input
                placeholder="Email"
                type="email"
                autoComplete="new-email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </InputGroup>
          </FormGroup>
          <FormGroup>
            <InputGroup className="input-group-alternative">
              <InputGroupAddon addonType="prepend">
                <InputGroupText>
                  <i className="ni ni-lock-circle-open" />
                </InputGroupText>
              </InputGroupAddon>
              <Input
                placeholder="Password"
                type="password"
                autoComplete="new-password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </InputGroup>
          </FormGroup>
          <div className="custom-control custom-control-alternative custom-checkbox">
            <input
              className="custom-control-input"
              id="customCheckLogin"
              type="checkbox"
            />
            <label
              className="custom-control-label"
              htmlFor="customCheckLogin"
            >
              <span className="text-muted">Remember me</span>
            </label>
          </div>
          <div className="text-center">
            <Button className="my-4" color="primary" type="submit">
              Sign in
            </Button>
          </div>
        </Form>
      </CardBody>
    </Card>
    <Row className="mt-3">
      <Col xs="6">
        <a
          className="text-light"
          href="#pablo"
          onClick={(e) => e.preventDefault()}
        >
          <small>Forgot password?</small>
        </a>
      </Col>
      <Col className="text-right" xs="6">
        <a
          className="text-light"
          href="/register"
        >
          <small>Create new account</small>
        </a>
      </Col>
    </Row>
  </Col>
  );
};

export default Login;
