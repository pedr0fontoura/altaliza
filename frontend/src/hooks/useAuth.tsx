/*
  This code does not represent a proper, production ready, authentication system.

  It's just an oversimplified version of how an authentication system built with React Context should look.
*/

import { ReactNode, createContext, useState, useEffect, useCallback, useContext } from 'react';

import { ApiResponse, ICharacter } from '../types';

import api from '../lib/api';

interface ICredentials {
  id: number;
}

interface IAuthContext {
  character: ICharacter | undefined;
  signIn(credentials: ICredentials): Promise<void>;
  signOut(): void;
  updateCharacter(character: ICharacter): void;
}

interface IAuthProvider {
  children: ReactNode;
}

const LOCAL_STORAGE_CHARACTER_KEY = '@Altaliza:character';

const authContext = createContext<IAuthContext>({} as IAuthContext);

const useAuthProvider = (): IAuthContext => {
  const [character, setCharacter] = useState<ICharacter | undefined>();

  const signIn = useCallback(async ({ id }: ICredentials): Promise<void> => {
    const { data: response } = await api.get<ApiResponse<ICharacter>>(`characters/${id}`);

    if (response.type === 'success') {
      localStorage.setItem(LOCAL_STORAGE_CHARACTER_KEY, JSON.stringify(response.data));

      setCharacter(response.data);
    }
  }, []);

  const signOut = useCallback((): void => {
    localStorage.removeItem(LOCAL_STORAGE_CHARACTER_KEY);

    setCharacter(undefined);
  }, []);

  const updateCharacter = useCallback((characterData: ICharacter): void => {
    localStorage.setItem(LOCAL_STORAGE_CHARACTER_KEY, JSON.stringify(characterData));

    setCharacter(characterData);
  }, []);

  useEffect(() => {
    const recoverAndValidateCharacter = async (): Promise<void> => {
      const characterData = localStorage.getItem(LOCAL_STORAGE_CHARACTER_KEY);

      if (!characterData) return;

      // Refresh user data
      const { id }: ICharacter = JSON.parse(characterData);

      const { data: response } = await api.get<ApiResponse<ICharacter>>(`characters/${id}`);

      if (response.type === 'success') {
        localStorage.setItem(LOCAL_STORAGE_CHARACTER_KEY, JSON.stringify(response.data));

        setCharacter(response.data);
      } else {
        localStorage.removeItem(LOCAL_STORAGE_CHARACTER_KEY);
      }
    };

    recoverAndValidateCharacter();
  }, []);

  return { character, signIn, signOut, updateCharacter };
};

export const AuthProvider = ({ children }: IAuthProvider) => {
  const auth = useAuthProvider();

  return <authContext.Provider value={auth}>{children}</authContext.Provider>;
};

export const useAuth = () => {
  const context = useContext(authContext);

  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }

  return context;
};
