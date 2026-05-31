using Mono.Cecil.Cil;

public class EqualsConstantInstruction : IInstruction
{
    private readonly string _register;
    private readonly int _constant;
    private readonly string _registerResult;

    public EqualsConstantInstruction(string register, int constant, string registerResult)
    {
        _register = register;
        _constant = constant;
        _registerResult = registerResult;
    }
    
    public void Execute(Interpreter interpreter)
    {
        var a = interpreter.Read(_register);
        interpreter.Write(_registerResult, a == _constant ? 1 : 0);
    }
}