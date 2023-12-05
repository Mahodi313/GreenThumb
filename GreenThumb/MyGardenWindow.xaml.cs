using GreenThumb.Data;
using GreenThumb.Models;
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
    /// Interaction logic for MyGardenWindow.xaml
    /// </summary>
    public partial class MyGardenWindow : Window
    {
        private readonly UserModel _user;

        public MyGardenWindow(UserModel user)
        {
            InitializeComponent();
            _user = user;

            UpdateUI();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new(_user);
            plantWindow.Show();
            Close();
        }

        private void UpdateUI() 
        {
            if (_user != null) 
            {
                using (GreenThumbDbContext context = new GreenThumbDbContext()) 
                {
                    GreenUow uow = new(context);
                    // Get users garden
                    var gardenOfUser = uow.GardenRepo.GetUserGarden(_user.UserId);

                    if (gardenOfUser != null) 
                    {
                        //Get the plants of that garden and add them to the list.
                        var plants = uow.GardenRepo.GetPlantsOfGarden(gardenOfUser);

                        foreach (var plant in plants) 
                        {
                            ListBoxItem item = new();
                            item.Content = plant.Name;
                            item.Tag = plant;

                            lstPlants.Items.Add(item);
                        }
                    }                    
                }
            }
        }
    }
}
