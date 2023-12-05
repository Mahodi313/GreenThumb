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
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {

        private readonly PlantModel _plant;
        private readonly UserModel _user;
        
        public PlantDetailsWindow(PlantModel plant, UserModel user)
        {
            InitializeComponent();

            _user = user;
            _plant = plant;

            UpdateUI();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new(_user);
            plantWindow.Show();
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                using (GreenThumbDbContext context = new GreenThumbDbContext())
                {
                    GreenUow uow = new(context);

                    var gardenOfUser = uow.GardenRepo.GetUserGarden(_user.UserId);

                    if (gardenOfUser != null)
                    {
                        var plantsOfUser = uow.GardenRepo.GetPlantsOfGarden(gardenOfUser);

                        // Check if user already has the plant in his garden!
                        foreach (var plant in plantsOfUser) 
                        {
                            if (_plant.Name == plant.Name) 
                            {
                                throw new ArgumentException($"{plant.Name} already exists in your garden! Try with another one.");
                            }
                        }

                        uow.GardenRepo.AddPlantToGarden(_plant, gardenOfUser);

                        uow.SaveChanges();

                        MessageBox.Show($"{_plant.Name} has been successfully added to your garden!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

                        PlantWindow plantWindow = new(_user);
                        plantWindow.Show();
                        Close();
                    }
                }
            }
            catch(ArgumentException ax) 
            {
                MessageBox.Show(ax.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception) 
            {
                MessageBox.Show("Error when adding plant! Try again..", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateUI() 
        {
            lblName.Content = _plant.Name;
            txtDescription.Text = _plant.Description;

            using (GreenThumbDbContext context = new GreenThumbDbContext()) 
            {
                GreenUow uow = new(context);

                var instructionsOfPlant = uow.InstructionRepo.GetInstructionsOfPlant(_plant.PlantId);

                foreach (var instruction in instructionsOfPlant) 
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = new 
                    {
                        instruction.Name,
                        instruction.Description
                    };
                    item.Tag = instruction;

                    lstInstructions.Items.Add(item);
                }
            }
        }
    }
}
