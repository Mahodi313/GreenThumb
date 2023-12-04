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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(username.Trim()) || string.IsNullOrWhiteSpace(password.Trim())) 
                {
                    throw new ArgumentException("Please fill in all needed information!");
                }
                if (password.Length < 6) 
                {
                    throw new ArgumentException("The password needs to be atleast 6 characters long or more!");
                }

                using(GreenThumbDbContext context = new()) 
                {
                    GreenRepository<UserModel> userRepo = new(context);

                    var users = await userRepo.GetAll();

                    foreach (var user in users) 
                    {
                        if (username == user.Username) 
                        {
                            throw new ArgumentException("The username that you provided already exists!");
                        }
                    }
                }

                UserModel newUser = new() 
                {
                    Username = username,
                    password = password,
                    IsAdmin = false
                                      
                };

                // Save user to the database

                using (GreenThumbDbContext context = new()) 
                {
                    GreenRepository<UserModel> userRepo = new(context);

                    await userRepo.Add(newUser);

                    await userRepo.SaveChanges();
                }

                // Create garden for user

                GardenModel newGarden = new() 
                {
                    UserId = newUser.UserId
                };

                using (GreenThumbDbContext context = new()) 
                {
                    GreenRepository<GardenModel> gardenRepo = new(context);

                    await gardenRepo.Add(newGarden);

                    await gardenRepo.SaveChanges();
                }

                MessageBox.Show("Account successfully created! Your garden is created for you...", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            catch(ArgumentException ax) 
            {
                MessageBox.Show(ax.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
