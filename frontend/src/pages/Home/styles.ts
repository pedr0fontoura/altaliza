import styled from 'styled-components';

import { BREAKPOINTS } from '../../styles/constants';

export const Container = styled.div`
  width: 100%;
  max-width: ${BREAKPOINTS.LARGE};

  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;

  margin: auto;

  padding: 0 0.5rem 0 0.5rem;
`;

export const Section = styled.section`
  width: 100%;

  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;

  & + section {
    margin-top: 2rem;
  }
`;

export const SectionTitle = styled.h1`
  font-size: 2rem;
`;
