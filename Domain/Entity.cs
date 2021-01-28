// <copyright file="Entity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Common entity in database.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the id of the entity.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
