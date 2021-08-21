import { useState, useMemo, useCallback, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import {} from 'react-icons/fa';

import { ApiResponse, ICharacterVehicle } from '../../types';

import api, { returnCharacterVehicle } from '../../lib/api';

import { Container, Table, TableRow, Actions, Return, Renew } from './styles';

interface IRouteParams {
  id: string;
}

const CharacterVehicles = () => {
  const [vehicles, setVehicles] = useState<ICharacterVehicle[]>([]);

  const routeParams = useParams<IRouteParams>();

  const currentCharacterId = parseInt(routeParams.id, 10);

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
      const { data: response } = await api.get<ApiResponse<ICharacterVehicle[]>>(
        `characters/${routeParams.id}/vehicles`,
      );

      if (response.type === 'success') {
        setVehicles(response.data);
      }
    };

    fetchData();
  }, []);

  return (
    <Container>
      <Table>
        <thead>
          <TableRow>
            <th>ID</th>
            <th>Modelo</th>
            <th>Categoria</th>
            <th>Data de expiração</th>
            <th>Ações</th>
          </TableRow>
        </thead>
        <tbody>
          {vehicles.map(({ id, vehicle }, index) => (
            <TableRow key={id}>
              <td>{id}</td>
              <td>{vehicle.name}</td>
              <td>{vehicle.category.name}</td>
              <td>{parsedDates[index]}</td>
              <Actions>
                <Return type="button" onClick={() => returnVehicle(currentCharacterId, id)}>
                  Devolver
                </Return>
                <Renew type="button">Renovar</Renew>
              </Actions>
            </TableRow>
          ))}
        </tbody>
      </Table>
    </Container>
  );
};

export default CharacterVehicles;
