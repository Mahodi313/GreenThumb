using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace GreenThumb.Managers
{
    public static class KeyManager
    {
        public static string GetEncryptionKey()
        {
            string directoryPath = "TextFiles";
            string filePath = Path.Combine(directoryPath, "Key.txt");

            // Check if the directory exists and create it if it doesn't exist

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Check if the file exists

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                string key = GenerateEncryptionKey();

                // Check if file exists or files is readonly. If file is read only, then you can't edit the textfile.

                if (!File.Exists(filePath) || (File.GetAttributes(filePath) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    File.WriteAllText(filePath, key);
                }
                else
                {

                    MessageBox.Show("Cannot write to a read-only file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                return key;
            }
        }
        public static string GenerateEncryptionKey()
        {
            var rng = new RNGCryptoServiceProvider();

            var byteArray = new byte[16];
            rng.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }
    }
}
