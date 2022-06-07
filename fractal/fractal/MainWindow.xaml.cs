using System;
using System.Windows;
namespace fractal
{
    /// <summary>
    /// Реализация логики поведения программы.
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MinHeight = SystemParameters.PrimaryScreenHeight / 2;
            MinWidth = SystemParameters.PrimaryScreenWidth / 2;
        }


        /// <summary>
        /// Активация фрактала по нажатию.
        /// </summary>
        /// <param name="sender">ссылка</param>
        /// <param name="e">событие</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var cochForm = new CochForm((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + startColor.Text),
                     (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + endColor.Text));
                cochForm.Show();
            }
            catch
            {
                var cochForm = new CochForm((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"),
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));
                cochForm.Show();
            }
        }


        /// <summary>
        /// Активация фрактала по нажатию.
        /// </summary>
        /// <param name="sender">ссылка</param>
        /// <param name="e">событие</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var serpForm = new SerpCarpet((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + startColor.Text),
                     (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + endColor.Text));
                serpForm.Show();
            }
            catch
            {
                var serpForm = new SerpCarpet((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"),
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));
                serpForm.Show();
            }
        }


        /// <summary>
        /// Активация фрактала по нажатию.
        /// </summary>
        /// <param name="sender">ссылка</param>
        /// <param name="e">событие</param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                var serpForm2 = new SerpTriangle((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + startColor.Text),
                     (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + endColor.Text));
                serpForm2.Show();
            }
            catch
            {
                var serpForm2 = new SerpTriangle((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"),
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));
                serpForm2.Show();
            }
        }


        /// <summary>
        /// Активация фрактала по нажатию.
        /// </summary>
        /// <param name="sender">ссылка</param>
        /// <param name="e">событие</param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var cantorForm = new Cantor((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + startColor.Text),
                     (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + endColor.Text));
                cantorForm.Show();
            }
            catch 
            {
                var cantorForm = new Cantor((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"),
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));
                cantorForm.Show();
            }
        }


        /// <summary>
        /// Активация фрактала по нажатию.
        /// </summary>
        /// <param name="sender">ссылка</param>
        /// <param name="e">событие</param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                var tree = new TreeCantor((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + startColor.Text),
                     (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#" + endColor.Text));
                tree.Show();
            }
            catch 
            {
                var tree = new TreeCantor((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"),
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#000000"));
                tree.Show();
            }
            
        }


       

        
    }
}
