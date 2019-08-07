using Avanade.HackathonAzul.AzulServicesDirtyTests.Integration.Navitaire;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.SeatMap.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Response.Booking;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Business.Navitaire
{
    public class SeatBusiness
    {
        private string _token;
        private NavitaireGraphQLIntegration _integrationGraphQL;
        private NavitaireRestIntegration _integrationRest;

        public SeatBusiness(string token)
        {
            _token = token;
            _integrationGraphQL = new NavitaireGraphQLIntegration(_token);
            _integrationRest = new NavitaireRestIntegration();
        }

        public async Task<List<SeatMapResponse>> GetSeatMapAvailabilityBySegmentKey(string segmentKey)
        {
            List<SeatMapResponse> result = await _integrationGraphQL.GetSeatMapAvailabilityBySegmentKey(segmentKey);

            return result;
        }

        public List<Unit> GetAvailabilitySeat(List<SeatMapResponse> seatMapResponseList)
        {
            List<Unit> units = null;

            units = (from seatMapResponse in seatMapResponseList
                     from deck in seatMapResponse.SeatMap.Decks
                     from compartment in deck.Value.Compartments
                     from unit in compartment.Value.Units
                     where unit.Type == "NormalSeat" && unit.Assignable && unit.Availability == "Open"
                     select unit).ToList();

            return units;
        }

        public async Task AssingnmentSeat(string passengerKey, string unitKey)
        {
            var request = GetRequestDefaultAssingmentSeat();
            var result = await _integrationRest.RequestAsync(HttpMethod.Post, $"/api/nsk/v1/booking/passengers/{passengerKey}/seats/{unitKey}", request, _token);

            Console.Write(result);
        }

        public async Task<bool> UnassignPassengerSegmentSeat(string passengerKey, string seatKey)
        {
            bool result = default(bool);

            result = await _integrationGraphQL.UnassignPassengerSegmentSeat(passengerKey, seatKey);
            return result;
        }

        public bool ThereIsSeatReservedFirstPassenger(BookingResponse booking)
        {
            return (booking.Journeys[0]?.Segments[0]?.PassengersSegment[0].Value?.Seats.Any() == true);
        }

        private object GetRequestDefaultAssingmentSeat()
        {
            var request = new
            {
                collectedCurrencyCode = "BRL",
                waiveFee = true,
                inventoryControl = "Session",
                ignoreSeatSsrs = true
            };
            return request;
        }
    }
}
