﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using GameStoreBroker.Application.Extensions;
using GameStoreBroker.Application.Schema;
using GameStoreBroker.ClientApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GameStoreBroker.Application.Operations
{
    internal class GetProductOperation : Operation
    {
        private readonly IHost _host;
        private readonly ILogger<GetProductOperation> _logger;

        public GetProductOperation(IHost host, Options options) : base(host, options)
        {
            _host = host;
            _logger = _host.Services.GetRequiredService<ILogger<GetProductOperation>>();
        }

        protected override async Task ProcessAsync(CancellationToken ct)
        {
            using var scope = _host.Services.CreateScope();
            var storeBroker = scope.ServiceProvider.GetRequiredService<IGameStoreBrokerService>();

            _logger.LogInformation("Starting GetProduct operation.");

            var schema = await GetSchemaAsync<GetProductOperationSchema>(ct).ConfigureAwait(false);
            var aadAuthInfo = GetAadAuthInfo(schema.AadAuthInfo);
            var accessTokenProvider = new AccessTokenProvider(aadAuthInfo);

            var product = await new ProductService(storeBroker, accessTokenProvider).GetProductAsync(schema, ct).ConfigureAwait(false);
            _logger.LogInformation("Product: {product}", product.ToJson());
        }
    }
}