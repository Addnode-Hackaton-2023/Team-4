import React from 'react'
import { Link } from 'react-router-dom'
import './App.css'
import logo from './Logo.png'

function App() {
    return (
        <div>
            <img className="logo" src={logo} />
            <h5 className="subtitle is-5">Välj stad</h5>
            <Link to="/stockholm" className="button is-link">Stockholm</Link><br/>
            <Link to="/malmo" className="button is-link">Malmö</Link><br/>
            <Link to="/goteborg" className="button is-link">Göteborg</Link><br/>
        </div>
    )
}

export default App
