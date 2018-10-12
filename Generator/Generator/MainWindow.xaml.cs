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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes;
using MaterialDesignColors;
using System.Security.Cryptography;
using System.Threading;

//

using System.Data;

namespace Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarTop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tomasz Chorzępa \n" +
            "w57009\n " +
            "2018",
            "Informacje o autorze projektu");
        }

        private void CleanListButton_Click(object sender, RoutedEventArgs e)
        {
            this.OutputTextBox.Text = null;
        }

        //https://cezarywalenciuk.pl/blog/programing/post/c-string-z-losowymi-znaki


        public static string RandomString(int range) // LINQ “Range” - method 1
        {
            var chars = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, range)
                            .Select(s => s[random.Next(s.Length)])
                            .ToArray());

            return result;
        }


        public static string GetUniqueKey(int maxSize) // RNGCryptoServiceProvider - method 2 (Secure Random Numbers)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(data);
            data = new byte[maxSize];
            crypto.GetBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string GetUniqueKeyDigits(int maxSize) // RNGCryptoServiceProvider - method 2.1 digits only
        {
            char[] chars = new char[62];
            chars =
            "1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(data);
            data = new byte[maxSize];
            crypto.GetBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string GuidString(int numOfCharsNeeded) // GUID - method 3
        {
            if (numOfCharsNeeded <= 32)
                return Guid.NewGuid().ToString("n").Substring(0, numOfCharsNeeded);
            else
            {
                int f = numOfCharsNeeded / 32 + 1;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i <= f; i++)
                {
                    sb.Append(Guid.NewGuid().ToString("n"));
                }

                return sb.ToString().Remove(numOfCharsNeeded);
            }
        }


        public string PickMethod(int numOfCharsGen)
        {
           
            var z1 = m1RadioButton.IsChecked;
            var z2 = m2RadioButton.IsChecked;
            var z3 = m3RadioButton.IsChecked;
            var z4 = m4RadioButton.IsChecked;
            string returnString ="";
            if ( z1 == true)
            {
                returnString = RandomString(numOfCharsGen);
                Thread.Sleep(30);
            }
            else  if (z2 == true)
            {
                returnString = GetUniqueKey(numOfCharsGen);
            }
            else   if (z3 == true)
            {
                returnString = GuidString(numOfCharsGen);
            }
            else if (z4 == true)
            {
                returnString = GetUniqueKeyDigits(numOfCharsGen);
            }

            return returnString;

        }





        private void ButtonGen1_Click(object sender, RoutedEventArgs e)
        {

            //  int a = int.Parse(textBoxAmount.Text);
            if (Int32.TryParse(textBoxAmount.Text, out int a))
            {

                for (int i = 0; i < a; i++)
                {
                    this.OutputTextBox.Text += PickMethod(4) + "\n";
                }
            }
            else
            {
                MessageBox.Show("Type integer value in amount section.","Perse error");
            }

              
        }

        private void ButtonGen2_Click(object sender, RoutedEventArgs e)
        {
            
                
            if (Int32.TryParse(textBoxAmount.Text, out int a))
            {
                for (int i = 0; i < a; i++)
                {
                    this.OutputTextBox.Text += PickMethod(6) + "\n";
                }
            }
            else
            {
                MessageBox.Show("Type integer value in amount section.", "Perse error");
            }
        }

        private void ButtonGen3_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(textBoxAmount.Text, out int a))
            {

                for (int i = 0; i < a; i++)
                {
                    this.OutputTextBox.Text += PickMethod(4) + "-" + PickMethod(4) + "\n";
                }
            }
            else
            {
                MessageBox.Show("Type integer value in amount section.", "Perse error");
            }
        }

        private void ButtonGen4_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(textBoxAmount.Text, out int a))
            {

                for (int i = 0; i < a; i++)
                {
                    this.OutputTextBox.Text += PickMethod(3) + "-" + PickMethod(3) + "-" + PickMethod(3) + "\n";
                }
            }
            else
            {
                MessageBox.Show("Type integer value in amount section.", "Perse error");
            }
        }

        private void ButtonGen5_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(textBoxAmount.Text, out int a))
            {

                for (int i = 0; i < a; i++)
                {
                    this.OutputTextBox.Text += PickMethod(4) + "-" + PickMethod(4) + "-" + PickMethod(4) + "-" + PickMethod(2) + "\n";
                }
            }
            else
            {
                MessageBox.Show("Type integer value in amount section.", "Perse error");
            }
        }

        private void ButtonGen6_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(textBoxAmount.Text, out int a))
            {

                for (int i = 0; i < a; i++)
                {
                    this.OutputTextBox.Text += PickMethod(4) + "-" + PickMethod(4) + "-" + PickMethod(4) + "-" + PickMethod(4) + "\n";
                }
            }
            else
            {
                MessageBox.Show("Type integer value in amount section.", "Perse error");
            }
        }

    }
}
