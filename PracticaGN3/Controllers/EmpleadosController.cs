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
    public class EmpleadosController : ControllerBase
    {
        private readonly IRepository repositorio;

        public EmpleadosController(IRepository repositorio)
        {
            this.repositorio = repositorio;
        }
        // GET: api/<EmpleadosController>
        [HttpGet]
        public IActionResult Get()
        {
            DataTable dataTable = repositorio.EjecutarConsulta("LeerEmpleados");
            return Ok(dataTable);
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empleados value)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter claveDepartamentoParametro = new SqlParameter("@ClaveEmpleado", SqlDbType.Int);
            claveDepartamentoParametro.Value = value.ClaveEmpleado;
            parametros.Add(claveDepartamentoParametro);

            SqlParameter nombreParametro = new SqlParameter("@Nombre", SqlDbType.VarChar);
            nombreParametro.Value = value.Nombre;
            parametros.Add(nombreParametro);

            SqlParameter fechaIngresoParametro = new SqlParameter("@FechaIngreso", SqlDbType.DateTime);
            fechaIngresoParametro.Value =value.FechaIngreso;
            parametros.Add(fechaIngresoParametro);

            SqlParameter fechaNacimientoParametro = new SqlParameter("@FechaNacimiento", SqlDbType.DateTime);
            fechaNacimientoParametro.Value = value.FechaNacimiento;
            parametros.Add(fechaNacimientoParametro);

            SqlParameter departamentoID = new SqlParameter("@DepartamentoID", SqlDbType.Int);
            departamentoID.Value = value.DepartamentoID;
            parametros.Add(departamentoID);

            SqlParameter[] arregloParametros = parametros.ToArray();
            repositorio.EjecutarNonQuery("CrearEmpleado", arregloParametros);

            var respuesta = new { mensaje = "Operación exitosa" };
            return Ok(respuesta);
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empleados value)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter claveDepartamentoParametro = new SqlParameter("@ClaveEmpleado", SqlDbType.Int);
            claveDepartamentoParametro.Value = id;
            parametros.Add(claveDepartamentoParametro);

            SqlParameter nombreParametro = new SqlParameter("@Nombre", SqlDbType.VarChar);
            nombreParametro.Value = value.Nombre;
            parametros.Add(nombreParametro);

            SqlParameter fechaIngresoParametro = new SqlParameter("@FechaIngreso", SqlDbType.DateTime);
            fechaIngresoParametro.Value = value.FechaIngreso;
            parametros.Add(fechaIngresoParametro);

            SqlParameter fechaNacimientoParametro = new SqlParameter("@FechaNacimiento", SqlDbType.DateTime);
            fechaNacimientoParametro.Value = value.FechaNacimiento;
            parametros.Add(fechaNacimientoParametro);

            SqlParameter departamentoID = new SqlParameter("@DepartamentoID", SqlDbType.Int);
            departamentoID.Value = value.DepartamentoID;
            parametros.Add(departamentoID);

            SqlParameter[] arregloParametros = parametros.ToArray();
            repositorio.EjecutarNonQuery("ActualizarEmpleado", arregloParametros);

            var respuesta = new { mensaje = "Operación exitosa" };
            return Ok(respuesta);
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter claveDepartamentoParametro = new SqlParameter("@ClaveEmpleado", SqlDbType.Int);
            claveDepartamentoParametro.Value = id;
            parametros.Add(claveDepartamentoParametro);

            SqlParameter[] arregloParametros = parametros.ToArray();
            repositorio.EjecutarNonQuery("EliminarEmpleado", arregloParametros);

            var respuesta = new { mensaje = "Operación exitosa" };
            return Ok(respuesta);
        }
    }
}
