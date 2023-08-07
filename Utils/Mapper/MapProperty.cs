[AttributeUsage(AttributeTargets.Property)]
public class MapPropertyAttribute : Attribute
{
    private readonly string _propertyName;

    public MapPropertyAttribute(string propertyName)
    {
        _propertyName = propertyName;
    }

    public string PropertyName => this._propertyName;

    public string PropertyType => this.GetType().ToString();
}