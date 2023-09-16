namespace Proyecto_Vehiculo.Services
{
    public interface IBusinessService
    {
        bool IsColorValid(string MayuscColor);
        bool IsPatenteValid(string patente);    
    }
}
