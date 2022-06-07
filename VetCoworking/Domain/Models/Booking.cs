namespace VetCoworking.Domain.Models
{
    /// <summary>
    /// Modelo usado como entidad en el patrón de repositorio
    /// </summary>
    public partial class Booking
    {
        //Id unico en db
        public Guid Id { get; set; }

        // Nombre del paciente 
        public string PatientName { get; set; }

        //Fecha de inicio del booking
        public DateTime Start { get; set; }

        //Fecha de terminación del booking
        public DateTime End { get; set; }
    }
}
