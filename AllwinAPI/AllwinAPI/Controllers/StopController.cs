using AllwinAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AllwinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : ControllerBase
    {
        [HttpGet]
        public StopCompleteDO GetStop(int stopId)
        {
            return new StopCompleteDO()
            {
                RouteId = 1,
                StopId = stopId,
                Name = "Ica nära",
                Adress = "Stockholmsvägen 1, 182 78 Stocksund",
                Latitude = 59.385100,
                Longitude = 18.045380,
                ContactPerson = "Person 1",
                ContactPhone = "07012345678"
            };
        }

        [HttpGet]
        public List<StopListDO> GetAllStopsForRoute(int routeId)
        {
            return new List<StopListDO>
            {
                new StopListDO()
                {
                    RouteId = routeId,
                    StopId = 1,
                    Name = "Ica nära",
                    Adress = "Stockholmsvägen 1, 182 78 Stocksund",
                    Latitude = 59.385100,
                    Longitude =  18.045380,
                },
                new StopListDO()
                {
                    RouteId = routeId,
                    StopId = 2,
                    Name = "Coop",
                    Adress = "Stockholmsvägen 20, 181 50 Lidingö",
                    Latitude = 59.363430,
                    Longitude = 18.123540,
                },
                new StopListDO()
                {
                    RouteId = routeId,
                    StopId = 3,
                    Name = "Lidl",
                    Adress = "Enhagsvägen 24, 183 34 Täby",
                    Latitude = 59.443940,
                    Longitude = 18.073490,
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
