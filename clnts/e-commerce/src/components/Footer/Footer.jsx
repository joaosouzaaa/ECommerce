import React from "react";
import Waves from "../../assets/wave.svg";
import styles from './Footer.module.css'

const Footer = () => {
  return (
    <div>
      <h1>Footer</h1>
      <img src={Waves} alt="" className={styles.wave__image}/>
    </div>
  );
};

export default Footer;
