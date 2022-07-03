import { useRouter } from "next/router";
import React from "react";
import { Card } from "react-bootstrap";
import RegisterForm from "../components/Forms/RegisterForm";

const Register = () => {
  const router = useRouter();

  const redirect = () => {
    router.push("/login");
  };

  return (
    <Card style={{ width: "50%", padding: "4%", margin: "40px auto" }}>
      <RegisterForm />
      <p onClick={() => redirect()}>{"Already have account? Log in"}</p>
    </Card>
  );
};

export default Register;
