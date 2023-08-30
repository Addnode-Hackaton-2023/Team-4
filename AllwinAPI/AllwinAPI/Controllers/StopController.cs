using Microsoft.AspNetCore.Mvc;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : ControllerBase
    {

        [HttpGet]
        public void GetAllStopsForRoute(int routeId)
        {
            return;
        }

        [HttpPost]
        public void RegisterWeigth(WeightDO weight)
        {
            return;
        }
    }
}
