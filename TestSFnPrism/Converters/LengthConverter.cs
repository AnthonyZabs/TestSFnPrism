using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TestSFnPrism.Converters
{
    public class LengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            string param = parameter as string;

            if (string.IsNullOrEmpty(text))
                text = string.Empty;

            if (param.Equals("11"))
            {
                if (text.Length <= 11)
                    return true;
            }
            else if (param.Equals("16"))
            {
                if (text.Length > 11 && text.Length <= 16)
                    return true;
            }
            else if (param.Equals("18"))
            {
                if (text.Length > 16 && text.Length <= 18)
                    return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
