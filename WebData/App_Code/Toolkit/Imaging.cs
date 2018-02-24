using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System;
using System.Collections;
using System.Drawing.Drawing2D;

namespace Zensoft.Website.Toolkit
{

    
    public class Imaging
    {

        #region "Helper Methods"


        private static int _imgHeight;
        private static int _imgWidth;

        public static Size GetSize(string sPath)
        {
            Image g = Image.FromFile(sPath);
            Size s = g.Size;
            g.Dispose();
            return s;
        }

        /// <summary>
        /// return height of image
        /// </summary>
        /// <param name="sPath">file path of image</param>
        /// <returns></returns>
        public static int GetHeight(string sPath)
        {
            Image g = Image.FromFile(sPath);
            int h = g.Height;
            g.Dispose();
            return h;
        }

        /// <summary>
        /// return width of image
        /// </summary>
        /// <param name="sPath">file path of image</param>
        /// <returns></returns>
        public static int GetWidth(string sPath)
        {
            Image g = Image.FromFile(sPath);
            int w = g.Width;
            g.Dispose();
            return w;
        }

        /// <summary>
        /// return height of image
        /// </summary>
        /// <param name="sFile">Stream of image</param>
        /// <returns></returns>
        public static int GetHeightFromStream(Stream sFile)
        {
            Image g = Image.FromStream(sFile, true);
            return g.Height;
        }

        /// <summary>
        /// width of image
        /// </summary>
        /// <param name="sFile">Steam of image</param>
        /// <returns></returns>
        public static int GetWidthFromStream(Stream sFile)
        {
            Image g = Image.FromStream(sFile, true);
            int w = g.Width;
            g.Dispose();
            return w;
        }

        /// <summary>
        /// create an image
        /// </summary>
        /// <param name="sFile">path of load image file - will be resized according to height and width set</param>
        /// <returns></returns>
        //public static string CreateImage(string sFile)
        //{
        //    Image g = Image.FromFile(sFile);
        //    int h = g.Height;
        //    int w = g.Width;
        //    g.Dispose();
        //    return CreateImage(sFile, h, w);
        //}

        /// <summary>
        /// create an image
        /// </summary>
        /// <param name="sFile">path of image file</param>
        /// <param name="intHeight">height</param>
        /// <param name="intWidth">width</param>
        /// <returns></returns>
        //public static string CreateImage(string sFile, int intHeight, int intWidth)
        //{
        //    var fi = new FileInfo(sFile);
        //    string tmp = fi.FullName.Replace(fi.Extension, "_TEMP" + fi.Extension);
        //    if (FileWrapper.Instance.Exists(tmp))
        //    {
        //        FileWrapper.Instance.SetAttributes(tmp, FileAttributes.Normal);
        //        FileWrapper.Instance.Delete(tmp);
        //    }

        //    File.Copy(sFile, tmp);
        //    var original = new Bitmap(tmp);

        //    PixelFormat format = original.PixelFormat;
        //    if (format.ToString().Contains("Indexed"))
        //    {
        //        format = PixelFormat.Format24bppRgb;
        //    }

        //    int newHeight = intHeight;
        //    int newWidth = intWidth;
        //    Size imgSize;
        //    if (original.Width > newWidth || original.Height > newHeight)
        //    {
        //        imgSize = NewImageSize(original.Width, original.Height, newWidth, newHeight);
        //        _imgHeight = imgSize.Height;
        //        _imgWidth = imgSize.Width;
        //    }
        //    else
        //    {
        //        imgSize = new Size(original.Width, original.Height);
        //        _imgHeight = original.Height;
        //        _imgWidth = original.Width;
        //    }

        //    string sFileExt = fi.Extension;
        //    string sFileNoExtension = Path.GetFileNameWithoutExtension(sFile);
        //    string sPath = Path.GetDirectoryName(sFile);
        //    if (sPath != null)
        //    {
        //        sPath = sPath.Replace("/", "\\");
        //    }
        //    if (sPath != null && !sPath.EndsWith("\\"))
        //    {
        //        sPath += "\\";
        //    }
        //    Image img = Image.FromFile(tmp);
        //    var newImg = new Bitmap(_imgWidth, _imgHeight, format);
        //    newImg.SetResolution(img.HorizontalResolution, img.VerticalResolution);

