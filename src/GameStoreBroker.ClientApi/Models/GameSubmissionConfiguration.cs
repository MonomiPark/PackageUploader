﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;

namespace GameStoreBroker.ClientApi.Models
{
    public class GameSubmissionConfiguration : IGameSubmissionConfiguration
    {
        /// <summary>
        /// Scheduled release time (UTC). Default value is null, and submission will be published as soon as possible.
        /// </summary>
        public DateTime? ReleaseTimeInUtc { get; init; }

        /// <summary>
        /// Flag of if manual publish is enabled. Default value is false.
        /// </summary>
        public bool IsManualPublish { get; init; }

        /// <summary>
        /// Certification notes
        /// </summary>
        public string CertificationNotes { get; set; }
    }
}
