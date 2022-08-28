using MipsPerformanceReader.Helpers;

namespace MipsPerformanceReader.Models;

public class HexadecimalFile
{
    public string[] Content { get; set; } = null!;

    public string[] AsBinary()
    {
        var contentAsBinary = new List<string>();
        foreach (var value in Content)
        {
            if (string.IsNullOrWhiteSpace(value)) continue;
            contentAsBinary.Add(value.HexadecimalToBinary());
        }

        return contentAsBinary.ToArray();
    }
}