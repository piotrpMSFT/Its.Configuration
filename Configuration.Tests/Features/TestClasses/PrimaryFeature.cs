// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Composition;
using System.Threading;
using Its.Configuration.Features;

namespace Its.Configuration.Tests.Features.TestClasses
{
    [Export(typeof (IFeature))]
    public class PrimaryFeature : IFeature
    {
        public static int CtorCount = 0;
        public static int ActivateCount = 0;
        public static Action OnCtor = () => { };
        public static Action OnActivate = () => { };

        public PrimaryFeature()
        {
            Interlocked.Increment(ref CtorCount);
            OnCtor();
        }

        private readonly FeatureActivator initialized = new FeatureActivator(() =>
        {
            Interlocked.Increment(ref ActivateCount);
            OnActivate();
        });

        public IObservable<bool> Availability
        {
            get
            {
                return initialized;
            }
        }
    }
}