using GreenThumb.Data;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

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
            try
            {
                ListBoxItem selectedItem = (ListBoxItem)lstPlants.SelectedItem;

                if (selectedItem != null)
                {
                    PlantModel plant = (PlantModel)selectedItem.Tag;

                    if (plant != null)
                    {
                        PlantDetailsWindow plantDetailsWindow = new(plant, _user);
                        plantDetailsWindow.Show();
                        Close();
                    }
                }
                else
                {
                    throw new NullReferenceException("You need to select a plant before proceeding");
                }
            }
            catch (NullReferenceException nex)
            {
                MessageBox.Show(nex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while selecting item!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnMyGarden_Click(object sender, RoutedEventArgs e)
        {
            MyGardenWindow myGardenWindow = new(_user);
            myGardenWindow.Show();
            Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LoggedInUser = null;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
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
