import { FaCheck } from 'react-icons/fa';

import vectre from '../../assets/vectre.png';

import OptionsPicker, { IOption } from '../../components/OptionsPicker';

import {
  Container,
  Content,
  Title,
  Category,
  Description,
  StockInfo,
  Image,
  RentTimeSelectorWrapper,
  Price,
  Button,
} from './styles';

const RENT_TIME_OPTIONS: IOption[] = [
  {
    id: 'Rent1Day',
    text: '1 Dia',
    description: 'Só para experimentar',
  },
  {
    id: 'Rent7Day',
    text: '7 Dias',
    description: 'Um pouco de conforto não mata ninguém',
  },
  {
    id: 'Rent15Day',
    text: '15 Dias',
    description: 'Nunca mais eu ando a pé',
  },
];

const VehicleDetails = () => {
  return (
    <Container>
      <Content>
        <Title>Emperor Vectre</Title>

        <Category>Esporte</Category>

        <Description>
          “Seu gosto é inusitado demais para os clássicos? Mais exagerado do que razoável? Pare de procurar uma
          lata-velha qualquer e cause aquela primeira impressão marcante com o Emperor Vectre. Como uma supermodelo
          campeã dos 100 metros, o Vectre é um espetáculo em todos os sentidos.” - <b>Legendary Motorsport</b>
        </Description>

        <StockInfo>
          <FaCheck />
          <p>Em estoque e pronto para entrega</p>
        </StockInfo>

        <RentTimeSelectorWrapper>
          <p>Tempo de aluguel</p>
          <OptionsPicker options={RENT_TIME_OPTIONS} />
        </RentTimeSelectorWrapper>

        <Price>
          <span>R$</span> 500
        </Price>

        <Button>Alugar Veículo</Button>
      </Content>

      <Image>
        <img src={vectre} alt="Emperor Vectre" />
      </Image>
    </Container>
  );
};

export default VehicleDetails;