        //    Graphics canvas = Graphics.FromImage(newImg);
        //    canvas.SmoothingMode = SmoothingMode.None;
        //    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //    if (sFileExt.ToLowerInvariant() != ".png")
        //    {
        //        canvas.Clear(Color.White);
        //        canvas.FillRectangle(Brushes.White, 0, 0, imgSize.Width, imgSize.Height);
        //    }
        //    canvas.DrawImage(img, 0, 0, imgSize.Width, imgSize.Height);
        //    img.Dispose();
        //    sFile = sPath;

        //    sFile += sFileNoExtension + sFileExt;
        //    if (FileWrapper.Instance.Exists(sFile))
        //    {
        //        FileWrapper.Instance.SetAttributes(sFile, FileAttributes.Normal);
        //        FileWrapper.Instance.Delete(sFile);
        //    }

        //    //newImg.Save
        //    var arrData = new byte[2048];
        //    Stream content = new MemoryStream();
        //    ImageFormat imgFormat = ImageFormat.Bmp;
        //    if (sFileExt.ToLowerInvariant() == ".png")
        //    {
        //        imgFormat = ImageFormat.Png;
        //    }
        //    else if (sFileExt.ToLowerInvariant() == ".gif")
        //    {
        //        imgFormat = ImageFormat.Gif;
        //    }
        //    else if (sFileExt.ToLowerInvariant() == ".jpg")
        //    {
        //        imgFormat = ImageFormat.Jpeg;
        //    }
        //    newImg.Save(content, imgFormat);
        //    using (Stream outStream = FileWrapper.Instance.Create(sFile))
        //    {
        //        long originalPosition = content.Position;
        //        content.Position = 0;

        //        try
        //        {
        //            int intLength = content.Read(arrData, 0, arrData.Length);

        //            while (intLength > 0)
        //            {
        //                outStream.Write(arrData, 0, intLength);
        //                intLength = content.Read(arrData, 0, arrData.Length);
        //            }
        //        }
        //        finally
        //        {
        //            content.Position = originalPosition;
        //        }
        //    }

        //    newImg.Dispose();
        //    original.Dispose();

        //    canvas.Dispose();
        //    if (FileWrapper.Instance.Exists(tmp))
        //    {
        //        FileWrapper.Instance.SetAttributes(tmp, FileAttributes.Normal);
        //        FileWrapper.Instance.Delete(tmp);
        //    }


        //    return sFile;
        //}

        /// <summary>
        /// create a JPG image
        /// </summary>
        /// <param name="sFile">name of image</param>
        /// <param name="img">bitmap of image</param>
        /// <param name="compressionLevel">image quality</param>
        /// <returns></returns>
        public static string CreateJPG(string sFile, Bitmap img, int compressionLevel)
        {
            Graphics bmpOutput = Graphics.FromImage(img);
            bmpOutput.InterpolationMode = InterpolationMode.HighQualityBicubic;
            bmpOutput.SmoothingMode = SmoothingMode.HighQuality;
            var compressionRectange = new Rectangle(0, 0, _imgWidth, _imgHeight);
            bmpOutput.DrawImage(img, compressionRectange);

            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            Encoder myEncoder = Encoder.Quality;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, compressionLevel);
            myEncoderParameters.Param[0] = myEncoderParameter;
            if (File.Exists(sFile))
            {
                File.Delete(sFile);
            }
            try
            {
                img.Save(sFile, myImageCodecInfo, myEncoderParameters);
            }
            catch (Exception)
            {
                //suppress unexpected exceptions
            }


            img.Dispose();
            bmpOutput.Dispose();
            return sFile;
        }

