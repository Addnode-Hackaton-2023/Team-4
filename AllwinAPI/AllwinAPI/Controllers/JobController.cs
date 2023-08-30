using AllwinAPI.Db;
using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController
    {
        public readonly AllwinDbContext _dbContext;
        public JobController(AllwinDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("StartJob/route/{routeId}")]
        public JobDO StartJob([FromRoute] int routeId)
        {
            var instance = new JobDO()
            {
                JobId = 1,
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
        public void SetCompleteStop([FromRoute] int jobId, [FromRoute] int stopId, [FromBody] StopCompleteEventDO stopEvent)
        {
            return;
        }

        [HttpGet]
        [Route("GetActiveJobs")]
        public List<RouteInstanceDO> GetActiveJobs()
        {
            //var stops = _dbContext.Stops
            //   .Where(s => s.Routes.Any(r => r.RouteId == routeId))
            //   .Select(
            //       s => new StopListDO()
            //       {
            //           StopId = s.StopId,
            //           RouteId = routeId,
            //           Name = s.Name,
            //           Adress = s.Adress,
            //           Latitude = s.Latitude,
            //           Longitude = s.Longitude
            //       })
            //   .ToList();

            //var jobs = _dbContext.Jobs
            //    .Where(j => j.JobStops.Any(js => !js.Completed))

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
