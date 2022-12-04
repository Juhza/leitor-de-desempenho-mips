namespace MipsPerformanceReader.Utils;

public static class InstructionType
{
    public static readonly string[] RType =
    {
        "000000" // all r-type
    };
    
    public static readonly string[] Load =
    {
        "100000", // lb
        "100001", // lh
        "100011", // lw
        "100100", // lbu
        "100101" // lhu
    };
    
    public static readonly string[] Store =
    {
        "101000", // sb
        "101001", // sh
        "101011" // sw
    };
    
    public static readonly string[] Branch =
    {
        "000001", // bltz bgez
        "000100", // beq
        "000101", // bne
        "000110", // blez
        "000111" // bgtz
    };
    
    public static readonly string[] Jump =
    {
        "000010", // j
        "000011" // jal
    };
    
    public static readonly string[] IType =
    {
        "001000", // addi
        "001001", // addiu
        "001010", // slti
        "001011", // sltiu
        "001100", // andi
        "001101", // ori
        "001110", // xori
        "001111" // lui
    };
}