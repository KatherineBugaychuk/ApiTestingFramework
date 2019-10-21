using System;
using System.Collections.Generic;

namespace ApiTestFramework.Utilities
{
    class ObjectConverter
    {
        public static Dictionary<string, string> ConvertObjectToDictionary(object objectToConvert)
        {
            var fieldsMap = new Dictionary<string, string>();
            var fields = objectToConvert.GetType().GetProperties(CommonValues.PropertiesInCurrentClass);
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
                fieldsMap.Add(field.Name, fieldValue);
            }
            return fieldsMap;
        }
    }
}
