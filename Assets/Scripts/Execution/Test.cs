using System;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        var program = new List<IInstruction>
        {
            new WriteInstruction("initial", 37),
            new CopyInstruction("initial", "x"),
            
            // Print
            new LogInstruction("x"),
            
            new EqualsConstantInstruction("x", 1, "ended"),
            new BoolNegInstruction("ended", "notEnded"),
            new IfInstruction("notEnded", 7),
            
            // if X is Odd
            new ModConstantInstruction("x", 2, "isOdd"),
            new IfInstruction("isOdd", 3),
            new MulConstantInstruction("x", 3, "x"),
            new AddConstantInstruction("x", 1, "x"),
            new SkipInstruction(1),
            
            // else
            new DivConstantInstruction("x", 2, "x"),
            
            // Return to Print
            new RewindInstruction(10)
        };

        var interpreter = new Interpreter(program);

        int counter = 0;
        while (counter < program.Count * 100 && !interpreter.HasFinished())
        {
            interpreter.Next();
            counter++;
        }

        if (interpreter.HasFaulted())
        {
            Debug.LogError("Exception at Instruction #" + interpreter.GetLastExecutedInstructionIndex() + ": " + interpreter.GetException());
        }
    }
}
