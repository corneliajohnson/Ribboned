import React, { useState, useRef } from "react";
import ReactPlayer from "react-player";
import { Button } from "reactstrap";

export const RibbonDetail = () => {
  const [state, setState] = useState({
    playing: false,
    paused: false,
    duration: 0,
  });
  const [timeDisplayFormat, setTimeDisplayformat] = useState("normal");
  const [snags, setSnags] = useState([]);
  const { playing } = state;
  const { paused } = state;

  //refs
  const playerRef = useRef(null);
  const canvasRef = useRef(null);

  //play pause toggle
  const handlePlayPause = () => {
    setState({ ...state, playing: !state.playing });
  };

  const handlePlay = () => {
    setState({ ...state, playing: true });
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

  //add info for snag
  const addSnag = () => {
    const snagCopy = [...snags];
    snagCopy.push({
      time: playerRef.current.getCurrentTime(),
      display: format(playerRef.current.getCurrentTime()),
    });
    setSnags(snagCopy);
  };

  const handleSeekChange = (e, newValue) => {
    console.log({ newValue });
    setState({ ...state, played: parseFloat(newValue / 100) });
  };

  return (
    <>
      <div className="container">
        <h1 className="text-center">Ribbon Title</h1>
        <div>
          <div className="d-flex justify-content-center">
            <ReactPlayer
              onSeek={handleSeekChange}
              ref={playerRef}
              // muted={true}
              onPause={paused}
              playing={playing}
              onProgress={handleProgress}
              controls={true}
              url="https://www.youtube.com/watch?v=ysz5S6PUM-U"
              //url="https://media.w3.org/2010/05/sintel/trailer_hd.mp4"
            />
          </div>
          <div className="text-center m-3">
            <Button
              className="btn btn-lg btn-secondary w-50"
              onClick={() => {
                handlePlayPause();
                addSnag();
              }}
            >
              Add Snag {timeDisplayFormat}
            </Button>
          </div>
          {/* Snags */}
          <div className="row p-5">
            <div className="col align-self-center">
              <div class="list-group">
                <div class="list-group-item list-group-item-action active">
                  Ribbon Snags
                </div>
                {snags.map((snag) => (
                  <>
                    <div class="list-group-item list-group-item-actions">
                      <Button
                        className="btn btn-link"
                        onClick={() => {
                          //go to seconds stamp of video
                          playerRef.current.seekTo(snag.time);
                          //play video
                          handlePlay();
                        }}
                      >
                        {snag.display}
                      </Button>
                      Snag Note
                    </div>
                  </>
                ))}
                ;
              </div>
            </div>
          </div>
        </div>
        <canvas ref={canvasRef} />
      </div>
    </>
  );
};
