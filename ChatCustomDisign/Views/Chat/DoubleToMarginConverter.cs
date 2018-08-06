using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ChatCustomDisign.Views.Chat
{
    public class DoubleToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var width = (double)value;
            var diffStr = (string)parameter;
            var diff = double.Parse(diffStr);
            return width-diff;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
