using System.Collections.Generic;
using System.Linq;
using CardLang.analysis;
using CardLang.node;

public class SemanticAnalyzer : DepthFirstAdapter
{
    private readonly Dictionary<string, Placeholder> _currentType = new();
    private readonly Queue<string> _currentOrder = new();
    private readonly Stack<Queue<Placeholder>> _placeholderStack = new();

    private Result _result = Result.Ok;

    private enum Placeholder
    {
        Invalid,
        Undefined,
        Statement,
        Expression
    }

    public enum Result
    {
        Ok,
        ExpectedStatement,
        ExpectedExpression,
        InvalidPlaceholder,
        UnknownPlaceholder,
        InvalidStopStatement,
        UnfilledPlaceholder
    }

    public Result Analyze(Start program)
    {
        _currentType.Clear();
        _currentOrder.Clear();
        _placeholderStack.Clear();
        _result = Result.Ok;
        
        program.Apply(this);
        return _result;
    }

    public override void InAProgramProgram(AProgramProgram node)
    {
        if (_result != Result.Ok)
            return;
        
        _currentType.Clear();
        _currentOrder.Clear();
        _placeholderStack.Clear();
        _result = Result.Ok;
    }

    public override void OutAProgramProgram(AProgramProgram node)
    {
        if (_result != Result.Ok)
            return;
        
        foreach (var placeholder in _placeholderStack)
        {
            if (placeholder.Any(type => type != Placeholder.Statement))
            {
                _result = Result.UnfilledPlaceholder;
                return;
            }
        }
    }

    public override void InAStatementCard(AStatementCard node)
    {
        if (_result != Result.Ok)
            return;
        
        if (_placeholderStack.Count != 0)
        {
            var list = _placeholderStack.Peek();
            if (list.Count == 0)
            {
                _placeholderStack.Pop();
            }
            else
            {
                var needed = list.Peek();
                if (needed != Placeholder.Statement)
                {
                    _result = Result.ExpectedExpression;
                    return;
                }
            }
        }

        _currentOrder.Clear();
        _currentType.Clear();

        foreach (TIdentifier id in node.GetIdentifier())
        {
            _currentOrder.Enqueue(id.Text);
            _currentType.Add(id.Text, Placeholder.Undefined);
        }
    }

    public override void OutAStatementCard(AStatementCard node)
    {
        if (_result != Result.Ok)
            return;
        
        if (_currentOrder.Count == 0)
            return;

        var needed = new Queue<Placeholder>();
        foreach (string id in _currentOrder)
        {
            if (_currentType[id] == Placeholder.Undefined || _currentType[id] == Placeholder.Invalid)
            {
                _result = Result.InvalidPlaceholder;
                return;
            }

            needed.Enqueue(_currentType[id]);
        }

        _placeholderStack.Push(needed);
    }

    public override void InAReturnCard(AReturnCard node)
    {
        if (_result != Result.Ok)
            return;
        
        if (_placeholderStack.Count != 0)
        {
            var list = _placeholderStack.Peek();
            if (list.Count == 0)
            {
                _placeholderStack.Pop();
            }
            else
            {
                var required = list.Dequeue();
                if (required != Placeholder.Expression)
                {
                    _result = Result.ExpectedStatement;
                    return;
                }

                if (list.Count == 0)
                {
                    _placeholderStack.Pop();
                }
            }
        }

        _currentOrder.Clear();
        _currentType.Clear();

        foreach (TIdentifier id in node.GetIdentifier())
        {
            _currentOrder.Enqueue(id.Text);
            _currentType.Add(id.Text, Placeholder.Undefined);
        }
    }

    public override void OutAReturnCard(AReturnCard node)
    {
        if (_result != Result.Ok)
            return;
        
        if (_currentOrder.Count == 0)
            return;

        var needed = new Queue<Placeholder>();
        foreach (string id in _currentOrder)
            needed.Enqueue(_currentType[id]);

        _placeholderStack.Push(needed);
    }

    public override void InAExpressionCard(AExpressionCard node)
    {
        if (_result != Result.Ok)
            return;
        
        if (_placeholderStack.Count != 0)
        {
            var list = _placeholderStack.Peek();
            if (list.Count == 0)
            {
                _placeholderStack.Pop();
            }
            else
            {
                var required = list.Dequeue();
                if (required != Placeholder.Expression)
                {
                    _result = Result.ExpectedStatement;
                    return;
                }

                if (list.Count == 0)
                {
                    _placeholderStack.Pop();
                }
            }
        }

        _currentOrder.Clear();
        _currentType.Clear();
    }

    public override void InAStopCard(AStopCard node)
    {
        if (_result != Result.Ok)
            return;
        
        if (_placeholderStack.Count == 0)
        {
            _result = Result.InvalidStopStatement;
            return;
        }

        var list = _placeholderStack.Peek();
        if (list.Count > 0)
        {
            var needed = list.Peek();
            if (needed != Placeholder.Statement)
            {
                _result = Result.InvalidStopStatement;
                return;
            }
            
            list.Dequeue();
            if (list.Count == 0)
            {
                _placeholderStack.Pop();
            }
        }
    }

    public override void InAIdentifierExpression(AIdentifierExpression node)
    {
        if (_result != Result.Ok)
            return;
        
        if (!_currentType.TryGetValue(node.GetName().Text, out var type))
        {
            _result = Result.UnknownPlaceholder;
            return;
        }

        _currentType[node.GetName().Text] = type is Placeholder.Undefined or Placeholder.Expression
            ? Placeholder.Expression
            : Placeholder.Invalid;
    }

    public override void InAInsertStatement(AInsertStatement node)
    {
        if (_result != Result.Ok)
            return;
        
        if (!_currentType.TryGetValue(node.GetName().Text, out var type))
        {
            _result = Result.UnknownPlaceholder;
            return;
        }

        _currentType[node.GetName().Text] = type is Placeholder.Undefined or Placeholder.Statement
            ? Placeholder.Statement
            : Placeholder.Invalid;
    }
}