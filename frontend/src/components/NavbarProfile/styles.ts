import styled from 'styled-components';
import { Link } from 'react-router-dom';

interface IAvatarProps {
  active?: boolean;
}

export const Container = styled.div`
  margin-left: auto;
`;

export const Avatar = styled.button<IAvatarProps>`
  height: 3.5rem;
  width: 3.5rem;

  display: flex;
  justify-content: center;
  align-items: center;

  border-radius: 50%;
  border: none;

  color: ${({ active }) => (active ? '#01793b' : 'rgba(0, 0, 0, 0.2)')};
  font-size: ${({ active }) => (active ? '1.5rem' : '1rem')};

  overflow: hidden;

  background: ${({ active }) => (active ? '#fff' : '#ccc')};

  &:hover {
    cursor: pointer;
    filter: brightness(0.95);
  }
`;

export const Menu = styled.div`
  height: 100%;
  position: relative;
`;
export const ItemsWrapper = styled.div``;

export const Items = styled.div`
  width: 12rem;

  position: absolute;

  top: 4rem;
  right: 0;

  padding: 0.1rem 0;

  display: flex;
  flex-direction: column;

  border-radius: 0.25rem;
  border: 1px solid #eee;

  box-shadow: 0 0.5rem 1rem -5px rgba(0, 0, 0, 0.4);

  transform-origin: top right;

  background: #fff;
  z-index: 3;
`;

export const Item = styled.button`
  width: 100%;

  border: none;

  padding: 0.6rem 1rem;

  display: flex;
  align-items: center;
  gap: 0.5rem;

  color: rgba(17, 24, 39, 1);
  font-size: 0.9rem;
  font-weight: 500;

  background: none;

  &:hover {
    cursor: pointer;
    background: rgba(0, 0, 0, 0.1);
  }
`;

export const LinkItem = styled(Link)`
  width: 100%;

  border: none;

  padding: 0.6rem 1rem;

  display: flex;
  align-items: center;
  gap: 0.5rem;

  color: rgba(17, 24, 39, 1);
  font-size: 0.9rem;
  font-weight: 500;
  text-decoration: none;

  background: none;

  &:hover {
    cursor: pointer;
    background: rgba(0, 0, 0, 0.1);
  }
`;
