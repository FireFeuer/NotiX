using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace NotiX7.Assets.Converters
{
    public class NoteHeightToWidthConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) + 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
