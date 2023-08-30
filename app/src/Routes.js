import './App.css'
import Route from './Route'

function Routes({ location }) {
    const routes = ['Route1', 'Route2', 'Route3', 'Route4']

    return (
        <div className="App">
            <header className="App-header">
                <p>Choose route:</p>
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
