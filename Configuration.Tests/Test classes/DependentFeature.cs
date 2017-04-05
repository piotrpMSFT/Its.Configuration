// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Composition;
using System.Threading;

namespace Its.Configuration.Tests.Recipes
{
    [Export("Feature", typeof (ISupportInitialize))]
    public class DependentFeature : ISupportInitialize
    {
        public static int CtorCount = 0;
        public static int BeginInitCount = 0;
        public static int EndInitCount = 0;

        public static Action<PrimaryFeature> OnCtor = feature => { };

        public DependentFeature(PrimaryFeature primaryFeature)
        {
            Interlocked.Increment(ref CtorCount);
            OnCtor(primaryFeature);
        }

        public void BeginInit()
        {
            Interlocked.Increment(ref BeginInitCount);
        }

        public void EndInit()
        {
            Interlocked.Increment(ref EndInitCount);
        }
    }
}