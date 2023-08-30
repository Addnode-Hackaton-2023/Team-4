import { Link } from 'react-router-dom'
import './App.css'

function App() {
    return (
        <div className="App">
            <header className="App-header">
                {/*  <img src={logo} className="App-logo" alt="logo" /> */}
                <p>Holy Driver - Choose location:</p>
                <Link to="/stockholm">Stockholm</Link>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Stockholm
                </a>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Malmö
                </a>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Göteborg
                </a>
            </header>
        </div>
    )
}

export default App
