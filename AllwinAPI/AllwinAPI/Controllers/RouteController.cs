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
        [Route("StartRoute")]
        public void StartRoute(int routeId)
        {
            return;
        }
    }
}
