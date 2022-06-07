using System;
using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// Описание простого треугольника
    /// </summary>
    public struct Triangle
    {
        /// <summary>
        /// Квадрат содержащий точки треугольника.
        /// </summary>
        public RectangleF Rectangle { get; set; }

        /// <summary>
        /// Верхняя точка треугольника.
        /// </summary>
        public PointF Top
            => PointF.Add(Rectangle.Location, new SizeF(Rectangle.Width / 2f, 0));

        /// <summary>
        /// Левая точка треугольника.
        /// </summary>
        public PointF Left
            => PointF.Add(Rectangle.Location, new SizeF(0, Rectangle.Height));

        /// <summary>
        /// Правая точка треугольника.
        /// </summary>
        public PointF Right
            => PointF.Add(Rectangle.Location, new SizeF(Rectangle.Width, Rectangle.Height));
    }

    /// <summary>
    /// Реализация структуры отрезка. 
    /// ( в отличии от имеющейся в библиотеке System.Drawing обладает углом)
    /// </summary>
    public struct Line
    {
        /// <summary>
        /// Начальная точка.
        /// </summary>
        public PointF Start { get; set; }

        /// <summary>
        /// Конечная точка.
        /// </summary>
        public PointF End { get; set; }

        /// <summary>
        /// Угол относительно абсциссы.
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// Длина отрезка.
        /// </summary>
        public float Length
            => (float)Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2));
    }



}