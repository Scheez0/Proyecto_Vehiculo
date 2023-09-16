using Proyecto_Vehiculo.Entities;

namespace Proyecto_Vehiculo.Services
{
    public interface IVehiculoService
    {
        Task Insert(Vehiculo entity);
        bool IsColorValid(string MayuscColor);
        bool IsPatenteValid(string patente);
        Task<bool> PatenteExist(string patente);
    }
}
