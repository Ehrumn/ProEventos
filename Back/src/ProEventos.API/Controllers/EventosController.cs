using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly DataContext _context;

        public EventosController(DataContext context)
        {
            _context = context;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EventosController> _logger;
        

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
          return _context.Eventos;
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> GetByID(int id)
        {
          Evento evento = _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
          return evento is null ? NotFound() : evento;
        }

        [HttpPost]
        public string Post()
        {
          return "Exemplo POST";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
          return $"Exemplo PUT com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
          return $"Exemplo DELETE com id = {id}";
        }
    }
}
