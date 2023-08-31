import './App.css'
import { Link } from 'react-router-dom'

function Route({ routeId, routeName }) {
    return (
        <div>
            <p><Link className='button is-link' to={`/route/${routeId}`}>{routeName}</Link></p>
        </div>
    )
}

export default Route
