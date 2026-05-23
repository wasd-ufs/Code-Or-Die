public class RewindInstruction : IInstruction
{
    private readonly int _rewindCount;

    public RewindInstruction(int rewindCount)
    {
        _rewindCount = rewindCount;
    }
    
    public void Execute(Interpreter interpreter)
    {
        interpreter.Rewind(_rewindCount);
    }
}