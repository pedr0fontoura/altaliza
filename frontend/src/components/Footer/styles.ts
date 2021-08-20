import styled from 'styled-components';

import { BREAKPOINTS } from '../../styles/constants';

export const Container = styled.footer`
  width: 100%;
  max-width: ${BREAKPOINTS.LARGE};

  height: 8rem;

  margin: auto;
  margin-top: 1rem;

  padding: 0.5rem 0.5rem 0.2rem 0.5rem;

  border-top: 1px solid rgba(255, 255, 255, 0.2);

  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  align-items: center;
`;

export const Left = styled.div`
  font-size: 1.2rem;
  font-weight: 500;
`;

export const Center = styled.div`
  display: flex;
  justify-content: center;

  margin: auto;

  img {
    height: 5rem;

    transition: 0.2s ease-in-out;

    &:hover {
      cursor: pointer;
      transform: scale(1.05);
    }
  }
`;

export const Right = styled.div`
  display: flex;
  justify-content: flex-end;
  gap: 2rem;

  a {
    color: #fff;

    transition: 0.1s ease-in-out;

    &:hover {
      filter: brightness(0.8);
    }
  }
`;
