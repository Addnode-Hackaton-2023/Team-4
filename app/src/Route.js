import './App.css'
import Map1 from './Map1'
import { getRoute } from './api'
import React, { useEffect, useState } from 'react'
import ReactDOM from 'react-dom'
import { Link } from 'react-router-dom'

function Route({ routeId, routeName }) {
    const [stops, setStops] = useState([])

    useEffect(() => {
        getRoute(routeId).then((data) => {
            setStops(data?.data)
        })
    }, [routeId])

    let stopList
    if (stops.length > 0) {
        stopList = (
            <ul>
                {stops.map((stop) => (
                    <li>
                        <Link to={`/stop/${stop.stopId}`}>
                            {stop.name} - {stop.adress}
                        </Link>
                    </li>
                ))}
            </ul>
        )
    } else {
        stopList = <p>No stops available</p>
    }
    return (
        <div>
            <p>Route - {routeName}:</p>
            {stopList}
            {/*ReactDOM.render(
                <Map1 stops={stops} />,
                document.body.appendChild(document.getElementById('viewDiv'))
            )*/}
        </div>
    )
}

export default Route
