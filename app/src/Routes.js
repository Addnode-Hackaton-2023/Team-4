import React, { useEffect, useState } from "react";
import { useLocation } from 'react-router-dom';
import './App.css'
import Route from './Route'
import { getRoutes } from './api'

function Routes({ location }) {
    const [routes, setRoutes] = useState([]);
    let routerLocation = useLocation();
    
    React.useEffect(() => {
        document.getElementById("rootOuterContainer").className = "App";
      }, [routerLocation]);
    
    useEffect(() => {
      getRoutes(location).then((data) => {
        setRoutes(data?.data);
      });
    }, [location]);

    let routeList;
    if (routes.length > 0) {
        routeList = <div><h5 className="subtitle is-5">Välj rutt:</h5>
        <ul>
            {routes.map((route) => (
                <Route routeName={route.routeName} routeId={route.routeId} />
            ))}
        </ul>
        </div>;
    } else {
        routeList = <p>Inga rutter är tillgängliga</p>;
    }

    return (
        <div>
            {routeList}
        </div>
    )
}

export default Routes
