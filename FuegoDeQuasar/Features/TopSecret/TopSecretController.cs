// <copyright file="TopSecretController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecret
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// TopSecret controller.
    /// </summary>
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/topsecret")]
    public class TopSecretController : Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopSecretController"/> class.
        /// </summary>
        /// <param name="mediator">MediatR injection.</param>
        public TopSecretController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Post satellites information.
        /// </summary>
        /// <param name="command">Satellites information parameters.</param>
        /// <returns>Sender information response.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Models.ReadModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync(Create.CommandRequest command) => await this.mediator.Send(command).ConfigureAwait(false);
    }
}
