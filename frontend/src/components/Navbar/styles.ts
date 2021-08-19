import styled from 'styled-components';
import { Link } from 'react-router-dom';

import { BREAKPOINTS } from '../../styles/constants';

interface IStyledLinkProps {
  active?: boolean;
}

export const Container = styled.nav`
  width: 100%;
  max-width: ${BREAKPOINTS.LARGE};

  height: 5rem;

  margin: auto;
  margin-bottom: 1rem;

  padding: 0.2rem 0.5rem 0.2rem 0.5rem;

  border-bottom: 1px solid rgba(255, 255, 255, 0.2);

  display: flex;
  justify-content: flex-start;
  align-items: center;
`;

export const Logo = styled.img`
  width: 164px;
`;

export const Menu = styled.div`
  height: 2rem;

  display: flex;
  justify-content: flex-start;
  gap: 0.8rem;

  margin-left: 2rem;
`;

export const StyledLink = styled(Link)<IStyledLinkProps>`
  display: flex;
  justify-content: center;
  align-items: center;

  padding: 0 1rem 0 1rem;
  border-radius: 4px;

  font-size: 1rem;
  font-weight: 500;
  color: ${({ active }) => (active ? '#fff' : '#dee1e6')};
  text-decoration: none;

  background: ${({ active }) => (active ? 'rgba(0, 0, 0, 0.3)' : 'none')};

  &:hover {
    background: rgba(0, 0, 0, 0.3);
  }
`;
