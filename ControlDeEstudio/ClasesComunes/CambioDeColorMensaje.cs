using System;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ControlDeEstudio.ClasesComunes
{
    public class CambioDeColorMensaje : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = (string)value;

            if (valor == "Error")
            {
                return new SolidColorBrush(Color.FromArgb(255, 179, 65, 40));
            }
            else if (valor == "Exito")
            {

                return new SolidColorBrush(Color.FromArgb(255, 52, 152, 87));
            }

            else if (valor == "Advertencia")
            {
                return new SolidColorBrush(Color.FromArgb(255, 190, 153, 51));
            }                
            
            else
            {
                return new SolidColorBrush(Colors.Transparent);
            }

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
