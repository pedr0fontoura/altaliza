import styled from 'styled-components';

import FadedImage from '../FadedImage';

interface IButtonProps {
  transparent?: boolean;
}

export const Container = styled.div`
  width: 100%;
  height: 24rem;

  display: flex;
  justify-content: space-between;
`;

export const Content = styled.div`
  width: 50%;

  display: flex;
  flex-direction: column;

  > div {
    margin-top: 4rem;

    display: flex;
    gap: 1rem;
  }
`;

export const Title = styled.h1`
  font-size: 3.5rem;
`;

export const Subtitle = styled.h2`
  font-size: 1.5rem;
  font-weight: 400;
`;

export const Text = styled.p`
  margin-top: 2rem;

  font-size: 1.1rem;
  font-style: italic;
  color: #e1f5e3;
`;

export const Image = styled(FadedImage)`
  width: 38rem;

  box-shadow: 0 25px 25px -12px rgba(0, 0, 0, 0.5);
`;

export const Button = styled.button<IButtonProps>`
  width: 10rem;
  height: 3.5rem;

  border: none;
  border-radius: 0.25rem;

  font-size: 1.2rem;
  font-weight: 500;
  color: ${({ transparent }) => (transparent ? '#fff' : '#01793b')};

  box-shadow: 0 0.2rem 0.5rem rgba(0, 0, 0, 0.1);

  background: ${({ transparent }) => (transparent ? 'rgba(255, 255, 255, 0.5)' : '#fff')};

  transition: 0.1s ease-in-out;

  &:hover {
    cursor: pointer;

    filter: brightness(0.8);
  }
`;
