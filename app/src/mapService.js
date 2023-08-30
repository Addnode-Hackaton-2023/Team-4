import Map from '@arcgis/core/Map.js'
import MapView from '@arcgis/core/views/MapView.js'

const noop = () => {}

const map = new Map({
    basemap: 'arcgis-topographic', // Basemap layer service
})

const view = new MapView({
    map: map,
    center: [-118.805, 34.027], // Longitude, latitude
    zoom: 13, // Zoom level
    container: 'viewDiv', // Div element
})

export const initialize = (container) => {
    view.container = container
    view.when()
        .then((_) => {
            console.log('Map and View are ready')
        })
        .catch(noop)
}
