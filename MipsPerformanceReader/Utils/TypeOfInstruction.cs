namespace MipsPerformanceReader.Utils;

public static class TypeOfInstruction
{
    public static readonly string[] Load = { "100000", "100100", "100001", "100101", "100011", "001111" };
    public static readonly string[] Store = { "101000", "101001", "101011" };
    public static readonly string[] Branch = { "000100", "000001", "000111", "000110", "000101" };
    public static readonly string[] Jump = { "000010", "000011" };
    public static readonly string[] RType = { "000000" };
    public static readonly string[] IType = { "001000", "001001", "001100", "001101", "001010", "001011" }; // verificar todos, n tenho certeza
                                                                                                            // faltam 111001, 001110, ver onde encaixa
}