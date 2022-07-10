import NavBarComponent from "./NavBarComponent";
import { screen, render, userEvent } from "../../tests/index";
import { BrowserRouter as Router } from "react-router-dom";

describe("NavBArComponent", () => {
  it('Should have the following values ("home" or "about" or "account" or "cart" or "sign-in")', () => {
    //render renderiza em memoria o componente
    render(
      <Router>
        <NavBarComponent />
      </Router>
    );
    //screen é basicamente a tela, com isso podemos buscar elementos por paremetros, clique control + espaço em (screeen.) para ver as opçoes
    const find = screen.getAllByRole("link");
    expect(find).toBeVisible();
  });
});
