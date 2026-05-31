using System;
using System.Collections.Generic;

public class Interpreter
{
    private readonly List<IInstruction> _instructions;
    private readonly Dictionary<string, int> _memory;
    
    private int _pointer;
    private String _exception;
    
    private IInstruction CurrentInstruction => _instructions[_pointer];

    public Interpreter(ICollection<IInstruction> instructions)
    {
        _instructions = new List<IInstruction>(instructions);
        
        _exception = null;
        _pointer = 0;
        
        _memory = new Dictionary<string, int>();
    }

    public void Reset()
    {
        _exception = null;
        _pointer = 0;
        
        _memory.Clear();
    }

    public void Next()
    {
        if (HasFinished())
            return;

        CurrentInstruction.Execute(this);
        _pointer++;
    }

    public void Rewind(int amount)
    {
        if (HasFinished())
            return;
        
        _pointer = Math.Max(_pointer - amount - 1, 0);
    }

    public void Skip(int amount)
    {
        if (HasFinished())
            return;
        
        _pointer = Math.Min(_pointer + amount, _instructions.Count);
    }

    public void Write(string name, int value)
    {
        if (HasFinished())
            return;
        
        _memory[name] = value;
    }

    public int Read(string name) => _memory.GetValueOrDefault(name, 0);
    

    public void RaiseException(string message)
    {
        if (HasFinished())
            return;
        
        _exception = message;
    }

    public int? GetLastExecutedInstructionIndex() => _pointer == 0 ? null : _pointer - 1;
    public IInstruction GetLastExecutedInstruction() => _pointer == 0 ? null : _instructions[_pointer - 1];
    public String GetException() => _exception;
    
    public bool HasFaulted() => _exception != null;
    public bool HasFinished() => _pointer >= _instructions.Count || HasFaulted();
}