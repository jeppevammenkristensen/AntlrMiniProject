namespace AntlrCSharp.Transformers;

public class GenerateData
{
    private readonly List<PropertyData> _properties = new List<PropertyData>();
    public string Name { get; }

    public CreateType CreateType { get; private set; }

    public GenerateData WithCreateType(CreateType createType)
    {
        CreateType = createType;
        return this;
    }

    public IReadOnlyList<PropertyData> Properties => _properties;

    public GenerateData(string name)
    {
        Name = name;
    }

    public void AddProperty(string name, string type)
    {
        _properties.Add(new PropertyData(name, type));
    }
}