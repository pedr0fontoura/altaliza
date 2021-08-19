import { FaUser } from 'react-icons/fa';

import { Container, ProfilePicture } from './styles';

const NavbarProfile = () => {
  return (
    <Container>
      <ProfilePicture>
        <FaUser size={20} />
      </ProfilePicture>
    </Container>
  );
};

export default NavbarProfile;
