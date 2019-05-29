using System.Data;

namespace SistemaPessoal.Helpers.Exceptions
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