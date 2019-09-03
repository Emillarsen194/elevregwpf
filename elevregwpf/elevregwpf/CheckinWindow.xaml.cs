using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace elevregwpf
{
    /// <summary>
    /// Interaction logic for CheckinWindow.xaml
    /// </summary>
    public partial class CheckinWindow : Window
    {
        public CheckinWindow()
        {
            InitializeComponent();





            checkt.Content = "Checkede ind " + DateTime.Now.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
