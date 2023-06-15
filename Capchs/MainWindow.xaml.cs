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

namespace Capchs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        string capthaText = "";
        public MainWindow()
        {
            InitializeComponent();
            UpdateCaptcha();
        }

        private void BtnUpdateCaptcha_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }

        private void UpdateCaptcha()
        {
            capthaText = "";
            SPanelSymbols.Children.Clear();
            CanvasNoise.Children.Clear();
            GenerateSymbols(5);
            GenerateNoise(25);

        }
        private void GenerateSymbols(int count)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(rnd.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();
                lbl.Text = symbol;
                lbl.FontSize = rnd.Next(35, 85);
                lbl.RenderTransform = new RotateTransform(rnd.Next(-45, 45));
                lbl.Margin = new Thickness(10, 10, 10, 10);
                //lbl.Foreground = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                SPanelSymbols.Children.Add(lbl);
                capthaText += symbol;
            }
        }
        private void GenerateNoise(int volumeNoise)
        {
            for (int i = 0; i < volumeNoise; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(100, 256), (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                ellipse.Width = ellipse.Height = rnd.Next(5, 50);
                CanvasNoise.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rnd.Next(0, 350));
                Canvas.SetTop(ellipse, rnd.Next(0, 250));

            }
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (captchaTBox.Text == "")
            {
                MessageBox.Show("Введите текст с картинки");
            }
            else
            {
                if (captchaTBox.Text == capthaText)
                {
                    MessageBox.Show("Вы прошли проверку");
                }
                else
                {
                    MessageBox.Show("Неправильно введенная каптча");
                }
            }
        }
    }
}
