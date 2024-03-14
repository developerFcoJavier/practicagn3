using System.Data;
using System.Data.SqlClient;

namespace PracticaGN3.Services
{
    public class Repository : IRepository
    {
        private readonly string _connection_str;

        public Repository(IConfiguration configuration)
        {
            _connection_str = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable EjecutarConsulta(string nombreProcedimiento, SqlParameter[] parametros = null)
        {
            using (SqlConnection connection = new SqlConnection(_connection_str))
            {
                using (SqlCommand command = new SqlCommand(nombreProcedimiento, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parametros != null)
                        {
                            command.Parameters.AddRange(parametros);
                        }

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                    
                }
            }
        }

        public void EjecutarNonQuery(string nombreProcedimiento, SqlParameter[] parametros)
        {
            using (SqlConnection connection = new SqlConnection(_connection_str))
            {
                using (SqlCommand command = new SqlCommand(nombreProcedimiento, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parametros != null)
                        {
                            command.Parameters.AddRange(parametros);
                        }

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch(Exception ex) {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }
    }
}
