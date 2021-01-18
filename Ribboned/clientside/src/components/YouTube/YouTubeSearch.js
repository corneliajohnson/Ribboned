import React from "react";
import { Input } from "reactstrap";

export const YouTubeSearch = () => {
  return (
    <>
      <div className="align-items-center">
        YouTube Search:
        <Input
          type="text"
          className="w-50 input--wide"
          placeholder="Search... "
        />
      </div>
    </>
  );
};
