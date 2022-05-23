using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class TipoCombustible
    {
        public int Id { get; set; }
        [Required]
        public string? Descripcion { get; set; } 
        public bool Estado { get; set; }  

    }
}
