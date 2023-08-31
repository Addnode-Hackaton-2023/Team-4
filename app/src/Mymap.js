import React, { useEffect, useRef } from 'react'
import './Mymap.css'

import Map from '@arcgis/core/Map.js'
import MapView from '@arcgis/core/views/MapView.js'

const useCreateMap = (mapRef) => {
    useEffect(() => {
        let view;

        const initializeMap = async (mapRef) => {
            const map = new Map({
                basemap: 'arcgis-navigation', // Basemap layer service
            })
            view = new MapView({
                container: 'viewDiv',
                map: map,
                center: [18.06324, 59.334591], //Longitude, latitude
                zoom: 10,
            })
        }

        initializeMap(mapRef);

        return () => view?.destroy();
    }, [mapRef]);
}

function Mymap({ stops }) {
    const elementRef = useRef(null);
    useCreateMap(elementRef);

    return <div className="map-view" ref={elementRef}></div>
}

export default Mymap
