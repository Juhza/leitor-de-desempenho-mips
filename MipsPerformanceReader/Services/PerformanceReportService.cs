using MipsPerformanceReader.Models;
using MipsPerformanceReader.Utils;

namespace MipsPerformanceReader.Services;

public class PerformanceReportService : IPerformanceReportService
{
    public PerformanceReport GetReport(HexadecimalFile file)
    {
        try
        {
            var content = file.AsBinary();
            var totalOfCycles = 0;

            foreach (var binaryValue in content)
            {
                var opcode = binaryValue.Substring(0, 6);
                totalOfCycles += GetCycleCountByInstructionOpcode(opcode);
            }

            return new PerformanceReport(totalOfCycles, file.Content.Length);
        }
        catch (Exception)
        {
            throw new Exception("invalidHexadecimalValue");
        }
    }

    private int GetCycleCountByInstructionOpcode(string opcode)
    {
        if (TypeOfInstruction.RType.Contains(opcode))
            return CyclesPerTypeOfInstruction.RType;
        if (TypeOfInstruction.Jump.Contains(opcode))
            return CyclesPerTypeOfInstruction.Jump;
        if (TypeOfInstruction.Branch.Contains(opcode))
            return CyclesPerTypeOfInstruction.Branch;
        if (TypeOfInstruction.Load.Contains(opcode))
            return CyclesPerTypeOfInstruction.Load;
        if (TypeOfInstruction.Store.Contains(opcode))
            return CyclesPerTypeOfInstruction.Store;
        if (TypeOfInstruction.IType.Contains(opcode))
            return CyclesPerTypeOfInstruction.IType;

        throw new Exception("missingOpcode");
    }
}