import { FaCar } from 'react-icons/fa';

import FadedImage from '../FadedImage';

import { Container, Name, Category, StyledLink, Stock } from './styles';

interface IVehicleCardProps {
  id: number;
  name: string;
  image: string;
  category: string;
  stock: number;
}

const VehicleCard = ({ id, name, image, category, stock }: IVehicleCardProps) => (
  <Container>
    <FadedImage src={image} alt={name}>
      <Stock>
        {stock}
        <FaCar />
      </Stock>
    </FadedImage>
    <Name>{name}</Name>
    <Category>{category}</Category>
    <StyledLink to={`vehicles/${id}`}>Alugar</StyledLink>
  </Container>
);

export default VehicleCard;
