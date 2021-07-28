﻿// Copyright (C) Microsoft. All rights reserved.

using System;
using System.Text.Json;

namespace GameStoreBroker.ClientApi
{
    internal static class ObjectExtensions
    {
        private static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions()
        {
            IgnoreNullValues = true,
        };

        public static string ToJson<T>(this T value, JsonSerializerOptions jsonSerializerOptions = null) where T : class
        {
            if (value == null)
            {
                return "null";
            }

            try
            {
                var serializedObject = JsonSerializer.Serialize(value, jsonSerializerOptions ?? DefaultJsonSerializerOptions);
                return serializedObject;
            }
            catch (Exception ex)
            {
                return $"Could not serialize object to json - {ex.Message}";
            }
        }
    }
}
