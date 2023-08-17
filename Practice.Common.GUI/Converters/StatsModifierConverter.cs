using Practice.Common.Classes;

using System;
using System.Globalization;
using System.Windows.Data;

namespace Practice.Common.GUI.Converters
{
    public class StatsModifierConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int total = 0;
            if (value == null) return 0;

            var val = (int)value;
            total = StatClass.Modifier(val);
            if (total < 0) return total.ToString();

            return "+" + total.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
