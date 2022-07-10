import React from "react";
import { Routes, Route } from "react-router-dom";
import NavBarComponent from "./components/NavBarComponent/NavBarComponent";
import About from "./pages/About/About";
import Cart from "./pages/Cart/Cart";
import Home from "./pages/Home/Home";
import Footer from "./components/Footer/Footer";
import Account from "./pages/Account/Account";
import SignIn from "./pages/SignIn/SignIn";

const App = () => {
  return (
    <>
      <NavBarComponent />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/account" element={<Account />} />
        <Route path="/cart" element={<Cart />} />
        <Route path="/sign-in" element={<SignIn />} />
      </Routes>
      <Footer />
    </>
  );
};

export default App;
