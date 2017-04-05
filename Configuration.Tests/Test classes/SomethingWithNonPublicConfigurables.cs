// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Composition;

namespace Its.Configuration.Tests
{
    [Export]
    public class SomethingWithNonPublicConfigurables
    {
        [Import("some_bool")]
        private bool aBool;

        [Import("some_date")]
        internal DateTime aDate;

        [Import("some_string")]
        protected string aString;

        [Import("some_int")]
        protected internal int anInt;

        public bool ABool
        {
            get
            {
                return aBool;
            }
            set
            {
                aBool = value;
            }
        }

        public DateTime ADate
        {
            get
            {
                return aDate;
            }
            set
            {
                aDate = value;
            }
        }

        public string AString
        {
            get
            {
                return aString;
            }
            set
            {
                aString = value;
            }
        }

        public int AnInt
        {
            get
            {
                return anInt;
            }
            set
            {
                anInt = value;
            }
        }
    }
}