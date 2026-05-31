public class ExportInstruction : IInstruction
{
    private readonly string _sourceRegister;
    private ExternalVariable _target;

    public ExportInstruction(string sourceRegister, ref ExternalVariable target)
    {
        _sourceRegister = sourceRegister;
        _target = target;
    }
    
    public void Execute(Interpreter interpreter)
    {
        _target.Value = interpreter.Read(_sourceRegister);
    }
}

public class ExternalVariable
{
    public int Value { get; set; }
}