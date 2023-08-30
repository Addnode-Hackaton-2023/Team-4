import './App.css'
import { getRoute } from './api'
import React, { useEffect, useState } from "react";

function Route({ routeId, routeName }) {
    const [stops, setStops] = useState([]);
    
    useEffect(() => {
      getRoute(routeId).then((data) => {
        setStops(data?.data);
      });
    }, [routeId]);

    return (
        <div>
            <p>
                Route - {routeName}:
            </p>
            <ul>
                {stops.map((stop) => (
                    <li>
                        {stop.name} - {stop.adress}
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default Route
