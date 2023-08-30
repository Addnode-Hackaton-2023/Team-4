import './App.css'
import { getRoute } from './api'
import React, { useEffect, useState } from "react";
import { Link } from 'react-router-dom'

function Route({ routeId, routeName }) {
    const [stops, setStops] = useState([]);
    
    useEffect(() => {
      getRoute(routeId).then((data) => {
        setStops(data?.data);
      });
    }, [routeId]);
    
    let stopList;
    if (stops.length > 0) {
        stopList =
            <ul>
                {stops.map((stop) => (
                    <li>
                        {stop.name} - {stop.adress}
                    </li>
                ))}
            </ul>;
    } else {
        stopList = <p>No stops available</p>
    }

    return (
        <div>
            <p>
                Route - {routeName}:
            </p>
            <ul>
                {stops.map((stop) => (
                    <li>
                        <Link to={`/stop/${stop.stopId}`}>{stop.name} - {stop.adress}</Link>
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default Route
