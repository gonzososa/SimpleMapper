[AttributeUsage(AttributeTargets.Class)]
public class MapClassAttribute : Attribute
{
    private readonly string _className;

    public MapClassAttribute (string srcType)
    {
        _className = srcType;
    }

    public string ClassName => _className;

}