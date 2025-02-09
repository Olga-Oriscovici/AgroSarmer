using System.IO;
using Microsoft.AspNetCore.Mvc;
using AgroSarmer.Services;

public class ReportsController : Controller
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    public IActionResult GeneratePdfReport()
    {
        var reportBytes = _reportService.GeneratePdfReport();
        return File(reportBytes, "application/pdf", "CropReport.pdf");
    }

    public IActionResult GenerateExcelReport()
    {
        var reportBytes = _reportService.GenerateExcelReport();
        return File(reportBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CropReport.xlsx");
    }
}

