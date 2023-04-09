using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace NotiX7.Assets.Converters
{
    class BackgroundToBotderBrushConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            Color color = (Color)System.Windows.Media.ColorConverter.ConvertFromString(value.ToString());
            SolidColorBrush solidColorBrush = new SolidColorBrush(color);
            solidColorBrush.Opacity = 0.66;
            return solidColorBrush;
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
