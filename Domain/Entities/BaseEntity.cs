namespace SistemaPessoal.Domain.Entities
{
    abstract class BaseEntity
    {
        protected virtual int Id { get; set; }

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}