        /// <summary>
        /// create an image based on a stream (read from a database)
        /// </summary>
        /// <param name="sFile">image name</param>
        /// <param name="intHeight">height</param>
        /// <param name="intWidth">width</param>
        /// <returns>steam</returns>
        public static MemoryStream CreateImageForDB(Stream sFile, int intHeight, int intWidth)
        {
            var newStream = new MemoryStream();
            Image g = Image.FromStream(sFile);
            //Dim thisFormat = g.RawFormat
            if (intHeight > 0 & intWidth > 0)
            {
                int newHeight = intHeight;
                int newWidth = intWidth;
                if (g.Width > newWidth | g.Height > newHeight)
                {
                    Size imgSize = NewImageSize(g.Width, g.Height, newWidth, newHeight);
                    _imgHeight = imgSize.Height;
                    _imgWidth = imgSize.Width;
                }
                else
                {
                    _imgHeight = g.Height;
                    _imgWidth = g.Width;
                }
            }
            else
            {
                _imgWidth = g.Width;
                _imgHeight = g.Height;
            }

            var imgOutput1 = new Bitmap(g, _imgWidth, _imgHeight);
            Graphics bmpOutput = Graphics.FromImage(imgOutput1);
            bmpOutput.InterpolationMode = InterpolationMode.HighQualityBicubic;
            bmpOutput.SmoothingMode = SmoothingMode.HighQuality;
            var compressionRectange = new Rectangle(0, 0, _imgWidth, _imgHeight);
            bmpOutput.DrawImage(g, compressionRectange);
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            Encoder myEncoder = Encoder.Quality;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 90);
            myEncoderParameters.Param[0] = myEncoderParameter;
            imgOutput1.Save(newStream, myImageCodecInfo, myEncoderParameters);
            g.Dispose();
            imgOutput1.Dispose();
            bmpOutput.Dispose();
            return newStream;
        }

        /// <summary>
        /// return the approriate encoded for the mime-type of the image being created
        /// </summary>
        /// <param name="myMimeType">mime type (e.g jpg/png)</param>
        /// <returns></returns>
        public static ImageCodecInfo GetEncoderInfo(string myMimeType)
        {
            try
            {
                int i;
                ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
                for (i = 0; i <= (encoders.Length - 1); i++)
                {
                    if ((encoders[i].MimeType == myMimeType))
                    {
                        return encoders[i];
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// scale an image based on existing dimensions and updated requirement
        /// </summary>
        /// <param name="currentWidth">current width</param>
        /// <param name="currentHeight">current height</param>
        /// <param name="newWidth">new width</param>
        /// <param name="newHeight">new height</param>
        /// <returns>updated calculated height/width minesions</returns>
        public static Size NewImageSize(int currentWidth, int currentHeight, int newWidth, int newHeight)
        {
            decimal decScale = ((decimal)currentWidth / (decimal)newWidth) > ((decimal)currentHeight / (decimal)newHeight) ? Convert.ToDecimal((decimal)currentWidth / (decimal)newWidth) : Convert.ToDecimal((decimal)currentHeight / (decimal)newHeight);
            newWidth = Convert.ToInt32(Math.Floor((decimal)currentWidth / decScale));
            newHeight = Convert.ToInt32(Math.Floor((decimal)currentHeight / decScale));

            var newSize = new Size(newWidth, newHeight);

            return newSize;
        }
        #endregion


        #region "Helper Methods"

        public static Color[] GetColors(bool includeSystemColors)
        {
            KnownColor[] tempColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            ArrayList colors = new ArrayList();

            for (int loopCount = 0; loopCount <= tempColors.Length - 1; loopCount++)
            {
                if ((!Color.FromKnownColor(tempColors[loopCount]).IsSystemColor | includeSystemColors) & !(Color.FromKnownColor(tempColors[loopCount]).Name == "Transparent"))
                {
                    colors.Add(Color.FromKnownColor(tempColors[loopCount]));
                }
            }
            return (Color[])colors.ToArray(typeof(Color));
        }

        public static string[] GetRotateTypes()
        {
            string[] tempResult = Enum.GetNames(typeof(RotateFlipType));
            Array.Sort(tempResult);
            return (tempResult);
        }

        public static FontFamily[] GetFontFamilies()
        {
            ArrayList fonts = new ArrayList();

            for (int loopCount = 0; loopCount <= FontFamily.Families.Length - 1; loopCount++)
            {
                fonts.Add(FontFamily.Families[loopCount]);
            }
            return (FontFamily[])fonts.ToArray(typeof(FontFamily));
        }
        #endregion

        #region "Text on Image Methods"

        public static void AddTextToImage(string fileNameIn, Font myFont, Color fontColor, Point textLocation, string textToAdd)
        {
            AddTextToImage(fileNameIn, fileNameIn, myFont, fontColor, textLocation, textToAdd);
        }

        public static void AddTextToImage(string fileNameIn, string fileNameOut, Font myFont, Color fontColor, Point textLocation, string textToAdd)
        {

            Graphics myGraphics = null;
            Bitmap myBitmap = null;

            try
            {
                myBitmap = new Bitmap(fileNameIn);

                myGraphics = Graphics.FromImage(myBitmap);

                StringFormat myStringFormat = new StringFormat();
                myStringFormat.Alignment = StringAlignment.Near;

                myGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                SolidBrush myBrush = new SolidBrush(fontColor);

                myGraphics.DrawString(textToAdd, myFont, myBrush, new Point(textLocation.X, textLocation.Y), myStringFormat);
                myBitmap.Save(fileNameOut, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (myGraphics != null)
                {
                    myGraphics.Dispose();
                }
                if (myBitmap != null)
                {
                    myBitmap.Dispose();
                }
            }
        }

        #endregion

        #region "Cropping Methods"

        public static void CropImage(string fileNameIn, Rectangle theRectangle)
        {
            CropImage(fileNameIn, fileNameIn, theRectangle);
        }

        public static void CropImage(string fileNameIn, string fileNameOut, Rectangle theRectangle)
        {
            Bitmap myBitmap = null;
            Bitmap myBitmapCropped = null;
            Graphics myGraphics = null;

            try
            {
                myBitmap = new Bitmap(fileNameIn);

                myBitmapCropped = new Bitmap(theRectangle.Width, theRectangle.Height);
                myGraphics = Graphics.FromImage(myBitmapCropped);

                myGraphics.DrawImage(myBitmap, new Rectangle(0, 0, myBitmapCropped.Width, myBitmapCropped.Height), theRectangle.Left, theRectangle.Top, theRectangle.Width, theRectangle.Height, GraphicsUnit.Pixel);

                myBitmap.Dispose();
                myBitmapCropped.Save(fileNameOut, ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (myBitmap != null)
                {
                    myBitmap.Dispose();
                }
                if (myBitmapCropped != null)
                {
                    myBitmapCropped.Dispose();
                }
                if (myGraphics != null)
                {
                    myGraphics.Dispose();
                }
            }
        }

        public static void DrawRectangle(string fileNameIn, Rectangle theRectangle, Color myColor)
        {
            DrawRectangle(fileNameIn, fileNameIn, theRectangle, myColor);
        }

        public static void DrawRectangle(string fileNameIn, string fileNameOut, Rectangle theRectangle, Color myColor)
        {
            Graphics myGraphics = null;
            Bitmap myBitmap = null;

            try
            {
                myBitmap = new Bitmap(fileNameIn);
                myGraphics = Graphics.FromImage(myBitmap);

                Pen myPen = new Pen(myColor, 1);
                myGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                myGraphics.DrawRectangle(myPen, theRectangle);
                myPen.Dispose();

                myBitmap.Save(fileNameOut, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (myBitmap != null)
                {
                    myBitmap.Dispose();
                }
                if (myGraphics != null)
                {
                    myGraphics.Dispose();
                }
            }
        }

        #endregion

        #region "Rotating Methods"

        public static void RotateImage(string fileNameIn, string fileNameOut, RotateFlipType theRotateFlipType)
        {
            using (Bitmap myBitmap = new Bitmap(fileNameIn))
            {
                myBitmap.RotateFlip(theRotateFlipType);
                myBitmap.Save(fileNameOut, ImageFormat.Jpeg);
            }
        }

        public static void RotateImage(string fileNameIn, RotateFlipType theRotateFlipType)
        {
            RotateImage(fileNameIn, fileNameIn, theRotateFlipType);
        }

        #endregion

        #region "Resize Methods"

        public static void ResizeImage(string fileNameIn, int maxWidth, int maxHeight)
        {
            ResizeImage(fileNameIn, fileNameIn, maxWidth, maxHeight, ImageFormat.Jpeg);
        }

        public static void ResizeImage(string fileNameIn, int maxWidthOrWidth)
        {
            ResizeImage(fileNameIn, fileNameIn, maxWidthOrWidth, ImageFormat.Jpeg);
        }

        public static void ResizeImage(string fileNameIn, string fileNameOut, Size theSize)
        {
            ResizeImage(fileNameIn, fileNameOut, theSize, ImageFormat.Jpeg);
        }

        public static void ResizeImage(string fileNameIn, string fileNameOut, int maxWidthOrHeight, ImageFormat theImageFormat)
        {
            //bool portrait = false;
            Bitmap bmpSource = null;

            bmpSource = new Bitmap(fileNameIn);

            Size originalSize = bmpSource.Size;
            Size newSize = new Size(0, 0);

            bmpSource.Dispose();

            decimal maxHeightDecimal = Convert.ToDecimal(maxWidthOrHeight);
            decimal maxWidthAsDecimal = Convert.ToDecimal(maxWidthOrHeight);

            decimal resizeFactor;

            if (originalSize.Height > originalSize.Width)
            {
                resizeFactor = Convert.ToDecimal(Decimal.Divide(originalSize.Height, maxHeightDecimal));
                newSize.Height = maxWidthOrHeight;
                newSize.Width = Convert.ToInt32(originalSize.Width / resizeFactor);
            }
            else
            {
                resizeFactor = Convert.ToDecimal(Decimal.Divide(originalSize.Width, maxWidthAsDecimal));
                newSize.Width = maxWidthOrHeight;
                newSize.Height = Convert.ToInt32(originalSize.Height / resizeFactor);
            }


            ResizeImage(fileNameIn, fileNameOut, newSize, theImageFormat);
        }

        public static void ResizeImage(string fileNameIn, string fileNameOut, int maxWidth, int maxHeight, ImageFormat theImageFormat)
        {
            Size originalSize = GetImageSize(fileNameIn);
            Size newSize = new Size(0, 0);

            decimal resizeFactor = System.Math.Max(Convert.ToDecimal(Decimal.Divide(originalSize.Height, maxHeight)), Convert.ToDecimal(Decimal.Divide(originalSize.Width, maxWidth)));

            newSize.Height = Convert.ToInt32(originalSize.Height / resizeFactor);
            newSize.Width = Convert.ToInt32(originalSize.Width / resizeFactor);

            ResizeImage(fileNameIn, fileNameOut, newSize, theImageFormat);
        }

        public static void ResizeImage(string fileNameIn, string fileNameOut, Size theSize, ImageFormat theImageFormat)
        {
            Bitmap mySourceBitmap = null;
            Bitmap myTargetBitmap = null;
            Graphics myGraphics = null;

            Size originalSize = GetImageSize(fileNameIn);

            try
            {
                mySourceBitmap = new Bitmap(fileNameIn);

                int newWidth = theSize.Width;
                int newHeight = theSize.Height;

                myTargetBitmap = new Bitmap(newWidth, newHeight);

                myGraphics = Graphics.FromImage(myTargetBitmap);

                myGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                //Nếu kích thước ảnh mới lớn hơn kích thước ảnh cũ thì giữ nguyên ảnh cũ
                if (originalSize.Height > newHeight && originalSize.Width > newWidth)
                {
                    myGraphics.DrawImage(mySourceBitmap, new Rectangle(0, 0, newWidth, newHeight));
                    mySourceBitmap.Dispose();

                    myTargetBitmap.Save(fileNameOut, theImageFormat);
                }
                else
                {
                    if (fileNameIn != fileNameOut)
                        File.Copy(fileNameIn, fileNameOut);
                    //myGraphics.DrawImage(mySourceBitmap, new Rectangle(0, 0, originalSize.Width, originalSize.Height));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (myGraphics != null)
                    myGraphics.Dispose();
                if (mySourceBitmap != null)
                    mySourceBitmap.Dispose();

                if (myTargetBitmap != null)
                    myTargetBitmap.Dispose();

            }
        }

        public static void ResizeCropImage(string fileNameIn, string fileNameOut, int maxWidth, int maxHeight)
        {
            Size originalSize = GetImageSize(fileNameIn);

            decimal resizeFactor = System.Math.Min(Convert.ToDecimal(Decimal.Divide(originalSize.Height, maxHeight)), Convert.ToDecimal(Decimal.Divide(originalSize.Width, maxWidth)));

            Bitmap mySourceBitmap = null;
            Bitmap myTargetBitmap = null;
            Graphics myGraphics = null;

            Bitmap myBitmap = null;
            Bitmap myBitmapCropped = null;

            int newHeight = Convert.ToInt32(originalSize.Height / resizeFactor);
            int newWidth = Convert.ToInt32(originalSize.Width / resizeFactor);
            try
            {
                //resize anh
                mySourceBitmap = new Bitmap(fileNameIn);

                myTargetBitmap = new Bitmap(newWidth, newHeight);

                myGraphics = Graphics.FromImage(myTargetBitmap);

                myGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic; //System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                myGraphics.SmoothingMode = SmoothingMode.HighQuality;

                myGraphics.DrawImage(mySourceBitmap, new Rectangle(0, 0, newWidth, newHeight));

                mySourceBitmap.Dispose();

                //Crop anh
                Rectangle theRectangle = new Rectangle();

                if (newWidth > maxWidth)
                {
                    theRectangle.X = (newWidth - maxWidth) / 2;
                    theRectangle.Y = 0;
                }
                else
                {
                    theRectangle.X = 0;
                    theRectangle.Y = (newHeight - maxHeight) / 2;
                }

                theRectangle.Width = maxWidth;
                theRectangle.Height = maxHeight;

                myBitmapCropped = new Bitmap(theRectangle.Width, theRectangle.Height);
                myGraphics = Graphics.FromImage(myBitmapCropped);

                myGraphics.DrawImage(myTargetBitmap, new Rectangle(0, 0, myBitmapCropped.Width, myBitmapCropped.Height), theRectangle.Left, theRectangle.Top, theRectangle.Width, theRectangle.Height, GraphicsUnit.Pixel);


                ImageCodecInfo codecInfo = Imaging.GetEncoderInfo("image/jpeg");

                //  Set the quality
                EncoderParameters parameters = new EncoderParameters(1);

                // Quality: 90
                parameters.Param[0] = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, 90L);
                //image.Save(destPath + "10.jpg", codecInfo, parameters);

                myBitmapCropped.Save(fileNameOut, codecInfo, parameters);

                //CreateJPG(fileNameOut, myBitmapCropped, 90);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (myBitmap != null)
                {
                    myBitmap.Dispose();
                }
                if (myBitmapCropped != null)
                {
                    myBitmapCropped.Dispose();
                }
                if (myGraphics != null)
                {
                    myGraphics.Dispose();
                }
            }
        }

        #endregion

        #region "Other Imaging Methods"

        public static Size GetImageSize(string fileNameIn)
        {

            Bitmap myBitmap = null;
            Size theSize = Size.Empty;

            try
            {
                myBitmap = new Bitmap(fileNameIn);
                theSize = myBitmap.Size;
            }
            catch { }
            finally
            {
                if (myBitmap != null)
                    myBitmap.Dispose();
            }
            return theSize;
        }

        public static ImageFormat GetImageFormat(string fileNameIn)
        {

            Bitmap bmpSource = null;
            ImageFormat theFormat = null;

            try
            {
                bmpSource = new Bitmap(fileNameIn);
                theFormat = bmpSource.RawFormat;
            }
            catch
            {
                throw;
            }
            finally
            {
                bmpSource.Dispose();
            }

            return theFormat;
        }

        public static string GetImageHash(string fileNameIn)
        {
            Bitmap myBitmap = null;
            try
            {
                myBitmap = new Bitmap(fileNameIn);
                MemoryStream stream = new MemoryStream();
                myBitmap.Save(stream, ImageFormat.Bmp);
                byte[] bytes = stream.ToArray();
                byte[] HashVal = (new MD5CryptoServiceProvider()).ComputeHash(bytes);

                return Convert.ToBase64String(HashVal);
            }
            catch (OutOfMemoryException)
            {
                throw new ArgumentException("Path does not contain a valid image");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("This is not a valid path");
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException("File not found");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (myBitmap != null)
                {
                    myBitmap.Dispose();
                }
            }
        }
        #endregion

    }
}
