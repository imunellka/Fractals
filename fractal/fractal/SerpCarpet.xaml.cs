using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FractalDrawer;

namespace fractal
{

    /// <summary>
    /// Реализация логики для SerpCarpet.
    /// </summary>
    public partial class SerpCarpet : Window
    {
        
        private readonly SierpinskiCarpet serp1 = new();

        public SerpCarpet(System.Windows.Media.Color color1, System.Windows.Media.Color color2)
        {
            InitializeComponent();
            MinHeight = SystemParameters.PrimaryScreenHeight / 2;
            MinWidth = SystemParameters.PrimaryScreenWidth / 2;
            serp1.Canvas = canvas1;
            serp1.StartColor = color1;
            serp1.EndColor = color2;
            try
            {
                serp1.IndR = Math.Abs(serp1.EndColor.R - serp1.StartColor.R) / (serp1.EndColor.R - serp1.StartColor.R);
                serp1.IndG = Math.Abs(serp1.EndColor.G - serp1.StartColor.G) / (serp1.EndColor.G - serp1.StartColor.G);
                serp1.IndB = Math.Abs(serp1.EndColor.B - serp1.StartColor.B) / (serp1.EndColor.B - serp1.StartColor.B);
            }
            catch
            {
                //проверка деления на ноль.
            }
            serp1.R = (byte)Math.Abs(serp1.EndColor.R - serp1.StartColor.R);
            serp1.G = (byte)Math.Abs(serp1.EndColor.G - serp1.StartColor.G);
            serp1.B = (byte)Math.Abs(serp1.EndColor.B - serp1.StartColor.B);
        }


        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            serp1.Depth = (int)slider1.Value;
            if (serp1.Canvas != null)
            {
                canvas1.Children.Clear();
                serp1.R = (byte)Math.Abs(serp1.EndColor.R - serp1.StartColor.R);
                serp1.G = (byte)Math.Abs(serp1.EndColor.G - serp1.StartColor.G);
                serp1.B = (byte)Math.Abs(serp1.EndColor.B - serp1.StartColor.B);
                serp1.R = (byte)(Math.Round(serp1.R / (float)serp1.Depth));
                serp1.G = (byte)(Math.Round(serp1.G / (float)serp1.Depth));
                serp1.B = (byte)(Math.Round(serp1.B / (float)serp1.Depth));
                serp1.RecursionDraw(canvas1, serp1.DrawMainRectangle(canvas1), serp1.Depth);
            }
        }


        /// <summary>
        /// Реакция на изменение размера окна.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {
            serp1.Depth = (int)slider1.Value;
            if (serp1.Canvas != null)
            {
                canvas1.Children.Clear();
                serp1.RecursionDraw(canvas1, serp1.DrawMainRectangle(canvas1), serp1.Depth);
            }
        }


        /// <summary>
        /// Обработчик сохранения.
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">событие</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double dpi = 300;
                var scale = dpi / 96;
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)(canvas1.ActualWidth * scale), (int)(canvas1.ActualHeight * scale), dpi, dpi, PixelFormats.Pbgra32);
                bmp.Render(canvas1);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                System.IO.FileStream stream = System.IO.File.Create("./Canvas.png");
                MessageBox.Show("Сохранено в папку с exe-шником ");
                encoder.Save(stream);
                stream.Close();
            }
            catch
            {
                MessageBox.Show("Сохранено!");
            }
        }
    }
}
