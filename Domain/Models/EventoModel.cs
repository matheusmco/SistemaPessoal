using System;
using SistemaPessoal.Domain.Entities;

namespace SistemaPessoal.Domain.Models
{
    public class EventoModel
    {
        public int EventoId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public string Localizacao { get; set; }
        public string NotasGerais { get; set; }

        public EventoModel()
        {

        }

        public EventoModel(EventoEntity Entidade)
        {
            if (Entidade == null)
            {
                throw new ArgumentException("Entidade de evento nula no construtor do Model", nameof(Entidade));
            }

            EventoId = Entidade.Id;
            Descricao = Entidade.Descricao;
            DataHora = Entidade.DataHora;
            Localizacao = Entidade.Localizacao;
            NotasGerais = Entidade.NotasGerais;
        }
    }
}