import { Switch, Route } from 'react-router-dom';

import Home from '../pages/Home';
import SignIn from '../pages/SignIn';
import CharacterVehicles from '../pages/CharacterVehicles';
import RenewVehicle from '../pages/RenewVehicle';
import VehicleDetails from '../pages/VehicleDetails';

const Routes = () => (
  <Switch>
    <Route path="/" exact component={Home} />
    <Route path="/signin" exact component={SignIn} />
    <Route path="/character/vehicles" exact component={CharacterVehicles} />
    <Route path="/characters/vehicles/:id/renew" exact component={RenewVehicle} />
    <Route path="/vehicles/:id" exact component={VehicleDetails} />
  </Switch>
);

export default Routes;
