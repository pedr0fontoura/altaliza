import styled from 'styled-components';

interface IOptionsProps {
  active?: boolean;
}

export const Container = styled.div`
  width: 100%;
  height: 5.5rem;

  display: flex;
  gap: 1rem;
`;

export const Option = styled.button<IOptionsProps>`
  flex-grow: 1;
  flex-basis: 0;

  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;

  padding: 1rem;

  border: 2px solid ${({ active }) => (active ? '#00974A' : '#eee')};
  border-radius: 0.5rem;

  outline: 0;

  background: none;

  transition: 0.1s ease-in;

  &:hover {
    cursor: pointer;
    border: 2px solid ${({ active }) => (active ? '#00974A' : 'rgba(0, 151, 73, 0.5)')};
  }

  > p {
    text-align: left;
  }
`;

export const Text = styled.p`
  font-size: 1rem;
  font-weight: 600;
  color: rgba(17, 24, 39, 1);
`;

export const Description = styled.p`
  width: 100%;

  margin-top: 0.5rem;

  font-size: 0.9rem;
  font-weight: 500;
  color: rgba(156, 163, 175, 1);
`;
