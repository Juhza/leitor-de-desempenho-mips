using MipsPerformanceReader.Models;

namespace MipsPerformanceReader.Services
{
    public class NopAdditionService : INopAdditionService
    {
        private List<BinaryInstruction> _instructions = null!;
        private BinaryInstruction _nop = new BinaryInstruction(binary: "00000000000000000000000000000000");
        private int _nopsToAdd = 2;

        public List<BinaryInstruction> AddNops(HexadecimalFile file)
        {
            _instructions = file
                .AsBinary()
                .Select(binary => new BinaryInstruction(binary))
                .ToList();
            var instructionsWithNops = new List<BinaryInstruction>();

            for (var i = 0; i < _instructions.Count; i++)
            {
                var instruction = _instructions[i];
                instructionsWithNops.Add(instruction);

                if (!instruction.HasIntermediates || i == _instructions.Count - 1)
                {
                    _nopsToAdd = _nopsToAdd < 2 ? _nopsToAdd + 1 : _nopsToAdd;
                    continue;
                }

                var nextInstruction = _instructions[i + 1];

                var shouldAddNop = IsNopNeeded(instruction, nextInstruction);
                if (!shouldAddNop) continue;

                for (var j = 0; j < _nopsToAdd; j++)
                {
                    instructionsWithNops.Add(_nop);
                }

                _nopsToAdd -= 1;
            }

            return instructionsWithNops;
        }

        private bool IsNopNeeded(BinaryInstruction instruction, BinaryInstruction nextInstruction)
        {
            var destination = instruction.BinaryFields[3];
            var destinationIsUsedNext = nextInstruction.BinaryFields[1] == destination || nextInstruction.BinaryFields[2] == destination;
            return destinationIsUsedNext;
        }
    }
}
