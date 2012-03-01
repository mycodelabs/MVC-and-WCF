using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace infrasrtucture.utilities
{
    public static class ExpandoUtilities
    {
        public static object ToConcrete<T>(ExpandoObject expandoObject)
        {
            object instance = Activator.CreateInstance<T>();
            var dict = expandoObject as IDictionary<string, object>;
            PropertyInfo[] targetProperties = instance.GetType().GetProperties();

            foreach (PropertyInfo property in targetProperties)
            {
                object propVal;
                if(property.PropertyType.IsGenericType)
                {
               }
                else
                {
                    if (dict.TryGetValue(property.Name, out propVal))
                    {
                        property.SetValue(instance, propVal, null);
                    }    
                }
                
            }

            return instance;

        }
    }
}