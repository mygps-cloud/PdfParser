using PdfParser.PdfParserService;

namespace PdfParser.Exstension
{
   public static class DIConfigureService
    {
        public static IServiceCollection Add_DIServces(this IServiceCollection serviceDescriptors)
        {
          serviceDescriptors.AddSingleton<ExtractTextFromPdf>();

          return serviceDescriptors;

        }
        
    }
}