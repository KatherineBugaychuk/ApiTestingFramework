using System.Linq;
using System.Reflection;

namespace ApiTestingFramework.Utilities
{
    public static class PropertyUtilities
    {
        public static readonly BindingFlags PropertiesInCurrentClass = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        public static string PropertiesToString(this object obj)
        {
            var properties = obj.GetType().GetProperties(PropertiesInCurrentClass);
            return string.Join(", ", properties.ToList().Select(property => $"{property.Name}: {GetPropertyValue(property, obj)}").ToList());
        }

        public static bool IsPrimitive(object obj)
        {
            if (obj == null)
                return false;
            var type = obj.GetType();
            return type.IsPrimitive || type == typeof(string);
        }

        private static string GetPropertyValue(PropertyInfo property, object obj)
        {
            var propertyValue = property.GetValue(obj);
            if (propertyValue == null)
            {
                return "null";
            }
            return IsPrimitive(propertyValue) ? propertyValue.ToString() : PropertiesToString(propertyValue);
        }
    }
}
