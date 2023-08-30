using AllwinAPI.Db;
using AllwinAPI.Db.DbModel;
using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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
            var job = new JobDO();

            var route = _dbContext.Routes.Where(x => x.RouteId == routeId).FirstOrDefault();
            if (route == null) return null;

            var dbJob = new Job()
            {
                RouteId = routeId,
                ETA = DateTime.Now.AddHours(2),
                LatestLatitude = null,
                LatestLongitude = null,
                Route = route,
            };

            var jobStops = new List<JobStop>();
            route.Stops.ForEach(stop =>
            {
                jobStops.Add(new JobStop() { 
                    StopOrder = stop.StopOrder, 
                    Completed = false, 
                    DeviationComment = string.Empty, 
                    LatestLongitude = null, 
                    LoadedWeight = 0, 
                    LatestLatitude = 0, 
                    StopId = stop.StopId
                });
            });
            
            dbJob.JobStops = jobStops;

            _dbContext.Jobs.Add(dbJob);
            _dbContext.SaveChanges();

            job.LoadedWeight = 0;
            job.JobId = dbJob.JobId;
            job.RouteName = dbJob.Route.RouteName;
            job.ETA = null;
            job.LatestLatitude = null;
            job.LatestLongitude = null;
            job.JobStops = dbJob.JobStops.Select(stop =>
            
                new JobStopDO()
                {
                    StopId = stop.StopId,
                    IsCompleted = false,
                    JobId = stop.JobId
                }
            ).ToList();

            return job;
        }

        [HttpPost]
        [Route("CompleteStop/{jobId}/stop/{stopId}")]
        public JobDO SetCompleteStop([FromRoute] int jobId, [FromRoute] int stopId, [FromBody] StopCompleteEventDO stopEvent)
        {
            var instance = new JobDO()
            {
                JobId = 1,
                RouteName = "Stockholm rutt 1",
                ETA = DateTime.Now.AddHours(2),
                LatestLatitude = 59.385100,
                LatestLongitude = 18.045380,
                LoadedWeight = 157
                //Stops = new List<int> { 1, 2, 3 },
            };
            return instance;
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
                    Stops = j.JobStops.Select(js =>
                    new StopCompleteDO()
                    {
                        StopId = js.Stop.StopId,
                        Name = js.Stop.Name,
                        Adress = js.Stop.Adress,
                        Latitude = js.Stop.Latitude,
                        Longitude = js.Stop.Longitude,
                        ContactPerson = js.Stop.ContactPerson,
                        ContactPhone = js.Stop.ContactPhone
                    }).ToList(),
                    TownName = j.Route.Town.TownName,

                }).ToList();

            return jobs;
        }
    }
}
