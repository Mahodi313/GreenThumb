using GreenThumb.Data;
using GreenThumb.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Saves current logged-in user when log in is successfull.
        public static UserModel? LoggedInUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                string username = txtUsername.Text;
                string password = txtPassword.Password;

                if (string.IsNullOrWhiteSpace(username.Trim()) || string.IsNullOrWhiteSpace(password.Trim()))
                {
                    throw new ArgumentException("Username or password field is empty!");
                }

                using (GreenThumbDbContext context = new()) 
                {
                    GreenRepository<UserModel> userRepo = new(context);

                    var users = await userRepo.GetAll();

                    if (users.Count <= 0)
                    {
                        throw new ArgumentException("There are no accounts created! Please create an account.");
                    }
                    else 
                    {
                        foreach (var user in users)
                        {

                            if (username == user.Username && password == user.Password)
                            {
                                // Implement logic for opening Plant main window for user
                                PlantWindow plantWindow = new(user);
                                plantWindow.Show();
                                Close();

                                LoggedInUser = user;
                            }
                            else
                            {
                                throw new ArgumentException("The username or password is invalid! Try again.");
                            }
                        }
                    }
                }
            }
            catch(ArgumentException ax)  
            {
                MessageBox.Show(ax.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception) 
            {
                MessageBox.Show("Error while logging in! Try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void tbkRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}