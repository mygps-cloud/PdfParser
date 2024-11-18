namespace PdfParser.RecordEntity
{
    public record class Entity
    {     

        public string? OrderID { get; init; }
        public string? Dealers { get; init; }
         public string? VIN { get; init; }
        public string? PickupInformation { get; init; }
        public string? DeliveryInformation { get; init; }
        public string? AdditionalInformation { get; init; }
        public string? Vahicle { get; init; }
        
    }
}

