using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController
    {
        [HttpPost]
        [Route("StartJob/{routeId}")]
        public RouteInstanceDO StartRoute([FromRoute] int routeId)
        {
            var instance = new RouteInstanceDO()
            {
                RouteInstanceId = 1,
                RouteName = "Stockholm rutt 1",
                ETA = DateTime.Now.AddHours(2),
                LatestLatitude = 59.385100,
                LatestLongitude = 18.045380,
                LoadedWeight = 157,
                Stops = new List<int> { 1, 2, 3 },
            };

            return instance;
        }

        [HttpPost]
        [Route("CompleteStop/{jobId}/stop/{stopId}")]
        public void SetCompleteStop([FromRoute] int jobId, [FromRoute] int stopId, [FromQuery] int weight)
        {
            return;
        }
    }
}
