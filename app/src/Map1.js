import './App.css'
import { getRoute } from './api'
import Map from '@arcgis/core/Map.js'
// import MapView from '@arcgis/core/views/MapView.js'
import SceneView from '@arcgis/core/views/SceneView.js'
// import esriConfig from '@arcgis/core/config.js'
import React, { useEffect, useState } from 'react'

/* const key =
    'AAPKaaa696cbe9f44021ba8aa1d271924f71fYD65N2risPRaS7wEFOGmw0ihhMP6Lfo1LxShaM34iX7eKua86RoOAbp0nnFvudi'
esriConfig.apiKey = key
 */
function Map1() {
    const map = new Map({
        basemap: 'dark-gray-vector',
    })

    const view = new SceneView({
        map: map,
        container: 'viewDiv',
        center: [-106.4508651185194, 31.763963987428166],
        zoom: 16,
    })

    /* const [stops, setStops] = useState([])

    useEffect(() => {
        getRoute(routeId).then((data) => {
            setStops(data?.data)
        })
    }, [routeId]) */

    return <div></div>
}

export default Map1
