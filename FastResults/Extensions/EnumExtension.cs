using System;
using System.ComponentModel;

namespace FastResults.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                return attribute.Description;

            throw new ArgumentException("Not found description", nameof(enumValue));
        }

        public static T GetValueByDescription<T>(this string description) where T : Enum
        {
            foreach (Enum enumItem in Enum.GetValues(typeof(T)))
                if (enumItem.GetDescription() == description)
                    return (T)enumItem;

            throw new ArgumentException("Not found value", nameof(description));
        }
    }
}
