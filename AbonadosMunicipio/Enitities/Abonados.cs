namespace AbonadosMunicipio.Enitities
{
    public class Abonados
    {
        public int Id { get; set; }
        public string ? NombreCompleto { get; set; }
        public string? Direccion { get; set; }
        public string? NumeroMedidor { get; set; }
        public int ConsumoMensual { get; set; }
        public int TipoServicioId { get; set; }
    }
}
