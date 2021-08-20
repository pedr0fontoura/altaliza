import { useState, useEffect } from 'react';

import { ApiResponse, IVehicle } from '../../types';

import api from '../../lib/api';

import VehicleCard from '../VehicleCard';

import { Container } from './styles';

const VehicleList = () => {
  const [vehicles, setVehicles] = useState<IVehicle[]>([]);

  useEffect(() => {
    const fetchData = async (): Promise<void> => {
      const { data: response } = await api.get<ApiResponse<IVehicle[]>>('/vehicles');

      if (response.type === 'success') {
        setVehicles(response.data);
      }
    };

    fetchData();
  }, []);

  return (
    <Container>
      {vehicles.map(vehicle => (
        <VehicleCard
          key={vehicle.id}
          id={vehicle.id}
          name={vehicle.name}
          image={vehicle.image}
          category={vehicle.category.name}
          stock={vehicle.stock}
        />
      ))}
    </Container>
  );
};

export default VehicleList;
