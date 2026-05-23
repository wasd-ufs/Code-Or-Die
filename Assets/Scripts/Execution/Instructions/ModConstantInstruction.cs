using System;
using Mono.Cecil.Cil;

public class ModConstantInstruction : IInstruction
{
    private readonly string _register;
    private readonly int _constant;
    private readonly string _registerResult;

    public ModConstantInstruction(string register, int constant, string registerResult)
    {
        _register = register;
        _constant = constant;
        _registerResult = registerResult;
    }
    
    public void Execute(Interpreter interpreter)
    {
        if (_constant == 0)
        {
            interpreter.RaiseException("Mod by zero");
            return;
        }
        
        var a = interpreter.Read(_register);
        interpreter.Write(_registerResult, a % _constant);
    }
}