using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace VoinarovskyTestSystem.Converter
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                bool reverse = parameter != null && parameter.ToString().ToLower() == "false";
                return (boolValue ^ reverse) ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
