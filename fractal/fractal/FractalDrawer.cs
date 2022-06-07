using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using Shapes;
using System.Windows;
using System.Collections.Generic;

namespace FractalDrawer
{
    /// <summary>
    /// Класс от которого наследуются все фракталы.
    /// (Не содержит метод drow, так как сигнатуры методов- отрисовки классов наследников различаются.)
    /// </summary>
    public abstract class Fractal
    {

        /// <summary>
        /// Свойство для глубины рекурсии.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Свойство передает текущий канвас.
        /// </summary>
        public Canvas Canvas { get; set; }

        /// <summary>
        /// Метод ответсвенный за сортировку.
        /// </summary>
        abstract public void DrawTo();

        /// <summary>
        /// Свойство задающее начальный цвет.
        /// </summary>
        public System.Windows.Media.Color StartColor { get; set; }


        /// <summary>
        /// Свойство задающее начальный цвет.
        /// </summary>
        public System.Windows.Media.Color EndColor { get; set; }

        /// <summary>
        /// Свойство задающее R in RGB
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// Свойство задающее G in RGB
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        /// Свойство задающее B in RGB
        /// </summary>
        public byte B { get; set; }

        /// <summary>
        /// Индикатор для R.
        /// </summary>
        public int IndR { get; set; }

        /// <summary>
        /// Индикатор для G.
        /// </summary>
        public int IndG { get; set; }

        /// <summary>
        /// Индикатор для B.
        /// </summary>
        public int IndB { get; set; }

    }

    /// <summary>
    /// Реализация треугольника Серпинского. 
    /// </summary>
    /// 
    public class SierpinskiTriangle:Fractal 
    {
        

        /// <summary>
        /// Соотношение сторон для правильных расчетов.
        /// </summary>
        private readonly float _coefficient = (float)Math.Sqrt(3) / 2f;

        

