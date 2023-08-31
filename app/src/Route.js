import './App.css'
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
    return (
        <div>
            <p><Link to={`/route/${routeId}`}>Route - {routeName}:</Link></p>          
        </div>
    )
}

export default Route
