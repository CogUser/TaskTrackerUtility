using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerUtilityApp.API.DTO;

namespace TaskTrackerUtilityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartValuesController: ControllerBase
    {
         // GET api/chartValues
        [HttpGet]
        public IActionResult GetChartValues()
        {
            var values = new List<ChartValues>();
            values.Add(new ChartValues(){
                PlayerName = "Player1",
                Run = 20
            });
            values.Add(new ChartValues(){
                PlayerName = "Player2",
                Run = 40
            });

            return Ok(values);
        }
    }
}