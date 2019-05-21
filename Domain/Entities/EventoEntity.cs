using System;
using SistemaPessoal.Data.Interfaces;
using SistemaPessoal.Domain.Models;

namespace SistemaPessoal.Domain.Entities
{
    class EventoEntity : BaseEntity
    {
        private readonly IEventoRepository _repository;

        private string descricao;
        private DateTime? dataHora;
        private string localizacao;
        private string notasGerais;
        
        public string Descricao => descricao;
        private void SetDescricao(string descricao) => this.descricao = descricao;

        public DateTime? DataHora => dataHora;
        private void SetDataHora(DateTime? dataHora) => this.dataHora = dataHora;

        public string Localizacao => localizacao;
        private void SetLocalizacao(string localizacao) => this.localizacao = localizacao;

        public string NotasGerais => notasGerais;
        private void SetNotasGerais(string notasGerais) => this.notasGerais = notasGerais;

        public EventoEntity(IEventoRepository repository) : base(0)
        {
            _repository = repository;
        }

        public EventoEntity(IEventoRepository repository, EventoModel Model) : base(Model.EventoId)
        {
            _repository = repository;

            descricao = Model.Descricao;
            dataHora = Model.DataHora;
            localizacao = Model.Localizacao;
            notasGerais = Model.NotasGerais;
        }

        public int Save()
        {
            this.Id = _repository.Save(this);
            return this.Id;
        }
    }
}