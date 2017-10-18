﻿// Licensed to the Apache Software Foundation (ASF) under one or more
// contributor license agreements.  See the NOTICE file distributed with
// this work for additional information regarding copyright ownership.
// The ASF licenses this file to You under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with
// the License.  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using Math3.exception;
using Math3.exception.util;
using System;

namespace Math3.linear
{
    /// <summary>
    /// Class to signal parse failures.
    /// </summary>
    public class MathParseException : MathIllegalStateException, ExceptionContextProvider
    {
        /// <param name="wrong">Bad string representation of the object.</param>
        /// <param name="position">Index, in the <c>wrong</c> string, that caused the
        /// parsing to fail.</param>
        /// <param name="type">Class of the object supposedly represented by the
        /// <c>wrong</c> string.</param>
        public MathParseException(String wrong, int position, Type type)
        {
            getContext().addMessage(new LocalizedFormats("CANNOT_PARSE_AS_TYPE"), wrong, position, type.Name);
        }

        /// <param name="wrong">Bad string representation of the object.</param>
        /// <param name="position">Index, in the <c>wrong</c> string, that caused the
        /// parsing to fail.</param>
        public MathParseException(String wrong, int position)
        {
            getContext().addMessage(new LocalizedFormats("CANNOT_PARSE"), wrong, position);
        }
    }
}