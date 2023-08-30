using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : ControllerBase
    {

        [HttpGet]
        public List<StopDO> GetAllStopsForRoute(int routeId)
        {
            return new List<StopDO>
            {
                new StopDO()
                {
                    routeId = 1,
                    stopId = 1,
                    name = "Ica nära"
                },
                new StopDO()
                {
                    routeId = 1,
                    stopId = 2,
                    name = "Coop"
                },
                new StopDO()
                {
                    routeId = 1,
                    stopId = 3,
                    name = "Lidl"
                }
            };
        }

        [HttpPost]
        public void RegisterWeigth(WeightDO weight)
        {
            return;
        }
    }
}
