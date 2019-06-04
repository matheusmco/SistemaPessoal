using System.Collections.Generic;
using SistemaPessoal.Domain.Models;

namespace SistemaPessoal.Services.Interfaces
{
    public interface IEventoService
    {
        EventoModel Save(EventoModel Evento);
        EventoModel Update(EventoModel Evento);
        IEnumerable<EventoModel> GetAll();
        EventoModel GetById(int id);
        void Delete(int id);
    }
}