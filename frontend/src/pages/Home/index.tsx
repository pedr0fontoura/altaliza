import { Container, Section, SectionTitle } from './styles';

import Hero from '../../components/Hero';
import VehicleList from '../../components/VehicleList';

const Home = () => (
  <Container>
    <Section>
      <Hero />
    </Section>
    <Section>
      <SectionTitle>Veículos</SectionTitle>
      <VehicleList />
    </Section>
  </Container>
);

export default Home;
