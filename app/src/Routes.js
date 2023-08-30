import './App.css'
import Route from './Route'

function Routes() {
    const routes = ['Route1', 'Route2', 'Route3', 'Route4']

    return (
        <div className="App">
            <header className="App-header">
                <p>Holy Driver - Choose location:</p>
                <ul>
                    {routes.map((route) => (
                        <Route routeName={route} />
                    ))}
                </ul>
            </header>
        </div>
    )
}

export default Routes
