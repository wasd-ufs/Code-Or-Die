public class BoolNegInstruction : IInstruction
{
    private readonly string _registerSource;
    private readonly string _registerTarget;

    public BoolNegInstruction(string registerSource, string registerTarget)
    {
        _registerSource = registerSource;
        _registerTarget = registerTarget;
    }
    
    public void Execute(Interpreter interpreter)
    {
        var source = interpreter.Read(_registerSource);
        interpreter.Write(_registerTarget, source == 0 ? 1 : 0);
    }
}