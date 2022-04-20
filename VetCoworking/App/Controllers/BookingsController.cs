using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetCoworking.App.Model;
using VetCoworking.Domain.Abstractions;
using VetCoworking.Domain.Models;

namespace VetCoworking.App.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    [PrimaryConstructor]
    public partial class BookingsController : ControllerBase
    {
        private readonly IBookingsRepository IBookingsRepository;


        /// <summary>
        /// Inserta reserva 
        /// </summary>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        
        public async Task<IActionResult> InsertBooking([FromBody] BookingModel book, CancellationToken ct)
        {
            var booking = new Booking {
                Id = new Guid(),
                PatientName = book.PatientName,
                Start = book.Start,
                End = book.End
            };
            await IBookingsRepository.AddAsync(booking);
            return Accepted();
        }

        /// <summary>
        /// Borra una reserva 
        /// </summary>
        [HttpPost]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public async Task<IActionResult> DeleteBooking([FromRoute] Guid id, CancellationToken ct)
        {
            var booking = new Booking
            {
                Id = id
            };
            await IBookingsRepository.DeleteAsync(booking);
            return Accepted();
        }
        /// <summary>
        /// Actualiza una reserva
        /// </summary>
        [HttpPost]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public async Task<IActionResult> UpdateBooking([FromBody] BookingModel book, [FromRoute] Guid id, CancellationToken ct)
        {
            var booking = new Booking
            {
                Id = id,
                PatientName = book.PatientName,
                Start = book.Start,
                End = book.End
            };
            await IBookingsRepository.UpdateAsync(booking);
            return Accepted();
        }

        /// <summary>
        /// Obtiene una reserva
        /// </summary>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {

            var booking = await IBookingsRepository.GetByIdAsync(id);
            return Content(JsonSerializer.Serialize(booking));
        }

        /// <summary>
        /// Obtiene todas las reservas
        /// </summary>
        [HttpGet]
        [Route("get/all")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
                
            var bookings = await IBookingsRepository.ListAllAsync();
            return Content(JsonSerializer.Serialize(bookings));
        }

    }
}



