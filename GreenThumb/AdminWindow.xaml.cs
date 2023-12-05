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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                ListBoxItem selectedItem = (ListBoxItem)lstPlants.SelectedItem;

                if (selectedItem != null) 
                {
                    PlantModel plantToDelete = (PlantModel)selectedItem.Tag;

                    if (plantToDelete != null) 
                    {
                        using (GreenThumbDbContext context = new GreenThumbDbContext()) 
                        {
                            GreenRepository<PlantModel> plantRepo = new(context);

                            try 
                            {
                                plantRepo.Delete(plantToDelete);

                                await plantRepo.SaveChanges();

                                await UpdateUI();

                                MessageBox.Show("Plant Removed!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            catch (Exception ex) 
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                else 
                {
                    throw new NullReferenceException("Please select a plant to delete!");
                }
            } 
            catch(NullReferenceException nex) 
            {
                MessageBox.Show(nex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch(Exception) 
            { 
                MessageBox.Show("Error deleting plant!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private async Task UpdateUI() 
        {
            lstInstructions.Items.Clear();
            lstPlants.Items.Clear();

            using (GreenThumbDbContext context = new GreenThumbDbContext()) 
            {
                GreenRepository<PlantModel> plantRepo = new(context);
                GreenRepository<InstructionModel> instructionRepo = new(context);

                var plants = await plantRepo.GetAll();
                var instructions = await instructionRepo.GetAll();

                foreach ( var plant in plants ) 
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = new { plant.PlantId, plant.Name };
                    item.Tag = plant;

                    lstPlants.Items.Add(item);
                }

                foreach ( var instruction in instructions ) 
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = new {instruction.Name, instruction.PlantId};
                    item.Tag = instruction;

                    lstInstructions.Items.Add(item);
                }
            }
        }
        public async void InitializeAsync() 
        {
            await UpdateUI();
        }
    }
}
