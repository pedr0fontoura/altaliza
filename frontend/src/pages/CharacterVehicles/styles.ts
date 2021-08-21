import styled from 'styled-components';

import { BREAKPOINTS } from '../../styles/constants';

export const Container = styled.div`
  width: 100%;
  max-width: ${BREAKPOINTS.LARGE};

  display: flex;
  justify-content: flex-start;
  align-items: flex-start;

  margin: auto;

  border-radius: 0.5rem;

  padding: 1rem;

  background: #fff;
`;

export const Table = styled.table`
  width: 100%;

  border-spacing: 0px;
  border-radius: 0.25rem;
  border: 1px solid #eee;

  color: rgba(107, 114, 128, 1);
  font-size: 1rem;
  font-weight: 500;
  text-align: left;
`;

export const TableRow = styled.tr`
  width: 100%;

  > th {
    padding: 0.5rem;
    border-bottom: 1px solid #eee;
    text-align: left;
    background: #f9fafb;
  }

  > td {
    padding: 0.5rem;
    border-bottom: 1px solid #eee;
  }

  &:last-child > td {
    border-bottom: none;
  }
`;

export const Actions = styled.td`
  width: 100%;

  display: inline-flex;
  gap: 1rem;
`;

const Button = styled.button`
  border: none;
  border-radius: 0.25rem;

  padding: 0.5rem;

  box-shadow: 0 0.2rem 0.5rem rgba(0, 0, 0, 0.1);

  font-size: 0.9rem;
  color: #fff;
  font-weight: bold;

  transition: 0.1s;

  &:hover {
    cursor: pointer;
    filter: brightness(0.9);
  }
`;

export const Return = styled(Button)`
  background: #df3e3e;
`;

export const Renew = styled(Button)`
  background: #00974a;
`;
