public class WriteInstruction : IInstruction
{
    private readonly string _register;
    private readonly int _value;

    public WriteInstruction(string register, int value)
    {
        _register = register;
        _value = value;
    }

    public void Execute(Interpreter interpreter)
    {
        interpreter.Write(_register, _value);
    }
}