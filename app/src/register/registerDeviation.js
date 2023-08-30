import '../App.css'
import { useParams } from 'react-router-dom';
import React, { useEffect, useState } from "react";
import { postDeviation } from '../api';

function RegisterDeviation() {
    const [deviation, setDeviation] = React.useState('');
    let {stopId} = useParams();
    
    const submitDeviation = () =>{
        let d = document.getElementById('deviationId').value;
        setDeviation(d)
        postDeviation(stopId, deviation)
        console.log(deviation)
    }
    
    return(
        <div>
            <input type="text"  id='deviationId'/>
            <div onClick={submitDeviation}>Registrera</div>
        </div>
    )
}

export default RegisterDeviation
