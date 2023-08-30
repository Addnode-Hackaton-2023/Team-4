import { Link } from 'react-router-dom'
import './App.css'

function App() {
    const reload = () => window.location.reload()
    return (
        <div className="App">
            <header className="App-header">
                <p>Holy Driver - Choose location:</p>
                <Link to="/stockholm">Stockholm</Link>
                <Link to="/malmo">Malmö</Link>
                <Link to="/goteborg">Göteborg</Link>
                <Link to="/map.html">Map</Link>
                <Link to="/map1">Map1</Link>
            </header>
        </div>
    )
}

export default App