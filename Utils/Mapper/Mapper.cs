using System.Reflection;

namespace SimpleMapper.Utils.Mapper;

public class Mapper
{
    public static T Map<T>(object input) where T : new()
    {
        T obj = new T ();

        MapClassAttribute[] classAttributes = (MapClassAttribute[])obj.GetType().GetCustomAttributes(typeof(MapClassAttribute), false);

        if (classAttributes != null && classAttributes[0].ClassName.Equals (input.GetType().Name))
        {
            Dictionary<string, MapPropertyAttribute> propAttrs = new Dictionary<string, MapPropertyAttribute>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                MapPropertyAttribute[] qma = (MapPropertyAttribute[])prop.GetCustomAttributes(typeof(MapPropertyAttribute), false);

                if (qma.Any ())
                {
                    MapPropertyAttribute qpp = qma[0];

                    if (qpp.PropertyName.Contains ('.')) //just handle one hierarchy level >> Object.Property
                    {
                        string [] parts = qpp.PropertyName.Split ('.');
                        var value = input.GetType()?.GetProperty(parts[0])?.GetValue (input, null);
                        var newValue = value.GetType()?.GetProperty(parts[1])?.GetValue (value, null);

                        if (newValue != null)
                        {
                            obj.GetType().GetProperty(prop.Name).SetValue (obj, newValue);
                        }

                        continue;
                    }

                    if (input.GetType()?.GetProperty(qpp.PropertyName)?.GetValue (input, null) != null)
                    {
                        var value = input.GetType().GetProperty(qpp.PropertyName).GetValue (input, null);
                        obj.GetType().GetProperty(prop.Name).SetValue (obj, value, null);
                    }
                }
            }
        }
        else
        {
            throw new ArgumentException ("Wrong object");
        }

        return obj;
    }
}