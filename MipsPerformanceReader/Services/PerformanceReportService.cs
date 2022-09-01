using MipsPerformanceReader.Models;
using MipsPerformanceReader.Utils;

namespace MipsPerformanceReader.Services;

public class PerformanceReportService : IPerformanceReportService
{
    private int _totalOfRType = 0;
    private int _totalOfIType = 0;
    private int _totalOfJType = 0;

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

            return new PerformanceReport(totalOfCycles, content.Length, _totalOfRType, _totalOfJType, _totalOfIType);
        }
        catch (Exception)
        {
            throw new Exception("invalidHexadecimalValue");
        }
    }

    private int GetCycleCountByInstructionOpcode(string opcode)
    {
        if (TypeOfInstruction.RType.Contains(opcode))
        {
            _totalOfRType += 1;
            return CyclesPerTypeOfInstruction.RType;
        }

        if (TypeOfInstruction.Jump.Contains(opcode))
        {
            _totalOfJType += 1;
            return CyclesPerTypeOfInstruction.Jump;
        }
        
        if (TypeOfInstruction.Branch.Contains(opcode))
        {
            _totalOfIType += 1;
            return CyclesPerTypeOfInstruction.Branch;
        }
        
        if (TypeOfInstruction.Load.Contains(opcode))
        {
            _totalOfIType += 1;
            return CyclesPerTypeOfInstruction.Load;
        }
        
        if (TypeOfInstruction.Store.Contains(opcode))
        {
            _totalOfIType += 1;
            return CyclesPerTypeOfInstruction.Store;
        }
        
        if (TypeOfInstruction.IType.Contains(opcode))
        {
            _totalOfIType += 1;
            return CyclesPerTypeOfInstruction.IType;
        }

        throw new Exception("missingOpcode");
    }
}