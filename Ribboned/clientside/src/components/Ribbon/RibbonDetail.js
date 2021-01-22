import React from "react";
//import "../../../node_modules/video-react/dist/video-react";
import { Player } from "video-react";

export const RibbonDetail = () => {
  return (
    <>
      <div className="container">
        <h1>Ribbon Detail</h1>
        <Player>
          <source src="https://media.w3.org/2010/05/sintel/trailer_hd.mp4" />
        </Player>
      </div>
    </>
  );
};
