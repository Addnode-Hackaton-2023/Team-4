import { useParams } from 'react-router-dom';
import './App.css'
import { getDetailedStopInfo } from './api'
import React, { useEffect, useState } from "react";

function StopOverview() {
    const [stopDetails, setStopDetails] = useState([]);
    let {stopId} = useParams();

    useEffect(() => {
      getDetailedStopInfo(stopId).then((data) => {
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
