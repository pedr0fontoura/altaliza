import { BrowserRouter } from 'react-router-dom';

import GlobalStyles from './styles/global';

import Navbar from './components/Navbar';
import Footer from './components/Footer';

import Routes from './routes';

function App() {
  return (
    <>
      <GlobalStyles />
      <BrowserRouter>
        <Navbar />
        <Routes />
        <Footer />
      </BrowserRouter>
    </>
  );
}

export default App;
