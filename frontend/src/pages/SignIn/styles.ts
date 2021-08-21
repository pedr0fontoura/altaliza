import styled from 'styled-components';

import { BREAKPOINTS } from '../../styles/constants';

export const Container = styled.div`
  width: 100%;
  max-width: ${BREAKPOINTS.LARGE};

  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;

  margin: auto;

  padding: 0 0.5rem 0 0.5rem;
`;

export const Content = styled.div`
  width: 30rem;

  padding: 4rem;

  border: 2px solid #ddd;
  border-radius: 0.25rem;

  background: #fff;
`;

export const Form = styled.form`
  display: flex;
  flex-direction: column;
  gap: 1rem;

  label {
    display: flex;
    flex-direction: column;
    gap: 0.5rem;

    color: rgba(17, 24, 39, 1);
    font-size: 0.9rem;
  }

  input {
    height: 2.5rem;

    padding: 1rem;

    border: 1px solid #ddd;
    border-radius: 0.25rem;

    color: rgba(17, 24, 39, 0.8);
    font-size: 0.9rem;
  }

  button {
    height: 2.5rem;

    border: none;
    border-radius: 0.25rem;

    color: rgba(255, 255, 255, 0.9);
    font-weight: 500;
    font-size: 1rem;

    box-shadow: 0 0.2rem 0.5rem rgba(0, 0, 0, 0.1);

    background: #00974a;

    &:hover {
      cursor: pointer;
      filter: brightness(0.95);
    }
  }

  & + form {
    margin-top: 3rem;

    border-top: 1px solid #ddd;

    padding-top: 3rem;
  }
`;

export const Title = styled.p`
  margin-bottom: 1.5rem;

  color: rgba(17, 24, 39, 0.8);
  font-size: 1.5rem;
  font-weight: 600;
  text-align: center;
`;
