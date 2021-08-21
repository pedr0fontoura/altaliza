import axios from 'axios';

import { ApiResponse, ICharacterVehicle, RentTimeEnum } from '../types';

const api = axios.create({
  baseURL: process.env.REACT_APP_ALTALIZA_API,
  headers: {
    common: {
      'Content-Type': 'application/json',
    },
  },
});

export const rentCharacterVehicle = async (
  characterId: number,
  vehicleId: number,
  rentTime: RentTimeEnum,
): Promise<ICharacterVehicle | undefined> => {
  const requestBody = {
    characterId,
    vehicleId,
    rentTime,
  };

  const { data: response } = await api.post<ApiResponse<ICharacterVehicle>>('characters/vehicles', requestBody);

  let characterVehicle: ICharacterVehicle | undefined;

  if (response.type === 'success') {
    characterVehicle = response.data;
  }

  return characterVehicle;
};

export const returnCharacterVehicle = async (characterId: number, characterVehicleId: number): Promise<boolean> => {
  const { data: response } = await api.post<ApiResponse<null>>(
    `characters/${characterId}/vehicles/${characterVehicleId}`,
  );

  return response.type === 'success';
};

export default api;
