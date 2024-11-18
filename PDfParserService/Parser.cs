using System.Text;
using System.Text.RegularExpressions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using PdfParser.RecordEntity;

namespace PdfParser.PdfParserService
{
    public class ExtractTextFromPdf
    {
        private string Parser(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            using (PdfDocument pdf = new PdfDocument(reader))
            {
                StringBuilder text = new StringBuilder();
                for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(pdf.GetPage(i)));
                }
                return text.ToString();
            }
        }

        public Entity InjectPdfString(string path)
        {

            string data = Parser(path);


            string orderId = Regex.Match(data, @"Release ID (\w+)").Groups[1].Value;


            string vin = Regex.Match(data, @"VIN\s([\w\d]+)").Groups[1].Value;


            // string pickUpLocation = Regex.Match(data, @"Pickup Location\s*(.*\n.*)").Groups[1].Value.Trim();
            string pickUpLocation = Regex.Match(data, @"Pickup Location\s*(.*?)(?=\nBuyer)", RegexOptions.Singleline).Groups[1].Value.Trim();


            // string deliveryInformation = Regex.Match(data, @"Buyer\s*Name\s*(.*)\nAddress\s*(.*\n.*)").Groups[1].Value.Trim();

            string deliveryInformation = Regex.Match(data, @"Buyer\s*Name\s*(.*?)(?=\nAnnouncements)", RegexOptions.Singleline).Groups[1].Value.Trim();


            string dealer = Regex.Match(data, @"Buyer\s*Name\s*(.*)").Groups[1].Value.Trim();


            string pickUpInstruction = "";


       
            string vehicleInfo = Regex.Match(data, @"YMMT\s([\w\s\d]+)\nVehicle").Groups[1].Value.Trim();

         
            string color = Regex.Match(data, @"Color\s([\w]+)").Groups[1].Value.Trim();

      
            string body = Regex.Match(data, @"Body\s([\w]+)").Groups[1].Value.Trim();

           
            string fullVehicleInfo = $"{vehicleInfo}, Color: {color}, Body: {body}";


            return new Entity
            {
                OrderID = orderId,
                VIN = vin,
                PickupInformation = pickUpLocation,
                DeliveryInformation = deliveryInformation,
                Dealers = dealer,
                AdditionalInformation = pickUpInstruction,
                Vahicle = fullVehicleInfo
            };
        }
    }
}
