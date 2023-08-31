import axios from "axios";

const baseURL = "https://allwinapi20230830114644.azurewebsites.net/api/";
const headers = {
    'Access-Control-Allow-Origin': '*',
    'content-type': 'application/json',
    'Access-Control-Allow-Headers': '*'};

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

export function postStartRoute(routeId){
    const endpoint = `Job/StartJob/route/${routeId}`;

    return axios.post(baseURL + endpoint, 
        {},
        {headers: headers}
    )
}

export function postCompleteStop(jobId, stopId, weight, comment){
    const endpoint = `Job/CompleteStop/${jobId}/stop/${stopId}`;

    return axios.post(baseURL + endpoint, {
        "weight": weight,
        "deviationComment": comment},
        {headers: headers}
    )
}