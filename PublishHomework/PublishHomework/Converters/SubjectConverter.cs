using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace PublishHomework.Converters
{
    public class SubjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = value.ToString();
            var field = typeof(Models.Subject).GetField(name);
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false) as DescriptionAttribute;
            if (attribute != null)
            {
                return attribute.Description;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}