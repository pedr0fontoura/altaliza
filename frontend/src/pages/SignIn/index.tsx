import { useState, useCallback } from 'react';
import { useHistory } from 'react-router-dom';

import { useAuth } from '../../hooks/useAuth';
import { createCharacter } from '../../lib/api';

import { Container, Content, Form, Title } from './styles';

const SignIn = () => {
  const [characterId, setCharacterId] = useState(0);

  const [characterName, setCharacterName] = useState('');
  const [characterWallet, setCharacterWallet] = useState(0);

  const { signIn } = useAuth();

  const { push } = useHistory();

  const handleSignIn = useCallback(
    async (id: number) => {
      await signIn({ id });
      push('/');
    },
    [signIn],
  );

  const handleSignUp = useCallback(
    async (name: string, wallet: number) => {
      const character = await createCharacter(name, wallet);

      if (character) {
        await signIn({ id: character.id });
        push('/');
      }
    },
    [signIn],
  );

  return (
    <Container>
      <Content>
        <Form>
          <Title>Acesse sua conta</Title>
          <label htmlFor="signin-id">
            ID do personagem
            <input
              type="number"
              name="signin-id"
              value={characterId}
              onChange={e => setCharacterId(parseInt(e.target.value, 10))}
            />
          </label>
          <button type="button" onClick={() => handleSignIn(characterId)}>
            Entrar
          </button>
        </Form>
        <Form>
          <Title>Novo personagem</Title>
          <label htmlFor="signup-name">
            Nome do personagem
            <input
              type="text"
              name="signup-name"
              value={characterName}
              onChange={e => setCharacterName(e.target.value)}
            />
          </label>
          <label htmlFor="signup-name">
            Carteira
            <input
              type="text"
              name="signup-name"
              min="0"
              value={characterWallet}
              onChange={e => setCharacterWallet(parseInt(e.target.value, 10))}
            />
          </label>
          <button type="button" onClick={() => handleSignUp(characterName, characterWallet)}>
            Criar personagem
          </button>
        </Form>
      </Content>
    </Container>
  );
};

export default SignIn;
