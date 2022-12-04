using MipsPerformanceReader.Models;

namespace MipsPerformanceReader.Services
{
    public interface IInstructionReorderingService
    {
        List<BinaryInstruction> ReorderInstructions(HexadecimalFile file);
    }
}