import '../App.css'
import { useParams } from 'react-router-dom';
import React, { useEffect, useState } from "react";
import { postCompleteStop } from '../api';

function RegisterDeviation() {
    const [deviation, setDeviation] = React.useState('');
    let {stopId, jobId} = useParams();
    
    const submitDeviation = () =>{
        let d = document.getElementById('deviationId').value;
        setDeviation(d)
        postCompleteStop(jobId, stopId, 0, d);
    }
    
    return(
        <div className='register-weight'>
            <div className="field">
                <input className="input" type="text"  id='deviationId'/>
            </div>
            <div className='button is-link' onClick={submitDeviation}>Registrera</div>
        </div>
    )
}

export default RegisterDeviation
