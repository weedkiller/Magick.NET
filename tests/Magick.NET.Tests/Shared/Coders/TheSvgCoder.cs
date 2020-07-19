﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    [TestClass]
    public class TheSvgCoder
    {
        [TestMethod]
        public void ShouldDetectFormatFromXmlDeclaration()
        {
            var data = Encoding.ASCII.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8""?>");

            var info = new MagickImageInfo(data);

            Assert.AreEqual(MagickFormat.Svg, info.Format);
            Assert.AreEqual(0, info.Width);
            Assert.AreEqual(0, info.Height);
        }

        [TestMethod]
        public void ShouldDetectFormatFromSvgTag()
        {
            var data = Encoding.ASCII.GetBytes(@"<svg xmlns=""http://www.w3.org/2000/svg"" width=""1000"" height=""716"">");

            var info = new MagickImageInfo(data);

            Assert.AreEqual(MagickFormat.Svg, info.Format);
            Assert.AreEqual(1000, info.Width);
            Assert.AreEqual(716, info.Height);
        }

        [TestMethod]
        public void ShouldUseWidthFromReadSettings()
        {
            using (var image = new MagickImage())
            {
                var settings = new MagickReadSettings
                {
                    Width = 100,
                };

                image.Read(Files.Logos.MagickNETSVG, settings);

                Assert.AreEqual(100, image.Width);
                Assert.AreEqual(48, image.Height);
            }
        }

        [TestMethod]
        public void ShouldUseHeightFromReadSettings()
        {
            using (var image = new MagickImage())
            {
                var settings = new MagickReadSettings
                {
                    Height = 200,
                };

                image.Read(Files.Logos.MagickNETSVG, settings);
            }
        }

        [TestMethod]
        public void ShouldUseWidthAndHeightFromReadSettings()
        {
            using (var image = new MagickImage())
            {
                var settings = new MagickReadSettings
                {
                    Width = 300,
                    Height = 300,
                };

                image.Read(Files.Logos.MagickNETSVG, settings);

                Assert.AreEqual(300, image.Width);
                Assert.AreEqual(144, image.Height);

                image.Ping(Files.Logos.MagickNETSVG, settings);

                Assert.AreEqual(300, image.Width);
                Assert.AreEqual(144, image.Height);
            }
        }

        [TestMethod]
        public void ShouldReadFontsWithQuotes()
        {
            var svg = @"<?xml version=""1.0"" encoding=""utf-8""?>
<svg version=""1.1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 220 80"">
<style type=""text/css"">
  .st0{font-family:'Arial';font-size:40}
  .st1{font-family:""Times New Roman"";font-size:40}
</style>
<g id=""changable-text"">
  <text transform=""matrix(1 0 0 1 1 35)"" class=""st0"">FONT TEST</text>
  <text transform=""matrix(1 0 0 1 1 70)"" class=""st1"">FONT TEST</text>
</g>
</svg>";
            var bytes = Encoding.ASCII.GetBytes(svg);
            using (var image = new MagickImage(bytes))
            {
                Assert.AreEqual(220, image.Width);
                Assert.AreEqual(80, image.Height);

                try
                {
                    System.IO.Directory.CreateDirectory("/Users/runner/work/Magick.NET/testimage");
                    image.Write("/Users/runner/work/Magick.NET/testimage/test.png");
                }
                catch
                {
                }

                /*
                ColorAssert.AreEqual(MagickColors.White, image, 118, 6);
                ColorAssert.AreEqual(MagickColors.Black, image, 120, 6);
                ColorAssert.AreEqual(MagickColors.Black, image, 141, 6);
                ColorAssert.AreEqual(MagickColors.White, image, 145, 6);
                ColorAssert.AreEqual(MagickColors.White, image, 114, 43);
                ColorAssert.AreEqual(MagickColors.Black, image, 116, 43);
                ColorAssert.AreEqual(MagickColors.Black, image, 135, 43);
                */
            }
        }

        [TestMethod]
        public void IsThreadSafe()
        {
            var svg = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""50"" height=""15"" xmlns=""http://www.w3.org/2000/svg"">
  <text x=""25"" y=""11"" font-size=""9px"" font-family=""Verdana"">1</text>
</svg>";
            var bytes = Encoding.UTF8.GetBytes(svg);

            var signature = LoadImage(bytes);
            Parallel.For(1, 10, (int i) =>
            {
                Assert.AreEqual(signature, LoadImage(bytes));
            });
        }

        private static string LoadImage(byte[] bytes)
        {
            using (var image = new MagickImage(bytes))
            {
                return image.Signature;
            }
        }
    }
}
