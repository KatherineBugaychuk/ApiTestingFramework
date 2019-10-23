using System.Linq;
using System.Reflection;

namespace ApiTestFramework.Utilities
{
    public static class PropertyUtilities
    {
        public static string PropertiesToString(this object obj)
        {
            var properties = obj.GetType().GetProperties(CommonValues.PropertiesInCurrentClass);
            return string.Join(", ", properties.ToList().Select(property => $"{property.Name}: {GetPropertyValue(property, obj)}").ToList());
        }

        private static string GetPropertyValue(PropertyInfo property, object obj)
        {
            var propertyValue = property.GetValue(obj);
            if (propertyValue == null)
            {
                return string.Empty;
            }
            return IsPrimitive(propertyValue) ? propertyValue.ToString() : PropertiesToString(propertyValue);
        }

        private static bool IsPrimitive(object obj)
        {
            var type = obj.GetType();
            return type.IsPrimitive || type == typeof(string);
        }
    }
}
