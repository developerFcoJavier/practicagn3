using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace PracticaGN3.Services
{
    public class Converter
    {
        public async Task<StringBuilder> Main(object objeto)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var property in objeto.GetType().GetProperties())
            {
                string propertyName = property.Name;
                string propertyValue = property.GetValue(objeto)?.ToString(); // Obtener el valor de la propiedad como string

                sb.AppendFormat("\"@{0}\", \"{1}\"", char.ToUpper(propertyName[0]) + propertyName.Substring(1), propertyValue);
            }

            return sb;
        }
    }
}
