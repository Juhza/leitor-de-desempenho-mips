using MipsPerformanceReader.Models;

namespace MipsPerformanceReader.Services
{
    public interface INopAdditionService
    {
        List<BinaryInstruction> AddNops(HexadecimalFile file);
    }
}