import { useRouter } from "next/router";
import React from "react";
import { Navbar, Container, Nav, NavDropdown } from "react-bootstrap";
import SearchBar from "./SearchBar";

const NavbarItems = {
  Categories: "Categories",
  Brands: "Brands",
  Products: "Products",
  Man: "Man",
  Woman: "Woman",
  Kids: "Kids",
};

const NavbarComponent = () => {
  const router = useRouter();

  const redirect = (param) => {
    router.push(`/${param.toString().toLowerCase()}`);
  };

  return (
    <Navbar bg="light" expand="lg">
      <Container fluid>
        <Navbar.Brand href="#">eSport</Navbar.Brand>
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
            <NavDropdown
              onClick={() => redirect(NavbarItems.Products)}
              title={NavbarItems.Products}
              id="navbarScrollingDropdown"
            >
              <NavDropdown.Item onClick={() => redirect(NavbarItems.Man)}>
                {NavbarItems.Man}
              </NavDropdown.Item>
              <NavDropdown.Item onClick={() => redirect(NavbarItems.Woman)}>
                {NavbarItems.Woman}
              </NavDropdown.Item>
              <NavDropdown.Item onClick={() => redirect(NavbarItems.Kids)}>
                {NavbarItems.Kids}
              </NavDropdown.Item>
              <NavDropdown.Divider />
            </NavDropdown>
          </Nav>
          <SearchBar />
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavbarComponent;