        /// <summary>
        /// Отрисовка основного треугольника.
        /// </summary>
        /// <returns>Основной треугольник</returns>
        public Triangle DrawMainTriangle(Canvas myCanvas )
        {
            float x, y, bigSide, smallSide;
            if (myCanvas.ActualHeight / (float)myCanvas.ActualWidth >= _coefficient)
            {
                bigSide = (float)myCanvas.ActualWidth;
                smallSide = bigSide * _coefficient;
                x = 0;
                y = ((float)myCanvas.ActualHeight - smallSide) / 2f;
            }
            else
            {
                smallSide = (float)myCanvas.ActualHeight;
                bigSide = smallSide / _coefficient;
                x = ((float)myCanvas.ActualWidth - bigSide) / 2f;
                y = 0;
            }
            var rectangle = new RectangleF(new PointF(x, y),
                new SizeF(bigSide, smallSide));
            var triangle = new Triangle { Rectangle = rectangle };
            var line = new System.Windows.Shapes.Line();
            line.X1 = triangle.Top.X;
            line.Y1 = triangle.Top.Y;
            line.X2 = triangle.Left.X;
            line.Y2 = triangle.Left.Y;
            line.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R),
                                        (byte)(StartColor.G), (byte)(StartColor.B)));

            myCanvas.Children.Add(line);
            var line1 = new System.Windows.Shapes.Line();
            line1.X1 = triangle.Left.X;
            line1.Y1 = triangle.Left.Y;
            line1.X2 = triangle.Right.X;
            line1.Y2 = triangle.Right.Y;
            line1.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R),
                                        (byte)(StartColor.G), (byte)(StartColor.B)));
            myCanvas.Children.Add(line1);
            var line2 = new System.Windows.Shapes.Line();
            line2.X1 = triangle.Right.X;
            line2.Y1 = triangle.Right.Y;
            line2.X2 = triangle.Top.X;
            line2.Y2 = triangle.Top.Y;
            line2.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R),
                                        (byte)(StartColor.G), (byte)(StartColor.B)));
            myCanvas.Children.Add(line2);
            return triangle;
        }

        /// <summary>
        /// Метод запускающий отрисовку.
        /// </summary>
        public override void DrawTo()
        {
            DrawMainTriangle(Canvas);
        }

        /// <summary>
        /// Отрисовка по рекурсии.
        /// </summary>
        /// <param name="triangle">Прошлый треугольник</param>
        /// <param name="count">Глубина рекурсии</param>
        public void RecursionDraw(Canvas myCanvas, Triangle triangle, int count)
        {
            if (count == 1)
                return;
            var newBigSide = triangle.Rectangle.Width / 2;
            var newSmallSide = triangle.Rectangle.Height / 2;
            DrawTriangle( myCanvas, new Triangle
            {
                Rectangle = new RectangleF(
                    PointF.Add(
                        triangle.Rectangle.Location,
                        new SizeF(triangle.Rectangle.Width / 4f, 0)),
                        new SizeF(newBigSide,newSmallSide))}, count);
            DrawTriangle( myCanvas, new Triangle
            {
                Rectangle = new RectangleF(
                    PointF.Add(triangle.Rectangle.Location,new SizeF(0, newSmallSide)),
                        new SizeF(newBigSide,newSmallSide))}, count);
            DrawTriangle( myCanvas, new Triangle
            {
                Rectangle = new RectangleF(
                    PointF.Add(triangle.Rectangle.Location,new SizeF(newBigSide, newSmallSide)),
                    new SizeF(newBigSide,newSmallSide))}, count);
        }
        
        /// <summary>
        /// Отрисовка треугольника
        /// </summary>
        /// <param name="triangle">Треугольник</param>
        /// <param name="count">Глубина рекурсии</param>
        private void DrawTriangle(Canvas myCanvas, Triangle triangle, int count)
        {
            var line = new System.Windows.Shapes.Line();
            line.X1 = triangle.Top.X;
            line.Y1 = triangle.Top.Y;
            line.X2 = triangle.Left.X;
            line.Y2 = triangle.Left.Y;
            line.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R + IndR*R * (Depth - count)),
                                        (byte)(StartColor.G + IndG*G * (Depth - count)), (byte)(StartColor.B + IndB*B * (Depth - count))));
            myCanvas.Children.Add(line);
            var line1 = new System.Windows.Shapes.Line();
            line1.X1 = triangle.Left.X;
            line1.Y1 = triangle.Left.Y;
            line1.X2 = triangle.Right.X;
            line1.Y2 = triangle.Right.Y;
            line1.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R + IndR * R * (Depth - count)),
                                        (byte)(StartColor.G + IndG * G * (Depth - count)), (byte)(StartColor.B + IndB * B * (Depth - count))));
            myCanvas.Children.Add(line1);
            var line2 = new System.Windows.Shapes.Line();
            line2.X1 = triangle.Right.X;
            line2.Y1 = triangle.Right.Y;
            line2.X2 = triangle.Top.X;
            line2.Y2 = triangle.Top.Y;
            line2.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R + IndR * R * (Depth - count)),
                                        (byte)(StartColor.G + IndG * G * (Depth - count)), (byte)(StartColor.B + IndB * B * (Depth - count))));
            myCanvas.Children.Add(line2);
            RecursionDraw(myCanvas, triangle, count - 1);
        }
    }


    /// <summary>
    /// Реализация ковра Серпинского. 
    /// </summary>
    /// 
    public class SierpinskiCarpet :Fractal
    {


        /// <summary>
        /// Отрисовка основного квадрата.
        /// </summary>
        /// <returns>Основной квадрат</returns>
        public RectangleF DrawMainRectangle(Canvas myCanvas)
        {
            
            float canvaHeight,canvaWidth;
            canvaHeight = (float)myCanvas.ActualHeight;
            canvaWidth = (float)myCanvas.ActualWidth;
            float x, y, side;
            if (canvaWidth > canvaHeight)
            {
                side = (float)canvaHeight;
                x = ((float)canvaWidth - side) / 2;
                y = 0;
            }
            else
            {
                side = (float)canvaWidth;
                x = 0;
                y = ((float)canvaHeight - side) / 2;
            }
            var rectangle = new RectangleF(new PointF(x, y),new SizeF(side, side));
            var rect = new System.Windows.Shapes.Rectangle();
            rect.Height = side;
            rect.Width = side;
            Thickness marg = new Thickness(x, y, 0, 0);
            rect.Margin = marg;
            rect.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R ),
                                        (byte)(StartColor.G ), (byte)(StartColor.B )));

            if ( myCanvas.IsInitialized)
                myCanvas.Children.Add(rect);
            return rectangle;
        }


        /// <summary>
        /// Отрисовка рекурсии.
        /// </summary>
        /// <param name="rectangle">Прошлый квадрат</param>
        /// <param name="count">Глубина рекурсии</param>
        public void RecursionDraw(Canvas myCanvas, RectangleF rectangle, int count)
        {
            if (count == 0)
                return;
            var newRectangles = new RectangleF[9];
            var newSide = rectangle.Height / 3;
            var сoordinates = rectangle.Location;
            for (var i = 0; i < newRectangles.Length; i++)
            {
                newRectangles[i] = new RectangleF(сoordinates,new SizeF(newSide, newSide));
                сoordinates = i % 3 == 2
                    ? new PointF(rectangle.X, сoordinates.Y + newSide)
                    : PointF.Add(сoordinates, new SizeF(newSide, 0));
            }
            var rect = new System.Windows.Shapes.Rectangle();
            rect.Height = newRectangles[4].Height;
            rect.Width = newRectangles[4].Height;
            Thickness margin = new Thickness(newRectangles[4].X, newRectangles[4].Y, 0, 0);
            rect.Margin = margin;
            rect.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R + IndR * R * (Depth - count)),
                                        (byte)(StartColor.G + IndG * G * (Depth - count)), (byte)(StartColor.B + IndB * B * (Depth - count))));
            myCanvas.Children.Add(rect);
            for (var i = 0; i < newRectangles.Length; i++)
            {
                if (i != 4)
                    RecursionDraw(myCanvas,newRectangles[i], count - 1);
            } 
        }

        /// <summary>
        /// Метод запускающий отрисовку.
        /// </summary>
        public override void DrawTo()
        {
            DrawMainRectangle(Canvas);
        }
    }



    /// <summary>
    /// Реализация Пифагорова дерева. 
    /// </summary>
    /// 
    public class PythagorasFractal: Fractal
    {
       
        /// <summary>
        /// Левый угол поворота.
        /// </summary>
        public double LeftAngle { get; set; }

        /// <summary>
        /// Правый угол поворота.
        /// </summary>
        public double RightAngle { get; set; }


        /// <summary>
        /// Соотношения длин отрезков.
        /// </summary>
        public double Coefficient { get; set; }

        

        
        /// <summary>
        /// Отрисовка ветки Пифагорова дерева
        /// </summary>
        /// <param name="start">Точка отсчета</param>
        /// <param name="angle">Угол наклона</param>
        /// <param name="length">Длина ветки</param>
        /// <param name="count">Глубина рекурсии</param>
        public void DrawLine(Canvas MyCanvas1, PointF start, double angle, double length, int count)
        {
            if (count == 0)
                return;
            var end = new PointF(
                (float)(start.X + length * Math.Cos(angle)),
                (float)(start.Y - length * Math.Sin(angle)));
            var line = new System.Windows.Shapes.Line();
            line.X1 = start.X;
            line.Y1 = start.Y;
            line.X2 = end.X;
            line.Y2 = end.Y;
            line.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R + IndR*R * (Depth - count)), 
                                        (byte)(StartColor.G + IndG*G * (Depth - count)), (byte)(StartColor.B + IndB*B * (Depth - count))));
            MyCanvas1.Children.Add(line);
            DrawLine(MyCanvas1,end, angle + LeftAngle, length / Coefficient, count - 1);
            DrawLine(MyCanvas1,end, angle - RightAngle, length / Coefficient, count - 1);
        }

        /// <summary>
        /// Метод запускающий отрисовку.
        /// </summary>
        public override void DrawTo()
        {
            DrawLine(Canvas, new PointF(), 45, 45, Depth);
        }
    }



    /// <summary>
    /// Реализация Множества Кантора.
    /// </summary>
    /// 
    public class CantorSet : Fractal
    {
        /// <summary>
        /// Длина линии.
        /// </summary>
        public float LineHeight { get; set; }

        /// <summary>
        /// Длина пробелов.
        /// </summary>
        public float WhitespaceHeight { get; set; }

       
        /// <summary>
        /// Отрисвка прямоугольников.
        /// </summary>
        /// <param name="rectangle">Прошлый прямоугольник</param>
        /// <param name="count">Глубина рекурсии</param>
        public void DrawRectangle(Canvas myCanvas, RectangleF rectangle, int count)
        {
            if (count == 0)
                return;
            var rect = new System.Windows.Shapes.Rectangle();
            rect.Height = rectangle.Height;
            rect.Width = rectangle.Width;
            Thickness marg = new Thickness(rectangle.X, rectangle.Y, 0, 0);
            rect.Margin = marg;
            rect.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R + IndR * R * (Depth - count)),
                                        (byte)(StartColor.G + IndG * G * (Depth - count)), (byte)(StartColor.B + IndB * B * (Depth - count))));
            if (myCanvas.IsInitialized)
                myCanvas.Children.Add(rect);
            DrawRectangle(myCanvas,
                new RectangleF(
                    PointF.Add(rectangle.Location,new SizeF(0, LineHeight + WhitespaceHeight)),
                    SizeF.Subtract(rectangle.Size, new SizeF(2 * rectangle.Width / 3f, 0))),count - 1);
            DrawRectangle(myCanvas,
                new RectangleF(
                    PointF.Add(rectangle.Location,new SizeF(2 * rectangle.Width / 3f, LineHeight + WhitespaceHeight)),
                    SizeF.Subtract(rectangle.Size, new SizeF(2 * rectangle.Width / 3f, 0))), count - 1);
        }
        /// <summary>
        /// Метод запускающий отрисовку.
        /// </summary>
        public override void DrawTo()
        {
            DrawRectangle(Canvas, new RectangleF(), Depth);
        }
    }



    /// <summary>
    /// Реализация Кривой Коха.
    /// </summary>
    /// 
    public class CochCurve : Fractal
    {
        
        /// <summary>
        /// Отрисовка элементов.
        /// </summary>
        /// <param name="line">Производная линия</param>
        /// <param name="count">Глубина рекурсии<param>
        public void DrawLine(Canvas myCanvas,Shapes.Line line, int count)
        {
            if (count == 0)
            {
                var line1 = new System.Windows.Shapes.Line();
                line1.X1 = line.Start.X;
                line1.Y1 = line.Start.Y;
                line1.X2 = line.End.X;
                line1.Y2 = line.End.Y;
                line1.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(StartColor.R + IndR * R * (Depth - count)),
                                        (byte)(StartColor.G + IndG * G * (Depth - count)), (byte)(StartColor.B + IndB * B * (Depth - count))));
                myCanvas.Children.Add(line1);
                return;
            }
            foreach (var newLine in SplitLine(line))
            {
                DrawLine(myCanvas,newLine, count - 1);
            }
        }

        /// <summary>
        /// Деление линии на 4 части.
        /// </summary>
        /// <param name="line">Производная линия</param>
        /// <returns>Список линий</returns>
        private static IEnumerable<Shapes.Line> SplitLine(Shapes.Line line)
        {
            var newLength = line.Length / 3;
            var line1 = new Shapes.Line()
            {
                Start = line.Start,
                Angle = line.Angle,
                End = new PointF(
                    (float)(line.Start.X + newLength * Math.Cos(line.Angle)),
                    (float)(line.Start.Y - newLength * Math.Sin(line.Angle)))
            };

            yield return line1;
            var angle2 = (float)(line1.Angle + Math.PI / 3f);
            var line2 = new Shapes.Line()
            {
                Start = line1.End,
                Angle = angle2,
                End = new PointF(
                    (float)(line1.End.X + newLength * Math.Cos(angle2)),
                    (float)(line1.End.Y - newLength * Math.Sin(angle2)))
            };

            yield return line2;
            var angle3 = (float)(line2.Angle - 2f * Math.PI / 3f);
            var line3 = new Shapes.Line()
            {
                Start = line2.End,
                Angle = angle3,
                End = new PointF(
                    (float)(line2.End.X + newLength * Math.Cos(angle3)),
                    (float)(line2.End.Y - newLength * Math.Sin(angle3)))
            };

            yield return line3;
            var angle4 = (float)(line3.Angle + Math.PI / 3f);
            var line4 = new Shapes.Line()
            {
                Start = line3.End,
                Angle = angle4,
                End = new PointF(
                    (float)(line3.End.X + newLength * Math.Cos(angle4)),
                    (float)(line3.End.Y - newLength * Math.Sin(angle4)))
            };
            yield return line4;
        }
        /// <summary>
        /// Метод запускающий отрисовку.
        /// </summary>
        public override void DrawTo()
        {
            DrawLine(Canvas, new Shapes.Line(), Depth);
        }
    }
}