import { useRouter } from "next/router";
import React, { SyntheticEvent, useState } from "react";
import { Form, Button } from "react-bootstrap";
import { isLoggedIn, login } from "../services/userService";

const LoginForm = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const router = useRouter();

  const isFormValid = username !== "" && password !== "";
  
  const handleLoginClick = async (e: SyntheticEvent) => {
    e.preventDefault();

    isFormValid && login({ username, password }).then(() => isLoggedIn() && router.push('/')); 
  };

  return (
    <Form>
      <Form.Group className="mb-3" controlId="formBasicUsername ">
        <Form.Label>Username</Form.Label>
        <Form.Control
          type="text"
          placeholder="Enter username"
          onChange={(e) => setUsername(e.target.value)}
        />
      </Form.Group>
      <Form.Group className="mb-3" controlId="formBasicPassword">
        <Form.Label>Password</Form.Label>
        <Form.Control
          type="password"
          placeholder="Password"
          onChange={(e) => setPassword(e.target.value)}
        />
      </Form.Group>
      <Button
        variant="primary"
        type="submit"
        disabled={!isFormValid}
        onClick={(e) => handleLoginClick(e)}
      >
        Login
      </Button>
    </Form>
  );
};

export default LoginForm;
