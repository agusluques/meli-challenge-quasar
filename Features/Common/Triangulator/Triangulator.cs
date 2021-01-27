// <copyright file="Triangulator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.Common.Triangulator
{
    using System;
    using FuegoDeQuasar.Common.Models;

    /// <summary>
    /// Triangulator class.
    /// </summary>
    public static class Triangulator
    {
        private static float x1;
        private static float x2;
        private static float x3;
        private static float y1;
        private static float y2;
        private static float y3;
        private static float d1;
        private static float d2;
        private static float d3;

        /// <summary>
        /// Triangulate a position.
        /// Formulas in: https://math.stackexchange.com/a/884851.
        /// </summary>
        /// <param name="p1">Position 1.</param>
        /// <param name="p2">Position 2.</param>
        /// <param name="p3">Position 3.</param>
        /// <param name="distance1">Distance 1.</param>
        /// <param name="distance2">Distance 2.</param>
        /// <param name="distance3">Distance 3.</param>
        /// <returns>Returns 2 floats (x, y).</returns>
        public static Position Triangulate(Position p1, Position p2, Position p3, float distance1, float distance2, float distance3)
        {
            x1 = p1.X;
            x2 = p2.X;
            x3 = p3.X;
            y1 = p1.Y;
            y2 = p2.Y;
            y3 = p3.Y;
            d1 = distance1;
            d2 = distance2;
            d3 = distance3;

            Position position = new Position(
                            (float)GetXCoordinate(),
                            (float)GetYCoordinate());
            return position;
        }

        private static double GetXCoordinate()
        {
            return GetXNumerator() / GetXDenominator();
        }

        private static double GetYCoordinate()
        {
            return GetYNumerator() / GetYDenominator();
        }

        private static double GetXNumerator()
        {
            return (C() * E()) - (F() * B());
        }

        private static double GetXDenominator()
        {
            return (E() * A()) - (B() * D());
        }

        private static double GetYNumerator()
        {
            return (C() * D()) - (A() * F());
        }

        private static double GetYDenominator()
        {
            return (B() * D()) - (A() * E());
        }

        private static double A()
        {
            return (-2 * x1) + (2 * x2);
        }

        private static double B()
        {
            return (-2 * y1) + (2 * y2);
        }

        private static double C()
        {
            return Math.Pow(d1, 2) - Math.Pow(d2, 2) - Math.Pow(x1, 2) + Math.Pow(x2, 2) - Math.Pow(y1, 2) + Math.Pow(y2, 2);
        }

        private static double D()
        {
            return (-2 * x2) + (2 * x3);
        }

        private static double E()
        {
            return (-2 * y2) + (2 * y3);
        }

        private static double F()
        {
            return Math.Pow(d2, 2) - Math.Pow(d3, 2) - Math.Pow(x2, 2) + Math.Pow(x3, 2) - Math.Pow(y2, 2) + Math.Pow(y3, 2);
        }
    }
}
