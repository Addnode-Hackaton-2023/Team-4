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

export function postWeight(stopId, weight){
    const endpoint = 'Stop/RegisterWeight'

    axios.post(baseURL + endpoint, {
        "stopId": stopId,
        "weight": weight},
        {headers: headers}
    )
} 

export function postDeviation(stopId, comment){
    const endpoint = 'Stop/RegisterDeviation'

    axios.post(baseURL + endpoint, {
        "stopId": stopId,
        "comment": comment},
        {headers: headers}
    )
} 