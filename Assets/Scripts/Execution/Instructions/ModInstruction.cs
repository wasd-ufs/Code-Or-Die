public class ModInstruction : IInstruction
{
    private readonly string _registerA;
    private readonly string _registerB;
    private readonly string _registerResult;

    public ModInstruction(string registerA, string registerB, string registerResult)
    {
        _registerA = registerA;
        _registerB = registerB;
        _registerResult = registerResult;
    }
    
    public void Execute(Interpreter interpreter)
    {
        var a = interpreter.Read(_registerA);
        var b = interpreter.Read(_registerB);

        if (b == 0)
        {
            interpreter.RaiseException("Mod by 0");
            return;
        }
        
        interpreter.Write(_registerResult, a % b);
    }
}