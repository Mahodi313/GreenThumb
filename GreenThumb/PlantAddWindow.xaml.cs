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

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for PlantAddWindow.xaml
    /// </summary>
    public partial class PlantAddWindow : Window
    {
        public PlantAddWindow()
        {
            InitializeComponent();
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
            Close();
        }
    }
}
