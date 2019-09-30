using ApiTestFramework.Endpoints.Attributes;
using ApiTestFramework.Endpoints.Requests;
using ApiTestFramework.Validation;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace ApiTestFramework.Execution
{
    class Validator
    {
        public static void ValidateRequest(object obj)
        {
            ValidateCommaSeparatedValues(obj);
        }

        public static void ValidateCommaSeparatedValues(object obj)
        {
            obj = obj as Request;
            foreach (var field in obj.GetType().GetProperties(Comparator.PropertiesInCurrentClass))
            {
                var commaSeparatedAttribute = field.GetCustomAttributes(typeof(CommaSeparatedValues), true).FirstOrDefault() as CommaSeparatedValues;
                if (commaSeparatedAttribute != null) 
                {
                    var min = commaSeparatedAttribute.CountMin;
                    var max = commaSeparatedAttribute.CountMax;
                    var values = (string)field.GetValue(obj);
                    var countOfValues = values.Split(',').Length;
                    Assert.IsTrue(countOfValues >= min || countOfValues <= max, 
                        $"Wrong number of comma separated values: {countOfValues}\nShould be greater than {min} and less than {max}");
                }
            }
        }
    }
}
