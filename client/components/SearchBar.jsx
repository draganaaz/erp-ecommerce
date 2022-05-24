import React, { useState, useEffect } from "react";
import { Button, FormControl, Form } from "react-bootstrap";
import { useRecoilState } from "recoil";
import axios from "axios";
import {searchResultsState} from '../atoms/atoms'

const SearchBar = () => {
  const [input, setInput] = useState("");
  const [, setProducts] = useRecoilState(searchResultsState);
  const minChars = 3; // number of chars after which search is performed
  const productsUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

  const getProducts = async (input) => {
    // Begin searching after minimal required number of chars
    if (input.length >= minChars) {
      axios
        .get(`${productsUrl}/query=${input}`)
        .then((res) => {
          console.log(res);
        })
        .catch((err) => {
          console.error(err);
        });
    }
  };

  // Search products on input change
  useEffect(() => {
    getProducts(input).then((products) => {
      setProducts(products);
    });
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
