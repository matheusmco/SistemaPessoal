using System.Collections.Generic;
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
        private IEventoRepository _repository;
        private EventoEntity _entity;

        public EventoController()
        {
            _repository = new EventoRepository();
            _entity = new EventoEntity(_repository);
            _service = new EventoService(_entity);
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
