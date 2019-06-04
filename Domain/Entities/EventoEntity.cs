using System;
using System.Collections.Generic;
using System.Linq;
using SistemaPessoal.Data.Interfaces;
using SistemaPessoal.Domain.Models;
using SistemaPessoal.Helpers.Exceptions;
using SistemaPessoal.Helpers.Extensions;

namespace SistemaPessoal.Domain.Entities
{
    public class EventoEntity
    {
        private readonly IEventoRepository _repository;

        private int id;
        private string descricao;
        private DateTime? dataHora;
        private string localizacao;
        private string notasGerais;

        public int Id => id;
        private void SetId(int id) => this.id = id;

        public string Descricao => descricao;
        private void SetDescricao(string descricao) => this.descricao = descricao;

        public DateTime? DataHora => dataHora;
        private void SetDataHora(DateTime? dataHora) => this.dataHora = dataHora;

        public string Localizacao => localizacao;
        private void SetLocalizacao(string localizacao) => this.localizacao = localizacao;

        public string NotasGerais => notasGerais;
        private void SetNotasGerais(string notasGerais) => this.notasGerais = notasGerais;

        public EventoEntity(IEventoRepository repository)
        
        {
            _repository = repository;
        }

        public EventoEntity(IEventoRepository repository, EventoModel Model)
        {
            _repository = repository;

            descricao = Model.Descricao;
            dataHora = Model.DataHora;
            localizacao = Model.Localizacao;
            notasGerais = Model.NotasGerais;
        }

        public int Save()
        {
            var id = _repository.Save(this);

            SetId(id);

            return Id;
        }

        public int Update()
        {
            var id = _repository.Update(this);

            SetId(id);

            return Id;
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
                throw new DatabaseNotFoundException("Não foi encontrado nenhum evento com esse Id");
            }

            return Entity;
        }

        public IEnumerable<EventoEntity> GetAll()
        {
            var lista = _repository.GetAll();

            if(lista.Count() == 0)
            {
                throw new DatabaseNotFoundException("Não foi encontrado nenhum evento");
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