using VetCoworking.Domain.Abstractions;
using VetCoworking.Domain.Models;
using VetCoworking.Persistence;
using VetCoworking.Persistence.Repositories.Common;

namespace VetCoworking.Repositories
{
    public class BookingsRepository : EFRepository<Booking, VetCoworkingContext>, IBookingsRepository
    {
        public BookingsRepository(VetCoworkingContext dbContext)
            : base(dbContext)
        {
        }
    }
}



