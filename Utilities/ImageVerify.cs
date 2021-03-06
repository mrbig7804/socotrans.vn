using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Security.Cryptography;

namespace Zensoft.Website.Utilities
{
    public class ImageVerify
    {
        /// <summary>
        /// The constructor will not do anything!
        /// </summary>
        public ImageVerify()
        { }

        /// <summary>
        /// The function <c>getRandomAlphaNumeric</c> will return the string
        /// generated by the <c>RandomNumberGenerator</c> class. This will be used
        /// to make the string value. The function will check whether the randomnly
        /// generated numerics are falling into 32 to 127 for making
        /// it as a character. If the value returned is not in the range
        /// then that we will be used as it is. By default, the randomnly generated number 
        /// array will hold 3 elements.
        /// </summary>
        /// <returns>string value, which is  the randomnly generated alphanumeric value</returns>
        public string getRandomAlphaNumeric()
        {

            RandomNumberGenerator rm;
            rm = RandomNumberGenerator.Create();

            byte[] data = new byte[3];

            rm.GetNonZeroBytes(data);

            string sRand = "";
            string sTmp = "";

            for (int nCnt = 0; nCnt <= data.Length - 1; nCnt++)
            {
                int nVal = Convert.ToInt32(data.GetValue(nCnt));

                if (nVal > 32 && nVal < 127)
                {
                    sTmp = Convert.ToChar(nVal).ToString();
                }
                else
                {
                    sTmp = nVal.ToString();
                }

                sRand += sTmp.ToString();
            }

            return sRand;
        }

        /// <summary>
        /// Ooops!! I'm too tired to make documentation of this. I think, it is 
        /// possible to add more features to this function. 
        /// 
        /// Let me add doc. later after some time!
        /// </summary>
        /// <param name="sTextToImg">The text which has to be generated as a image</param>
        /// <returns></returns>
        public Bitmap generateImage(string sTextToImg)
        {
            //
            // Here, i haven't used any try..catch 
            //

            PixelFormat pxImagePattern = PixelFormat.Format32bppArgb;
            Bitmap bmpImage = new Bitmap(1, 1, pxImagePattern);
            Font fntImageFont = new Font("Tahoma", 20, FontStyle.Bold);
            Graphics gdImageGrp = Graphics.FromImage(bmpImage);

            float iWidth = gdImageGrp.MeasureString(sTextToImg, fntImageFont).Width;
            float iHeight = gdImageGrp.MeasureString(sTextToImg, fntImageFont).Height;

            bmpImage = new Bitmap((int)iWidth, (int)iHeight, pxImagePattern);

            gdImageGrp = Graphics.FromImage(bmpImage);
            gdImageGrp.Clear( Color.FromArgb(64,40,40));

            gdImageGrp.TextRenderingHint = TextRenderingHint.AntiAlias;

            Random rd = new Random();

            for (int iX = 3;iX< bmpImage.Width - 3; iX++)
            {
                for (int iY = 3; iY< bmpImage.Height - 3; iY++)
                {
                    if (rd.Next(25) < 2)
                        bmpImage.SetPixel(iX, iY, System.Drawing.Color.White);
                }
            }

            gdImageGrp.DrawString(sTextToImg, fntImageFont, new SolidBrush(Color.White), 0, 0);
            gdImageGrp.Flush();

            return bmpImage;



        }
    }
}

