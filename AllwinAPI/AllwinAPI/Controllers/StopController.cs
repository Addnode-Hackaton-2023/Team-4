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
                    Latitude = 59.385100,
                    Longitude =  18.045380,
                    ContactPerson = "Person 1",
                    ContactPhone = "07012345678"
                },
                new StopDO()
                {
                    routeId = 1,
                    stopId = 2,
                    name = "Coop",
                    adress = "Stockholmsvägen 20, 181 50 Lidingö",
                    Latitude = 59.363430,
                    Longitude = 18.123540,
                    ContactPerson = "Person 2",
                    ContactPhone = "07012345679"
                },
                new StopDO()
                {
                    routeId = 1,
                    stopId = 3,
                    name = "Lidl",
                    adress = "Enhagsvägen 24, 183 34 Täby",
                    Latitude = 59.443940,
                    Longitude = 18.073490,
                    ContactPerson = "Person 3",
                    ContactPhone = "07012345670"
                }
            };
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
