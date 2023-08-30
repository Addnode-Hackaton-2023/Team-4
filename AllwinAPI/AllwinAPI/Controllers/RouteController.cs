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
            var route = new AllwinAPI.Db.DbModel.Route()
            {
                RouteName = createRoute.RouteName
            };

            var number = 0;
            foreach (var stop in createRoute.Stops)
            {
                route.Stops.Add(
                    new StopInRoute()
                    {
                        Stop = new Stop()
                        {
                            Adress = stop.Adress,
                            Name = stop.Name,
                            Latitude = stop.Latitude,
                            Longitude = stop.Longitude,
                            TownId = createRoute.TownId,
                            ContactPerson = "Person 1",
                            ContactPhone = "07012345678"
                        }
                    });
            }


            _dbContext.Attach(route);
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
