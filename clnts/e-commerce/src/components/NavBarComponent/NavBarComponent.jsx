import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import styles from "./NavBarComponent.module.css";
import Logo from "../../assets/ecommerce-logo.png";
import Waves from "../../assets/wave_nav.svg";

const NavBarComponent = () => {
  const navigate = useNavigate();
  const [selectedNavBarLink, setSelectedNavBarLink] = useState("home");
  return (
    <>
      <img
        src={Waves}
        onClick={() => {
          navigate("/");
        }}
        alt=""
        className={styles.waves}
      />

      <nav className={styles.nav__link}>
        <div>
          <img
            onClick={() => navigate("/")}
            src={Logo}
            alt=""
            className={styles.logo}
          />
        </div>
        <ul>
          <li
            onClick={() => {
              setSelectedNavBarLink("home");
              navigate("/");
            }}
          >
            <Link to="/">Home</Link>
          </li>
          <li
            onClick={() => {
              setSelectedNavBarLink("about");
              navigate("/about");
            }}
          >
            <Link to="/about">Sobre</Link>
          </li>
          <li
            onClick={() => {
              setSelectedNavBarLink("account");
              navigate("/account");
            }}
          >
            <Link to="/account">Conta</Link>
          </li>
          <li
            onClick={() => {
              setSelectedNavBarLink("cart");
              navigate("/cart");
            }}
          >
            <Link to="/cart">Carrinho</Link>
          </li>
          <li
            onClick={() => {
              setSelectedNavBarLink("sign-in");
              navigate("/sign-in");
            }}
          >
            <Link to="/sign-in">Sign Up</Link>
          </li>
        </ul>
      </nav>
    </>
  );
};

export default NavBarComponent;
