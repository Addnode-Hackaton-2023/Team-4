import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import './index.css'
import App from './App'
import LocationRoutes from './Routes'
import Mymap from './Mymap'
import reportWebVitals from './reportWebVitals'
import StopOverview from './StopOverview'
import './config'

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
                <Route path="/mymap" element={<Mymap />} />
                <Route path="/stop/:stopId/job/:jobId" element={<StopOverview />} />
                <Route path="/route/:routeId" element={<Mymap />} />
                <Route path="/map.html" onEnter={reload} />
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
)

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals()
