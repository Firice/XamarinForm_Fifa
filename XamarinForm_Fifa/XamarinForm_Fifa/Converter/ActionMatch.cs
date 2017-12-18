namespace XamarinForm_Fifa.Converter
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class ActionMatch : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value.ToString() == "G" || value.ToString() == "OG" || value.ToString()=="PG")
                {
                    return "goal.png";
                }
                else if (value.ToString() == "Y")
                {
                    return "yellowcard.png";
                }
                else if (value.ToString() == "R")
                {
                    return "redcard.png";
                }
                else if (value.ToString() == "Sub")
                {
                    return "replace.png";
                }
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
