import { useState, useCallback, useEffect } from 'react';
import { useParams, useHistory } from 'react-router-dom';
import { FaCheck, FaTimes } from 'react-icons/fa';

import { ApiResponse, IVehicle } from '../../types';

import api, { rentCharacterVehicle } from '../../lib/api';
import formatValue from '../../utils/formatValue';

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

interface IRouteParams {
  id: string;
}

const IN_STOCK = 'Em estoque e pronto para entrega!';

const OUT_OF_STOCK = 'Infelizmente o veículo não está disponível';

const RENT_TIME_MAP = {
  rent1Day: 0,
  rent7Day: 1,
  rent15Day: 2,
};

const RENT_TIME_OPTIONS: IOption[] = [
  {
    id: 'rent1Day',
    text: '1 Dia',
    description: 'Só para experimentar',
  },
  {
    id: 'rent7Day',
    text: '7 Dias',
    description: 'Um pouco de conforto não mata ninguém',
  },
  {
    id: 'rent15Day',
    text: '15 Dias',
    description: 'Nunca mais eu ando a pé',
  },
];

const VehicleDetails = () => {
  const [vehicle, setVehicle] = useState<IVehicle>();
  const [rentTime, setRentTime] = useState<keyof typeof RENT_TIME_MAP>();

  const { id } = useParams<IRouteParams>();
  const { push } = useHistory();

  const inStock = !!vehicle && vehicle.stock > 0;

  const price = (vehicle && rentTime && vehicle[rentTime]) || 0;
  const formattedPrice = formatValue(price);

  const selectRentTime = (optionId: string) => {
    if (optionId === 'rent1Day' || optionId === 'rent7Day' || optionId === 'rent15Day') {
      setRentTime(optionId);
    }
  };

  const rentVehicle = useCallback(async () => {
    if (!rentTime) {
      return;
    }

    // rentCharacterVehicle(characterId, parseInt(id, 10), RENT_TIME_MAP[rentTime]);

    push('/');
  }, [id, rentTime]);

  useEffect(() => {
    const fetchData = async (): Promise<void> => {
      const { data: response } = await api.get<ApiResponse<IVehicle>>(`vehicles/${id}`);

      if (response.type === 'success') {
        setVehicle(response.data);
      }
    };

    fetchData();
  }, []);

  return (
    <Container>
      <Content>
        <Title>{vehicle?.name}</Title>

        <Category>{vehicle?.category.name}</Category>

        <Description>{vehicle?.category.description}</Description>

        <StockInfo>
          {inStock ? (
            <>
              <FaCheck className="green" />
              <p>{IN_STOCK}</p>
            </>
          ) : (
            <>
              <FaTimes className="red" />
              <p>{OUT_OF_STOCK}</p>
            </>
          )}
        </StockInfo>

        <RentTimeSelectorWrapper>
          <p>Tempo de aluguel</p>
          <OptionsPicker options={RENT_TIME_OPTIONS} onOptionPick={selectRentTime} />
        </RentTimeSelectorWrapper>

        <Price>
          Total <span>{formattedPrice}</span>
        </Price>

        <Button type="button" disabled={!rentTime} onClick={rentVehicle}>
          Alugar Veículo
        </Button>
      </Content>

      <Image>
        <img src={vehicle?.image} alt={vehicle?.name} />
      </Image>
    </Container>
  );
};

export default VehicleDetails;
