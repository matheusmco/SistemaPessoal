using System.Collections.Generic;

namespace SistemaPessoal.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected virtual int Id { get; set; }

        public BaseEntity(int id)
        {
            Id = id;
        }

        public virtual int Save(BaseEntity Entidade)
        {
            return default(int);
        }

        public virtual int Update(BaseEntity Entidade)
        {
            return default(int);
        }

        public virtual BaseEntity GetById(int id)
        {
            return default(BaseEntity);
        }

        public virtual IEnumerable<BaseEntity> GetAll()
        {
            return null;
        }

        public virtual void Delete(int id)
        {
            
        }
    }
}