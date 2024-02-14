import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import AuthorizationComponent from "./components/AuthorizationComponent";
import DashboardComponent from "./components/DashboardComponent";

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/auth" element={<AuthorizationComponent />} />
        <Route path="/dashboard" element={<DashboardComponent />} />
      </Routes>
    </Router>
  );
};

export default App;
