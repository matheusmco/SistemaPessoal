using System;
using System.Collections.Generic;
using System.Linq;
using SistemaPessoal.Data.Interfaces;
using SistemaPessoal.Domain.Models;
using SistemaPessoal.Helpers.Extensions;

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

        public int Update()
        {
            this.Id = _repository.Update(this);
            return this.Id;
        }

        public EventoEntity GetById(int id)
        {
            if (id.IsZeroOrNull())
            {
                throw new ArgumentException($"Parâmetro {nameof(id)} não pode ser zero ou nulo", nameof(id));
            }

            var Entity = _repository.GetById(id);

            if (Entity == null)
            {
                throw new ApplicationException("Não foi encontrado nenhum evento com esse Id");
                // TODO: change to DatabaseNotFoundException
            }

            return Entity;
        }

        public IEnumerable<EventoEntity> GetAll()
        {
            var lista = _repository.GetAll();

            if(lista.Count() == 0)
            {
                throw new ApplicationException("Não foi encontrado nenhum evento");
                // TODO: change to DatabaseNotFoundException
            }

            return lista;
        }

        public void Delete(int id)
        {
            if (id.IsZeroOrNull())
            {
                throw new ArgumentException($"Parâmetro {nameof(id)} não pode ser zero ou nulo", nameof(id));
            }

            _repository.Delete(id);
        }
    }
}