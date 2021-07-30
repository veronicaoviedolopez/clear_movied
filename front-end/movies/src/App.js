import React, { Component } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import "./App.css";
import Header from "./Components/Header";
import Landing from "./Components/Landing";


class App extends Component  {
  render() {
     return (
      <BrowserRouter>
        <div className="mybg">
          <Route path="/" component={Header} />
          <Route path="/" component={Landing} />
        </div>
      </BrowserRouter>
  );
  }
};

export default App;
