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
            var routes = _dbContext.Routes
                .Where(r => r.TownId == townId)
                .Select(
                    r => new RouteDO()
                    {
                        RouteId = r.RouteId,
                        RouteName = r.RouteName
                    })
                .ToList();

            return routes;
        }

        [HttpPost]
        [Route("StartRoute")]
        public void StartRoute(int routeId)
        {
            return;
        }
    }
}
