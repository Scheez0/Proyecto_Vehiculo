using System.ComponentModel.DataAnnotations;

namespace Proyecto_Vehiculo.DTO.VehiculoDTO
{
    public class VehiculoCreateDTO
    {
        [Required(ErrorMessage = "Campo Patente Requerido")]
        public string Patente { get; set; }

        [Required(ErrorMessage = "Campo MarcaId Requerido")]
        public int MarcaId { get; set; }

        public int ModeloId { get; set; }
        public string? Color { get; set; }

        [Required(ErrorMessage = "Campo CarroceriaId Requerido")]
        public int CarroceriaId { get; set; }
    }
}
