import styled from 'styled-components';

import { BREAKPOINTS } from '../../styles/constants';

export const Container = styled.div`
  width: 100%;
  max-width: ${BREAKPOINTS.LARGE};

  min-height: 30rem;

  display: flex;
  justify-content: space-between;
  align-items: flex-start;

  margin: auto;

  border-radius: 0.5rem;

  padding: 1rem;

  background: #fff;
`;

export const Content = styled.div`
  width: 50%;

  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;

  color: rgba(156, 163, 175, 1);
  font-weight: 400;
`;

export const Title = styled.h1`
  color: #000;
  font-size: 2.5rem;
`;

export const Category = styled.h2`
  margin-top: 0.5rem;

  font-weight: 400;
  color: rgba(17, 24, 39, 1);
`;

export const Description = styled.p`
  margin-top: 1rem;
`;

export const StockInfo = styled.div`
  display: flex;
  align-items: center;
  gap: 0.5rem;

  margin-top: 2rem;

  font-size: 0.9rem;
  font-weight: 500;

  > svg.green {
    color: #00974a;
  }

  > svg.red {
    color: #d40303;
  }
`;

export const Image = styled.div`
  width: 45%;

  img {
    width: 100%;
    height: 100%;

    border-radius: 0.5rem;
  }
`;

export const RentTimeSelectorWrapper = styled.div`
  width: 100%;

  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;

  margin-top: 2rem;

  font-weight: 500;
  font-size: 0.9rem;

  > div {
    margin-top: 0.5rem;
  }
`;

export const Price = styled.p`
  margin-top: 1rem;

  font-size: 1.5rem;
  color: rgba(17, 24, 39, 1);

  span {
    font-weight: 500;
  }
`;

export const Button = styled.button`
  width: 100%;

  display: flex;
  justify-content: center;
  align-items: center;

  margin-top: 1rem;

  padding: 1rem;

  border: none;
  border-radius: 0.25rem;

  outline: 0;

  font-size: 1rem;
  font-weight: 600;
  color: #ffffff;

  box-shadow: 0 0.2rem 0.5rem rgba(0, 0, 0, 0.1);

  background: #00974a;

  transition: 0.1s ease-in;

  &:hover {
    cursor: pointer;
    background: #006e35;
  }

  &:disabled {
    cursor: not-allowed;
    opacity: 0.5;
    background: #00974a;
  }
`;
