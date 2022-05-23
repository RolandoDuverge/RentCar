namespace RentCar.Models
{
    public class Vehiculo
    {
        public int Id { get; set; } 
        public string Descripcion { get; set; }
        public string NoChasis { get; set; }
        public string NoMotor { get; set; }
        public string NoPlaca { get; set; }
        public int TipoVehiculoId { get; set; }
        public int MarcaVehiculoId { get;  set; }
        public int TipoCombustibleId { get; set; }
        public bool Estado { get; set; }


    }
}
