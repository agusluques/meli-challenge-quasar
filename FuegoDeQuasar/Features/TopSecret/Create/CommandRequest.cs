// <copyright file="CommandRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecret.Create
{
    using System.Collections.Generic;
    using FuegoDeQuasar.Features.TopSecret.Models;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// CommandRequest TopSecret.
    /// </summary>
    public class CommandRequest : IRequest<IActionResult>
    {
        /// <summary>
        /// Gets or sets lists of satellites information.
        /// </summary>
        [FromBody]
        public IList<WriteModel> Satellites { get; set; }
    }
}
