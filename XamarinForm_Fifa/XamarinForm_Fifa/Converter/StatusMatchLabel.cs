namespace XamarinForm_Fifa.Converter
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    using Models;

    public class StatusMatchLabel : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = "";
            switch (value)
            {
                case null:
                    return result;
                case MatchDetail m:
                    if (m.Started && m.Live)
                    {
                        result = "Live -" + m.MatchStatusShort;
                    }
                    else
                    {
                        result = m.Finished ? "FT" : "Upcoming";
                    }
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
