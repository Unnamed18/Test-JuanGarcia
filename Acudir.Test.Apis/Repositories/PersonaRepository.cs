using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Acudir.Test.Apis.Models;
using NombreDelProyecto.Interfaces;

namespace Acudir.Test.Apis.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly string _filePath = "Data/Test.json"; // Ruta del archivo JSON

        // Método para obtener todas las personas, con posibilidad de filtrar por nombre y edad 
        public List<Persona> GetAll(string nombre = null, int? edad = null)  
        {
            var personas = LeerJson();

            // Validar si hay personas en la lista antes de filtrar
            if (personas == null || !personas.Any())
            {
                return new List<Persona>();
            }

            // Filtrar por nombre si no es nulo
            if (!string.IsNullOrEmpty(nombre))
            {
                personas = personas.Where(p => p.Nombre != null && p.Nombre.Contains(nombre)).ToList();
            }

            // Filtrar por edad si no es nula
            if (edad.HasValue)
            {
                personas = personas.Where(p => p.Edad == edad).ToList();
            }

            return personas;
        }

        // Método para agregar una nueva persona
        public void Add(Persona nuevaPersona)
        {
            var personas = LeerJson();

            if (nuevaPersona != null && !string.IsNullOrEmpty(nuevaPersona.Nombre))
            {
                personas.Add(nuevaPersona);
                EscribirJson(personas);
            }
        }

        // Método para actualizar una persona existente
        public void Update(Persona personaModificada)
        {
            var personas = LeerJson();
            var persona = personas.FirstOrDefault(p => p.Nombre == personaModificada.Nombre);

            if (persona != null)
            {
                persona.Edad = personaModificada.Edad;
                persona.Direccion = personaModificada.Direccion;
                EscribirJson(personas);
            }
        }

        // Método para leer los datos del archivo JSON
        private List<Persona> LeerJson()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Persona>(); // Retorna una lista vacía si no existe el archivo
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Persona>>(json);
        }

        // Método para escribir los datos en el archivo JSON
        private void EscribirJson(List<Persona> personas)
        {
            var json = JsonConvert.SerializeObject(personas, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
