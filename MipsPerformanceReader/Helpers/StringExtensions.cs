using MipsPerformanceReader.Models;
using MipsPerformanceReader.Utils;

namespace MipsPerformanceReader.Helpers;

public static class StringExtensions
{
    public static string HexadecimalToBinary(this string hexadecimalValue)
    {
        var binaryValue = Convert.ToString(Convert.ToInt32(hexadecimalValue, 16), 2);
        var missingZeros = 32 - binaryValue.Length;
        while (missingZeros > 0)
        {
            binaryValue = string.Concat("0", binaryValue);
            missingZeros -= 1;
        }

        return binaryValue;
    }

    public static string[] BreakBinaryInstruction(this string binaryValue)
    {
        var opcode = binaryValue.Substring(0, 6);

        if (InstructionType.RType.Contains(opcode))
        {
            var rs = binaryValue.Substring(6, 5);
            var rt = binaryValue.Substring(11, 5);
            var rd = binaryValue.Substring(16, 5);
            var shamt = binaryValue.Substring(21, 5);
            var funct = binaryValue.Substring(26, 6);

            return new[] { opcode, rs, rt, rd, shamt, funct };
        }
        else if (InstructionType.IType.Contains(opcode) || InstructionType.Store.Contains(opcode) || 
                 InstructionType.Load.Contains(opcode) || InstructionType.Branch.Contains(opcode))
        {
            var rs = binaryValue.Substring(6, 5);
            var rt = binaryValue.Substring(11, 5);
            var immediate = binaryValue.Substring(16, 16);

            return new[] { opcode, rs, rt, immediate };
        }
        else if (InstructionType.Jump.Contains(opcode))
        {
            var targetAddress = binaryValue.Substring(6, 26);

            return new[] { opcode, targetAddress };
        }

        throw new Exception("missingOpcode");
    }
}