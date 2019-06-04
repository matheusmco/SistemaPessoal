using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaPessoal.Data.Implementations;
using SistemaPessoal.Data.Interfaces;
using SistemaPessoal.Domain.Entities;
using SistemaPessoal.Domain.Models;
using SistemaPessoal.Services.Implementations;
using SistemaPessoal.Services.Interfaces;

namespace SistemaPessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IEventoService _service;

        public EventoController()
        {
            _service = new EventoService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventoModel>> Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public EventoModel Post([FromBody] EventoModel Model)
        {
            return _service.Save(Model);
        }

        [HttpPut("{id}")]
        public EventoModel Put(int id, [FromBody] EventoModel Model)
        {
            return _service.Update(Model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
