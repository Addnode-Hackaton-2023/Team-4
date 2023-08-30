import './App.css'

function Route({ routeName }) {
    const stops = [
        'Stockholmsvägen 1, 182 78 Stocksund',
        'Stockholmsvägen 20, 181 50 Lidingö',
        'Enhagsvägen 24, 183 34 Täby',
        'Sankt Eriksgatan 113, 113 43 Stockholm',
        'Bibliotekstorget 2A, 171 45 Solna',
        'Saluvägen 10, 187 66 Täby',
        'Sveavägen 59, 113 59 STOCKHOLM',
        'Sibyllegatan 8, 114 42 Stockholm',
        'Kista Galleria, 164 91 Kista',
        'Landsvägen 47, 172 65 Sundbyberg',
        'Sankt Göransgatan 70, 112 38 Stockholm',
        'Djupdalsvägen 29, 192 73 Sollentuna',
        'Tistelvägen 21, 191 62 Sollentuna',
        'Rinkebytorget 1, 163 73 Spånga',
        'Folkungagatan 51, 116 22 Stockholm',
        'Villmanstrandsgatan 6, 164 73 Kista',
        'Magnus Ladulåsgatan 3, 118 65 Stockholm',
        'Bromstensvägen 158, 163 55 Spånga',
        'Liljeholmstorget 44, 117 61 Stockholm',
        'Hammarby allé 118, 120 65 Stockholm',
        'Värmdövägen 691, 132 35 Saltsjö-Boo',
        'Enköpingsvägen 26B, 177 45 Järfälla',
        'Årevägen 32, 162 61 Vällingby',
        'Bussens väg 5, 122 43 Enskede',
        'Värmevägen 1A, 177 57 Järfälla',
    ]

    return (
        <div className="App">
            <header className="App-header">
                <p>Route- {routeName}: </p>
                <ul>
                    {stops.map((stop) => (
                        <li>
                            <a
                                className="App-link"
                                href="https://reactjs.org"
                                target="_blank"
                                rel="noopener noreferrer"
                            >
                                {stop}
                            </a>
                        </li>
                    ))}
                </ul>
            </header>
        </div>
    )
}

export default Route
