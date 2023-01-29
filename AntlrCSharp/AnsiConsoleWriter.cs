using System.Text;
using Spectre.Console;

namespace AntlrCSharp;

public class AnsiConsoleErrorWriter : TextWriter
{
    public override Encoding Encoding { get; }

    public override void Write(string? format)
    {
        AnsiConsole.MarkupInterpolated($"[red]{format}[/]");
    }
}

public class AnsiConsoleWriter : TextWriter
{
    

    public override Encoding Encoding { get; }

    public override void Write(string? format)
    {
        AnsiConsole.MarkupInterpolated($"[green]{format}[/]");
    }
}