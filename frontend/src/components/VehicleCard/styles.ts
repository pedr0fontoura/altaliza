import styled from 'styled-components';

export const Container = styled.div`
  width: 25%;

  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;

  padding: 0.5rem;

  border-radius: 0.25rem;
`;

export const Stock = styled.div`
  position: absolute;

  display: flex;
  align-items: center;
  gap: 0.5rem;

  bottom: 0.5rem;
  right: 0.5rem;

  font-size: 1.1rem;
`;

export const Name = styled.h1`
  font-size: 1.25rem;
  font-weight: 500;
`;

export const Category = styled.p`
  font-size: 1rem;
`;

export const Button = styled.button`
  width: 100%;

  height: 2.5rem;

  margin-top: 2rem;

  border: none;
  border-radius: 0.25rem;

  color: rgb(1, 105, 52, 0.9);
  font-weight: 600;
  font-size: 1.05rem;

  outline: none;

  box-shadow: 0 0.2rem 0.5rem rgba(0, 0, 0, 0.1);

  background: #fff;

  transition: 0.1s ease-in;

  &:hover {
    cursor: pointer;
    filter: brightness(0.8);
  }
`;
