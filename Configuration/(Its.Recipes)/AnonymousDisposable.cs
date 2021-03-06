// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;

namespace Its.Recipes
{
    /// <summary>
    /// A disposable that calls a specified action when disposed.
    /// </summary>
#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
#endif
    internal class AnonymousDisposable : IDisposable
    {
        private readonly Action dispose;
        private readonly object lockObject = new object();
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousDisposable" /> class.
        /// </summary>
        /// <param name="dispose">The action to be called when the anonymous disposable is disposed.</param>
        /// <exception cref="ArgumentNullException">dispose</exception>
        public AnonymousDisposable(Action dispose)
        {
            if (dispose == null)
            {
                throw new ArgumentNullException("dispose");
            }
            this.dispose = dispose;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            lock (lockObject)
            {
                if (disposed)
                {
                    return;
                }
                disposed = true;
                dispose();
            }
        }
    }
}