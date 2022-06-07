using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FractalDrawer;


namespace fractal
{
    /// <summary>
    /// Реализация логики для SerpTriangle.
    /// </summary>
    public partial class SerpTriangle : Window
    {
        private SierpinskiTriangle serp = new();

        public SerpTriangle(System.Windows.Media.Color color1, System.Windows.Media.Color color2)
        {
            InitializeComponent();
            MinHeight = SystemParameters.PrimaryScreenHeight / 2;
            MinWidth = SystemParameters.PrimaryScreenWidth / 2;
            serp.Canvas = canvas;
            serp.StartColor = color1;
            serp.EndColor = color2;
            try
            {
                serp.IndR = Math.Abs(serp.EndColor.R - serp.StartColor.R) / (serp.EndColor.R - serp.StartColor.R);
                serp.IndG = Math.Abs(serp.EndColor.G - serp.StartColor.G) / (serp.EndColor.G - serp.StartColor.G);
                serp.IndB = Math.Abs(serp.EndColor.B - serp.StartColor.B) / (serp.EndColor.B - serp.StartColor.B);
            }
            catch
            {
                //проверка деления на ноль.
            }
            serp.R = (byte)Math.Abs(serp.EndColor.R - serp.StartColor.R);
            serp.G = (byte)Math.Abs(serp.EndColor.G - serp.StartColor.G);
            serp.B = (byte)Math.Abs(serp.EndColor.B - serp.StartColor.B);
        }



        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (serp.Canvas != null)
            {
                canvas.Children.Clear();
                serp.Depth = (int)slider.Value;


                serp.R = (byte)Math.Abs(serp.EndColor.R - serp.StartColor.R);
                serp.G = (byte)Math.Abs(serp.EndColor.G - serp.StartColor.G);
                serp.B = (byte)Math.Abs(serp.EndColor.B - serp.StartColor.B);
                serp.R = (byte)(Math.Round(serp.R / (float)serp.Depth));
                serp.G = (byte)(Math.Round(serp.G / (float)serp.Depth));
                serp.B = (byte)(Math.Round(serp.B / (float)serp.Depth));
                serp.RecursionDraw(canvas, serp.DrawMainTriangle(canvas), serp.Depth);
            }


        }


        /// <summary>
        /// Реакция на изменение размера окна.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (serp.Canvas != null)
            {
                canvas.Children.Clear();
                serp.Depth = (int)slider.Value;
                serp.RecursionDraw(canvas, serp.DrawMainTriangle(canvas), serp.Depth);
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
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)(canvas.ActualWidth * scale), (int)(canvas.ActualHeight * scale), dpi, dpi, PixelFormats.Pbgra32);
                bmp.Render(canvas);

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
