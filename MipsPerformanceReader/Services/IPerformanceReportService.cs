using MipsPerformanceReader.Models;

namespace MipsPerformanceReader.Services;

public interface IPerformanceReportService
{
    PerformanceReport GetReport(HexadecimalFile file);
}