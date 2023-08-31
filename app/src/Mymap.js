import React, { useEffect, useRef } from 'react'
import { useParams } from 'react-router-dom';
import './Mymap.css'

import TileInfo from "@arcgis/core/layers/support/TileInfo.js";
import Map from '@arcgis/core/Map.js'
import MapView from '@arcgis/core/views/MapView.js'
import Graphic from '@arcgis/core/Graphic.js'
import * as route from '@arcgis/core/rest/route.js'
import RouteParameters from '@arcgis/core/rest/support/RouteParameters.js'
import FeatureSet from '@arcgis/core/rest/support/FeatureSet.js'
import { getRoute } from './api'

const routeUrl =
    'https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World'

function drawRoute(view) {
    const routeParams = new RouteParameters({
        stops: new FeatureSet({
            features: view.graphics.toArray(),
        }),

        returnDirections: true,
    })

    route
        .solve(routeUrl, routeParams)
        .then(function (data) {
            data.routeResults.forEach(function (result) {
                result.route.symbol = {
                    type: 'simple-line',
                    color: [5, 150, 255],
                    width: 3,
                }
                view.graphics.add(result.route)
            })
        })
        .catch(function (error) {
            console.log(error)
        })
}

const getColor = (i, x) => {
    if (i === 0) {
        return 'green'
    } else if (i == x) {
        return 'red'
    } else {
        return 'black'
    }
}

const createStopGraphics = (view, stopList) => {
    for (let i = 0; i < stopList.length; i++) {
        var point = {
            //Create a point
            type: 'point',
            longitude: stopList[i].longitude,
            latitude: stopList[i].latitude,
        }
        const graphic = new Graphic({
            symbol: {
                type: 'simple-marker',
                color: getColor(i, stopList.length - 1),
                size: '10px',
            },
            geometry: point,
        })
        view.graphics.add(graphic)
    }
}

const addRegisterStopButton = (view) => {
    const newButton = document.createElement('button');
    newButton.textContent = 'Starta';
    newButton.style.width = '70px';
    newButton.className = 'button is-primary';

    newButton.addEventListener('click', () => {
        const options = {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0,
        };
        navigator.geolocation.watchPosition(
            (location) => successCallback(view, location),
            errorCallback,
            options
        );
        newButton.hidden = true;
    });

    view.ui.empty('bottom-right');
    view.ui.add(newButton, 'bottom-right');
}

let currentLocation = null;
const successCallback = (view, position) => {
    console.log(position);
    if (currentLocation != null) {
        view.graphics.remove(currentLocation);
        currentLocation = null;
    }
    var point = {
        //Create a point
        type: 'point',
        longitude: position.coords.longitude,
        latitude: position.coords.latitude,
    };
    currentLocation = new Graphic({
        symbol: {
            type: 'simple-marker',
            color: 'blue',
            size: '15px',
        },
        geometry: point,
    });
    view.graphics.add(currentLocation);
}

const errorCallback = (error) => {
    console.log(error)
}

const useCreateMap = (mapRef, routeId) => {
    useEffect(() => {
        let view;

        const initializeMap = async (mapRef, routeData) => {
            const map = new Map({
                basemap: 'arcgis-navigation', // Basemap layer service
            });
            view = new MapView({
                container: mapRef.current,
                map: map,
                center: [18.06324, 59.334591], //Longitude, latitude
                zoom: 10,
                constraints: {
                    lods: TileInfo.create().lods,
                    maxZoom: 17,
                    minZoom: 8
                }
            });
            console.log(view.constraints);
            createStopGraphics(view, routeData);
            drawRoute(view);
            addRegisterStopButton(view);
        }

        getRoute(routeId).then((data) => {
            let routeData = data?.data;
            initializeMap(mapRef, routeData);
        });

        return () => view?.destroy();
    }, [mapRef]);
}

function Mymap() {
    let {routeId} = useParams();
    const elementRef = useRef(null);
    useCreateMap(elementRef, routeId);

    return <div className="map-view" ref={elementRef}></div>
}

export default Mymap
