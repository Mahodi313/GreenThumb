using GreenThumb.Data;
using GreenThumb.Models;
using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for PlantAddWindow.xaml
    /// </summary>
    public partial class PlantAddWindow : Window
    {
        private PlantModel? _plant;

        public PlantAddWindow()
        {
            InitializeComponent();
            UpdateUI();
        }

        private async void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string plantName = txtPlantName.Text;
                string plantDescription = txtPlantDesc.Text;

                if (string.IsNullOrWhiteSpace(plantName.Trim()))
                {
                    throw new ArgumentException("Please fill in all needed information!");
                }
                else
                {
                    using (GreenThumbDbContext context = new GreenThumbDbContext())
                    {
                        GreenRepository<PlantModel> plantRepo = new(context);
                        var plants = await plantRepo.GetAll();

                        foreach (var plant in plants)
                        {
                            if (plantName == plant.Name)
                            {
                                throw new ArgumentException("The plant you provided already exists!");
                            }
                        }
                    }

                    PlantModel newPlant = new()
                    {
                        Name = plantName,
                        Description = plantDescription,
                    };

                    _plant = newPlant;

                    using (GreenThumbDbContext context = new GreenThumbDbContext())
                    {
                        GreenRepository<PlantModel> plantRepo = new(context);

                        await plantRepo.Add(newPlant);

                        await plantRepo.SaveChanges();
                    }

                    MessageBox.Show("Plant has been successfully added!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    MessageBox.Show("Now you can enter instructions if you want!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtPlantName.IsReadOnly = true;
                    txtPlantDesc.IsReadOnly = true;
                    btnAddPlant.IsEnabled = false;
                    txtInstructionName.IsReadOnly = false;
                    txtInstructionDesc.IsReadOnly = false;
                    btnAddInstruction.IsEnabled = true;
                }
            }
            catch (ArgumentException ax)
            {
                MessageBox.Show(ax.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_plant != null)
                {
                    string name = txtInstructionName.Text;
                    string description = txtInstructionDesc.Text;

                    if (string.IsNullOrWhiteSpace(name.Trim()))
                    {
                        throw new ArgumentException("You need to atleast fill in the name of the instruction before adding it!");
                    }

                    InstructionModel newInstruction = new()
                    {
                        Name = name,
                        Description = description,
                        PlantId = _plant.PlantId
                    };

                    using (GreenThumbDbContext context = new())
                    {
                        GreenRepository<InstructionModel> instructionRepo = new(context);

                        await instructionRepo.Add(newInstruction);

                        await instructionRepo.SaveChanges();
                    }

                    MessageBox.Show("Instruction Added!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtInstructionName.Clear();
                    txtInstructionDesc.Clear();
                }
                else
                {
                    throw new ArgumentException("Please add a plant first!");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
            Close();
        }

        private void UpdateUI()
        {
            txtPlantName.Clear();
            txtPlantDesc.Clear();
            txtInstructionName.Clear();
            txtInstructionDesc.Clear();
            btnAddPlant.IsEnabled = true;
            txtPlantName.IsReadOnly = false;
            txtPlantDesc.IsReadOnly = false;
            txtInstructionName.IsReadOnly = true;
            txtInstructionDesc.IsReadOnly = true;
            btnAddInstruction.IsEnabled = false;
        }
    }
}
