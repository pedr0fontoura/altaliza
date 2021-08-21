import { useLocation } from 'react-router-dom';

import logo from '../../assets/altaliza.png';

import NavbarProfile from '../NavbarProfile';

import { Container, Logo, Menu, StyledLink } from './styles';

const Navbar = () => {
  const { pathname } = useLocation();

  return (
    <Container>
      <Logo src={logo} alt="Altaliza" />
      <Menu>
        <StyledLink to="/" $active={pathname === '/'}>
          Início
        </StyledLink>
      </Menu>
      <NavbarProfile />
    </Container>
  );
};

export default Navbar;
