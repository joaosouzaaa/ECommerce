import React, { useState } from "react";

import { Link } from "react-router-dom";
import styles from "./NavBarComponent.module.css";
import Logo from "../../assets/ecommerce-logo.png";
import Waves from "../../assets/wave_nav.svg";

const NavBarComponent = () => {
  const [selectedNavBarLink, setSelectedNavBarLink] = useState("home");
  return (
    <>
      <img src={Waves} alt="" className={styles.waves} />

      <nav className={styles.nav__link}>
        <div>
          <img src={Logo} alt="" className={styles.logo} />
        </div>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/about">Sobre</Link>
          </li>
          <li>
            <Link to="/account">Conta</Link>
          </li>
          <li>
            <Link to="/cart">Carrinho</Link>
          </li>
          <li>
            <Link to="/sign-in">Sign Up</Link>
          </li>
        </ul>
      </nav>
    </>
  );
};

export default NavBarComponent;
