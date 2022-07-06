import React from "react";
import TabsWrapper from "../components/Tabs";
import { isLoggedIn } from "../services/userService";

const adminPanel = () => {
  return isLoggedIn() ? (
    <TabsWrapper />
  ) : (
    <h3>You are not allowed to access this page.</h3>
  );
};

export default adminPanel;
