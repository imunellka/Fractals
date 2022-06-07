using System.Windows;
using FractalDrawer;
using Shapes;
using System.Drawing;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace fractal
{
    /// <summary>
    /// Реализация логики для CochForm.
    /// </summary>
    public partial class CochForm : Window
    {
        private CochCurve coche = new CochCurve();
        public CochForm(System.Windows.Media.Color color1, System.Windows.Media.Color color2)
        {
            InitializeComponent();
            MinHeight = SystemParameters.PrimaryScreenHeight / 2;
            MinWidth = SystemParameters.PrimaryScreenWidth / 2;
            MinHeight = SystemParameters.PrimaryScreenHeight / 2;
            MinWidth = SystemParameters.PrimaryScreenWidth / 2;
            coche.Canvas = canvas1;
            coche.StartColor = color1;
            coche.EndColor = color2;
            try
            {
                coche.IndR = Math.Abs(coche.EndColor.R - coche.StartColor.R) / (coche.EndColor.R - coche.StartColor.R);
                coche.IndG = Math.Abs(coche.EndColor.G - coche.StartColor.G) / (coche.EndColor.G - coche.StartColor.G);
                coche.IndB = Math.Abs(coche.EndColor.B - coche.StartColor.B) / (coche.EndColor.B - coche.StartColor.B);
            }
            catch
            {
                //проверка деления на ноль.
            }
            coche.R = (byte)Math.Abs(coche.EndColor.R - coche.StartColor.R);
            coche.G = (byte)Math.Abs(coche.EndColor.G - coche.StartColor.G);
            coche.B = (byte)Math.Abs(coche.EndColor.B - coche.StartColor.B);
        }


        /// <summary>
        /// Реакция на изменение значения слайдера.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (coche.Canvas != null)
            {
                canvas1.Children.Clear();
                coche.Depth = (int)slider1.Value;
                coche.R = (byte)Math.Abs(coche.EndColor.R - coche.StartColor.R);
                coche.G = (byte)Math.Abs(coche.EndColor.G - coche.StartColor.G);
                coche.B = (byte)Math.Abs(coche.EndColor.B - coche.StartColor.B);
                coche.R = (byte)(Math.Round(coche.R / (float)coche.Depth));
                coche.G = (byte)(Math.Round(coche.G / (float)coche.Depth));
                coche.B = (byte)(Math.Round(coche.B / (float)coche.Depth));
                var initial = new Shapes.Line()
                {
                    Start = new PointF(0, (float)canvas1.ActualHeight / 1.5f),
                    End = new PointF((float)canvas1.ActualWidth, (float)canvas1.ActualHeight / 1.5f),
                    Angle = 0
                };
                coche.DrawLine(canvas1,initial, coche.Depth);
            }
        }


        /// <summary>
        /// Реакция на изменение размера окна.
        /// </summary>
        /// <param name="sender">cсылка</param>
        /// <param name="e">событие</param>
        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (coche.Canvas != null)
            {
                canvas1.Children.Clear();

                coche.Depth = (int)slider1.Value;
                var initial = new Shapes.Line()
                {
                    Start = new PointF(0, (float)canvas1.ActualHeight / 1.5f),
                    End = new PointF((float)canvas1.ActualWidth, (float)canvas1.ActualHeight / 1.5f),
                    Angle = 0
                };
                coche.DrawLine(canvas1, initial, coche.Depth);
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
