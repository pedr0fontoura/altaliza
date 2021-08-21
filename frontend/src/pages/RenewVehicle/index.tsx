import { useState, useCallback, useMemo, useEffect } from 'react';
import { useParams, useHistory } from 'react-router-dom';

import { ApiResponse, ICharacterVehicle } from '../../types';

import api, { renewCharacterVehicle } from '../../lib/api';

import { RENT_TIME_MAP } from '../../utils/rentTime';
import formatValue from '../../utils/formatValue';

import { useAuth } from '../../hooks/useAuth';

import OptionsPicker, { IOption } from '../../components/OptionsPicker';

import {
  Container,
  Content,
  Title,
  Category,
  Description,
  ExpirationDate,
  Image,
  RentTimeSelectorWrapper,
  Price,
  Button,
} from './styles';

interface IRouteParams {
  id: string;
}

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

const RenewVehicle = () => {
  const [characterVehicle, setVehicle] = useState<ICharacterVehicle>();
  const [rentTime, setRentTime] = useState<keyof typeof RENT_TIME_MAP>();

  const { id } = useParams<IRouteParams>();
  const { character } = useAuth();
  const { push } = useHistory();

  const price = useMemo(
    () => (characterVehicle && rentTime && characterVehicle.vehicle[rentTime]) || 0,
    [characterVehicle, rentTime],
  );

  const formattedPrice = useMemo(() => formatValue(price), [price]);

  const formattedDate = useMemo(
    () => characterVehicle && new Date(characterVehicle.expirationDate).toLocaleString('pt-BR'),
    [characterVehicle],
  );

  const selectRentTime = (optionId: string) => {
    if (optionId === 'rent1Day' || optionId === 'rent7Day' || optionId === 'rent15Day') {
      setRentTime(optionId);
    }
  };

  const renewVehicle = useCallback(async () => {
    if (!rentTime || !character) {
      return;
    }

    await renewCharacterVehicle(character.id, parseInt(id, 10), RENT_TIME_MAP[rentTime]);

    push('/character/vehicles');
  }, [id, rentTime, character]);

  useEffect(() => {
    const fetchData = async (): Promise<void> => {
      const { data: response } = await api.get<ApiResponse<ICharacterVehicle>>(`characters/vehicles/${id}`);

      if (response.type === 'success') {
        setVehicle(response.data);
      }
    };

    fetchData();
  }, []);

  return (
    <Container>
      <Content>
        <Title>
          {characterVehicle?.vehicle.name}
          <small>{`(${characterVehicle?.id})`}</small>
        </Title>

        <Category>{characterVehicle?.vehicle.category.name}</Category>

        <Description>{characterVehicle?.vehicle.category.description}</Description>

        <ExpirationDate>
          <div>Expira em</div>
          {formattedDate}
        </ExpirationDate>

        <RentTimeSelectorWrapper>
          <p>Tempo de aluguel</p>
          <OptionsPicker options={RENT_TIME_OPTIONS} onOptionPick={selectRentTime} />
        </RentTimeSelectorWrapper>

        <Price>
          Total <span>{formattedPrice}</span>
        </Price>

        <Button type="button" disabled={!rentTime || !character} onClick={renewVehicle}>
          Renovar Veículo
        </Button>
      </Content>

      <Image>
        <img src={characterVehicle?.vehicle.image} alt={characterVehicle?.vehicle.name} />
      </Image>
    </Container>
  );
};

export default RenewVehicle;
