import { Link } from 'react-router-dom'
import './App.css'

function App() {
    return (
        <div className="App">
            <header className="App-header">
                {/*  <img src={logo} className="App-logo" alt="logo" /> */}
                <p>Holy Driver - Choose location:</p>
                <Link to="/stockholm">Stockholm</Link>
                <Link to="/malmo">Malmö</Link>
                <Link to="/goteborg">Göteborg</Link>
            </header>
        </div>
    )
}

export default App
