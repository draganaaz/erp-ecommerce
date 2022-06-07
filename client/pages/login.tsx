import { useRouter } from "next/router";
import React from "react";
import { Card } from "react-bootstrap";
import LoginForm from "../components/LoginForm";

const Login = () => {
  const router = useRouter();

  const redirect = () => {
    router.push("/register");
  };
  
  return (
    <Card style={{ width: "50%", padding: "4%", margin: "40px auto" }}>
      <LoginForm />
      <p onClick={() => redirect()}>{"Don't have an account? Create one!"}</p>
    </Card>
  );
};

export default Login;
