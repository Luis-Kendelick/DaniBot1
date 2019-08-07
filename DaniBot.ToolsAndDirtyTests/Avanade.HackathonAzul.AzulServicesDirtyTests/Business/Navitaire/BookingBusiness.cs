using Avanade.HackathonAzul.AzulServicesDirtyTests.Integration.Navitaire;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.GetBookingByCustomerNumber.Response;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Response.Booking;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Booking.Response;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Business.Navitaire
{
    public class BookingBusiness
    {
        private NavitaireGraphQLIntegration _integration;

        public BookingBusiness(string token)
        {
            _integration = new NavitaireGraphQLIntegration(token);
        }

        public async Task<BookingResponse> ReatriveBooking(string recordLocator)
        {
            BookingResponse booking = await _integration.GetBooking(recordLocator);

            return booking;
        }

        public async Task<IEnumerable<GetBookengByCustomerNumberResponse>> GetBookingsByCustomerNumber(string customerNumber)
        {
            IEnumerable<GetBookengByCustomerNumberResponse> result = await _integration.GetBookingsByCustomerNumber(customerNumber);

            return result.Where(b => !string.IsNullOrEmpty(b.Origin) && !string.IsNullOrEmpty(b.Destination));
        }

        public async Task<bool> ResetBooking()
        {
            bool result = await _integration.ResetBooking();

            return result;
        }

        public async Task<BookingCommitResponse> CommitBooking()
        {
            return await _integration.CommitBooking();
        }

    }
}
