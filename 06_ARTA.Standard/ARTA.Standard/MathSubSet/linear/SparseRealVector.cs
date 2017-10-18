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
namespace Math3.linear
{
    /// <summary>
    /// Marker class for RealVectors that require sparse backing storage
    /// <para>
    /// Caveat: Implementation are allowed to assume that, for any <c>x</c>,
    /// the equality <c>x * 0d == 0d</c> holds. But it is is not true for
    /// <c>NaN</c>. Moreover, zero entries will lose their sign.
    /// Some operations (that involve <c>NaN</c> and/or infinities) may
    /// thus give incorrect results, like multiplications, divisions or
    /// functions mapping.
    /// </para>
    /// </summary>
    public abstract class SparseRealVector : RealVector { }
}