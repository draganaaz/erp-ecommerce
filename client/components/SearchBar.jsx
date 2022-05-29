/* eslint-disable react-hooks/exhaustive-deps */
import React, { useState, useEffect } from "react";
import { Button, FormControl, Form } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { productsState } from "../atoms/atoms";
import filterProducts from "../services/filterProducts";

const SearchBar = () => {
  const [input, setInput] = useState("");
  const [, setProducts] = useRecoilState(productsState);

  const minChars = 3; // number of chars after which search is performed

  // Search products on input change
  useEffect(() => {
    if (input.length >= minChars) {
      filterProducts({ query: input }).then((res) => {
        setProducts(res);
      });
    }
  }, [input]);

  // Handle input change
  const handleChange = (e) => {
    setInput(e.target.value);
  };

  return (
    <Form className="d-flex">
      <FormControl
        type="search"
        placeholder="Search..."
        className="me-2"
        aria-label="Search"
        onChange={handleChange}
      />
      <Button variant="outline-success">Search</Button>
    </Form>
  );
};

export default SearchBar;
