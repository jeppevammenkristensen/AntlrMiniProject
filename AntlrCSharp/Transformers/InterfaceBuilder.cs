using System.Text;

namespace AntlrCSharp.Transformers;

public class InterfaceBuilder
{
    public void Build(GenerateData data, StringBuilder builder)
    {
        builder.AppendLine($"public interface {data.Name}");
        builder.AppendLine("{");
        foreach (var (name, type) in data.Properties)
        {
            builder.AppendLine($"\t{type} {name} {{get; set; }}");
        }

        builder.AppendLine("}");

    }
}