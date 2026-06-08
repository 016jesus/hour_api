
using Horas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Horas.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class HourController(HourService hourService) : ControllerBase
    {
        //mirar la inyeccion de dependencias luego
        private readonly HourService HourS = hourService;

        [HttpPost("sum")]
         public IActionResult Sum([FromBody] HourRequest request){
            if (request == null)
                return BadRequest("Request is null");
            var result = HourS.Sum(request);
            
            return Ok(new {result = result.ToString()});
        }
    }

}