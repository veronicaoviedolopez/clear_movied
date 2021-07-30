import React from "react";
import { Link } from "react-router-dom";

const Header = () => {
  return (
    <nav className="navbar mx-2 navbar-expand-lg navbar-light bg-transparent">
    <Link className="navbar-brand text-secondary font-google-logo" to="/">
     Movies Search
    </Link>
    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
      <span className="navbar-toggler-icon"></span>
    </button>
  
    <div className="collapse navbar-collapse" id="navbarTogglerDemo02">
      <ul className="navbar-nav mr-auto mt-2">
        <li className="nav-item active">
          <Link className="nav-link" to="/"> Home </Link>
        </li>
      </ul>
      </div>
  </nav>
  );
};

export default Header;