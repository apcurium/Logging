﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Microsoft.Framework.Internal;

namespace Microsoft.Framework.Logging
{
    public static class TraceSourceFactoryExtensions
    {
        public static ILoggerFactory AddTraceSource(
            [NotNull] this ILoggerFactory factory,
            [NotNull] string switchName,
            [NotNull] TraceListener listener)
        {
            return factory.AddTraceSource(new SourceSwitch(switchName), listener);
        }

        public static ILoggerFactory AddTraceSource(
            [NotNull] this ILoggerFactory factory, 
            [NotNull] SourceSwitch sourceSwitch,
            [NotNull] TraceListener listener)
        {
            factory.AddProvider(new TraceSourceLoggerProvider(sourceSwitch, listener));

            return factory;
        }
    }
}