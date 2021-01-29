// <copyright file="QueryRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.GetAll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Query request top secret split.
    /// </summary>
    public class QueryRequest : IRequest<IActionResult>
    {
    }
}
