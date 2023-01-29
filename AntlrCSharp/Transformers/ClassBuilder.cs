using System.Text;

namespace AntlrCSharp.Transformers;

public class ClassBuilder
{
    public void Build(GenerateData data, StringBuilder builder)
    {
        builder.AppendLine($"public class {data.Name}");
        builder.AppendLine("{");
        foreach (var (name, type) in data.Properties)
        {
            builder.AppendLine($"\tpublic {type} {name} {{get; set; }}");
        }

        builder.AppendLine("}");

    }
}