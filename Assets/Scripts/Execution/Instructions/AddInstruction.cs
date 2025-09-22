using System;
using Mono.Cecil.Cil;

public class AddInstruction : IInstruction
{
    private readonly string _registerA;
    private readonly string _registerB;
    private readonly string _registerResult;

    public AddInstruction(string registerA, string registerB, string registerResult)
    {
        _registerA = registerA;
        _registerB = registerB;
        _registerResult = registerResult;
    }
    
    public void Execute(Interpreter interpreter)
    {
        var a = interpreter.Read(_registerA);
        var b = interpreter.Read(_registerB);
        interpreter.Write(_registerResult, a + b);
    }
}