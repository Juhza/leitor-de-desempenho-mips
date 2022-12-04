using MipsPerformanceReader.Models;
using MipsPerformanceReader.Utils;

namespace MipsPerformanceReader.Services;

public class PerformanceReportService : IPerformanceReportService
{
    private int _totalOfRType;
    private int _totalOfIType;
    private int _totalOfJType;

    public PerformanceReport GetReport(HexadecimalFile file)
    {
        try
        {
            var content = file.AsBinary();
            var totalOfCycles = 0;
            
            _totalOfRType = 0;
            _totalOfIType = 0;
            _totalOfJType = 0;

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
        if (InstructionType.RType.Contains(opcode))
        {
            _totalOfRType += 1;
            return CyclesPerTypeOfInstruction.RType;
        }

        if (InstructionType.Jump.Contains(opcode))
        {
            _totalOfJType += 1;
            return CyclesPerTypeOfInstruction.Jump;
        }
        
        if (InstructionType.Branch.Contains(opcode))
        {
            _totalOfIType += 1;
            return CyclesPerTypeOfInstruction.Branch;
        }
        
        if (InstructionType.Load.Contains(opcode))
        {
            _totalOfIType += 1;
            return CyclesPerTypeOfInstruction.Load;
        }
        
        if (InstructionType.Store.Contains(opcode))
        {
            _totalOfIType += 1;
            return CyclesPerTypeOfInstruction.Store;
        }
        
        if (InstructionType.IType.Contains(opcode))
        {
            _totalOfIType += 1;
            return CyclesPerTypeOfInstruction.IType;
        }

        throw new Exception("missingOpcode");
    }
}