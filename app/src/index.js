import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import './index.css'
import App from './App'
import LocationRoutes from './Routes'
import Map1 from './Map1'
import reportWebVitals from './reportWebVitals'

const root = ReactDOM.createRoot(document.getElementById('root'))
const reload = () => window.location.reload()
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<App />} />
                <Route
                    path="/stockholm"
                    element={<LocationRoutes location={'1'} />}
                />
                <Route
                    path="/goteborg"
                    element={<LocationRoutes location={'2'} />}
                />
                <Route
                    path="/malmo"
                    element={<LocationRoutes location={'3'} />}
                />
                <Route path="/map1" element={<Map1 />} />
                <Route path="/map.html" onEnter={reload} />
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
)

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals()
