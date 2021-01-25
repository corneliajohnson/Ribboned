import React, { useContext, useEffect } from "react";
import { YouTubeSearch } from "./YouTube/YouTubeSearch";
import Logo from "../img/RibbonedWordOnly.png";
import { CategoryContext } from "../providers/CategoryProvider";

export const Home = () => {
  const { getCategories, categories } = useContext(CategoryContext);

  useEffect(() => {
    getCategories();
  }, []);

  return (
    <>
      <div className="container">
        {console.log(categories)}
        <div className="align-items-center">
          <img alt="ribboned" src={Logo} />
          <YouTubeSearch />
          <div style={{ height: "30vh", border: "1px solid black" }}>
            <h3>Show Videos Here</h3>
          </div>

          <h3>Recent Ribbon Snags</h3>
          <div style={{ height: "30vh", border: "1px solid black" }}>
            <h4>list of ribbon snags here</h4>
          </div>
        </div>
      </div>
    </>
  );
};
