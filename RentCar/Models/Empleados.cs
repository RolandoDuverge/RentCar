namespace RentCar.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }  
        public string Tanda { get; set; }
        public int Comision { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

    }
}
