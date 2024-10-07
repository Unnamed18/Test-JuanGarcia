using Acudir.Test.Apis.Models;

namespace NombreDelProyecto.Interfaces
{
    public interface IPersonaRepository
    {
        List<Persona> GetAll(string nombre = null, int? edad = null);
        void Add(Persona nuevaPersona);
        void Update(Persona personaModificada);
    } 
}