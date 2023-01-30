using System.Text;
using Antlr4.Runtime;
using AntlrCSharp;
using AntlrCSharp.Transformers;
using Spectre.Console;

while (true)
{
    var item = AnsiConsole.Ask<string>("[green]Enter:[/]");


    var result =
        ParseAndGetResult(item);
    AnsiConsole.MarkupLine(result ?? string.Empty);

    if (result is {})
        TextCopy.ClipboardService.SetText(result);
}

static string? ParseAndGetResult(string input)
{
    try
    {
        AntlrInputStream inputStream = new($"{input}");
        CreateLexer lexer = new(inputStream, new AnsiConsoleWriter(), new AnsiConsoleErrorWriter());
        CommonTokenStream commonTokenStream = new(lexer);
        CreateParser parser = new(commonTokenStream, new AnsiConsoleWriter(), new AnsiConsoleErrorWriter());
        
        CreateParser.CreateContext chatContext = parser.create();
        if (parser.NumberOfSyntaxErrors > 0)
        {
            AnsiConsole.MarkupLine("[red]Failed to parse input[/]");
            return null;
        }

        BasicCreateVisitor visitor = new();
        visitor.Visit(chatContext);
        var transformer = new DataTransformer();

        var builder = new StringBuilder();
        transformer.Build(visitor.Data[0], builder);

        return builder.ToString();
    }
    catch (Exception ex)
    {
        AnsiConsole.WriteException(ex);
    }

    return null;
}