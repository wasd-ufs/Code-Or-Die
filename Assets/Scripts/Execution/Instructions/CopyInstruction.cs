public class CopyInstruction : IInstruction
{
    private readonly string _sourceRegister;
    private readonly string _targetRegister;

    public CopyInstruction(string sourceRegister, string targetRegister)
    {
        _sourceRegister = sourceRegister;
        _targetRegister = targetRegister;
    }
    
    public void Execute(Interpreter interpreter)
    {
        var value = interpreter.Read(_sourceRegister);
        interpreter.Write(_targetRegister, value);
    }
}