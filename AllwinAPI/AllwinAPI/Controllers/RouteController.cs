using AllwinAPI.Db;
using AllwinAPI.Db.DbModel;
using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        public readonly AllwinDbContext _dbContext;
        public RouteController(AllwinDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<RouteDO> Get(int townId)
        {
            var routes = _dbContext.Routes
                .Where(r => r.TownId == townId)
                .Select(
                    r => new RouteDO()
                    {
                        RouteId = r.RouteId,
                        RouteName = r.RouteName
                    })
                .ToList();

            return routes;
        }

        [HttpPost]
        [Route("CreateNewRoute")]
        /// Creates a route and returns the routeId
        public int CreateNewRoute(CreateRouteDO createRoute)
        {
            var town = _dbContext.Towns.Single(t => t.TownId == createRoute.TownId);

            var maxRouteId = _dbContext.Routes.Max(r => r.RouteId);

            var route = new AllwinAPI.Db.DbModel.Route()
            {
                RouteId = maxRouteId + 1,
                RouteName = createRoute.RouteName,
                TownId = createRoute.TownId,
                Town = town
            };

            var maxStopId = _dbContext.Stops.Max(r => r.StopId);
            var number = 0;
            foreach (var stop in createRoute.Stops)
            {
                number++;
                route.Stops.Add(
                    new StopInRoute()
                    {
                        Stop = new Stop()
                        {
                            StopId = ++maxStopId,
                            Adress = stop.Adress,
                            Name = stop.Name,
                            Latitude = stop.Latitude,
                            Longitude = stop.Longitude,
                            TownId = createRoute.TownId,
                            ContactPerson = "Person 1",
                            ContactPhone = "07012345678",
                        },
                        StopOrder = number
                    });
            }

            _dbContext.Add(route);



            _dbContext.SaveChanges();

            return route.RouteId;
        }


        [HttpPost]
        [Route("OptimizeAndCreateNewRoute")]

        public int OptimizeAndCreateNewRoute()
        {
            string data = @"Stockholmsvägen 1, 182 78 Stocksund; 59.385100; 18.045380
Stockholmsvägen 20, 181 50 Lidingö; 59.363430; 18.123540
Enhagsvägen 24, 183 34 Täby; 59.443940; 18.073490
Sankt Eriksgatan 113, 113 43 Stockholm; 59.346390; 18.039720
Bibliotekstorget 2A, 171 45 Solna; 59.359510; 18.001260
Saluvägen 10, 187 66 Täby; 59.4590591; 18.137803
Sveavägen 59, 113 59 STOCKHOLM; 59.3408036; 18.0582458
Sibyllegatan 8, 114 42 Stockholm; 59.3361898; 18.0802584
Kista Galleria, 164 91 Kista; 59.4034402; 17.944066 	
Landsvägen 47, 172 65 Sundbyberg; 59.3610101; 17.9692108
Sankt Göransgatan 70, 112 38 Stockholm; 59.3334784; 18.0309713
Djupdalsvägen 29, 192 73 Sollentuna; 59.4453632; 17.9504741
Tistelvägen 21, 191 62 Sollentuna; 59.4302914; 17.9366161
Rinkebytorget 1, 163 73 Spånga; 59.3833; 17.9167
Folkungagatan 51, 116 22 Stockholm; 59.3144817; 18.0747498
Villmanstrandsgatan 6, 164 73 Kista; 59.4129253; 17.918273
Magnus Ladulåsgatan 3, 118 65 Stockholm; 59.311561584472656; 18.058460235595703
Bromstensvägen 158, 163 55 Spånga; 59.3764978; 17.9107051
Liljeholmstorget 44, 117 61 Stockholm; 59.3100245; 18.0232974
Hammarby allé 118, 120 65 Stockholm; 59.3021326; 18.1021281
Värmdövägen 691, 132 35 Saltsjö-Boo; 59.3230065; 18.2570404
Enköpingsvägen 26B, 177 45 Järfälla; 59.410246; 17.8624445
Årevägen 32, 162 61 Vällingby; 59.3609939; 17.8745624
Bussens väg 5, 122 43 Enskede; 59.2850686; 18.0510632
Värmevägen 1A, 177 57 Järfälla; 59.4279679; 17.846941";

            var newRoute = new CreateRouteDO();
            return CreateNewRoute(newRoute);
        }
    }
}
