import '../App.css'
import { useParams } from 'react-router-dom';
import React, { useEffect, useState } from "react";
import { postWeight } from '../api';

function RegisterWeight() {
    const [weight, setWeight] = React.useState(0);
    let {stopId} = useParams();
    
    const submitWeight = () =>{
        let w = document.getElementById('weightId').value;
        setWeight(w)
        postWeight(stopId, w)
        console.log(weight)
    }
    
    return(
        <div>
            <input type="text" pattern="[0-9]*" id='weightId'/>
            <div onClick={submitWeight}>Registrera</div>
        </div>
    )
}

export default RegisterWeight
