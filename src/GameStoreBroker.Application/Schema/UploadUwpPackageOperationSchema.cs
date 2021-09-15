// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;

namespace GameStoreBroker.Application.Schema
{
    internal class UploadUwpPackageOperationSchema : UploadPackageOperationSchema
    {
        protected override string GetOperationName() => "UploadUwpPackage";

        [Required]
        public string PackageFilePath { get; set; }
    }
}