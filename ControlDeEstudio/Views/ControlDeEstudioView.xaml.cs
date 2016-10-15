using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ControlDeEstudio.Views
{
    public partial class ControlDeEstudioView : UserControl
    {
        public ControlDeEstudioView()
        {
            InitializeComponent();
        }

        private void MostrarModalReferencia(object sender, RoutedEventArgs e)
        {
            var modal = new Modales.ModalReferencia();
            modal.Width = 600;
            modal.Height = 500;
            modal.Show();
        }


        private void MostrarModalSubtema(object sender, RoutedEventArgs e)
        {
            var modal = new Modales.ModalSubtema();
            modal.Width = 600;
            modal.Height = 500;
            modal.Show();
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
