public class SkipInstruction : IInstruction
{
    private readonly int skipCount;

    public SkipInstruction(int skipCount)
    {
        this.skipCount = skipCount;
    }
    
    public void Execute(Interpreter interpreter)
    {
        interpreter.Skip(skipCount);
    }
}