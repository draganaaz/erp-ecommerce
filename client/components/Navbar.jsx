import { useRouter } from "next/router";
import React from "react";
import { Navbar, Container, Nav } from "react-bootstrap";
import BasketIcon from "./BasketIcon";
import SearchBar from "./SearchBar";

const NavbarItems = {
  Categories: "Categories",
  Brands: "Brands",
  Man: "Man",
  Woman: "Woman",
  Kids: "Kids",
};

const NavbarComponent = () => {
  const router = useRouter();

  const redirect = (param) => {
    router.push(`/${param.toString().toLowerCase()}`);
  };

  const openCart = () => {
    router.push("/cart");
  };

  return (
    <Navbar bg="light" expand="lg">
      <Container fluid>
        <Navbar.Brand onClick={() => redirect('/')}>eSport</Navbar.Brand>
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
          <BasketIcon onClick={openCart} />
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavbarComponent;
