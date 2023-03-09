﻿using PracticeCommon.Common;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PracticeGUI.Converters
{

    public class StatsToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int total = 0;
            if (value == null) return total;

            var stats = value as StatClass;

            if (stats == null) return total;

            var properties = stats.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (prop.GetGetMethod() != null)
                {
                    var val = System.Convert.ToInt32(prop.GetValue(stats));
                    total += val;
                };
            }

            return total;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
