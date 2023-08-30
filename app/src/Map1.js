import './App.css'
import { initialize } from './mapService.js'
import React, { useEffect, useRef } from 'react'

function Map1() {
    const elementRef = useRef()

    useEffect((_) => {
        initialize(elementRef.current)
    }, [])

    return <div className="viewDiv" ref={elementRef}></div>
}

export default Map1
