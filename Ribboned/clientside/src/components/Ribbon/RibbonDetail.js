import React, { useState, useRef } from "react";
import ReactPlayer from "react-player";
import { Button } from "reactstrap";

export const RibbonDetail = () => {
  const [state, setState] = useState({
    playing: false,
    duration: 0,
  });
  const [timeDisplayFormat, setTimeDisplayformat] = useState("normal");
  const { playing, seeking } = state;
  const playerRef = useRef(null);

  //play pause toggle
  const handlePlayPause = () => {
    setState({ ...state, playing: !state.playing });
  };

  //format time
  const format = (seconds) => {
    if (isNaN(seconds)) {
      return "00:00";
    }

    //set formatting
    const date = new Date(seconds * 1000);
    const hh = date.getUTCHours();
    const mm = date.getUTCMinutes();
    const ss = date.getUTCSeconds().toString().padStart(2, "0");

    if (hh) {
      return `${hh}:${mm.toString().padStart(2, "0")}:${ss}`;
    }
    return `${mm}:${ss}`;
  };

  //get the seconds played
  const handleProgress = (changeState) => {
    if (!state.seeking) {
      setState({ ...state, ...changeState });
      //format seconds
      const time = format(changeState.playedSeconds);
      setTimeDisplayformat(time);
    }
  };

  return (
    <>
      <div className="container ">
        <h1 className="text-center">Ribbon Title</h1>
        <div>
          <div className="d-flex justify-content-center">
            <ReactPlayer
              ref={playerRef}
              // muted={true}
              playing={playing}
              onProgress={handleProgress}
              controls={true}
              url="https://www.youtube.com/watch?v=ysz5S6PUM-U"
            />
          </div>
          <div className="text-center m-3">
            <Button className="btn btn-lg w-50" onClick={handlePlayPause}>
              {playing ? `Add Snag ${timeDisplayFormat}` : "Continue"}
            </Button>
          </div>
        </div>
      </div>
    </>
  );
};
