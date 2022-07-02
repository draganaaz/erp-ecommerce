import React from "react";
import { Form } from "react-bootstrap";

const Select = ({ items, setSelected }) => {
  const handleSelect = (e) => {
    setSelected(e.target.value);
  };

  return (
    <Form.Select onChange={handleSelect}>
      <option value="">Sort by</option>
      {items.map((item, index) => (
        <option key={index} value={Object.keys(item)}>
          {Object.values(item)}
        </option>
      ))}
    </Form.Select>
  );
};

export default Select;
