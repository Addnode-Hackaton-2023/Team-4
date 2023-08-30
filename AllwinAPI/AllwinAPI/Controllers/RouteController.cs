using AllwinAPI.Db;
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
            //var a = _dbContext.Towns.Count();

            if (townId == 1) //"Stockholm"
            {
                return new List<RouteDO>
                {
                    new RouteDO()
                    {
                        RouteId = 1,
                        RouteName = "Stockholm rutt 1"
                    },
                    new RouteDO()
                    {
                        RouteId = 2,
                        RouteName = "Stockholm rutt 2"
                    },
                };
            }
            if (townId == 2) //"Göteborg"
            {
                return new List<RouteDO>
                {
                    new RouteDO()
                    {
                        RouteId = 3,
                        RouteName = "Göteborg rutt 1"
                    },
                    new RouteDO()
                    {
                        RouteId = 4,
                        RouteName = "Göteborg rutt 2"
                    },
                };
            }
            if (townId == 3) //"Malmö"
            {
                return new List<RouteDO>
                {
                    new RouteDO()
                    {
                        RouteId = 5,
                        RouteName = "Malmö rutt 1"
                    },
                    new RouteDO()
                    {
                        RouteId = 6,
                        RouteName = "Malmö rutt 2"
                    },
                };
            }

            return new List<RouteDO>();
        }

        [HttpPost]
        [Route("StartRoute")]
        public void StartRoute(int routeId)
        {
            return;
        }
    }
}
