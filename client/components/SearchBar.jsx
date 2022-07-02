/* eslint-disable react-hooks/exhaustive-deps */
import React, { useState, useEffect } from "react";
import { Button, FormControl, Form } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { paginatedProductsState } from "../atoms/atoms";
import getPaginatedProducts from "../services/getPaginatedProducts";

const SearchBar = () => {
  const [input, setInput] = useState("");
  const [, setPaginatedProducts] = useRecoilState(paginatedProductsState);

  const minChars = 3; // number of chars after which search is performed

  // Search products on input change
  useEffect(() => {
    if (input.length >= minChars) {
      getPaginatedProducts({ query: input }).then((res) => {
        setPaginatedProducts(res);
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
