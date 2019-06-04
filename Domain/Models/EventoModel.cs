using System;

namespace SistemaPessoal.Domain.Models
{
    public class EventoModel
    {
        public int EventoId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public string Localizacao { get; set; }
        public string NotasGerais { get; set; }
    }
}