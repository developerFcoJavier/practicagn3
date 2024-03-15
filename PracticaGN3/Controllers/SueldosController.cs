using Microsoft.AspNetCore.Mvc;
using PracticaGN3.Models;
using PracticaGN3.Services;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaGN3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SueldosController : ControllerBase
    {
        private readonly IRepository repositorio;

        public SueldosController(IRepository repositorio)
        {
            this.repositorio = repositorio;
        }
        // GET: api/<Sueldos>
        [HttpGet]
        public IActionResult Get()
        {
            DataTable dataTable = repositorio.EjecutarConsulta("LeerSueldos");
            return Ok(dataTable);
        }

        // GET api/<Sueldos>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Sueldos>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sueldos value)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter claveDepartamentoParametro = new SqlParameter("@EmpleadoID", SqlDbType.Int);
            claveDepartamentoParametro.Value = value.EmpleadoID;
            parametros.Add(claveDepartamentoParametro);

            SqlParameter sueldoParametro = new SqlParameter("@SueldoMensual", SqlDbType.Decimal);
            sueldoParametro.Value = decimal.Parse(value.SueldoMensual.ToString());
            parametros.Add(sueldoParametro);

            SqlParameter formaPagoParametro = new SqlParameter("@FormaPago", SqlDbType.VarChar);
            formaPagoParametro.Value = value.FormaPago;
            parametros.Add(formaPagoParametro);

            SqlParameter[] arregloParametros = parametros.ToArray();
            repositorio.EjecutarNonQuery("CrearSueldo", arregloParametros);

            var respuesta = new { mensaje = "Operación exitosa" };
            return Ok(respuesta);
        }

        // PUT api/<Sueldos>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sueldos value)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter claveDepartamentoParametro = new SqlParameter("@EmpleadoID", SqlDbType.Int);
            claveDepartamentoParametro.Value = id;
            parametros.Add(claveDepartamentoParametro);

            SqlParameter sueldoParametro = new SqlParameter("@SueldoMensual", SqlDbType.Decimal);
            sueldoParametro.Value = decimal.Parse(value.SueldoMensual.ToString());
            parametros.Add(sueldoParametro);

            SqlParameter formaPagoParametro = new SqlParameter("@FormaPago", SqlDbType.VarChar);
            formaPagoParametro.Value = value.FormaPago;
            parametros.Add(formaPagoParametro);

            SqlParameter[] arregloParametros = parametros.ToArray();
            repositorio.EjecutarNonQuery("ActualizarSueldo", arregloParametros);

            var respuesta = new { mensaje = "Operación exitosa" };
            return Ok(respuesta);
        }

        // DELETE api/<Sueldos>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter claveDepartamentoParametro = new SqlParameter("@ClaveDepartamento", SqlDbType.Int);
            claveDepartamentoParametro.Value = id;
            parametros.Add(claveDepartamentoParametro);

            SqlParameter[] arregloParametros = parametros.ToArray();
            repositorio.EjecutarNonQuery("EliminarSueldo", arregloParametros);

            var respuesta = new { mensaje = "Operación exitosa" };
            return Ok(respuesta);
        }
    }
}
