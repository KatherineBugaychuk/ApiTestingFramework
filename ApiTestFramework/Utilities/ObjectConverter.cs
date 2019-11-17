using System;
using System.Collections.Generic;

namespace ApiTestFramework.Utilities
{
    class ObjectConverter
    {
        public static Dictionary<string, string> ConvertObjectToDictionary(object objectToConvert)
        {
            var propetriesDictionary = new Dictionary<string, string>();
            var fields = objectToConvert.GetType().GetProperties(PropertyUtilities.PropertiesInCurrentClass);
            foreach (var field in fields)
            {
                string fieldValue;
                try
                {
                    fieldValue = field.GetValue(objectToConvert).ToString();
                }
                catch (Exception)
                {
                    fieldValue = "";
                }
                propetriesDictionary.Add(field.Name, fieldValue);
            }
            return propetriesDictionary;
        }
    }
}
