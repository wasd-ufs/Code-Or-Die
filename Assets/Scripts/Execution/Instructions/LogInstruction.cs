using Mono.Cecil.Cil;
using UnityEngine;

public class LogInstruction : IInstruction
{
    private readonly string _register;

    public LogInstruction(string register)
    {
        _register = register;
    }
    
    public void Execute(Interpreter interpreter)
    {
        var value = interpreter.Read(_register);
        Debug.Log(value);
    }
}