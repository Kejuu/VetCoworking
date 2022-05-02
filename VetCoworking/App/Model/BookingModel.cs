using System;

namespace VetCoworking.App.Model
{
    /// <summary>
    /// Modelo de booking par usar en el controlador
    /// </summary>
    public class BookingModel
    {
        public string PatientName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
