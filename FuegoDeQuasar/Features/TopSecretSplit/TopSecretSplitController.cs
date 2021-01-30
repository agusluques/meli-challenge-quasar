// <copyright file="TopSecretSplitController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// TopSecretSplit controller.
    /// </summary>
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/topsecret_split")]
    public class TopSecretSplitController : Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopSecretSplitController"/> class.
        /// </summary>
        /// <param name="mediator">MediatR injection.</param>
        public TopSecretSplitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Post one satellite information.
        /// </summary>
        /// <param name="command">Satellite information parameters.</param>
        /// <returns>Response.</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(Create.CommandRequest command) => await this.mediator.Send(command).ConfigureAwait(false);

        /// <summary>
        /// Get sender information.
        /// </summary>
        /// <param name="query">Query request.</param>
        /// <returns>Response.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Models.ReadModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync([FromQuery] GetAll.QueryRequest query) => await this.mediator.Send(query).ConfigureAwait(false);
    }
}
