import styled from 'styled-components';

export const Container = styled.div`
  position: relative;

  border-radius: 0.25rem;

  overflow: hidden;

  img {
    height: 100%;
    width: 100%;
  }
`;

export const ChildrenContainer = styled.div`
  position: absolute;

  width: 100%;
  height: 100%;

  z-index: 2;
`;

export const Fade = styled.div`
  width: 100%;
  height: 50%;

  position: absolute;

  bottom: 0;
  left: 0;

  background: linear-gradient(rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.8));

  z-index: 1;
`;
