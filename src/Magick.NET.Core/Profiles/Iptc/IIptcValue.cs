﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System;
using System.Text;

namespace ImageMagick
{
    /// <summary>
    /// A value of the iptc profile.
    /// </summary>
    public interface IIptcValue : IEquatable<IIptcValue>
    {
        /// <summary>
        /// Gets the tag of the iptc value.
        /// </summary>
        IptcTag Tag { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Gets the length of the value.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Converts this instance to a byte array.
        /// </summary>
        /// <returns>A <see cref="byte"/> array.</returns>
        byte[] ToByteArray();

        /// <summary>
        /// Returns a string that represents the current value.
        /// </summary>
        /// <returns>A string that represents the current value.</returns>
        string ToString();
    }
}
