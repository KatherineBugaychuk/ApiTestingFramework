using ApiTestFramework.Endpoints.Attributes;
using ApiTestFramework.Endpoints.Requests;
using ApiTestFramework.Utilities;
using NUnit.Framework;
using System.Linq;

namespace ApiTestFramework.Execution
{
    class Validator
    {
        public static void ValidateRequest(object obj)
            => ValidateCommaSeparatedValues(obj);

        public static void ValidateResponse(object obj)
            => ValidateMandatory(obj);

        public static void ValidateCommaSeparatedValues(object obj)
        {
            obj = obj as Request;
            foreach (var field in obj.GetType().GetProperties(PropertyUtilities.PropertiesInCurrentClass))
            {
                if (field.GetCustomAttributes(typeof(CommaSeparatedValues), true).FirstOrDefault() is CommaSeparatedValues commaSeparatedAttribute)
                {
                    var min = commaSeparatedAttribute.CountMin;
                    var max = commaSeparatedAttribute.CountMax;
                    var values = (string)field.GetValue(obj);
                    var countOfValues = values.Split(',').Length;
                    Assert.IsTrue(countOfValues >= min || countOfValues <= max,
                        $"Wrong number of comma separated values of property '{field.Name}': {countOfValues}. Value should be greater than {min} and less than {max}");
                }
            }
        }

        public static void ValidateMandatory(object obj)
        {
            foreach (var field in obj.GetType().GetProperties(PropertyUtilities.PropertiesInCurrentClass))
            {            
                bool isMandatory = field.GetCustomAttributes(typeof(Mandatory), true).Length > 0;
                var propertyValue = field.GetValue(obj);
                if (isMandatory && (PropertyUtilities.IsPrimitive(propertyValue) || propertyValue == null))
                {
                    Assert.IsTrue(propertyValue != null, $"Mandatory value of property '{field.Name}' is null");
                }
                if (!PropertyUtilities.IsPrimitive(propertyValue) && propertyValue != null)
                {
                    ValidateMandatory(propertyValue);
                }
            }
        }
    }

}
