using System.Data;
using System.Data.SqlClient;

namespace PracticaGN3.Services
{
    public interface IRepository
    {
        public DataTable EjecutarConsulta(string nombreProcedimiento, SqlParameter[] parametros = null);
        public void EjecutarNonQuery(string nombreProcedimiento, SqlParameter[] parametros);
    }
}
