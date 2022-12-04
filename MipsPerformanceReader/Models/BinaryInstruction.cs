using MipsPerformanceReader.Helpers;
using MipsPerformanceReader.Utils;

namespace MipsPerformanceReader.Models
{
    public class BinaryInstruction
    {
        public string Opcode { get; set; }
        public int ClockCycles { get; set; }
        public string[] BinaryFields { get; set; }
        public bool HasIntermediates { get; set; }

        public BinaryInstruction(string binary)
        {
            BinaryFields = binary.BreakBinaryInstruction();
            Opcode = BinaryFields.First();
            ClockCycles = GetCycleCountByInstructionOpcode(Opcode);
            HasIntermediates = !InstructionType.Jump.Contains(Opcode);
        }

        private int GetCycleCountByInstructionOpcode(string opcode)
        {
            if (InstructionType.RType.Contains(opcode))
                return CyclesPerTypeOfInstruction.RType;

            if (InstructionType.Jump.Contains(opcode))
                return CyclesPerTypeOfInstruction.Jump;

            if (InstructionType.Branch.Contains(opcode))
                return CyclesPerTypeOfInstruction.Branch;

            if (InstructionType.Load.Contains(opcode))
                return CyclesPerTypeOfInstruction.Load;

            if (InstructionType.Store.Contains(opcode))
                return CyclesPerTypeOfInstruction.Store;

            if (InstructionType.IType.Contains(opcode))
                return CyclesPerTypeOfInstruction.IType;

            throw new Exception("missingOpcode");
        }
    }
}
