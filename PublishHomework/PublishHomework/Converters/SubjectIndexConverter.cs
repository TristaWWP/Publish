using System;
using System.Globalization;
using System.Windows.Data;

namespace PublishHomework.Converters
{
    public class SubjectIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Models.Subject subject = (Models.Subject)value;
            int index = (int)subject - 1;
            return index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int index = (int)value;
            Models.Subject subject = (Models.Subject)index + 1;
            return subject;
        }
    }
}
