import axios from "axios";
import React from "react";

const baseURL = "https://allwinapi20230830114644.azurewebsites.net/api/";

export function getList(){
    const endpoint = 'Stop?routeId=1';

    axios.get(baseURL + endpoint).then((response) => {
      return response.data;
    });    
}
