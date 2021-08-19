import { FaCar } from 'react-icons/fa';

import vectre from '../../assets/vectre.png';

import FadedImage from '../FadedImage';

import { Container, Name, Category, Button, Stock } from './styles';

const VehicleCard = () => (
  <Container>
    <FadedImage src={vectre} alt="Emperor Vectre">
      <Stock>
        30
        <FaCar />
      </Stock>
    </FadedImage>
    <Name>Emperor Vectre</Name>
    <Category>Esporte</Category>
    <Button>Alugar</Button>
  </Container>
);

export default VehicleCard;
