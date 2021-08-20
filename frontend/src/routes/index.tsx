import { Switch, Route } from 'react-router-dom';

import Home from '../pages/Home';
import VehicleDetails from '../pages/VehicleDetails';

const Routes = () => (
  <Switch>
    <Route path="/" exact component={Home} />
    <Route path="/vehicles/:id" exact component={VehicleDetails} />
  </Switch>
);

export default Routes;
