
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Booking.Response;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.GetBookingByCustomerNumber.Response;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Response.Booking;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.SeatMap.Response;
using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Integration.Navitaire
{
    class NavitaireGraphQLIntegration
    {
        private readonly string _url = "https://adtestr3xdotrezapi.navitaire.com/api/v1/Graph";

        private GraphQL.Client.GraphQLClient _client;

        public NavitaireGraphQLIntegration(string token)
        {
            _client = new GraphQL.Client.GraphQLClient(_url);
            _client.DefaultRequestHeaders.Add("Authorization", token);
        }

        public async Task<IEnumerable<GetBookengByCustomerNumberResponse>> GetBookingsByCustomerNumber(string customerNumber)
        {
            var query = new GraphQLRequest
            {
                Query = $@"query searchByCustomerNumber 
                            {{searchByCustomerNumber(request: 
                                {{ customerNumber: ""{customerNumber}"" }}) 
                            {{ recordLocator,
                               origin,
                               destination
                            }}}}",
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<IEnumerable<GetBookengByCustomerNumberResponse>>("searchByCustomerNumber");
        }

        public async Task<BookingResponse> GetBooking(string recordLocator)
        {
            var query = new GraphQLRequest
            {
                Query = $@"mutation getBooking {{ bookingRetrieveByRecordLocator (
                recordLocator:""{ recordLocator }"") {{
                    bookingKey
                    recordLocator
                    currencyCode
                    contacts{{
                      key
                      value{{
                        customerNumber
                      }}
                    }}
                    typeOfSale {{
                        residentCountry
                    }}
                    info {{
                        status
                        priceStatus
                        bookedDate
                        createdDate
                        expirationDate
                    }}
                    payments {{
                        paymentKey
                        code
                        approvalDate
                        authorizationStatus
                        amounts {{
                            amount
                            currencyCode
                        }}
                    }}
                    breakdown {{
                        balanceDue
                        pointsBalanceDue
                        authorizedBalanceDue
                        totalAmount
                        journeyTotals {{
                            totalAmount
                            totalDiscount
                            totalPoints
                            totalTax
                        }}
                        passengerTotals {{
                            convenience {{
                                adjustments
                                taxes
                                total
                            }}
                            infant {{
                                adjustments
                                taxes
                                total
                            }}
                            nameChanges {{
                                adjustments
                                taxes
                                total
                            }}
                            seats {{
                                adjustments
                                taxes
                                total
                            }}
                            services {{
                                adjustments
                                taxes
                                total
                            }}
                            specialServices {{
                                adjustments
                                taxes
                                total
                            }}
                            spoilage {{
                                adjustments
                                taxes
                                total
                            }}
                            upgrades {{
                                adjustments
                                taxes
                                total
                            }}
                        }}
                        passengers {{
                            key
                            value {{
                                passengerKey
                                convenience {{
                                    adjustments
                                    taxes
                                    total
                                }}
                                infant {{
                                    adjustments
                                    taxes
                                    total
                                }}
                                nameChanges {{
                                    adjustments
                                    taxes
                                    total
                                }}
                                passengerKey
                                seats {{
                                    adjustments
                                    taxes
                                    total
                                }}
                                services {{
                                    adjustments
                                    taxes
                                    total
                                }}
                                specialServices {{
                                    adjustments
                                    taxes
                                    total
                                }}
                                spoilage {{
                                    adjustments
                                    taxes
                                    total
                                }}
                                upgrades {{
                                    adjustments
                                    taxes
                                    total
                                }}
                            }}
                        }}
                    }}
                    passengers {{
                        key
                        value {{
                            passengerKey
                            passengerTypeCode
                            program {{
							    code
							    levelCode
							    number
							}}
                            name {{
                                first
                                last
                                middle
                                suffix
                                title
                            }}
                            info{{
                                dateOfBirth
                            }}
                            infant{{
                                dateOfBirth
                            }}
                            fees {{
                              code
                              flightReference
                              serviceCharges {{
                                amount
                                currencyCode
                                type
                              }}
                            }}
                        }}
                    }}
                    journeys {{
                        journeyKey
						flightType
                        designator {{
                            departureStation: origin
                            arrivalStation: destination
                            std: departure
                            sta: arrival
                        }}
                        stops
                        segments {{
                            segmentKey
                            international
                            identifier {{
								carrierCode
                                identifier
								opSuffix
                            }}
                            passengerSegment {{
	                            key
	                            value {{
		                            liftStatus
		                            passengerKey
		                            bags {{
			                            baggageKey
			                            osTag
		                            }}
		                            ssrs {{
			                            count
			                            ssrCode
			                            ssrKey
										passengerKey
										ssrDetail
		                            }}
		                            seats {{
			                            unitDesignator
			                            compartmentDesignator
                                        arrivalStation
                                        departureStation
                                        passengerKey
                                        unitKey
		                            }}
	                            }}
                            }}
                            designator {{
                                departureStation: origin
                                arrivalStation: destination
                                std: departure
                                sta: arrival
                            }}
                            fares {{
                                fareKey
                                classType
                                fareClassOfService
                                classOfService
                                productClass
                                classType
                                travelClassCode
                                passengerFares {{
                                    discountCode
                                    fareDiscountCode
                                    passengerType
                                    serviceCharges {{
                                        amount
                                        code
                                        type
                                    }}
                                }}
                            }}
                            legs {{
                                legKey
                                designator {{
                                    departureStation: origin
                                    arrivalStation: destination
                                    std: departure
                                    sta: arrival
                                }}
                                legInfo {{
                                    equipmentType
                                    departureTerminal
                                    departureTimeVariant
                                    operatingCarrier
                                }}}}}}}}}}}}"
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<BookingResponse>("bookingRetrieveByRecordLocator");
        }

        public async Task<bool> ResetBooking()
        {
            var query = new GraphQLRequest
            {
                Query = $@"mutation bookingReset{{bookingReset}}",
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<bool>("bookingReset");
        }

        public async Task<List<SeatMapResponse>> GetSeatMapAvailabilityBySegmentKey(string segmentKey)
        {
            var query = new GraphQLRequest
            {
                Query = $@"query seat {{
                seatMapsBySegmentKey(segmentKey: ""{ segmentKey }"", request: {{cultureCode: ""pt-BR"", includePropertyLookup: true, includeSeatFees: true}}) {{
                    seatMap {{
                        name
                        equipmentType
                        equipmentTypeSuffix
                        departureStation
                        arrivalStation
                        availableUnits
                        category
                        marketingCode
                        decks {{
                            key
                            value {{
                                compartments {{
                                    key
                                    value {{
                                        units {{
                                            unitKey
                                            height
                                            width
                                            x
                                            y
                                            assignable
                                            availability
                                            type
                                            designator
                                            group
                                            text
                                            properties {{
                                                code
                                                value
                                            }}
                                        }}
                                    availableUnits
                                    designator
                                    length
                                    width
                                    sequence
                                    orientation
                                }}
                            }}
                        }}
                    }}
                }}
                fees {{
                    key
                    value {{
                        groups {{
                            key
                            value {{
                                fees {{
                                    serviceCharges {{
                                        amount
                                        code
                                        type
                                    }}
                                }}
                            group
                        }}}}}}}}}}}}"
            };

            var response = await _client.PostAsync(query);

            return response.GetDataFieldAs<List<SeatMapResponse>>("seatMapsBySegmentKey");
        }

        public async Task<BookingCommitResponse> CommitBooking()
        {
            var query = new GraphQLRequest
            {
                Query = @"mutation commit { bookingCommit(
                request: {
                    distributeToContacts: false
                    waiveNameChangeFee: false
                    waivePenaltyFee: false
                    waiveSpoilageFee: false
                    restrictionOverride: false
                }) {
                    bookingKey
                    recordLocator
                    breakdown {
                        balanceDue
                        pointsBalanceDue
                        authorizedBalanceDue
                        totalAmount}
                }}",
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<BookingCommitResponse>("bookingCommit");
        }

        public async Task<bool> UnassignPassengerSegmentSeat(string passengerKey, string seatKey)
        {
            var query = new GraphQLRequest
            {
                Query = $@"mutation seatDelete {{ seatDelete (
                passengerKey: ""{ passengerKey }""
                unitKey: ""{ seatKey }""
                request: {{
                    ignoreSeatSsrs: false
                    waiveFee: false
                }})}}"
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<bool>("seatDelete");
        }
    }
}
