/* eslint-disable react-hooks/exhaustive-deps */
import { useRouter } from "next/router";
import React, { SyntheticEvent, useEffect, useState } from "react";
import { Form, Button } from "react-bootstrap";
import { axiosInstance } from "../../helpers/axiosInstances";
import { messages } from "../../messages/messages";
import ToastMessage from "../Toast";

const RegisterForm = () => {
  const [email, setEmail] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [toastMessage, setToastMessage] = useState("");

  const router = useRouter();

  const isFormValid = email !== "" && username !== "" && password !== "";

  const handleRegisterClick = async (e: SyntheticEvent) => {
    e.preventDefault();

    isFormValid &&
      (await axiosInstance
        .post("/register", {
          email,
          username,
          password,
        })
        .then(() => router.push("/login"))
        .catch((err: Error) => {
          setToastMessage(err.message);
        }));
  };

  return (
    <>
      <Form>
        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>Email</Form.Label>
          <Form.Control
            type="text"
            placeholder="Enter email"
            onChange={(e) => setEmail(e.target.value)}
          />
        </Form.Group>
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
          onClick={(e) => handleRegisterClick(e)}
        >
          Register
        </Button>
      </Form>
      {toastMessage !== "" && <ToastMessage toastMessage={toastMessage} />}
    </>
  );
};

export default RegisterForm;
