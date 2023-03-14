using PracticeCommon.Common;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PracticeCommonGUI.Converters
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
