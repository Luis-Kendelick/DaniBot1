using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.SeatMap.Response
{
    //[Serializable]
    //public sealed class SeatMapResponse
    //{
    //    [JsonProperty("seatMapsBySegmentKey")]
    //    public SeatMapsBySegmentKey[] SeatMapsBySegmentKey { get; set; }
    //}

    [Serializable]
    public class SeatMapResponse
    {
        [JsonProperty("seatMap")]
        public SeatMap SeatMap { get; set; }

        [JsonProperty("fees")]
        public FeeSeatMap[] Fees { get; set; }
    }

    [Serializable]
    public class SeatMap
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("equipmentType")]
        public string EquipmentType { get; set; }

        [JsonProperty("equipmentTypeSuffix")]
        public string EquipmentTypeSuffix { get; set; }

        [JsonProperty("departureStation")]
        public string DepartureStation { get; set; }

        [JsonProperty("arrivalStation")]
        public string ArrivalStation { get; set; }

        [JsonProperty("availableUnits")]
        public long AvailableUnits { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("marketingCode")]
        public string MarketingCode { get; set; }

        [JsonProperty("decks")]
        public Deck[] Decks { get; set; }
    }

    [Serializable]
    public class Deck
    {
        [JsonProperty("key")]
        public long Key { get; set; }

        [JsonProperty("value")]
        public DeckValue Value { get; set; }
    }

    [Serializable]
    public class DeckValue
    {
        [JsonProperty("compartments")]
        public Compartment[] Compartments { get; set; }
    }

    [Serializable]
    public class Compartment
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public CompartmentValue Value { get; set; }
    }

    [Serializable]
    public class CompartmentValue
    {
        [JsonProperty("units")]
        public List<Unit> Units { get; set; }

        [JsonProperty("availableUnits")]
        public long AvailableUnits { get; set; }

        [JsonProperty("designator")]
        public string Designator { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("orientation")]
        public long Orientation { get; set; }
    }

    [Serializable]
    public class Unit
    {
        [JsonProperty("unitKey")]
        public string UnitKey { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("assignable")]
        public bool Assignable { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("designator")]
        public string Designator { get; set; }

        [JsonProperty("group")]
        public long Group { get; set; }

        [JsonProperty("properties")]
        public Property[] Properties { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    [Serializable]
    public class Property
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    [Serializable]
    public class FeeSeatMap
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public FeeValue Value { get; set; }
    }

    [Serializable]
    public class FeeValue
    {
        [JsonProperty("groups")]
        public Group[] Groups { get; set; }
    }

    [Serializable]
    public class Group
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public GroupValue Value { get; set; }
    }

    [Serializable]
    public class GroupValue
    {
        [JsonProperty("fees")]
        public ValueFee[] Fees { get; set; }

        [JsonProperty("group")]
        public long Group { get; set; }
    }

    [Serializable]
    public class ValueFee
    {
        [JsonProperty("serviceCharges")]
        public ServiceCharge[] ServiceCharges { get; set; }
    }

    [Serializable]
    public class ServiceCharge
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
