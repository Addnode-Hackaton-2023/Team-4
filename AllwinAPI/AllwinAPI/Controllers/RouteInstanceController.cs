using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteInstanceController : ControllerBase
    {

        [HttpGet]
        [Route("GetActiveRouteInstances")]
        public List<RouteInstanceDO> GetActiveRouteInstances()
        {
            return new List<RouteInstanceDO>()
            {
                new RouteInstanceDO()
                {
                    RouteInstanceId = 1,
                    RouteName = "Stockholm rutt 1",
                    ETA = DateTime.Now.AddHours(2),
                    LatestLatitude = 59.385100,
                    LatestLongitude = 18.045380,
                    LoadedWeight = 157,
                    Stops = new List<int> { 1, 2, 3 },
                }
            };
        }
    }
}
