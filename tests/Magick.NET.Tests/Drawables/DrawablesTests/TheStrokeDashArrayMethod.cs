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

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class DrawablesTests
    {
        public class TheStrokeDashArrayMethod
        {
            [Fact]
            public void ShouldRenderCorrectly()
            {
                using (var image = new MagickImage(MagickColors.White, 210, 210))
                {
                    var drawables = new Drawables()
                        .StrokeDashArray(20.0, 10.0)
                        .StrokeLineCap(LineCap.Round)
                        .StrokeAntialias(true)
                        .StrokeWidth(5.0)
                        .FillColor(MagickColors.Transparent)
                        .StrokeColor(MagickColors.OrangeRed)
                        .Rectangle(5, 5, 200, 200);

                    image.Draw(drawables);

                    ColorAssert.Equal(MagickColors.OrangeRed, image, 7, 40);
                    ColorAssert.Equal(MagickColors.OrangeRed, image, 7, 175);
                    ColorAssert.Equal(MagickColors.OrangeRed, image, 200, 30);
                    ColorAssert.Equal(MagickColors.OrangeRed, image, 200, 170);
                }
            }
        }
    }
}
