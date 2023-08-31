import '../App.css'
import { useParams } from 'react-router-dom';
import React, { useEffect, useState } from "react";
import { postCompleteStop } from '../api';

function RegisterWeight() {
    const [weight, setWeight] = React.useState(0);
    let {stopId} = useParams();
    
    const submitWeight = () =>{
        let w = document.getElementById('weightId').value;
        setWeight(w);
        //postCompleteStop(jobId, stopId, w, '');
    }
    
    return(
        <div className='register-weight'>
            <div className="field has-addons has-addons-right">
                <p className="control is-expanded">
                    <input className="input" type="text" pattern="[0-9]*" id='weightId'/>
                </p>
                <p className="control">
                    <a className="button is-static">kg</a>
                </p>
            </div>
            <div className='button is-link' onClick={submitWeight}>Registrera</div>
        </div>
    )
}

export default RegisterWeight
