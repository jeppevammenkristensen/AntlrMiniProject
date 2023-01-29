using System.Data;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using AntlrCSharp.Transformers;

namespace AntlrCSharp;

public class BasicCreateVisitor  : CreateBaseVisitor<string>
{
    private readonly List<GenerateData> _data = new List<GenerateData>();
    private GenerateData? _currentData;

    public IReadOnlyList<GenerateData> Data => _data;
    
    public override string VisitCreate(CreateParser.CreateContext context)
    {
        var text = context.IDENTIFIER().GetText();

        if (_currentData != null)
        {
            throw new InvalidOperationException($"Expected {nameof(_currentData)} to not be null");
        }

        _currentData = new GenerateData(text);

        if (context.createType() is { } createType)
        {
            var type = createType.GetChild(0) switch
            {
                RuleContext {RuleIndex: CreateParser.RULE_class} => CreateType.Class,
                RuleContext {RuleIndex: CreateParser.RULE_interface} => CreateType.Interface,
                RuleContext {RuleIndex: CreateParser.RULE_record} => CreateType.Record,
                _ => throw new ArgumentOutOfRangeException()
            };

            _currentData.WithCreateType(type);
        }

        var result =  base.VisitCreate(context);
        _data.Add(_currentData);
        _currentData = null;
        return result;
    }

    public override string VisitPropertydeclaration(CreateParser.PropertydeclarationContext context)
    {
        var current = _currentData ??
                      throw new InvalidOperationException(
                          "Expected current to not be null in the proeprty declaration part");
        
        foreach (var type in context.identifiernamedeclaration())
        {
            var typeText = type.GetText();
            current.AddProperty(type.IDENTIFIER().GetText(), type.identifiertype().GetText());
           
        }

        return base.VisitPropertydeclaration(context);
    }
}