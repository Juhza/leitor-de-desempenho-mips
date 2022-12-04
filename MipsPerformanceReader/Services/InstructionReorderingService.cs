using MipsPerformanceReader.Models;

namespace MipsPerformanceReader.Services
{
    public class InstructionReorderingService : IInstructionReorderingService
    {
        public List<BinaryInstruction> ReorderInstructions(HexadecimalFile file)
        {
            var instructions = file
                .AsBinary()
                .Select(binary => new BinaryInstruction(binary))
                .ToList();
            var reorganizedInstructions = new List<BinaryInstruction>();

            // passar pela lista identificando grupos de instrução dependentes
            for (var i = 0; i < instructions.Count; i++)
            {
                // se a operação for I TYPE OU R TYPE, checar se os imediatos são utilizados na instrução seguinte
                var instruction = instructions[i];
                if (!instruction.HasIntermediates) continue;

                var nextInstruction = instructions[i + 1];

                // ver logica rt rs qual é qual, precisa de conhecimento de mips
                // vamos dizer que o rt de um é o rs de outro, e portanto eles são dependentes
                // mudar o booleano abaixo de acordo com essa lógica

                var shouldReorganize = true;
                if (!shouldReorganize) continue;

                // buscar a próxima instrução que não use esses imediatos e reorganizar
                // adicionar na nova ordem das instruções na lista reorganizedInstructions
            }

            // lista resultante é retornada, e escrita num arquivo no output
            return reorganizedInstructions;
        }
    }
}
