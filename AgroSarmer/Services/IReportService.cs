using System.IO;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using AgroSarmer.Models;

namespace AgroSarmer.Services
{
    public interface IReportService
    {
        byte[] GeneratePdfReport();
        byte[] GenerateExcelReport();
    }

    public class ReportService : IReportService
    {
        private readonly List<Crop> _crops = new List<Crop>
        {
            new Crop { Name = "Wheat", Description = "Cereal used to make flour" },
            new Crop { Name = "Сorn", Description = "Cereal used in food industry" },
            // Добавьте другие культуры
        };

        public byte[] GeneratePdfReport()
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document();
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                document.Add(new Paragraph("Report on crops and field conditions"));
                foreach (var crop in _crops)
                {
                    document.Add(new Paragraph($"{crop.Name}: {crop.Description}"));
                }
                document.Close();
                return memoryStream.ToArray();
            }
        }

        public byte[] GenerateExcelReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Отчет");
                worksheet.Cells[1, 1].Value = "Отчет о посевах и состоянии полей";
                for (int i = 0; i < _crops.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = _crops[i].Name;
                    worksheet.Cells[i + 2, 2].Value = _crops[i].Description;
                }
                return package.GetAsByteArray();
            }
        }
    }
}
