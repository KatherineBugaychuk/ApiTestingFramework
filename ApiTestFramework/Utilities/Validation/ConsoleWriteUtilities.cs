using System.Linq;

namespace ApiTestFramework.Utilities.Validation
{
    public static class ConsoleWriteUtilities
    {
        public static string ConvertToString(this object obj)
        {
            var fields = obj.GetType().GetFields(CommonValues.PropertiesInCurrentClass);
            return $"{{{string.Join(", ", $"\"{fields.Select(field => field.Name)}\": {fields.Select(field => field.GetValue(obj))}")}}}";
        }
    }
}
