import { useState } from 'react';
import { FaUser, FaSignInAlt, FaSignOutAlt, FaCarAlt } from 'react-icons/fa';

import { useAuth } from '../../hooks/useAuth';

import { Container, Avatar, Menu, Items, Item, LinkItem } from './styles';

const NavbarProfile = () => {
  const [active, setActive] = useState(false);

  const { character, signOut } = useAuth();

  const isAuthenticated = !!character;

  const toggleDropdown = () => {
    setActive(state => !state);
  };

  const handleSignOut = () => {
    signOut();
    toggleDropdown();
  };

  return (
    <Container>
      <Menu>
        <Avatar active={isAuthenticated} onClick={() => setActive(state => !state)}>
          {isAuthenticated ? character?.name.charAt(0) : <FaUser size={20} />}
        </Avatar>
        {active ? (
          <Items>
            {isAuthenticated ? (
              <>
                <LinkItem to="/character/vehicles">
                  <FaCarAlt />
                  Meus veículos
                </LinkItem>
                <Item onClick={handleSignOut}>
                  <FaSignOutAlt />
                  Sair
                </Item>
              </>
            ) : (
              <LinkItem to="/signin" onClick={toggleDropdown}>
                <FaSignInAlt />
                Entrar
              </LinkItem>
            )}
          </Items>
        ) : null}
      </Menu>
    </Container>
  );
};

export default NavbarProfile;
