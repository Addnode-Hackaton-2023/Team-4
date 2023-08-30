import React, { useEffect, useState } from "react";
import './App.css'
import Route from './Route'
import { getRoutes } from './api'

function Routes({ location }) {
    const [routes, setRoutes] = useState([]);
    
    useEffect(() => {
      getRoutes(location).then((data) => {
        setRoutes(data?.data);
      });
    }, [location]);

    let routeList;
    if (routes.length > 0) {
        routeList = <div><p>Choose route:</p>
        <ul>
            {routes.map((route) => (
                <Route routeName={route.routeName} routeId={route.routeId} />
            ))}
        </ul>
        </div>;
    } else {
        routeList = <p>No routes available</p>;
    }

    return (
        <div className="App">
            <header className="App-header">
                {routeList}
            </header>
        </div>
    )
}

export default Routes
