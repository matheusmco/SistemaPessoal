using System.Collections.Generic;
using Dapper;
using SistemaPessoal.Data.Interfaces;
using SistemaPessoal.Domain.Entities;

namespace SistemaPessoal.Data.Implementations
{
    class IEventoRepository : RepositoryBase, SistemaPessoal.Data.Interfaces.IEventoRepository
    {
        public void Delete(int id)
        {
            using (var db = Connection)
            {
                db.Execute("delete from evento where evento_id = @id", new { id });
            }
        }

        public IEnumerable<EventoEntity> GetAll()
        {
            using (var db = Connection)
            {
                return db.Query<EventoEntity>(@"
                    select
                        Descricao,
                        DataHora,
                        Localizacao,
                        NotasGerais
                    from evento");
            }
        }

        public EventoEntity GetById(int id)
        {
            using (var db = Connection)
            {
                return db.QueryFirstOrDefault<EventoEntity>(@"
                    select
                        descricao as Descricao,
                        dataHora as DataHora,
                        localizacao as Localizacao,
                        notasGerais as NotasGerais
                    from evento
                    where evento_id = @id", new { id });
            }
        }

        public int Save(EventoEntity Entity)
        {
            using (var db = Connection)
            {
                return db.QueryFirstOrDefault<int>(@"
                    insert into evento (descricao, dataHora, localizacao, notasGerais) values (@descricao, @dataHora, @localizacao, @notasGerais);
                    select last_insert_rowid();",
                    new
                    {
                        descricao = Entity.Descricao,
                        dataHora = Entity.DataHora,
                        localizacao = Entity.Localizacao,
                        notasGerais = Entity.NotasGerais
                    }
                );
            }
        }

        public int Update(EventoEntity Entity)
        {
            using (var db = Connection)
            {
                db.Execute(@"
                    update evento set descricao = @descricao, dataHora = @dataHora, localizacao = @localizacao, notasGerais = @notasGerais where evento_id = @id",
                    new
                    {
                        descricao = Entity.Descricao,
                        dataHora = Entity.DataHora,
                        localizacao = Entity.Localizacao,
                        notasGerais = Entity.NotasGerais,
                        id = Entity.GetId
                    }
                );

                return Entity.GetId;
            }
        }
    }
}