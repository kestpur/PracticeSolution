using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Taken from:
    /// https://stackoverflow.com/questions/6145888/how-to-bind-an-enum-to-a-combobox-control-in-wpf
    /// </remarks>
    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Any())
            {
                return (attributes.First() as DescriptionAttribute).Description;
            }

            // If no description is found, the least we can do is replace underscores with spaces
            // You can add your own custom default formatting logic here
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(textInfo.ToLower(value.ToString().Replace("_", "-")));
        }

        public static IEnumerable<EnumValueDescription> GetAllValuesAndDescriptions(Type type)
        {
            return !type.IsEnum
                ? throw new ArgumentException($"{nameof(type)} must be an enum type")
                : Enum.GetValues(type).Cast<Enum>().Select((e) => new EnumValueDescription() { Value = e, Description = e.Description() }).ToList();
        }
    }
}
