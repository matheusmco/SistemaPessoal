using System.Data;

namespace SistemaPessoal.Data.Interfaces
{
    class DatabaseNotFoundException : DataException
    {
        public DatabaseNotFoundException()
        {

        }

        public DatabaseNotFoundException(string message = "Nenhum registro encontrado") : base(message)
        {
            
        }
    }
}