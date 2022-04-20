using VetCoworking.Domain.Abstractions;
using VetCoworking.Domain.Models;
using VetCoworking.Persistence.Repositories.Common;

namespace AQ.Core.Persistence.Repositories
{
    public class BookingsRepository : EFRepository<Booking, VetCoworkingContext>, IBookingsRepository
    {
        public BookingsRepository(VetCoworkingContext dbContext)
            : base(dbContext)
        {
        }
    }
}



