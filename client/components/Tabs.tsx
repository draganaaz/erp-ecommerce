import React, { useEffect, useState } from "react";
import getAllBrands from "../services/getAllBrands";
import getAllCategories from "../services/getAllCategories";
import getAllProducts from "../services/getAllProducts";
import TableWrapper from "./Table";

const TabsWrapper = () => {
  const tabs = ["Categories", "Brands", "Products"];
  const [selectedTab, setSelectedTab] = useState(tabs[0]);
  const [tableData, setTableData] = useState([]);

  const handleTabClick = (item: string) => {
    setSelectedTab(item);
    switch (item) {
      case "Categories":
        return getAllCategories().then((res) => setTableData(res));
      case "Brands":
        return getAllBrands().then((res) => setTableData(res));
      case "Products":
        return getAllProducts().then((res) => setTableData(res));
    }
  };

  useEffect(() => {
    // Load initial data
    getAllCategories().then((res) => setTableData(res));
  }, []);

  return (
    <nav className="tabs configurator-tabs">
      <ul>
        {tabs &&
          tabs.map((item: string) => (
            <li
              key={item}
              id={`${item}-configurator-tab`}
              className={
                item === selectedTab ? "conf-item selected" : "conf-item"
              }
              onClick={() => handleTabClick(item)}
            >
              <>
                <p>{item}</p>
                {item === selectedTab && (
                  <TableWrapper data={tableData} type={item} />
                )}
              </>
            </li>
          ))}
      </ul>
    </nav>
  );
};

export default TabsWrapper;
