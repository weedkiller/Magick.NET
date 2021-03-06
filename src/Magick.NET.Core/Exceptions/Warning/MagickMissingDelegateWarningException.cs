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

namespace ImageMagick
{
    /// <summary>
    /// Encapsulation of the ImageMagick MissingDelegateWarning exception.
    /// </summary>
    public sealed class MagickMissingDelegateWarningException : MagickWarningException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagickMissingDelegateWarningException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public MagickMissingDelegateWarningException(string message)
          : base(message)
        {
        }
    }
}
