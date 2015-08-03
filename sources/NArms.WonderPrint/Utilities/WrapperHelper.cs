namespace NArms.WonderPrint.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class WrapperHelper
    {
        private const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public;

        public static object ToDictionary(object input)
        {
            if (input == null)
                return null;

            var inputType = input.GetType();

            if (IsAtomic(inputType))
                return input;

            if (IsEnumerable(inputType))
            {
                var enumerable = input as IEnumerable<object>;
                if (enumerable == null)
                    return null;

                return new EnumerableWrapper(inputType.Name, input, enumerable.Select(ToDictionary));
            }            

            var namedDictionary = new ObjectWrapper(inputType.Name, input);

            var fields = inputType.GetFields(DefaultBindingFlags)
                .Select(x => new
                {
                    x.Name,
                    Value = x.GetValue(input)
                })
                /*.OrderBy(x => x.Name)*/;

            var properties = inputType.GetProperties(DefaultBindingFlags)
                .Select(x => new
                {
                    x.Name,
                    Value = x.GetValue(input)
                })
                /*.OrderBy(x => x.Name)*/;

            foreach (var field in fields)
                namedDictionary.Add(field.Name, ToDictionary(field.Value));

            foreach (var property in properties)
                namedDictionary.Add(property.Name, ToDictionary(property.Value));

            return namedDictionary;
        }

        private static bool IsAtomic(Type inputType)
        {
            return Types.Atomic.Contains(inputType);
        }

        private static bool IsEnumerable(Type type)
        {
            return typeof (IEnumerable).IsAssignableFrom(type) ||
                   typeof (IEnumerable<object>).IsAssignableFrom(type) ||
                   type.IsArray;
        }
    }
}