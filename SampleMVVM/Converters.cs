﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SampleMVVM.Converters
{
    public class ValueConverter : MarkupExtension, IValueConverter
    {
        private static ValueConverter _instance;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) - System.Convert.ToDouble(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ?? (_instance = new ValueConverter());
        }
    }
}
