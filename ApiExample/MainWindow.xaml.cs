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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApiExample.Analytics.Google;
namespace ApiExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static AnalyticsClient _gaClient;
        public MainWindow()
        {
            _gaClient = new AnalyticsClient();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _gaClient.Report();
        }
    }
}
