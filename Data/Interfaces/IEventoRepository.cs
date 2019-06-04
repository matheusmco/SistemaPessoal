using System.Collections.Generic;
using SistemaPessoal.Domain.Entities;

namespace SistemaPessoal.Data.Interfaces
{
    public interface IEventoRepository
    {
        int Save(EventoEntity Model);
        int Update(EventoEntity Model);
        EventoEntity GetById(int id);
        IEnumerable<EventoEntity> GetAll();
        void Delete(int id);
    }
}