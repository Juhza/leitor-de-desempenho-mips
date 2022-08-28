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
}