using System;
using System.Windows;
using FractalDrawer;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace fractal
{
    /// <summary>
    /// Реализация логики для Пифагорова дерева.
    /// </summary>
    public partial class TreeCantor : Window
    {
        private PythagorasFractal treeFractal = new PythagorasFractal();
        public TreeCantor(System.Windows.Media.Color color1, System.Windows.Media.Color color2)
        {
            try
            {
                InitializeComponent();
                MinHeight = SystemParameters.PrimaryScreenHeight / 2;
                MinWidth = SystemParameters.PrimaryScreenWidth / 2;
                treeFractal.Canvas = canvas2;
                treeFractal.StartColor = color1;
                treeFractal.EndColor = color2;
                try
                {
                    treeFractal.IndR = Math.Abs(treeFractal.EndColor.R - treeFractal.StartColor.R) / (treeFractal.EndColor.R - treeFractal.StartColor.R);
                    treeFractal.IndG = Math.Abs(treeFractal.EndColor.G - treeFractal.StartColor.G) / (treeFractal.EndColor.G - treeFractal.StartColor.G);
                    treeFractal.IndB = Math.Abs(treeFractal.EndColor.B - treeFractal.StartColor.B) / (treeFractal.EndColor.B - treeFractal.StartColor.B);
                }
                catch
                {
                    //проверка деления на ноль.
                }
                treeFractal.R = (byte)Math.Abs(treeFractal.EndColor.R- treeFractal.StartColor.R);
                treeFractal.G = (byte)Math.Abs(treeFractal.EndColor.G - treeFractal.StartColor.G);
                treeFractal.B = (byte)Math.Abs(treeFractal.EndColor.B - treeFractal.StartColor.B);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void slid1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (treeFractal.Canvas != null)
            {
                canvas2.Children.Clear();
                treeFractal.Depth = (int)slid1.Value;
                treeFractal.R = (byte)Math.Abs(treeFractal.EndColor.R - treeFractal.StartColor.R);
                treeFractal.G = (byte)Math.Abs(treeFractal.EndColor.G - treeFractal.StartColor.G);
                treeFractal.B = (byte)Math.Abs(treeFractal.EndColor.B - treeFractal.StartColor.B);
                treeFractal.R = (byte)(Math.Round(treeFractal.R / (float)treeFractal.Depth));
                treeFractal.G = (byte)(Math.Round(treeFractal.G / (float)treeFractal.Depth));
                treeFractal.B = (byte)(Math.Round(treeFractal.B / (float)treeFractal.Depth));
                treeFractal.RightAngle = (int)slid2.Value * Math.PI / 180;
                treeFractal.LeftAngle = (int)slid3.Value * Math.PI / 180;
                treeFractal.Coefficient = slid5.Value;
                treeFractal.DrawLine(canvas2, new PointF((float)canvas2.ActualWidth / 2f, (float)canvas2.ActualHeight), Math.PI / 2, canvas2.ActualHeight / 4, treeFractal.Depth);
            }
        }


        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void slid2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (treeFractal.Canvas != null)
            {
                canvas2.Children.Clear();
                treeFractal.Depth = (int)slid1.Value;
                treeFractal.RightAngle = (int)slid2.Value * Math.PI / 180;
                treeFractal.LeftAngle = (int)slid3.Value * Math.PI / 180;
                treeFractal.Coefficient = slid5.Value;
                treeFractal.DrawLine(canvas2, new PointF((float)canvas2.ActualWidth / 2f, (float)canvas2.ActualHeight), Math.PI / 2, canvas2.ActualHeight / 4, treeFractal.Depth);
            }
        }


        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void slid3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (treeFractal.Canvas != null)
            {
                canvas2.Children.Clear();
                treeFractal.Depth = (int)slid1.Value;
                treeFractal.RightAngle = (int)slid2.Value * Math.PI / 180;
                treeFractal.LeftAngle = (int)slid3.Value * Math.PI / 180;
                treeFractal.Coefficient = slid5.Value;
                treeFractal.DrawLine(canvas2, new PointF((float)canvas2.ActualWidth / 2f, (float)canvas2.ActualHeight), Math.PI / 2, canvas2.ActualHeight / 4, treeFractal.Depth);
            }
        }


        /// <summary>
        /// Реакция на изменение размеров окна.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (treeFractal.Canvas != null)
            {
                canvas2.Children.Clear();
                treeFractal.Depth = (int)slid1.Value;
                treeFractal.RightAngle = (int)slid2.Value * Math.PI / 180;
                treeFractal.LeftAngle = (int)slid3.Value * Math.PI / 180;
                treeFractal.Coefficient = slid5.Value;
                treeFractal.DrawLine(canvas2, new PointF((float)canvas2.ActualWidth / 2f, (float)canvas2.ActualHeight), Math.PI / 2, canvas2.ActualHeight / 4, treeFractal.Depth);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double dpi = 300;
                var scale = dpi / 96;
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)(canvas2.ActualWidth * scale), (int)(canvas2.ActualHeight * scale), dpi, dpi, PixelFormats.Pbgra32);
                bmp.Render(canvas2);

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
