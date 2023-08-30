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
                    name = "Ica nära",
                    adress = "Stockholmsvägen 1, 182 78 Stocksund",
                    Latitude = 0,
                    Longitude = 0,
                    ContactPerson = "Person 1",
                    ContactPhone = "07012345678"
                },
                new StopDO()
                {
                    routeId = 1,
                    stopId = 2,
                    name = "Coop",
                    adress = "Stockholmsvägen 20, 181 50 Lidingö",
                    Latitude = 1,
                    Longitude = 0,
                    ContactPerson = "Person 2",
                    ContactPhone = "07012345679"
                },
                new StopDO()
                {
                    routeId = 1,
                    stopId = 3,
                    name = "Lidl",
                    adress = "Enhagsvägen 24, 183 34 Täby",
                    Latitude = 1,
                    Longitude = 1,
                    ContactPerson = "Person 3",
                    ContactPhone = "07012345670"
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
