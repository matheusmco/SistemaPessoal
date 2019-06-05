using System.Collections.Generic;
using System.Linq;
using SistemaPessoal.Data.Interfaces;
using SistemaPessoal.Domain.Entities;
using SistemaPessoal.Domain.Models;
using SistemaPessoal.Services.Interfaces;

namespace SistemaPessoal.Services.Implementations
{
    class EventoService : IEventoService
    {
        private EventoEntity _entity;

        public EventoService(EventoEntity entity)
        {
            _entity = entity;
        }

        public void Delete(int id)
        {
            _entity.Delete(id);
        }

        public IEnumerable<EventoModel> GetAll()
        {
            return _entity.GetAll().Select(x => new EventoModel(x));
        }

        public EventoModel GetById(int id)
        {
            return new EventoModel(_entity.GetById(id));
        }

        public EventoModel Save(EventoModel Evento)
        {
            _entity.FillData(Evento);
            var id = _entity.Save();
            return new EventoModel(_entity.GetById(id));
        }

        public EventoModel Update(EventoModel Evento)
        {
            _entity.FillData(Evento);
            var id = _entity.Update();
            return new EventoModel(_entity.GetById(id));
        }
    }
}