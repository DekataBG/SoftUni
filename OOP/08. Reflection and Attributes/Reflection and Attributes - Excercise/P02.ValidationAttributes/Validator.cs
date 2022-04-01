using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var type = obj.GetType();

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var validationAttribute = property.GetCustomAttribute<MyValidationAttribute>();

                if(validationAttribute != null && !validationAttribute.IsValid(property.GetValue(obj)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
