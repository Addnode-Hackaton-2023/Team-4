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
        public List<JobDO> GetActiveJobs()
        {
            var jobs = _dbContext.Jobs
                .Where(j => j.JobStops.Any(js => !js.Completed))
                .Select(j => new JobDO()
                {
                    JobId = j.JobId,
                    RouteName = j.Route.RouteName,
                    ETA = j.ETA,
                    LatestLongitude = j.LatestLongitude,
                    LatestLatitude = j.LatestLatitude,
                    LoadedWeight = j.JobStops.Sum(js => js.LoadedWeight.HasValue ? js.LoadedWeight.Value : 0),
                    RouteId = j.RouteId,
                    Stops = j.JobStops.Select(js => js.StopId).ToList()

                }).ToList();

            return jobs;
        }
    }
}
