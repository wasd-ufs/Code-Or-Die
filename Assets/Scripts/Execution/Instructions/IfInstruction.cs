public class IfInstruction : IInstruction
{
    private readonly string _conditionRegister;
    private readonly int _skipCount;

    public IfInstruction(string conditionRegister, int skipCount)
    {
        _conditionRegister = conditionRegister;
        _skipCount = skipCount;
    }
    
    public void Execute(Interpreter interpreter)
    {
        var condition = interpreter.Read(_conditionRegister);
        if (condition == 0)
            interpreter.Skip(_skipCount);
    }
}