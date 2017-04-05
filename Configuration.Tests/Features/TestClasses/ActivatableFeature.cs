// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Composition;
using Its.Configuration.Features;

namespace Its.Configuration.Tests.Features.TestClasses
{
    [Export(typeof (IFeature))]
    public class ActivatableFeature : IFeature
    {
        private readonly FeatureActivator availability;

        public ActivatableFeature(params IObservable<bool>[] dependsOn)
        {
            availability = new FeatureActivator(
                Activate,
                Deactivate,
                dependsOn);
        }

        private void Deactivate()
        {
        }

        private void Activate()
        {
        }

        public IObservable<bool> Availability
        {
            get
            {
                return availability;
            }
        }
    }
}