using AllwinAPI.Db;
using AllwinAPI.Db.DbModel;
using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var route = _dbContext.Routes.Include(a => a.Stops).Where(x => x.RouteId == routeId).FirstOrDefault();

            if (route == null) return null;

            var maxJobId = _dbContext.Jobs.Any() ? _dbContext.Jobs.Max(r => r.JobId) : 0;

            var dbJob = new Job()
            {
                JobId = maxJobId + 1,
                RouteId = routeId,
                ETA = DateTime.Now.AddMinutes(route.Stops.Count() * 15).AddHours(2),
                LatestLatitude = null,
                LatestLongitude = null,
                Route = route,
            };

            var jobStops = new List<JobStop>();
            var jobStopNumber = _dbContext.JobStops.Any() ? _dbContext.JobStops.Max(r => r.JobStopId) : 0;
            route.Stops.ForEach(stop =>
                {
                    var stopdefintion = _dbContext.Stops.Where(s => s.StopId == stop.StopId).Single();
                    jobStops.Add(new JobStop()
                    {
                        JobStopId = ++jobStopNumber,
                        StopOrder = stop.StopOrder,
                        Completed = false,
                        DeviationComment = string.Empty,
                        LoadedWeight = 0,
                        StopId = stop.StopId,
                        Stop = stopdefintion,
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
            ).OrderBy(j => j.StopOrder).ToList();

            return job;
        }

        [HttpPost]
        [Route("CompleteStop/{jobId}/stop/{stopId}")]
        public JobDO SetCompleteStop([FromRoute] int jobId, [FromRoute] int stopId, [FromBody] StopCompleteEventDO stopEvent)
        {
            var job = _dbContext.Jobs.Include(j => j.JobStops).Where(j => j.JobId == jobId).FirstOrDefault();
            if (job == null) return null;

            var jobStop = job.JobStops.Where(js => js.StopId == stopId).FirstOrDefault();

            if (jobStop == null) return null;

            var stop = _dbContext.Stops.Single(s => s.StopId == jobStop.StopId);

            job.LatestLatitude = stop.Latitude;
            job.LatestLongitude = stop.Longitude;
            job.ETA = DateTime.Now.AddMinutes(job.JobStops.Count(js => !js.Completed) * 15).AddHours(2);

            if (stopEvent.Weight > 0)
            {
                jobStop.LoadedWeight = stopEvent.Weight;
                jobStop.Completed = true;
            }
            else if (!string.IsNullOrEmpty(stopEvent.DeviationComment))
            {
                jobStop.DeviationComment = stopEvent.DeviationComment;
                jobStop.Completed = true;
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

                               }).OrderBy(j => j.StopOrder).ToList(),
                TownName = job.Route.Town.TownName,

            };
            return jobDo;
        }

        [HttpGet]
        [Route("IsActiveJob")]
        public bool IsActiveJob(int jobId)
        {
            var active = _dbContext.Jobs
                .Any(j => j.JobId == jobId && j.JobStops.Any(js => !js.Completed));
            return active;
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
                                       StopName = js.Stop.Name

                                   }).ToList(),
                    TownName = j.Route.Town.TownName,

                }).ToList();

            return jobs;
        }
    }
}
