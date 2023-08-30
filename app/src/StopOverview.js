import './App.css'
import { getRoute } from './api'
import React, { useEffect, useState } from "react";

function StopOverview({ stopId }) {
    const [stopDetails, setStopDetails] = useState([]);

    useEffect(() => {
      getRoute(stopId).then((data) => {
        setStopDetails(data?.data);
      });
    }, [stopId]);

    return (
        <div>
            <h3>Stop - {stopDetails.name}</h3>
            <p>{stopDetails.adress}</p>
            <p>Kontaktperson: {stopDetails.contactPerson} - {stopDetails.contactPhone}</p>
        </div>
    )
}

export default StopOverview
