using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public  DataContext _context { get; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;

        }

       /* [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
          return _context.Eventos.ToList(); 

        }*/

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{
                var result = await _context.Eventos.ToListAsync(); 
                return Ok(result);
            }catch (System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,  "Busca de dados falhou!!!!");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try{
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId.Equals(id)); 
                return Ok(result);
            }catch (System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,  "Busca de dados falhou!!!!");
            }
        }

        /*[HttpGet("{id}")]
        public  ActionResult<Evento> Get(int id)
        {
            return _context.Eventos.Where(x=> x.EventoId.Equals(id)).FirstOrDefault();
        }*/
    }
}
