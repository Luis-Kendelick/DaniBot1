using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Response.Booking
{
    public class BookingResponse
    {
        [JsonProperty("bookingKey")]
        public string BookingKey { get; set; }

        [JsonProperty("recordLocator")]
        public string RecordLocator { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("typeOfSale")]
        public TypeOfSale TypeOfSale { get; set; }

        [JsonProperty("info")]
        public GetBookingServiceResponseInfo Info { get; set; }

        [JsonProperty("breakdown")]
        public Breakdown Breakdown { get; set; }

        [JsonProperty("journeys")]
        public Journey[] Journeys { get; set; }

        [JsonProperty("passengers")]
        public PassengerBooking[] Passengers { get; set; }

        [JsonProperty("payments")]
        public List<PaymentBooking> Payments { get; set; }

        [JsonProperty("contacts")]
        public List<BookingContact> Contacts { get; set; }

        #region Nested Classes

        public class PaymentBooking
        {
            [JsonProperty("paymentKey")]
            public string PaymentKey { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("approvalDate")]
            public DateTime? ApprovalDate { get; set; }

            [JsonProperty("authorizationStatus")]
            public string AuthorizationStatus { get; set; }

            [JsonProperty("amounts")]
            public AmountPayment Amounts { get; set; }

            #region Nested Classes

            public class AmountPayment
            {
                [JsonProperty("amount")]
                public decimal Amount { get; set; }

                [JsonProperty("currencyCode")]
                public string CurrencyCode { get; set; }
            }

            #endregion
        }

        #endregion
    }

    public class BookingContact
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public Contact Value { get; set; }
    }

    public class Contact
    {
        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }
    }

    public class PassengerBooking
    {
        public string Key { get; set; }

        public Passengers Value { get; set; }
    }

    public class AddOns
    {
        [JsonProperty("addOnsClass")]
        public IDictionary<string, AddOnsClass> AddOnsClass { get; set; }
    }

    public class AddOnsClass
    {
        [JsonProperty("paymentRequired")]
        public bool PaymentRequired { get; set; }

        [JsonProperty("addOnKey")]
        public string AddOnKey { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("created")]
        public Created Created { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("declinedText")]
        public string DeclinedText { get; set; }

        [JsonProperty("cultureCode")]
        public string CultureCode { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("modifiedAgentReference")]
        public string ModifiedAgentReference { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }

        [JsonProperty("isHistorical")]
        public bool IsHistorical { get; set; }

        [JsonProperty("charges")]
        public Charge[] Charges { get; set; }
    }

    public class Charge
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("ticketCode")]
        public string TicketCode { get; set; }

        [JsonProperty("collection")]
        public string Collection { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }
    }

    public class Created
    {
        [JsonProperty("agentReference")]
        public string AgentReference { get; set; }

        [JsonProperty("agentCode")]
        public string AgentCode { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("organizationCode")]
        public string OrganizationCode { get; set; }

        [JsonProperty("domainCode")]
        public string DomainCode { get; set; }

        [JsonProperty("locationCode")]
        public string LocationCode { get; set; }
    }

    public class Order
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("orderKey")]
        public string OrderKey { get; set; }

        [JsonProperty("phoneNumbers")]
        public PhoneNumber[] PhoneNumbers { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("locations")]
        public Location[] Locations { get; set; }

        [JsonProperty("criteria")]
        public Dictionary<string, string> Criteria { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("thumbnailFileName")]
        public string ThumbnailFileName { get; set; }

        [JsonProperty("participants")]
        public IDictionary<string, Participants> Participants { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("history")]
        public OrderHistory[] History { get; set; }

        [JsonProperty("usageDate")]
        public DateTime? UsageDate { get; set; }

        [JsonProperty("payment")]
        public OrderPayment Payment { get; set; }

        [JsonProperty("externalLocator")]
        public string ExternalLocator { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("descriptionFormatType")]
        public string DescriptionFormatType { get; set; }

        [JsonProperty("productDescription")]
        public string ProductDescription { get; set; }

        [JsonProperty("productVariationDescription")]
        public string ProductVariationDescription { get; set; }

        [JsonProperty("paymentAction")]
        public string PaymentAction { get; set; }

        [JsonProperty("amounts")]
        public OrderAmounts Amounts { get; set; }

        [JsonProperty("terms")]
        public Erm[] Terms { get; set; }

        [JsonProperty("cancellationTerms")]
        public Erm[] CancellationTerms { get; set; }

        [JsonProperty("details")]
        public Detail[] Details { get; set; }

        [JsonProperty("fees")]
        public OrderFee[] Fees { get; set; }

        [JsonProperty("notes")]
        public Note[] Notes { get; set; }

        [JsonProperty("parameters")]
        public Parameter[] Parameters { get; set; }
    }

    public class Address
    {
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("lineOne")]
        public string LineOne { get; set; }

        [JsonProperty("lineTwo")]
        public string LineTwo { get; set; }

        [JsonProperty("lineThree")]
        public string LineThree { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("provinceState")]
        public string ProvinceState { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }
    }

    public class Coordinates
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public class OrderAmounts
    {
        [JsonProperty("display")]
        public Discount Display { get; set; }

        [JsonProperty("initial")]
        public Discount Initial { get; set; }

        [JsonProperty("markup")]
        public Discount Markup { get; set; }

        [JsonProperty("listed")]
        public Discount Listed { get; set; }

        [JsonProperty("listedDiscount")]
        public Discount ListedDiscount { get; set; }

        [JsonProperty("discount")]
        public Discount Discount { get; set; }

        [JsonProperty("handling")]
        public Discount Handling { get; set; }

        [JsonProperty("handlingDiscount")]
        public Discount HandlingDiscount { get; set; }

        [JsonProperty("dueNow")]
        public Due DueNow { get; set; }

        [JsonProperty("dueLater")]
        public Due DueLater { get; set; }

        [JsonProperty("personalizations")]
        public decimal Personalizations { get; set; }

        [JsonProperty("taxable")]
        public decimal Taxable { get; set; }

        [JsonProperty("services")]
        public decimal Services { get; set; }

        [JsonProperty("fees")]
        public decimal Fees { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("taxRate")]
        public decimal TaxRate { get; set; }

        [JsonProperty("taxExempt")]
        public bool TaxExempt { get; set; }

        [JsonProperty("taxAtUnitPrice")]
        public bool TaxAtUnitPrice { get; set; }
    }

    public class Discount
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }
    }

    public class Due
    {
        [JsonProperty("preTax")]
        public decimal PreTax { get; set; }

        [JsonProperty("tax")]
        public decimal Tax { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }
    }

    public class Erm
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("terms")]
        public string Terms { get; set; }
    }

    public class Customer
    {
        [JsonProperty("customerKey")]
        public string CustomerKey { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("homePhone")]
        public string HomePhone { get; set; }

        [JsonProperty("workPhone")]
        public string WorkPhone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }
    }

    public class Name
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("middle")]
        public string Middle { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }
    }

    public class Detail
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("styleCode")]
        public string StyleCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class OrderFee
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("feeCategoryCode")]
        public string FeeCategoryCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("amount")]
        public Discount Amount { get; set; }

        [JsonProperty("foreignAmount")]
        public Discount ForeignAmount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("isWaiveable")]
        public bool IsWaiveable { get; set; }

        [JsonProperty("foreignCurrencyCode")]
        public string ForeignCurrencyCode { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("isChargeable")]
        public bool IsChargeable { get; set; }
    }

    public class OrderHistory
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("previousCode")]
        public string PreviousCode { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        [JsonProperty("hasError")]
        public bool HasError { get; set; }
    }

    public class Location
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("utcOffset")]
        public int UtcOffset { get; set; }

        [JsonProperty("usageDate")]
        public DateTime? UsageDate { get; set; }
    }

    public class Note
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }
    }

    public class Parameter
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Participants
    {
        [JsonProperty("participantKey")]
        public string ParticipantKey { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("participantTypeCode")]
        public string ParticipantTypeCode { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("isPrimary")]
        public bool IsPrimary { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("document")]
        public Document Document { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("homePhone")]
        public string HomePhone { get; set; }

        [JsonProperty("workPhone")]
        public string WorkPhone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }
    }

    public class Document
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("issuedByCode")]
        public string IssuedByCode { get; set; }

        [JsonProperty("documentTypeCode")]
        public string DocumentTypeCode { get; set; }
    }

    public class OrderPayment
    {
        [JsonProperty("paymentKey")]
        public string PaymentKey { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("issueNumber")]
        public string IssueNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("phoneNumbers")]
        public PhoneNumber[] PhoneNumbers { get; set; }
    }

    public class PhoneNumber
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }

    public class Source
    {
        [JsonProperty("agentCode")]
        public string AgentCode { get; set; }

        [JsonProperty("domainCode")]
        public string DomainCode { get; set; }

        [JsonProperty("locationCode")]
        public string LocationCode { get; set; }

        [JsonProperty("organizationCode")]
        public string OrganizationCode { get; set; }
    }

    public class Summary
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("held")]
        public decimal Held { get; set; }

        [JsonProperty("charged")]
        public decimal Charged { get; set; }

        [JsonProperty("supplierCode")]
        public string SupplierCode { get; set; }

        [JsonProperty("beginDate")]
        public DateTime? BeginDate { get; set; }

        [JsonProperty("beginLocation")]
        public string BeginLocation { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("endLocation")]
        public string EndLocation { get; set; }

        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Breakdown
    {
        [JsonProperty("balanceDue")]
        public decimal? BalanceDue { get; set; }

        [JsonProperty("pointsBalanceDue")]
        public decimal? PointsBalanceDue { get; set; }

        [JsonProperty("authorizedBalanceDue")]
        public decimal AuthorizedBalanceDue { get; set; }

        [JsonProperty("totalAmount")]
        public decimal? TotalAmount { get; set; }

        [JsonProperty("totalPoints")]
        public decimal? TotalPoints { get; set; }

        [JsonProperty("totalToCollect")]
        public decimal? TotalToCollect { get; set; }

        [JsonProperty("totalPointsToCollect")]
        public decimal TotalPointsToCollect { get; set; }

        [JsonProperty("totalCharged")]
        public decimal TotalCharged { get; set; }

        [JsonProperty("passengerTotals")]
        public PassengerTotals PassengerTotals { get; set; }

        [JsonProperty("passengers")]
        public BreakdowPassenger[] Passengers { get; set; }

        [JsonProperty("journeyTotals")]
        public JourneyTotals JourneyTotals { get; set; }

        [JsonProperty("journeys")]
        public Journeys Journeys { get; set; }

        [JsonProperty("addOnTotals")]
        public AddOnTotals AddOnTotals { get; set; }
    }

    public class BreakdowPassenger
    {
        public string Key { get; set; }

        public PassengerTotals Value { get; set; }
    }

    public class AddOnTotals
    {
        [JsonProperty("car")]
        public decimal? Car { get; set; }

        [JsonProperty("hotel")]
        public decimal? Hotel { get; set; }

        [JsonProperty("activities")]
        public decimal? Activities { get; set; }
    }

    public class JourneyTotals
    {
        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("totalPoints")]
        public decimal TotalPoints { get; set; }

        [JsonProperty("totalTax")]
        public decimal TotalTax { get; set; }

        [JsonProperty("totalDiscount")]
        public decimal TotalDiscount { get; set; }

        [JsonProperty("journeyKey")]
        public string JourneyKey { get; set; }
    }

    public class Journeys
    {
        [JsonProperty("journeyTotals")]
        public IDictionary<string, JourneyTotals> JourneyTotals { get; set; }
    }

    public class PassengerTotals
    {
        [JsonProperty("services")]
        public Convenience Services { get; set; }

        [JsonProperty("specialServices")]
        public Convenience SpecialServices { get; set; }

        [JsonProperty("seats")]
        public Convenience Seats { get; set; }

        [JsonProperty("upgrades")]
        public Convenience Upgrades { get; set; }

        [JsonProperty("spoilage")]
        public Convenience Spoilage { get; set; }

        [JsonProperty("nameChanges")]
        public Convenience NameChanges { get; set; }

        [JsonProperty("convenience")]
        public Convenience Convenience { get; set; }

        [JsonProperty("infant")]
        public Convenience Infant { get; set; }

        [JsonProperty("passengerKey")]
        public string PassengerKey { get; set; }
    }

    public class Convenience
    {
        [JsonProperty("total")]
        public decimal? Total { get; set; }

        [JsonProperty("taxes")]
        public decimal? Taxes { get; set; }

        [JsonProperty("adjustments")]
        public decimal? Adjustments { get; set; }

        [JsonProperty("charges")]
        public Harge[] Charges { get; set; }
    }

    public class Harge
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("collectType")]
        public string CollectType { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("foreignCurrencyCode")]
        public string ForeignCurrencyCode { get; set; }

        [JsonProperty("foreignAmount")]
        public decimal ForeignAmount { get; set; }

        [JsonProperty("ticketCode")]
        public string TicketCode { get; set; }
    }

    public class Comment
    {
        [JsonProperty("commentKey")]
        public string CommentKey { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("pointOfSale")]
        public Source PointOfSale { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }
    }

    public class Contacts
    {
        [JsonProperty("contactTypeCode")]
        public string ContactTypeCode { get; set; }

        [JsonProperty("phoneNumbers")]
        public PhoneNumber[] PhoneNumbers { get; set; }

        [JsonProperty("cultureCode")]
        public string CultureCode { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("sourceOrganization")]
        public string SourceOrganization { get; set; }

        [JsonProperty("distributionOption")]
        public string DistributionOption { get; set; }

        [JsonProperty("notificationPreference")]
        public string NotificationPreference { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }
    }

    public class GetBookingServiceResponseHistory
    {
        [JsonProperty("historyCategory")]
        public string HistoryCategory { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("pointOfSale")]
        public Source PointOfSale { get; set; }

        [JsonProperty("sourcePointOfSale")]
        public Source SourcePointOfSale { get; set; }

        [JsonProperty("receivedBy")]
        public string ReceivedBy { get; set; }

        [JsonProperty("receivedByReference")]
        public string ReceivedByReference { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }
    }

    public class Hold
    {
        [JsonProperty("expiration")]
        public DateTime? Expiration { get; set; }
    }

    public class GetBookingServiceResponseInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("priceStatus")]
        public string PriceStatus { get; set; }

        [JsonProperty("bookedDate")]
        public DateTime? BookedDate { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

    }

    public class Journey
    {
        [JsonProperty("flightType")]
        public string FlightType { get; set; }

        [JsonProperty("stops")]
        public int Stops { get; set; }

        [JsonProperty("designator")]
        public Designator Designator { get; set; }

        [JsonProperty("move")]
        public Move Move { get; set; }

        [JsonProperty("segments")]
        public Segment[] Segments { get; set; }

        [JsonProperty("journeyKey")]
        public string JourneyKey { get; set; }

        [JsonProperty("notForGeneralUser")]
        public bool NotForGeneralUser { get; set; }
    }

    public class Designator
    {
        [JsonProperty("ArrivalStation")]
        public string ArrivalStation { get; set; }

        [JsonProperty("DepartureStation")]
        public string DepartureStation { get; set; }

        [JsonProperty("Sta")]
        public DateTime? Sta { get; set; }

        [JsonProperty("Std")]
        public DateTime? Std { get; set; }
    }

    public class Move
    {
        [JsonProperty("maxMoveBackDays")]
        public int MaxMoveBackDays { get; set; }

        [JsonProperty("maxMoveOutDays")]
        public int MaxMoveOutDays { get; set; }
    }

    public class Segment
    {
        [JsonProperty("isStandby")]
        public bool IsStandby { get; set; }

        [JsonProperty("isConfirming")]
        public bool IsConfirming { get; set; }

        [JsonProperty("isBlocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("isHosted")]
        public bool IsHosted { get; set; }

        [JsonProperty("isChangeOfGauge")]
        public bool IsChangeOfGauge { get; set; }

        [JsonProperty("designator")]
        public Designator Designator { get; set; }

        [JsonProperty("isSeatmapViewable")]
        public bool IsSeatmapViewable { get; set; }

        [JsonProperty("fares")]
        public Fare[] Fares { get; set; }

        [JsonProperty("segmentKey")]
        public string SegmentKey { get; set; }

        [JsonProperty("identifier")]
        public Dentifier Identifier { get; set; }

        [JsonProperty("passengerSegment")]
        public IList<PassengerSegmentListObject> PassengersSegment { get; set; }

        [JsonProperty("channelType")]
        public string ChannelType { get; set; }

        [JsonProperty("cabinOfService")]
        public string CabinOfService { get; set; }

        [JsonProperty("externalIdentifier")]
        public Dentifier ExternalIdentifier { get; set; }

        [JsonProperty("priorityCode")]
        public string PriorityCode { get; set; }

        [JsonProperty("changeReasonCode")]
        public string ChangeReasonCode { get; set; }

        [JsonProperty("segmentType")]
        public string SegmentType { get; set; }

        [JsonProperty("salesDate")]
        public DateTime? SalesDate { get; set; }

        [JsonProperty("international")]
        public bool International { get; set; }

        [JsonProperty("flightReference")]
        public string FlightReference { get; set; }

        [JsonProperty("legs")]
        public Leg[] Legs { get; set; }
    }

    public class Dentifier
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("opSuffix")]
        public string OpSuffix { get; set; }
    }

    public class Fare
    {
        [JsonProperty("isGoverning")]
        public bool IsGoverning { get; set; }

        [JsonProperty("downgradeAvailable")]
        public bool DowngradeAvailable { get; set; }

        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("fareKey")]
        public string FareKey { get; set; }

        [JsonProperty("classOfService")]
        public string ClassOfService { get; set; }

        [JsonProperty("classType")]
        public string ClassType { get; set; }

        [JsonProperty("fareApplicationType")]
        public string FareApplicationType { get; set; }

        [JsonProperty("fareClassOfService")]
        public string FareClassOfService { get; set; }

        [JsonProperty("fareBasisCode")]
        public string FareBasisCode { get; set; }

        [JsonProperty("fareSequence")]
        public int FareSequence { get; set; }

        [JsonProperty("inboundOutBound")]
        public string InboundOutBound { get; set; }

        [JsonProperty("fareStatus")]
        public string FareStatus { get; set; }

        [JsonProperty("isAllotmentMarketFare")]
        public bool IsAllotmentMarketFare { get; set; }

        [JsonProperty("originalClassOfService")]
        public string OriginalClassOfService { get; set; }

        [JsonProperty("ruleNumber")]
        public string RuleNumber { get; set; }

        [JsonProperty("productClass")]
        public string ProductClass { get; set; }

        [JsonProperty("ruleTariff")]
        public string RuleTariff { get; set; }

        [JsonProperty("travelClassCode")]
        public string TravelClassCode { get; set; }

        [JsonProperty("crossReferenceClassOfService")]
        public string CrossReferenceClassOfService { get; set; }

        [JsonProperty("passengerFares")]
        public PassengerFare[] PassengerFares { get; set; }
    }

    public class PassengerFare
    {
        [JsonProperty("serviceCharges")]
        public Harge[] ServiceCharges { get; set; }

        [JsonProperty("discountCode")]
        public string DiscountCode { get; set; }

        [JsonProperty("fareDiscountCode")]
        public string FareDiscountCode { get; set; }

        [JsonProperty("passengerType")]
        public string PassengerType { get; set; }
    }

    public class Leg
    {
        [JsonProperty("legKey")]
        public string LegKey { get; set; }

        [JsonProperty("operationsInfo")]
        public OperationsInfo OperationsInfo { get; set; }

        [JsonProperty("designator")]
        public Designator Designator { get; set; }

        [JsonProperty("legInfo")]
        public LegInfo LegInfo { get; set; }

        [JsonProperty("nests")]
        public Nest[] Nests { get; set; }

        [JsonProperty("ssrs")]
        public LegSsr[] Ssrs { get; set; }

        [JsonProperty("seatmapReference")]
        public string SeatmapReference { get; set; }

        [JsonProperty("flightReference")]
        public string FlightReference { get; set; }
    }

    public class LegInfo
    {
        [JsonProperty("departureTimeUtc")]
        public DateTime? DepartureTimeUtc { get; set; }

        [JsonProperty("arrivalTimeUtc")]
        public DateTime? ArrivalTimeUtc { get; set; }

        [JsonProperty("adjustedCapacity")]
        public int AdjustedCapacity { get; set; }

        [JsonProperty("arrivalTerminal")]
        public string ArrivalTerminal { get; set; }

        [JsonProperty("arrivalTimeVariant")]
        public int ArrivalTimeVariant { get; set; }

        [JsonProperty("backMoveDays")]
        public int BackMoveDays { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [JsonProperty("changeOfDirection")]
        public bool ChangeOfDirection { get; set; }

        [JsonProperty("codeShareIndicator")]
        public string CodeShareIndicator { get; set; }

        [JsonProperty("departureTerminal")]
        public string DepartureTerminal { get; set; }

        [JsonProperty("departureTimeVariant")]
        public int DepartureTimeVariant { get; set; }

        [JsonProperty("equipmentType")]
        public string EquipmentType { get; set; }

        [JsonProperty("equipmentTypeSuffix")]
        public string EquipmentTypeSuffix { get; set; }

        [JsonProperty("eTicket")]
        public bool ETicket { get; set; }

        [JsonProperty("irop")]
        public bool Irop { get; set; }

        [JsonProperty("lid")]
        public int Lid { get; set; }

        [JsonProperty("marketingCode")]
        public string MarketingCode { get; set; }

        [JsonProperty("marketingOverride")]
        public bool MarketingOverride { get; set; }

        [JsonProperty("onTime")]
        public string OnTime { get; set; }

        [JsonProperty("operatedByText")]
        public string OperatedByText { get; set; }

        [JsonProperty("operatingCarrier")]
        public string OperatingCarrier { get; set; }

        [JsonProperty("operatingFlightNumber")]
        public string OperatingFlightNumber { get; set; }

        [JsonProperty("operatingOpSuffix")]
        public string OperatingOpSuffix { get; set; }

        [JsonProperty("outMoveDays")]
        public int OutMoveDays { get; set; }

        [JsonProperty("arrivalTime")]
        public DateTime? ArrivalTime { get; set; }

        [JsonProperty("departureTime")]
        public DateTime? DepartureTime { get; set; }

        [JsonProperty("prbcCode")]
        public string PrbcCode { get; set; }

        [JsonProperty("scheduleServiceType")]
        public string ScheduleServiceType { get; set; }

        [JsonProperty("sold")]
        public int Sold { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subjectToGovtApproval")]
        public bool SubjectToGovtApproval { get; set; }
    }

    public class Nest
    {
        [JsonProperty("adjustedCapacity")]
        public int AdjustedCapacity { get; set; }

        [JsonProperty("classNest")]
        public int ClassNest { get; set; }

        [JsonProperty("lid")]
        public int Lid { get; set; }

        [JsonProperty("travelClassCode")]
        public string TravelClassCode { get; set; }

        [JsonProperty("nestType")]
        public string NestType { get; set; }

        [JsonProperty("legClasses")]
        public LegClass[] LegClasses { get; set; }
    }

    public class LegClass
    {
        [JsonProperty("classNest")]
        public int ClassNest { get; set; }

        [JsonProperty("classAllotted")]
        public int ClassAllotted { get; set; }

        [JsonProperty("classType")]
        public string ClassType { get; set; }

        [JsonProperty("classAuthorizedUnits")]
        public int ClassAuthorizedUnits { get; set; }

        [JsonProperty("classOfService")]
        public string ClassOfService { get; set; }

        [JsonProperty("classRank")]
        public int ClassRank { get; set; }

        [JsonProperty("classSold")]
        public int ClassSold { get; set; }

        [JsonProperty("cnxSold")]
        public int CnxSold { get; set; }

        [JsonProperty("latestAdvancedReservation")]
        public int LatestAdvancedReservation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("thruSold")]
        public int ThruSold { get; set; }
    }

    public class OperationsInfo
    {
        [JsonProperty("arrivalGate")]
        public Gate ArrivalGate { get; set; }

        [JsonProperty("estimatedArrivalTime")]
        public DateTime? EstimatedArrivalTime { get; set; }

        [JsonProperty("departureGate")]
        public Gate DepartureGate { get; set; }

        [JsonProperty("actualOffBlockTime")]
        public DateTime? ActualOffBlockTime { get; set; }

        [JsonProperty("actualOnBlockTime")]
        public DateTime? ActualOnBlockTime { get; set; }

        [JsonProperty("actualTouchDownTime")]
        public DateTime? ActualTouchDownTime { get; set; }

        [JsonProperty("airborneTime")]
        public DateTime? AirborneTime { get; set; }

        [JsonProperty("arrivalNote")]
        public string ArrivalNote { get; set; }

        [JsonProperty("arrivalStatus")]
        public string ArrivalStatus { get; set; }

        [JsonProperty("baggageClaim")]
        public string BaggageClaim { get; set; }

        [JsonProperty("departureNote")]
        public string DepartureNote { get; set; }

        [JsonProperty("departureStatus")]
        public string DepartureStatus { get; set; }

        [JsonProperty("departureTimes")]
        public DepartureTimes DepartureTimes { get; set; }

        [JsonProperty("standardArrivalTime")]
        public DateTime? StandardArrivalTime { get; set; }

        [JsonProperty("tailNumber")]
        public string TailNumber { get; set; }
    }

    public class Gate
    {
        [JsonProperty("estimatedGate")]
        public string EstimatedGate { get; set; }

        [JsonProperty("actualGate")]
        public string ActualGate { get; set; }
    }

    public class DepartureTimes
    {
        [JsonProperty("scheduled")]
        public DateTime? Scheduled { get; set; }

        [JsonProperty("estimated")]
        public DateTime? Estimated { get; set; }
    }

    public class LegSsr
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("ssrNestCode")]
        public string SsrNestCode { get; set; }

        [JsonProperty("lid")]
        public int Lid { get; set; }

        [JsonProperty("sold")]
        public int Sold { get; set; }

        [JsonProperty("unitSold")]
        public int UnitSold { get; set; }
    }

    public class PassengerSegmentListObject
    {
        public string Key { get; set; }

        public PassengerSegment Value { get; set; }
    }

    public class PassengerSegment
    {
        [JsonProperty("passengerKey")]
        public string PassengerKey { get; set; }

        [JsonProperty("activityDate")]
        public DateTime? ActivityDate { get; set; }

        [JsonProperty("baggageAllowanceUsed")]
        public bool BaggageAllowanceUsed { get; set; }

        [JsonProperty("baggageAllowanceWeight")]
        public int BaggageAllowanceWeight { get; set; }

        [JsonProperty("baggageAllowanceWeightType")]
        public string BaggageAllowanceWeightType { get; set; }

        [JsonProperty("boardingSequence")]
        public string BoardingSequence { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("liftStatus")]
        public string LiftStatus { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("overBookIndicator")]
        public string OverBookIndicator { get; set; }

        [JsonProperty("priorityDate")]
        public DateTime? PriorityDate { get; set; }

        [JsonProperty("timeChanged")]
        public bool TimeChanged { get; set; }

        [JsonProperty("verifiedTravelDocs")]
        public string VerifiedTravelDocs { get; set; }

        [JsonProperty("sourcePointOfSale")]
        public Source SourcePointOfSale { get; set; }

        [JsonProperty("pointOfSale")]
        public Source PointOfSale { get; set; }

        [JsonProperty("seats")]
        public Seat[] Seats { get; set; }

        [JsonProperty("ssrs")]
        public Ssr[] Ssrs { get; set; }

        [JsonProperty("tickets")]
        public Ticket[] Tickets { get; set; }

        [JsonProperty("bags")]
        public PurpleBag[] Bags { get; set; }

        [JsonProperty("scores")]
        public Score[] Scores { get; set; }

        [JsonProperty("boardingPassDetail")]
        public BoardingPassDetail BoardingPassDetail { get; set; }

        [JsonProperty("hasInfant")]
        public bool HasInfant { get; set; }

        [JsonProperty("seatPreferences")]
        public SeatPreferences SeatPreferences { get; set; }
    }

    public class PurpleBag
    {
        [JsonProperty("baggageKey")]
        public string BaggageKey { get; set; }

        [JsonProperty("passengerKey")]
        public string PassengerKey { get; set; }

        [JsonProperty("arrivalStation")]
        public string ArrivalStation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("departureStation")]
        public string DepartureStation { get; set; }

        [JsonProperty("osTag")]
        public string OsTag { get; set; }
    }

    public class BoardingPassDetail
    {
        [JsonProperty("gateInformation")]
        public string GateInformation { get; set; }

        [JsonProperty("priorityInformation")]
        public string PriorityInformation { get; set; }

        [JsonProperty("cabinClass")]
        public string CabinClass { get; set; }

        [JsonProperty("compartmentLevel")]
        public string CompartmentLevel { get; set; }

        [JsonProperty("boardingZone")]
        public string BoardingZone { get; set; }

        [JsonProperty("seatAssignment")]
        public string SeatAssignment { get; set; }

        [JsonProperty("sequenceNumber")]
        public string SequenceNumber { get; set; }
    }

    public class Score
    {
        [JsonProperty("guestValueCode")]
        public string GuestValueCode { get; set; }

        [JsonProperty("score")]
        public int ScoreScore { get; set; }

        [JsonProperty("passengerKey")]
        public string PassengerKey { get; set; }
    }

    public class SeatPreferences
    {
        [JsonProperty("seat")]
        public string Seat { get; set; }

        [JsonProperty("travelClass")]
        public string TravelClass { get; set; }

        [JsonProperty("advancedPreferences")]
        public AdvancedPreference[] AdvancedPreferences { get; set; }
    }

    public class AdvancedPreference
    {
        [JsonProperty("seatMapCode")]
        public string SeatMapCode { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Seat
    {
        [JsonProperty("compartmentDesignator")]
        public string CompartmentDesignator { get; set; }

        [JsonProperty("penalty")]
        public int Penalty { get; set; }

        [JsonProperty("unitDesignator")]
        public string UnitDesignator { get; set; }

        [JsonProperty("seatInformation")]
        public SeatInformation SeatInformation { get; set; }

        [JsonProperty("arrivalStation")]
        public string ArrivalStation { get; set; }

        [JsonProperty("departureStation")]
        public string DepartureStation { get; set; }

        [JsonProperty("passengerKey")]
        public string PassengerKey { get; set; }

        [JsonProperty("unitKey")]
        public string UnitKey { get; set; }
    }

    public class SeatInformation
    {
        [JsonProperty("deck")]
        public int Deck { get; set; }

        [JsonProperty("seatSet")]
        public int SeatSet { get; set; }

        [JsonProperty("propertyList")]
        public PropertyList[] PropertyList { get; set; }
    }

    public class PropertyList
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Ssr
    {
        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("ssrDuration")]
        public string SsrDuration { get; set; }

        [JsonProperty("ssrKey")]
        public string SsrKey { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("ssrCode")]
        public string SsrCode { get; set; }

        [JsonProperty("feeCode")]
        public string FeeCode { get; set; }

        [JsonProperty("passengerKey")]
        public string PassengerKey { get; set; }

        [JsonProperty("ssrDetail")]
        public string SsrDetail { get; set; }

        [JsonProperty("ssrNumber")]
        public int SsrNumber { get; set; }

        [JsonProperty("market")]
        public Market Market { get; set; }
    }

    public class Market
    {
        [JsonProperty("identifier")]
        public Dentifier Identifier { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("departureDate")]
        public DateTime? DepartureDate { get; set; }
    }

    public class Ticket
    {
        [JsonProperty("ticketNumber")]
        public string TicketNumber { get; set; }

        [JsonProperty("infantTicketNumber")]
        public string InfantTicketNumber { get; set; }

        [JsonProperty("ticketIndicator")]
        public string TicketIndicator { get; set; }

        [JsonProperty("ticketStatus")]
        public string TicketStatus { get; set; }

        [JsonProperty("passengerKey")]
        public string PassengerKey { get; set; }
    }

    public class Locators
    {
        [JsonProperty("numericRecordLocator")]
        public string NumericRecordLocator { get; set; }

        [JsonProperty("parentRecordLocator")]
        public string ParentRecordLocator { get; set; }

        [JsonProperty("parentId")]
        public int ParentId { get; set; }

        [JsonProperty("recordLocators")]
        public RecordLocator[] RecordLocators { get; set; }
    }

    public class RecordLocator
    {
        [JsonProperty("systemDomainCode")]
        public string SystemDomainCode { get; set; }

        [JsonProperty("owningSystemCode")]
        public string OwningSystemCode { get; set; }

        [JsonProperty("bookingSystemCode")]
        public string BookingSystemCode { get; set; }

        [JsonProperty("recordCode")]
        public string RecordCode { get; set; }

        [JsonProperty("hostedCarrierCode")]
        public string HostedCarrierCode { get; set; }

        [JsonProperty("interactionPurpose")]
        public string InteractionPurpose { get; set; }
    }

    public class Passengers
    {
        [JsonProperty("passengerKey")]
        public string PassengerKey { get; set; }

        //[JsonProperty("passengerAlternateKey")]
        //public string PassengerAlternateKey { get; set; }

        //[JsonProperty("customerNumber")]
        //public string CustomerNumber { get; set; }

        [JsonProperty("fees")]
        public Fee[] Fees { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("passengerTypeCode")]
        public string PassengerTypeCode { get; set; }

        //[JsonProperty("discountCode")]
        //public string DiscountCode { get; set; }

        //[JsonProperty("bags")]
        //public FluffyBag[] Bags { get; set; }

        [JsonProperty("program")]
        public Program Program { get; set; }

        [JsonProperty("infant")]
        public Infant Infant { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        //[JsonProperty("travelDocuments")]
        //public TravelDocument[] TravelDocuments { get; set; }

        //[JsonProperty("addresses")]
        //public Dictionary<string, string>[] Addresses { get; set; }

        //[JsonProperty("weightCategory")]
        //public string WeightCategory { get; set; }
    }

    public class FluffyBag
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("baggageKey")]
        public string BaggageKey { get; set; }

        [JsonProperty("nonStandard")]
        public bool NonStandard { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("osTag")]
        public string OsTag { get; set; }

        [JsonProperty("osTagDate")]
        public DateTime? OsTagDate { get; set; }

        [JsonProperty("taggedToStation")]
        public string TaggedToStation { get; set; }

        [JsonProperty("stationCode")]
        public string StationCode { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("taggedToCarrierCode")]
        public string TaggedToCarrierCode { get; set; }

        [JsonProperty("weightType")]
        public string WeightType { get; set; }
    }

    public class Fee
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ssrCode")]
        public string SsrCode { get; set; }

        [JsonProperty("ssrNumber")]
        public int SsrNumber { get; set; }

        [JsonProperty("paymentNumber")]
        public int PaymentNumber { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("passengerFeeKey")]
        public string PassengerFeeKey { get; set; }

        [JsonProperty("override")]
        public bool Override { get; set; }

        [JsonProperty("flightReference")]
        public string FlightReference { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("isProtected")]
        public bool IsProtected { get; set; }

        [JsonProperty("serviceCharges")]
        public Harge[] ServiceCharges { get; set; }
    }

    public class Infant
    {
        //[JsonProperty("fees")]
        //public InfantFee[] Fees { get; set; }

        //[JsonProperty("nationality")]
        //public string Nationality { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        //[JsonProperty("travelDocuments")]
        //public TravelDocument[] TravelDocuments { get; set; }

        //[JsonProperty("residentCountry")]
        //public string ResidentCountry { get; set; }

        //[JsonProperty("gender")]
        //public string Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }
    }

    public class InfantFee
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("passengerFeeKey")]
        public string PassengerFeeKey { get; set; }

        [JsonProperty("override")]
        public bool Override { get; set; }

        [JsonProperty("flightReference")]
        public string FlightReference { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("isProtected")]
        public bool IsProtected { get; set; }

        [JsonProperty("serviceCharges")]
        public Harge[] ServiceCharges { get; set; }
    }

    public class TravelDocument
    {
        [JsonProperty("passengerTravelDocumentKey")]
        public string PassengerTravelDocumentKey { get; set; }

        [JsonProperty("documentTypeCode")]
        public string DocumentTypeCode { get; set; }

        [JsonProperty("birthCountry")]
        public string BirthCountry { get; set; }

        [JsonProperty("issuedByCode")]
        public string IssuedByCode { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("issuedDate")]
        public DateTime? IssuedDate { get; set; }
    }

    public class Info
    {
        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("residentCountry")]
        public string ResidentCountry { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonProperty("familyNumber")]
        public int? FamilyNumber { get; set; }
    }

    public class Program
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("levelCode")]
        public string LevelCode { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }

    public class PaymentElement
    {
        [JsonProperty("paymentKey")]
        public string PaymentKey { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("approvalDate")]
        public DateTime? ApprovalDate { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }

        [JsonProperty("amounts")]
        public PaymentAmounts Amounts { get; set; }

        [JsonProperty("authorizationCode")]
        public string AuthorizationCode { get; set; }

        [JsonProperty("authorizationStatus")]
        public string AuthorizationStatus { get; set; }

        [JsonProperty("fundedDate")]
        public DateTime FundedDate { get; set; }

        [JsonProperty("transactionCode")]
        public string TransactionCode { get; set; }

        [JsonProperty("dcc")]
        public Dcc Dcc { get; set; }

        [JsonProperty("threeDSecure")]
        public ThreeDSecure ThreeDSecure { get; set; }

        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("transferred")]
        public bool Transferred { get; set; }

        [JsonProperty("channelType")]
        public string ChannelType { get; set; }

        [JsonProperty("pointOfSale")]
        public Source PointOfSale { get; set; }

        [JsonProperty("sourcePointOfSale")]
        public Source SourcePointOfSale { get; set; }

        [JsonProperty("deposit")]
        public bool Deposit { get; set; }

        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("voucher")]
        public Voucher Voucher { get; set; }

        [JsonProperty("addedToState")]
        public bool AddedToState { get; set; }

        [JsonProperty("createdAgentId")]
        public int CreatedAgentId { get; set; }

        [JsonProperty("modifiedAgentId")]
        public int ModifiedAgentId { get; set; }
    }

    public class PaymentAmounts
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("collected")]
        public decimal Collected { get; set; }

        [JsonProperty("collectedCurrencyCode")]
        public string CollectedCurrencyCode { get; set; }

        [JsonProperty("quoted")]
        public decimal Quoted { get; set; }

        [JsonProperty("quotedCurrencyCode")]
        public string QuotedCurrencyCode { get; set; }
    }

    public class Attachment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("paymentId")]
        public int PaymentId { get; set; }

        [JsonProperty("attachment")]
        public string AttachmentAttachment { get; set; }
    }

    public class Dcc
    {
        [JsonProperty("rateId")]
        public string RateId { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("rateValue")]
        public decimal RateValue { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("putInState")]
        public string PutInState { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("applicable")]
        public bool Applicable { get; set; }
    }

    public class Details
    {
        [JsonProperty("accountNumberId")]
        public int AccountNumberId { get; set; }

        [JsonProperty("parentPaymentId")]
        public int? ParentPaymentId { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("installments")]
        public int Installments { get; set; }

        [JsonProperty("binRange")]
        public int BinRange { get; set; }

        [JsonProperty("fields")]
        public PropertyList Fields { get; set; }
    }

    public class ThreeDSecure
    {
        [JsonProperty("browserUserAgent")]
        public string BrowserUserAgent { get; set; }

        [JsonProperty("browserAccept")]
        public string BrowserAccept { get; set; }

        [JsonProperty("remoteIpAddress")]
        public string RemoteIpAddress { get; set; }

        [JsonProperty("termUrl")]
        public string TermUrl { get; set; }

        [JsonProperty("paReq")]
        public string PaReq { get; set; }

        [JsonProperty("acsUrl")]
        public string AcsUrl { get; set; }

        [JsonProperty("paRes")]
        public string PaRes { get; set; }

        [JsonProperty("authResult")]
        public string AuthResult { get; set; }

        [JsonProperty("cavv")]
        public string Cavv { get; set; }

        [JsonProperty("cavvAlgorithm")]
        public string CavvAlgorithm { get; set; }

        [JsonProperty("eci")]
        public string Eci { get; set; }

        [JsonProperty("xid")]
        public string Xid { get; set; }

        [JsonProperty("applicable")]
        public bool Applicable { get; set; }

        [JsonProperty("successful")]
        public bool Successful { get; set; }
    }

    public class Voucher
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("transactionId")]
        public int TransactionId { get; set; }

        [JsonProperty("overrideRestrictions")]
        public bool OverrideRestrictions { get; set; }

        [JsonProperty("overrideAmount")]
        public bool OverrideAmount { get; set; }

        [JsonProperty("recordLocator")]
        public string RecordLocator { get; set; }
    }

    public class Queue
    {
        [JsonProperty("segmentKey")]
        public string SegmentKey { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("subCode")]
        public string SubCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        [JsonProperty("passengerId")]
        public int PassengerId { get; set; }

        [JsonProperty("watchListId")]
        public int WatchListId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }
    }

    public class ReceivedBy
    {
        [JsonProperty("receivedBy")]
        public string ReceivedByReceivedBy { get; set; }

        [JsonProperty("latestReceivedBy")]
        public string LatestReceivedBy { get; set; }

        [JsonProperty("receivedReference")]
        public string ReceivedReference { get; set; }

        [JsonProperty("latestReceivedReference")]
        public string LatestReceivedReference { get; set; }

        [JsonProperty("referralCode")]
        public string ReferralCode { get; set; }
    }

    public class Sales
    {
        [JsonProperty("created")]
        public Source Created { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("modified")]
        public Source Modified { get; set; }
    }

    public class TypeOfSale
    {
        [JsonProperty("residentCountry")]
        public string ResidentCountry { get; set; }

        [JsonProperty("promotionCode")]
        public string PromotionCode { get; set; }
    }
}
