using System.Windows;
using FractalDrawer;
using System.Drawing;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace fractal
{
    /// <summary>
    /// Реализация логики для CantorSet.
    /// </summary>
    public partial class Cantor : Window
    {
        private CantorSet cantor = new CantorSet();
        public Cantor(System.Windows.Media.Color color1, System.Windows.Media.Color color2)
        {
            InitializeComponent();
            MinHeight = SystemParameters.PrimaryScreenHeight / 2;
            MinWidth = SystemParameters.PrimaryScreenWidth / 2;
            cantor.Canvas = canvas3;
            cantor.StartColor = color1;
            cantor.EndColor = color2;
            try
            {
                cantor.IndR = Math.Abs(cantor.EndColor.R - cantor.StartColor.R) / (cantor.EndColor.R - cantor.StartColor.R);
                cantor.IndG = Math.Abs(cantor.EndColor.G - cantor.StartColor.G) / (cantor.EndColor.G - cantor.StartColor.G);
                cantor.IndB = Math.Abs(cantor.EndColor.B - cantor.StartColor.B) / (cantor.EndColor.B - cantor.StartColor.B);
            }
            catch
            {
                //проверка деления на ноль.
            }
            cantor.R = (byte)Math.Abs(cantor.EndColor.R - cantor.StartColor.R);
            cantor.G = (byte)Math.Abs(cantor.EndColor.G - cantor.StartColor.G);
            cantor.B = (byte)Math.Abs(cantor.EndColor.B - cantor.StartColor.B);
        }

        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void slid1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cantor.Canvas != null)
            {
                canvas3.Children.Clear();
                cantor.Depth = (int)slid1.Value; 
                cantor.R = (byte)Math.Abs(cantor.EndColor.R - cantor.StartColor.R);
                cantor.G = (byte)Math.Abs(cantor.EndColor.G - cantor.StartColor.G);
                cantor.B = (byte)Math.Abs(cantor.EndColor.B - cantor.StartColor.B);
                cantor.R = (byte)(Math.Round(cantor.R / (float)cantor.Depth));
                cantor.G = (byte)(Math.Round(cantor.G / (float)cantor.Depth));
                cantor.B = (byte)(Math.Round(cantor.B / (float)cantor.Depth));
                cantor.LineHeight = (int)slid3.Value ;
                cantor.WhitespaceHeight = (int)slid2.Value;
                cantor.DrawRectangle(canvas3, new RectangleF(new PointF(0, 0), new SizeF((float)canvas3.ActualWidth, cantor.LineHeight)), cantor.Depth);
            }
        }


        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void slid3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cantor.Canvas != null)
            {
                canvas3.Children.Clear();
                cantor.Depth = (int)slid1.Value;
                cantor.LineHeight = (int)slid3.Value;
                cantor.WhitespaceHeight = (int)slid2.Value;
                cantor.DrawRectangle(canvas3, new RectangleF(new PointF(0, 0), new SizeF((float)canvas3.ActualWidth, cantor.LineHeight)), cantor.Depth);
            }
        }


        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void slid2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cantor.Canvas != null)
            {
                canvas3.Children.Clear();
                cantor.Depth = (int)slid1.Value;
                cantor.LineHeight = (int)slid3.Value;
                cantor.WhitespaceHeight = (int)slid2.Value;
                cantor.DrawRectangle(canvas3, new RectangleF(new PointF(0, 0), new SizeF((float)canvas3.ActualWidth, cantor.LineHeight)), cantor.Depth);

            }
        }


        /// <summary>
        /// Реакция на изменение размера окна.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (cantor.Canvas != null)
            {
                canvas3.Children.Clear();
                cantor.Depth = (int)slid1.Value;
                cantor.LineHeight = (int)slid3.Value;
                cantor.WhitespaceHeight = (int)slid2.Value;

                cantor.DrawRectangle(canvas3, new RectangleF(new PointF(0, 0), new SizeF((float)canvas3.ActualWidth, cantor.LineHeight)), cantor.Depth);
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
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)(canvas3.ActualWidth * scale), (int)(canvas3.ActualHeight * scale), dpi, dpi, PixelFormats.Pbgra32);
                bmp.Render(canvas3);
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
