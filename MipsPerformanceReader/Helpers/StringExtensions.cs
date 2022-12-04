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
        var opcode = binaryValue.Substring(0, 5);

        if (InstructionType.RType.Contains(opcode))
        {
            var rs = binaryValue.Substring(6, 10);
            var rt = binaryValue.Substring(11, 15);
            var rd = binaryValue.Substring(16, 20);
            var shamt = binaryValue.Substring(21, 25);
            var funct = binaryValue.Substring(26, 31);

            var values = new[] { opcode, rs, rt, rd, shamt, funct };
        }
        else if (InstructionType.IType.Contains(opcode) || InstructionType.Store.Contains(opcode) || 
                 InstructionType.Load.Contains(opcode) || InstructionType.Branch.Contains(opcode))
        {
            var rs = binaryValue.Substring(6, 10);
            var rt = binaryValue.Substring(11, 15);
            var immediate = binaryValue.Substring(16, 31);

            return new[] { opcode, rs, rt, immediate };
        }
        else if (InstructionType.Jump.Contains(opcode))
        {
            var targetAddress = binaryValue.Substring(6, 31);

            return new[] { opcode, targetAddress };
        }

        throw new Exception("missingOpcode");
    }
}