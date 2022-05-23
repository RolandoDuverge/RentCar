namespace RentCar.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string NumeroTarjetaCredito { get; set; }
        public int LimiteCredito { get; set; }  
        public string TipoPersona { get; set; }
        public bool Estado { get; set; }

    }
}
