namespace MipsPerformanceReader.Models;

public class PerformanceReport
{
    public int TotalOfCycles { get; }
    public int TotalOfInstructions { get; }
    public double CyclesPerInstruction { get; }

    public PerformanceReport(int totalOfCycles, int totalOfInstructions)
    {
        TotalOfCycles = totalOfCycles;
        TotalOfInstructions = totalOfInstructions;
        CyclesPerInstruction = totalOfCycles / (double)totalOfInstructions;
    }
}