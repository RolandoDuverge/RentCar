namespace RentCar.Models
{
    public class InspeccionCarro
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public int ClienteId { get; set; }
        public bool Rallado { get; set; }
        public int CantCombustible { get; set; }
        public bool GomaRepuesto { get; set; }
        public bool Gato { get; set; }
        public bool CristalRoto { get; set; }
        public bool GomaFrontLeft { get; set; }
        public bool GomaFrontRight { get; set; }
        public bool GomaBackLeft { get; set; }
        public bool GomaBackRight { get; set; }
        public string Comentario { get; set; }
        public int EmpleadoId { get; set; }
        public bool Estado { get; set; }
    }
}
