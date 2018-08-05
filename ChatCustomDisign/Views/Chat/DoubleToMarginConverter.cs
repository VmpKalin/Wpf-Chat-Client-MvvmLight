using System;
using System.Windows;
using System.Windows.Data;

namespace ChatCustomDisign.Views.Chat
{
    public class DoubleToMarginConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var left = (double)values[0];
            var top = (double)values[1];
            var right = (double)values[2];
            var bottom = (double)values[3];

            return new Thickness(left, top, right, bottom);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
