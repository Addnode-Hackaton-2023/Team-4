import '../App.css'
import React, { useEffect, useState } from "react";
import RegisterWeight from './registerWeight';
import RegisterDeviation from './registerDeviation';

function Register() {
    const [register, setRegister] = useState(null);

    if(register===null){
        return(
            <div>
                <div onClick={() => {setRegister(true)}}>Registrera vikt</div>
                <div onClick={() => {setRegister(false)}}>Registrera avvikelse</div>
            </div>)
    }else if(register){
        return(<RegisterWeight/>)
    }else{
        return(<RegisterDeviation/>)
    }
}

export default Register
