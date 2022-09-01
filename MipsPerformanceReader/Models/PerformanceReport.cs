namespace MipsPerformanceReader.Models;

public class PerformanceReport
{
    public int TotalOfCycles { get; }
    public int TotalOfInstructions { get; }
    public int TotalOfIType { get; }
    public int TotalOfRType { get; }
    public int TotalOfJType { get; }
    public double CyclesPerInstruction { get; }

    public PerformanceReport(int totalOfCycles, int totalOfInstructions,
        int totalOfRType, int totalOfJType, int totalOfIType)
    {
        TotalOfCycles = totalOfCycles;
        TotalOfInstructions = totalOfInstructions;
        
        TotalOfIType = totalOfIType;
        TotalOfJType = totalOfJType;
        TotalOfRType = totalOfRType;

        CyclesPerInstruction = totalOfCycles / (double)totalOfInstructions;
    }
}