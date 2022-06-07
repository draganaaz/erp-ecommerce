import { useRouter } from "next/router";
import React, { useEffect, useState } from "react";
import { Navbar, Container, Nav } from "react-bootstrap";
import { getUserNameFromJwt, removeUser } from "../services/tokenService";
import { isLoggedIn } from "../services/userService";
import BasketIcon from "./icons/BasketIcon";
import UserIcon from "./icons/UserIcon";
import SearchBar from "./SearchBar";

const NavbarItems = {
  Categories: "Categories",
  Brands: "Brands",
  Man: "Man",
  Woman: "Woman",
  Kids: "Kids",
};

const NavbarComponent = () => {
  const [userName, setUserName] = useState("");
  const router = useRouter();

  const redirect = (param: string) => {
    router.push(`/${param.toString().toLowerCase()}`);
  };

  // If user is logged in, log him out, otherwise redirect to login page
  const handleUserIconClick = () => {
    if (isLoggedIn()) {
      removeUser();
      router.reload();
    } else {
      redirect("login");
    }
  };

  // Fetching username from localStorage in useEffect where window is defined
  useEffect(() => {
    isLoggedIn() ? setUserName(`Welcome, ${getUserNameFromJwt()}`) : setUserName('')
  }, []);

  return (
    <Navbar bg="light" expand="lg">
      <Container fluid>
        <Navbar.Brand onClick={() => redirect("/")}>eSport</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarScroll" />
        <Navbar.Collapse id="navbarScroll">
          <Nav
            className="me-auto my-2 my-lg-0"
            style={{ maxHeight: "100px" }}
            navbarScroll
          >
            <Nav.Link onClick={() => redirect(NavbarItems.Categories)}>
              {NavbarItems.Categories}
            </Nav.Link>
            <Nav.Link onClick={() => redirect(NavbarItems.Brands)}>
              {NavbarItems.Brands}
            </Nav.Link>
            <Nav.Link onClick={() => redirect(NavbarItems.Man)}>
              {NavbarItems.Man}
            </Nav.Link>
            <Nav.Link onClick={() => redirect(NavbarItems.Woman)}>
              {NavbarItems.Woman}
            </Nav.Link>
            <Nav.Link onClick={() => redirect(NavbarItems.Kids)}>
              {NavbarItems.Kids}
            </Nav.Link>
          </Nav>
          <SearchBar />
          <BasketIcon onClick={() => redirect("/cart")} />
          {userName}
          <UserIcon onClick={handleUserIconClick} />
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavbarComponent;
