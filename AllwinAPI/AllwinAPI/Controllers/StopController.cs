using AllwinAPI.Db;
using AllwinAPI.Db.DbModel;
using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : ControllerBase
    {
        public readonly AllwinDbContext _dbContext;
        public StopController(AllwinDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("complete/{stopId}")]
        public StopCompleteDO GetStop([FromRoute] int stopId)
        {
            var stop = _dbContext.Stops
                .Where(s => s.StopId == stopId)
                .Select(
                    s => new StopCompleteDO()
                    {
                        StopId = s.StopId,
                        Name = s.Name,
                        Adress = s.Adress,
                        Latitude = s.Latitude,
                        Longitude = s.Longitude,
                        ContactPerson = s.ContactPerson,
                        ContactPhone = s.ContactPhone
                    })
                .FirstOrDefault();

            return stop;
        }

        [HttpGet]
        [Route("route/{routeId}")]
        public List<StopListDO> GetAllStopsForRoute([FromRoute] int routeId)
        {
            var stops = _dbContext.Stops
                .Where(s => s.Routes.Any(r => r.RouteId == routeId))
                .Select(
                    s => new StopListDO()
                    {
                        StopId = s.StopId,
                        RouteId = routeId,
                        Name = s.Name,
                        Adress = s.Adress,
                        Latitude = s.Latitude,
                        Longitude = s.Longitude
                    })
                .ToList();

            return stops;
        }

        [HttpPost]
        [Route("RegisterWeight")]
        public void RegisterWeight(WeightDO weight)
        {
            return;
        }

        [HttpPost]
        [Route("RegisterDeviation")]
        public void RegisteDeviation(DeviationDO deviation)
        {
            return;
        }
    }
}
