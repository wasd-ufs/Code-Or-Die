using System;
using Mono.Cecil.Cil;

public class ModConstantInversedInstruction : IInstruction
{
    private readonly int _constant;
    private readonly string _register;
    private readonly string _registerResult;

    public ModConstantInversedInstruction(int constant, string register, string registerResult)
    {
        _constant = constant;
        _register = register;
        _registerResult = registerResult;
    }
    
    public void Execute(Interpreter interpreter)
    {
        var a = interpreter.Read(_register);
        if (a == 0)
        {
            interpreter.RaiseException("Mod by zero");
            return;
        }
        
        interpreter.Write(_registerResult, _constant % a);
    }
}