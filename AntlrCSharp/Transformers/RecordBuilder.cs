using System.Text;

namespace AntlrCSharp.Transformers;

public class RecordBuilder
{
    public void Build(GenerateData data, StringBuilder builder)
    {
        builder.Append($"public record {data.Name}(");
        
        foreach (var (name, type, index) in data.Properties.Select((x,i) => (x.Name, x.Type, i)))
        {
            builder.Append($"{type} {name}");
            if (data.Properties.Count > index + 1)
            {
                builder.Append(',');
            }
        }

        builder.AppendLine(")");
    }
}