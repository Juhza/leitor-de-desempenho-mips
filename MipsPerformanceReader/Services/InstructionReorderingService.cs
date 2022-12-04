using MipsPerformanceReader.Models;

namespace MipsPerformanceReader.Services
{
    public class InstructionReorderingService : IInstructionReorderingService
    {
        private List<BinaryInstruction> _instructions = null!;

        public List<BinaryInstruction> ReorderInstructions(HexadecimalFile file)
        {
            _instructions = file
                .AsBinary()
                .Select(binary => new BinaryInstruction(binary))
                .ToList();
            var reorganizedInstructions = new List<BinaryInstruction>();

            // passar pela lista identificando grupos de instrução dependentes
            for (var i = 0; i < _instructions.Count; i++)
            {
                // se a operação for I TYPE OU R TYPE, checar se os imediatos são utilizados na instrução seguinte
                var instruction = _instructions[i];
                if (!instruction.HasIntermediates) continue;

                var nextInstruction = _instructions[i + 1];

                // ver logica rt rs qual é qual, precisa de conhecimento de mips
                // vamos dizer que o rt de um é o rs de outro, e portanto eles são dependentes
                // mudar o booleano abaixo de acordo com essa lógica

                var shouldReorganize = true;
                if (!shouldReorganize) continue;

                // buscar a próxima instrução que não use esses imediatos e reorganizar
                var instructionToRelocate = FindNextToRelocate(currentIndex: i, dependentIntermediates: new[] { string.Empty }); // trocar pelos intermediates

                // adicionar na nova ordem das instruções na lista reorganizedInstructions
            }

            // lista resultante é retornada, e escrita num arquivo no output
            return reorganizedInstructions;
        }

        private BinaryInstruction FindNextToRelocate(int currentIndex, string[] dependentIntermediates)
        {
            var currentInstruction = _instructions[currentIndex];

            for (int i = currentIndex; i < _instructions.Count; i++)
            {
                var instruction = _instructions[i];
                var usesAnyOfTheDependentIntermediates = dependentIntermediates.Any(value => instruction.BinaryFields.Contains(value));
                var clockCyclesFit = instruction.ClockCycles <= currentInstruction.ClockCycles;
                
                // ver se isso tá certo, tô considerando se a quantidade dos ciclos for maior não cabe para realocação
                if (usesAnyOfTheDependentIntermediates || !clockCyclesFit) continue;

                return instruction;
            }

            throw new Exception("noInstructionsToRelocate");
        }
    }
}
