using System;

namespace SistemaPessoal.Domain.Entities
{
    class EventoEntity
    {
        public int EventoId { get; }
        public string Descricao { get; }
        public DateTime? DataHora { get; }
        public string Localizacao { get; }
        public string NotasGerais { get; }
    }
}