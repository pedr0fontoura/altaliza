import { useState, useMemo, useCallback, useEffect } from 'react';
import { useHistory } from 'react-router-dom';

import { ApiResponse, ICharacterVehicle } from '../../types';

import api, { returnCharacterVehicle } from '../../lib/api';

import { useAuth } from '../../hooks/useAuth';

import { Container, Title, Table, TableRow, Actions, Return, Renew } from './styles';

const CharacterVehicles = () => {
  const [vehicles, setVehicles] = useState<ICharacterVehicle[]>([]);

  const { character } = useAuth();
  const { push } = useHistory();

  const parsedDates = useMemo(
    () => vehicles.map(cv => new Date(cv.expirationDate).toLocaleString('pt-BR')),
    [vehicles],
  );

  const returnVehicle = useCallback(
    async (characterId: number, vehicleId: number) => {
      const vehicleReturned = await returnCharacterVehicle(characterId, vehicleId);

      if (vehicleReturned) {
        setVehicles(prevState => {
          const filteredArray = prevState.filter(vehicle => vehicle.id !== vehicleId);

          return [...filteredArray];
        });
      }
    },
    [setVehicles],
  );

  useEffect(() => {
    const fetchData = async (): Promise<void> => {
      if (!character) {
        return;
      }

      const { data: response } = await api.get<ApiResponse<ICharacterVehicle[]>>(`characters/${character.id}/vehicles`);

      if (response.type === 'success') {
        setVehicles(response.data);
      }
    };

    if (!character) {
      push('/');
    }

    fetchData();
  }, [character]);

  return (
    <Container>
      <Title>Meus veículos</Title>

      <Table>
        <thead>
          <TableRow>
            <th>ID</th>
            <th>Modelo</th>
            <th>Categoria</th>
            <th>Data de expiração</th>
            {character ? <th>Ações</th> : null}
          </TableRow>
        </thead>
        <tbody>
          {vehicles.map(({ id, vehicle }, index) => (
            <TableRow key={id}>
              <td>{id}</td>
              <td>{vehicle.name}</td>
              <td>{vehicle.category.name}</td>
              <td>{parsedDates[index]}</td>
              {character ? (
                <Actions>
                  <Return type="button" onClick={() => returnVehicle(character.id, id)}>
                    Devolver
                  </Return>
                  <Renew type="button">Renovar</Renew>
                </Actions>
              ) : null}
            </TableRow>
          ))}
        </tbody>
      </Table>
    </Container>
  );
};

export default CharacterVehicles;
