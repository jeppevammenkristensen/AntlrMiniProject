using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.VisualBasic;

namespace AntlrCSharp.Transformers;

public class DataTransformer
{


    public void Build(GenerateData data, StringBuilder stringBuilder)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        if (stringBuilder == null) throw new ArgumentNullException(nameof(stringBuilder));

        if (data.CreateType == CreateType.Class)
        {
            var builder = new ClassBuilder();
            builder.Build(data, stringBuilder);
        }
        else if (data.CreateType == CreateType.Interface)
        {
            var builder = new InterfaceBuilder();
            builder.Build(data, stringBuilder);
        }
        else if (data.CreateType == CreateType.Record)
        {
            var builder = new RecordBuilder();
            builder.Build(data,stringBuilder);
        }
        else
        {
            throw new InvalidOperationException("Scenario with no builder");
        }
    }
}