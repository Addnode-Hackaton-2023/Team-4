import axios from "axios";

const baseURL = "https://allwinapi20230830114644.azurewebsites.net/api/";

export function getRoute(routeId){
    const endpoint = 'Stop/route/' + routeId;

    return axios.get(baseURL + endpoint);
}

export function getDetailedStopInfo(stopId){
    const endpoint = 'Stop/complete/' + stopId;

    return axios.get(baseURL + endpoint);
}

export function getRoutes(townName) {
    const endpoint = 'Route?townId=' + townName;

    return axios.get(baseURL + endpoint);
}