import Map from '@arcgis/core/Map.js'
import Graphic from '@arcgis/core/Graphic.js'
import * as route from '@arcgis/core/rest/route.js'
import RouteParameters from '@arcgis/core/rest/support/RouteParameters.js'
import FeatureSet from '@arcgis/core/rest/support/FeatureSet.js'
import MapView from '@arcgis/core/views/MapView.js'

const noop = () => {}
const routeUrl =
    'https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World'

function getRoute() {
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
                map.set('extent', result.route.geometry.extent)
            })
        })

        .catch(function (error) {
            console.log(error)
        })
}

async function addGraphic() {
    var response = await fetch(
        'https://allwinapi20230830114644.azurewebsites.net/api/Stop/route/1'
    )
    var stops = await response.json() //extract JSON from the http response
    for (let i = 0; i < stops.length; i++) {
        var point = {
            //Create a point
            type: 'point',
            longitude: stops[i].longitude,
            latitude: stops[i].latitude,
        }
        const graphic = new Graphic({
            symbol: {
                type: 'simple-marker',
                color: getColor(i, stops.length - 1),
                size: '10px',
            },
            geometry: point,
        })
        view.graphics.add(graphic)
    }
    getRoute() // Call the route service
}
const successCallback = (position) => {
    console.log(position)
    var point = {
        //Create a point
        type: 'point',
        longitude: position.coords.longitude,
        latitude: position.coords.latitude,
    }
    const graphic = new Graphic({
        symbol: {
            type: 'simple-marker',
            color: 'blue',
            size: '15px',
        },
        geometry: point,
    })
    view.graphics.add(graphic)
}

const errorCallback = (error) => {
    console.log(error)
}
function addControls() {
    // Display directions
    addGraphic()
    const directions = document.createElement('div')
    //directions.innerHTML = "hello world";
    directions.classList =
        'esri-widget esri-widget--panel esri-directions__scroller'
    directions.style.marginTop = '0'
    directions.style.width = '70px'
    view.ui.empty('bottom-right')
    view.ui.add(directions, 'bottom-right')

    const newButton = document.createElement('button')
    newButton.textContent = 'Starta'
    newButton.style.width = '70px'
    document.body.appendChild(newButton)

    newButton.addEventListener('click', () => {
        const options = {
            enableHighAccuracy: false,
            timeout: 5000,
            maximumAge: 0,
        }
        navigator.geolocation.watchPosition(
            successCallback,
            errorCallback,
            options
        )
        directions.hidden = true
    })
    directions.appendChild(newButton)
}

const map = new Map({
    basemap: 'arcgis-navigation', // Basemap layer service
})

const view = new MapView({
    container: 'viewDiv',
    map: map,
    center: [18.06324, 59.334591], //Longitude, latitude
    zoom: 10,
})
view.on('load', addControls())

const getColor = (i, x) => {
    if (i === 0) {
        return 'green'
    } else if (i == x) {
        return 'red'
    } else {
        return 'black'
    }
}

export const initialize = (container, stops) => {
    view.container = container
    view.when()
        .then((_) => {
            console.log('Map and View are ready')
        })
        .catch(noop)
    //extract JSON from the http response
    for (let i = 0; i < stops.length; i++) {
        var point = {
            //Create a point
            type: 'point',
            longitude: stops[i].longitude,
            latitude: stops[i].latitude,
        }
        const graphic = new Graphic({
            symbol: {
                type: 'simple-marker',
                color: getColor(i, stops.length - 1),
                size: '10px',
            },
            geometry: point,
        })
        view.graphics.add(graphic)
    }
}
