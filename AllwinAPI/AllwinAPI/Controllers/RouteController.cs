using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {

        [HttpGet]
        public List<RouteDO> Get(string town)
        {
            if (town == "Stockholm")
            {
                return new List<RouteDO>
                {
                    new RouteDO()
                    {
                        routeId = 1,
                        routeName = "Stockholm rutt 1"
                    },
                    new RouteDO()
                    {
                        routeId = 2,
                        routeName = "Stockholm rutt 2"
                    },
                };
            }
            if (town == "Göteborg")
            {
                return new List<RouteDO>
                {
                    new RouteDO()
                    {
                        routeId = 3,
                        routeName = "Göteborg rutt 1"
                    },
                    new RouteDO()
                    {
                        routeId = 4,
                        routeName = "Göteborg rutt 2"
                    },
                };
            }
            if (town == "Malmö")
            {
                return new List<RouteDO>
                {
                    new RouteDO()
                    {
                        routeId = 5,
                        routeName = "Malmö rutt 1"
                    },
                    new RouteDO()
                    {
                        routeId = 6,
                        routeName = "Malmö rutt 2"
                    },
                };
            }
            return null;
        }
    }
}
