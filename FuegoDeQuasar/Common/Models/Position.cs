// <copyright file="Position.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Common.Models
{
    /// <summary>
    /// Represent a position in a 2D map.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">x position.</param>
        /// <param name="y">y position.</param>
        public Position(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets x axis.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets y axis.
        /// </summary>
        public float Y { get; set; }
    }
}
