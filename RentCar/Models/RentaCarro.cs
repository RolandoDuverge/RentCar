namespace RentCar.Models
{
    public class RentaCarro
    {
        public int Id { get; set; } 
        public int EmpleadosId { get; set; }
        public int VehiculoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public float MontoDia { get; set; }
        public int TotalDias {  get; set; }
        public string Comentario { get; set; }
        public bool Estado { get; set; }

    }
}
