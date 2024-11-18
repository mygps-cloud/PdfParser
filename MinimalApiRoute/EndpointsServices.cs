using PdfParser.PdfParserService;
using PdfParser.RecordEntity;

namespace PdfParser.MinimalApiRoute
{
    public static class EndpointsServices
    {
        public static void AddPdfParserEndpointsServices(this IEndpointRouteBuilder app)
        {
            var entityGroup = app.MapGroup("Entity");

            entityGroup.MapGet("/GetPdfData", GetPdfData).WithName(nameof(GetPdfData));
        }

        public static Task<Entity> GetPdfData(ExtractTextFromPdf extractTextFromPdf)
        {

            var pdfExtractor =  extractTextFromPdf.InjectPdfString("foto/Byer.pdf");

            var result = new Entity
            {
                OrderID=pdfExtractor.OrderID,
                DeliveryInformation =pdfExtractor.DeliveryInformation ,
                PickupInformation=pdfExtractor.PickupInformation,
                AdditionalInformation=pdfExtractor.AdditionalInformation,
                Vahicle = pdfExtractor.Vahicle,
                Dealers=pdfExtractor.Dealers,
                VIN=pdfExtractor.VIN,
            
            };
            Console.WriteLine(result);

            return Task.FromResult(result);
        }
    }
}
