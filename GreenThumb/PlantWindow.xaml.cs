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
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        private UserModel _user;
        private List<PlantModel> _plants = new();

        public PlantWindow(UserModel user)
        {
            InitializeComponent();
            InitializeAsync();
            _user = user;
           
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMyGarden_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Retrieves the searched text and converts it to upper. This ensures so that it doesn't matter if you write in lowercase or upper.
            string searchText = txtSearch.Text.ToUpper();

            await UpdateUI(searchText);
        }

        public async Task UpdateUI(string? searchText = null) 
        {
            lstPlants.Items.Clear();


            using (GreenThumbDbContext context = new())
            {
                GreenRepository<PlantModel> plantsRepo = new(context);

                var plants = await plantsRepo.GetAll();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    // If the searchText is not null, it will filter out all the plants to where it starts with the SearchText characters and then show the list.
                    plants = plants.Where(x => x.Name.ToUpper().StartsWith(searchText.ToUpper())).ToList();
                }

                _plants = plants;

                foreach (var plant in _plants)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = plant.Name;
                    item.Tag = plant;

                    lstPlants.Items.Add(item);
                }
            }
        }
       
        public async void InitializeAsync() 
        {
            //No need for an argument because the parameter variable in UpdateUI() is set to = null.
            await UpdateUI();
        }
    }
}
