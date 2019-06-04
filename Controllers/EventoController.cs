using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaPessoal.Data.Implementations;
using SistemaPessoal.Data.Interfaces;
using SistemaPessoal.Domain.Entities;

namespace SistemaPessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private BaseEntity _entidade;
        private IEventoRepository _repository;

        public EventoController()
        {
            _repository = new EventoRepository();
            _entidade = new EventoEntity(_repository);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BaseEntity>> Get()
        {
            return Ok(_entidade.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_entidade.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] BaseEntity Entidade)
        {
            _entidade.Save(Entidade);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BaseEntity Entidade)
        {
            _entidade.Update(Entidade);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _entidade.Delete(id);
        }
    }
}
