import { BrowserRouter } from 'react-router-dom';

import GlobalStyles from './styles/global';

import AppProvider from './hooks';

import Navbar from './components/Navbar';
import Footer from './components/Footer';

import Routes from './routes';

function App() {
  return (
    <>
      <GlobalStyles />
      <BrowserRouter>
        <AppProvider>
          <Navbar />
          <Routes />
          <Footer />
        </AppProvider>
      </BrowserRouter>
    </>
  );
}

export default App;
