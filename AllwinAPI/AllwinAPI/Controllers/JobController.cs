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
                    LoadedWeight = 0,
                    StopId = stop.StopId,
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
            job.TownName = dbJob.Route.Town.TownName;
            job.CurrentJobStops = dbJob.JobStops.Select(stop =>

                new JobStopDO()
                {
                    StopId = stop.StopId,
                    IsCompleted = false,
                    JobId = stop.JobId,
                    LoadedWeight = 0,
                    ContactPerson = stop.Stop.ContactPerson,
                    ContactPhone = stop.Stop.ContactPhone
                }
            ).ToList();

            return job;
        }

        [HttpPost]
        [Route("CompleteStop/{jobId}/stop/{stopId}")]
        public JobDO SetCompleteStop([FromRoute] int jobId, [FromRoute] int stopId, [FromBody] StopCompleteEventDO stopEvent)
        {
            var job = _dbContext.Jobs.Where(j => j.JobId == jobId).FirstOrDefault();
            if (job == null) return null;

            var stop = job.JobStops.Where(js => js.StopId == stopId).FirstOrDefault();

            if (stop == null) return null;

            if(stopEvent.Weight > 0)
            {
                stop.LoadedWeight = stopEvent.Weight;
                stop.Completed = true;
            }
            else if (!string.IsNullOrEmpty(stopEvent.DeviationComment))
            {
                stop.DeviationComment = stopEvent.DeviationComment;
                stop.Completed = true;
            }
            else
            {
                return null;
            }

            _dbContext.SaveChanges();

            var jobDo = new JobDO()
            {
                JobId = job.JobId,
                RouteName = job.Route.RouteName,
                ETA = job.ETA,
                LatestLongitude = job.LatestLongitude,
                LatestLatitude = job.LatestLatitude,
                LoadedWeight = job.JobStops.Sum(js => js.LoadedWeight.HasValue ? js.LoadedWeight.Value : 0),
                RouteId = job.RouteId,
                CurrentJobStops = job.JobStops.Select(js =>
                               new JobStopDO()
                               {
                                   StopId = js.StopId,
                                   IsCompleted = js.Completed,
                                   JobId = js.JobId,
                                   DeviationComment = js.DeviationComment,
                                   LoadedWeight = js.LoadedWeight,
                                   ContactPerson = js.Stop.ContactPerson,
                                   ContactPhone = js.Stop.ContactPhone,

                               }).ToList(),
                TownName = job.Route.Town.TownName,

            };
            return jobDo;
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
                    CurrentJobStops = j.JobStops.Select(js =>
                                   new JobStopDO()
                                   {
                                       StopId = js.StopId,
                                       IsCompleted = js.Completed,
                                       JobId = js.JobId,
                                       DeviationComment = js.DeviationComment,
                                       LoadedWeight = js.LoadedWeight,
                                       ContactPerson = js.Stop.ContactPerson,
                                       ContactPhone = js.Stop.ContactPhone,
                                      
                                   }).ToList(),
                    TownName = j.Route.Town.TownName,

                }).ToList();

            return jobs;
        }
    }
}
