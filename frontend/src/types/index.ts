interface ISuccessApiResponse<T> {
  type: 'success';
  status: 200;
  data: T;
}

interface IErrorApiResponse {
  type: 'error';
  status: number;
  error: {
    [key: string]: string[];
  };
}

export type ApiResponse<T> = ISuccessApiResponse<T> | IErrorApiResponse;

export interface ICharacter {
  id: number;
  name: string;
  wallet: number;
}

export interface IVehicleCategory {
  id: number;
  name: string;
  description: string;
}

export interface IVehicle {
  id: number;
  category: IVehicleCategory;
  name: string;
  stock: number;
  image: string;
  rent1Day: number;
  rent7Day: number;
  rent15Day: number;
}

export interface ICharacterVehicle {
  id: number;
  vehicle: IVehicle;
  expirationDate: Date;
}
