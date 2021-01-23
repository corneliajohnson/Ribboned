import React, { useState, useRef } from "react";
import ReactPlayer from "react-player";
import { Button } from "reactstrap";

export const RibbonDetail = () => {
  const [state, setState] = useState({
    playing: false,
    duration: 0,
  });
  const [timeDisplayFormat, setTimeDisplayformat] = useState("normal");
  const [bookmarks, setBookmarks] = useState([]);
  const { playing } = state;

  //refs
  const playerRef = useRef(null);
  const controlsRef = useRef(null);
  const canvasRef = useRef(null);

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

  const addBookmark = () => {
    const bookmarksCopy = [...bookmarks];
    bookmarksCopy.push({
      time: playerRef.current.getCurrentTime(),
      display: format(playerRef.current.getCurrentTime()),
    });
    setBookmarks(bookmarksCopy);
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
            <Button
              className="btn btn-lg btn-secondary w-50"
              onClick={handlePlayPause}
              onClick={addBookmark}
            >
              {playing ? `Add Snag ${timeDisplayFormat}` : "Continue"}
            </Button>
          </div>
          {/* Snags */}
          <div className="content-aldin-center m-3">
            <h3>Snags</h3>
            {bookmarks.map((bookmark, index) => (
              <>
                <div key={index} item>
                  <div
                    onClick={() => {
                      playerRef.current.seekTo(bookmark.time);
                      controlsRef.current.style.visibility = "visible";

                      setTimeout(() => {
                        controlsRef.current.style.visibility = "hidden";
                      }, 1000);
                    }}
                    elevation={3}
                  >
                    <div>bookmark at {bookmark.display}</div>
                  </div>
                </div>
              </>
            ))}
            ;
          </div>
        </div>
        <canvas ref={canvasRef} />
      </div>
    </>
  );
};
