using ApiTestFramework.Utilities;
using NUnit.Framework;
using System;

namespace ApiTestFramework.Validation
{
    public enum CompareType
    {
        ContainsAll,
        EqualsAll
    }

    class Comparator
    {
        public static void CompareObjects(object actual, object expected, CompareType compareType = CompareType.ContainsAll)
        {
            Console.WriteLine("***Compare***\nExpected:\n" + expected.PropertiesToString() + "\nActual:\n" + actual.PropertiesToString());
            var expectedFields = expected.GetType().GetProperties(PropertyUtilities.PropertiesInCurrentClass);        
            var actualFields = actual.GetType().GetProperties(PropertyUtilities.PropertiesInCurrentClass);
            foreach (var expectedField in expectedFields)
            {
                foreach (var actualField in actualFields)
                {
                    if (AreAllFieldsToBeCompared(compareType) && expectedFields.Length != actualFields.Length)
                    {
                        Assert.Fail("Number of fields are not equal");
                    }
                    if (expectedField.Name.Equals(actualField.Name))
                    {
                        if (!CompareFieldValues(actualField.GetValue(actual), expectedField.GetValue(expected)))
                        {
                            Assert.Fail("Values are not equal.\nExpected: " + expectedField.Name + " = " + expectedField.GetValue(expected)
                                    + "\n  Actual: " + actualField.Name + " = " + actualField.GetValue(actual));
                        }
                    }
                }
            }
            Console.WriteLine("***Success***");
        }

        static bool AreAllFieldsToBeCompared(CompareType compareType)
            => compareType.Equals(CompareType.ContainsAll) || compareType.Equals(CompareType.EqualsAll);
        
        static bool CompareFieldValues(object actualValue, object expectedValue)
        {         
            if (expectedValue == null)
            {
                return true;
            }
            if (actualValue == null)
            {
                return false;
            }
            bool result = false;
            var actualValueType = actualValue.GetType();
            if (actualValueType.IsPrimitive || actualValueType.IsAssignableFrom(typeof(string)) || actualValueType.IsAssignableFrom(typeof(int)) || actualValueType.IsAssignableFrom(typeof(double)))
            {
                result = ArePrimitiveValuesEqual(expectedValue, actualValue);
            }
            else if (actualValueType.IsArray)
            {
                var actualValuesArray = (object[])actualValue;
                var expectedValuesArray = (object[])expectedValue;
                for (int i = 0; i<actualValuesArray.Length; i++)
                {
                    if (expectedValuesArray == null)
                    {
                        result = true;
                        break;
                    }
                    result = CompareFieldValues(actualValuesArray[i], expectedValuesArray[i]);
                    if (!result)
                    {
                        break;
                    }
                }
            }
            else
            {
                var expectedFields = expectedValue.GetType().GetProperties(PropertyUtilities.PropertiesInCurrentClass);
                var actualFields = actualValue.GetType().GetProperties(PropertyUtilities.PropertiesInCurrentClass);
                foreach (var expectedField in expectedFields) {
                    foreach (var actualField in actualFields) {
                        if (expectedField.Name.Equals(actualField.Name)) {
                            result = CompareFieldValues(actualField.GetValue(actualValue), expectedField.GetValue(expectedValue));
                        }
                    }
                }
            }
            return result;
        }

        static bool ArePrimitiveValuesEqual(object expectedValue, object actualValue)
            => (expectedValue == null && actualValue == null) || (expectedValue == null && actualValue != null) || (actualValue != null && expectedValue.ToString().Equals(actualValue.ToString()));
    }
}
