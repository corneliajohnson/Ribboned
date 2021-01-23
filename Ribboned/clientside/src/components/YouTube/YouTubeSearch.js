import React from "react";
import { Input } from "reactstrap";

export const YouTubeSearch = () => {
  return (
    <>
      <div>
        YouTube Search:
        <Input
          type="text"
          className="w-100 input--wide"
          placeholder="Search... "
        />
      </div>
    </>
  );
};
