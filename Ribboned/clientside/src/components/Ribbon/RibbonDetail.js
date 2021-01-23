import React, { useState } from "react";
import ReactPlayer from "react-player";
import { Button } from "reactstrap";

export const RibbonDetail = () => {
  const [state, setState] = useState({
    playing: false,
  });

  const { playing } = state;

  const handlePlayPause = () => {
    setState({ ...state, playing: !state.playing });
    console.log("hi");
  };

  return (
    <>
      <div className="container ">
        <h1 className="text-center">Ribbon Title</h1>
        <div>
          <div className="d-flex justify-content-center">
            <ReactPlayer
              // muted={true}
              playing={playing}
              controls={true}
              url="https://www.youtube.com/watch?v=ysz5S6PUM-U"
            />
          </div>
          <div className="text-center m-3">
            <Button className="btn btn-lg w-50" onClick={handlePlayPause}>
              Click
            </Button>
          </div>
        </div>
      </div>
    </>
  );
};
