using CardLang.analysis;
using CardLang.node;

public class TreeAnalyzer : DepthFirstAdapter
{
    private int _indentation;
    private string _tree;

    public string GetTreeString(Start start)
    {
        _indentation = 0;
        _tree = string.Empty;

        start.Apply(this);
        return _tree;
    }

    public override void DefaultIn(Node node)
    {
        _indentation++;
        for (int i = 0; i < _indentation; i++)
            _tree += '\t';
        
        _tree += node.GetType().FullName + '\n';
    }

    public override void DefaultOut(Node node)
    {
        _indentation--;
    }
}