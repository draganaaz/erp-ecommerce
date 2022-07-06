import React from "react";
import { Form } from "react-bootstrap";

const Select = ({ items, setSelected, defaultValue }) => {
  const handleSelect = (e) => {
    setSelected(e.target.value);
  };

  return (
    <Form.Select onChange={handleSelect}>
      <option value="">{defaultValue}</option>
      {items.map((item, index) => (
        <option key={index} value={Object.keys(item)}>
          {Object.values(item)}
        </option>
      ))}
    </Form.Select>
  );
};

export default Select;
