﻿
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
    {
    public class Validator
        {
        public static bool IsValid (object obj)
            {

            Type objType = obj.GetType();

            PropertyInfo[] propertyInfos = objType
                .GetProperties()
                .Where(p => p.CustomAttributes
                    .Any(ca => typeof(MyValidationAttribute)
                        .IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                IEnumerable<MyValidationAttribute> attributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute)
                        .IsAssignableFrom(ca.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in attributes)
                    {
                    if (!attribute.IsValid(propertyInfo.GetValue(obj)))
                        {
                        return false;
                        }
                    }
                }

            return true;

            }
        }
    }
