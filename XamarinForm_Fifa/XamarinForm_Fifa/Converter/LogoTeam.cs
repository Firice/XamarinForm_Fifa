namespace XamarinForm_Fifa.Converter
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    using Models;

    public class LogoTeam : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value is MatchDetail matchDetail && parameter !=null)
            {
                return parameter.ToString()=="H" ? matchDetail.HomeLogoImage : matchDetail.AwayLogoImage;
            }

            return "xamarin_logo.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
