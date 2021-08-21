import axios from 'axios';

import { ApiResponse, ICharacterVehicle, RentTimeEnum, ICharacter } from '../types';

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

export const renewCharacterVehicle = async (
  characterId: number,
  vehicleId: number,
  rentTime: RentTimeEnum,
): Promise<ICharacterVehicle | undefined> => {
  const requestBody = {
    characterId,
    vehicleId,
    rentTime,
  };

  const { data: response } = await api.post<ApiResponse<ICharacterVehicle>>(
    `characters/${characterId}/vehicles/${vehicleId}/renew`,
    requestBody,
  );

  let characterVehicle: ICharacterVehicle | undefined;

  if (response.type === 'success') {
    characterVehicle = response.data;
  }

  return characterVehicle;
};

export const returnCharacterVehicle = async (characterId: number, characterVehicleId: number): Promise<boolean> => {
  const { data: response } = await api.delete<ApiResponse<null>>(
    `characters/${characterId}/vehicles/${characterVehicleId}`,
  );

  return response.type === 'success';
};

export const createCharacter = async (name: string, wallet: number): Promise<ICharacter | undefined> => {
  const requestBody = {
    name,
    wallet,
  };

  const { data: response } = await api.post<ApiResponse<ICharacter>>('characters', requestBody);

  let character: ICharacter | undefined;

  if (response.type === 'success') {
    character = response.data;
  }

  return character;
};

export default api;
