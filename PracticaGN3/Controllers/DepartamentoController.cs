using Microsoft.AspNetCore.Mvc;
using PracticaGN3.Models;
using PracticaGN3.Services;
using System.Data;
using System.Data.SqlClient;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaGN3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IRepository repositorio;

        public DepartamentoController(IRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: api/<DepartamentoController>
        [HttpGet]
        public IActionResult Get()
        {
            DataTable dataTable = repositorio.EjecutarConsulta("LeerDepartamentos");
            return Ok(dataTable);
        }  

        // GET api/<DepartamentoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Departamentos value)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter claveDepartamentoParametro = new SqlParameter("@ClaveDepartamento", SqlDbType.Int);
            claveDepartamentoParametro.Value = value.ClaveDepartamento;
            parametros.Add(claveDepartamentoParametro);

            SqlParameter descripcionParametro = new SqlParameter("@Descripcion", SqlDbType.VarChar);
            descripcionParametro.Value = value.Descripcion;

            parametros.Add(descripcionParametro);

            SqlParameter[] arregloParametros = parametros.ToArray();
            repositorio.EjecutarNonQuery("CrearDepartamento",arregloParametros);

            var respuesta = new { mensaje = "Operación exitosa" };
            return Ok(respuesta);
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
