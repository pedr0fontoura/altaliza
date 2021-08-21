import { Switch, Route } from 'react-router-dom';

import Home from '../pages/Home';
import VehicleDetails from '../pages/VehicleDetails';
import CharacterVehicles from '../pages/CharacterVehicles';

const Routes = () => (
  <Switch>
    <Route path="/" exact component={Home} />
    <Route path="/vehicles/:id" exact component={VehicleDetails} />
    <Route path="/characters/:id/vehicles" exact component={CharacterVehicles} />
  </Switch>
);

export default Routes;
