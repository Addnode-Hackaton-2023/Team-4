import { useParams } from 'react-router-dom';
import './App.css'
import { getDetailedStopInfo } from './api'
import React, { useEffect, useState } from "react";
import Register from './register/register';

function StopOverview() {
    const [stopDetails, setStopDetails] = useState([]);
    let {stopId, jobId} = useParams();

    useEffect(() => {
      getDetailedStopInfo(stopId).then((data) => {
        setStopDetails(data?.data);
      });
    }, [stopId]);

    return (
        <div>
            <h3>Stopp - {stopDetails.name}</h3>
            <p>{stopDetails.adress}</p>
            <p>Kontaktperson: {stopDetails.contactPerson} - {stopDetails.contactPhone}</p>
            <Register/>
        </div>
    )
}

export default StopOverview
