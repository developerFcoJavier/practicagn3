namespace PracticaGN3.Models
{
    public class Empleados
    {
        public int ClaveEmpleado { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public DateTime FechaNacimiento { get; set; }
        public int DepartamentoID { get; set; }
    }
}
