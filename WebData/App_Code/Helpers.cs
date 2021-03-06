using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.IO;
using System.Linq;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Zensoft.Website.Configuration
{
    public class Helpers
    {
        public const int PRODUCT_CLOTHING_ID = 1;
        public const int PRODUCT_SHOE_ID = 2;
        public const int PRODUCT_ACCESSARY_ID = 3;

        private static string[] _cities = new string[] { 
            "TP. Hà Nội","TP. HCM","TP. Hải Phòng","TP. Đà Nẵng","TP. Cần Thơ",
            "An Giang","Bắc Giang","Bắc Kạn","Bạc Liêu","Bắc Ninh",
            "Bến Tre","Bình Định","Bình Dương","Bình Phước","Bình Thuận","Cà Mau",
            "Cao Bằng","Đắk Lắk","Đắk Nông","Điện Biên","Đồng Nai","Đồng Tháp","Gia Lai",
            "Hà Giang","Hà Nam","Hà Tây","Hà Tĩnh","Hải Dương","Hậu Giang","Hòa Bình",
            "Hưng Yên","Khành Hòa","Kiên Giang","Kon Tum","Lai Châu","Lâm Đồng",
            "Lạng Sơn","Lào Cai","Long An","Nam Định","Nghệ An","Ninh Bình","Ninh Thuận",
            "Phú Thọ","Phú Yên","Quang Bình","Quàng Nam","Quảng Ngãi","Quảng Ninh",
            "Quảng Trị","Sóc Trăng","Sơn La","Tây Ninh","Thái Bình","Thái Nguyên","Thanh Hóa",
            "Thừa Thiên Huế","Tiền Giang","Trà vinh","Tuyên Quang","Vĩnh Long","Vĩnh Phúc","Vũng Tàu","Yên Bái"};

        public static StringCollection GetCities()
        {
            StringCollection cities = new StringCollection();
            cities.AddRange(_cities);
            return cities;
        }

        public static string PriceFormat(int price)
        {
            return Regex.Replace(price.ToString("###,### đ;(###,###) đ;Liên hệ"), ",", ".");
        }

        public static string PriceFormat(int price, int salePrice)
        {
            if ((salePrice != 0) && (salePrice < price))
                return "<span>" + PriceFormat(salePrice) + "</span><span>" + PriceFormat(price) + "</span>";
            else
                return PriceFormat(price);
        }

        /// <summary>
        /// Hàm làm tròn số thập phân lên số nguyên
        /// </summary>
        /// <param name="input">Số thập phân</param>
        /// <returns>Kết quả trả về dạng chuỗi</returns>
        public static string Approximate(float input)
        {
            string y = "";
            string z = "";
            string result = "";

            string[] x = new Regex(",").Split(input.ToString().Replace(".", ","));                  //tách phần nguyên và phần thập phân

            if (x.Length == 2)                                                                      //nếu phần thập phân > 0
            {
                y = x.First();                                                                      //gán giá trị phần nguyên
                z = x.Last();                                                                       //gán giá trị phần thập phân

                int y1 = 0;
                int y2 = 0;

                if (int.Parse(y) >= 10 & int.Parse(y) <= 99)                                        //nếu phần nguyên từ 10-99
                {
                    y1 = int.Parse(y.First().ToString());                                           //gán số hàng chục của phần nguyên
                    y2 = int.Parse(y.Last().ToString());                                            //gán số hàng đơn vị của phần nguyên
                }
                else                                                                                //nếu phần nguyên từ < 10
                    y2 = int.Parse(y.First().ToString());                                           //gán số hàng đơn vị của phần nguyên

                int z1 = int.Parse(z.First().ToString());                                           //gán số đầu tiên của phần thập phân

                if (z1 >= 5 & z1 <= 9)                                                              //nếu số đấu tiên của phần thập phân từ 5-9
                {
                    if (y2 == 9)                                                                    //nếu số hàng đơn vị của phần nguyên =9
                    {
                        y2 = 0;                                                                     //gán số hàng đơn vị của phần nguyên = 0
                        y1 += 1;                                                                    //tăng 1 giá trị cho số hàng chục của phần nguyên
                    }
                    else                                                                            //nếu số ấu tiên của phần thập phân #9
                        y2 += 1;                                                                    //tăng 1 đơn vị cho số hàng đơn vị của phần nguyên
                }

                result = y1.ToString() + y2.ToString();
            }
            else                                                                                    //nếu phần thập phân = 0
            {
                y = x.First();                                                                      //lấy về giá trị cuối cùng là phần nguyên

                result = y.ToString();
            }

            return result;
        }

        public static string stringCurrency(int number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            decimal decS = 0;

            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }

            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }

            i = s.Length;

            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }

            if (booAm) str = "Âm " + str;

            return str + "đồng";
        }
    }
}