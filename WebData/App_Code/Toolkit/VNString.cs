using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for VNString
/// </summary>
public class VNString
{
    public VNString()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string vietDecode(string input)
    {
        input = input.Replace(".", " .");
        input = input.Replace("?", " ?");
        //---------------------------------a^
        input = input.Replace("ấ", "a");
        input = input.Replace("ầ", "a");
        input = input.Replace("ẩ", "a");
        input = input.Replace("ẫ", "a");
        input = input.Replace("ậ", "a");
        //---------------------------------A^
        input = input.Replace("Ấ", "A");
        input = input.Replace("Ầ", "A");
        input = input.Replace("Ẩ", "A");
        input = input.Replace("Ẫ", "A");
        input = input.Replace("Ậ", "A");
        //---------------------------------a(
        input = input.Replace("ắ", "a");
        input = input.Replace("ằ", "a");
        input = input.Replace("ẳ", "a");
        input = input.Replace("ẵ", "a");
        input = input.Replace("ặ", "a");
        //---------------------------------A(
        input = input.Replace("Ắ", "A");
        input = input.Replace("Ằ", "A");
        input = input.Replace("Ẳ", "A");
        input = input.Replace("Ẵ", "A");
        input = input.Replace("Ặ", "A");
        //---------------------------------a
        input = input.Replace("á", "a");
        input = input.Replace("à", "a");
        input = input.Replace("ả", "a");
        input = input.Replace("ã", "a");
        input = input.Replace("ạ", "a");
        input = input.Replace("â", "a");
        input = input.Replace("ă", "a");
        //---------------------------------A
        input = input.Replace("Á", "A");
        input = input.Replace("À", "A");
        input = input.Replace("Ả", "A");
        input = input.Replace("Ã", "A");
        input = input.Replace("Ạ", "A");
        input = input.Replace("Â", "A");
        input = input.Replace("Ă", "A");
        //---------------------------------e^
        input = input.Replace("ế", "e");
        input = input.Replace("ề", "e");
        input = input.Replace("ể", "e");
        input = input.Replace("ễ", "e");
        input = input.Replace("ệ", "e");
        //---------------------------------E^
        input = input.Replace("Ế", "E");
        input = input.Replace("Ề", "E");
        input = input.Replace("Ể", "E");
        input = input.Replace("Ễ", "E");
        input = input.Replace("Ệ", "E");
        //---------------------------------e
        input = input.Replace("é", "e");
        input = input.Replace("è", "e");
        input = input.Replace("ẻ", "e");
        input = input.Replace("ẽ", "e");
        input = input.Replace("ẹ", "e");
        input = input.Replace("ê", "e");
        //---------------------------------E
        input = input.Replace("É", "E");
        input = input.Replace("È", "E");
        input = input.Replace("Ẻ", "E");
        input = input.Replace("Ẽ", "E");
        input = input.Replace("Ẹ", "E");
        input = input.Replace("Ê", "E");
        //---------------------------------i
        input = input.Replace("í", "i");
        input = input.Replace("ì", "i");
        input = input.Replace("ỉ", "i");
        input = input.Replace("ĩ", "i");
        input = input.Replace("ị", "i");
        //---------------------------------I
        input = input.Replace("Í", "I");
        input = input.Replace("Ì", "I");
        input = input.Replace("Ỉ", "I");
        input = input.Replace("Ĩ", "I");
        input = input.Replace("Ị", "I");
        //---------------------------------o^
        input = input.Replace("ố", "o");
        input = input.Replace("ồ", "o");
        input = input.Replace("ổ", "o");
        input = input.Replace("ỗ", "o");
        input = input.Replace("ộ", "o");
        //---------------------------------O^
        input = input.Replace("Ố", "O");
        input = input.Replace("Ồ", "O");
        input = input.Replace("Ổ", "O");
        input = input.Replace("Ô", "O");
        input = input.Replace("Ộ", "O");
        //---------------------------------o*
        input = input.Replace("ớ", "o");
        input = input.Replace("ờ", "o");
        input = input.Replace("ở", "o");
        input = input.Replace("ỡ", "o");
        input = input.Replace("ợ", "o");
        //---------------------------------O*
        input = input.Replace("Ớ", "O");
        input = input.Replace("Ờ", "O");
        input = input.Replace("Ở", "O");
        input = input.Replace("Ỡ", "O");
        input = input.Replace("Ợ", "O");
        //---------------------------------u*
        input = input.Replace("ứ", "u");
        input = input.Replace("ừ", "u");
        input = input.Replace("ử", "u");
        input = input.Replace("ữ", "u");
        input = input.Replace("ự", "u");
        //---------------------------------U*
        input = input.Replace("Ứ", "U");
        input = input.Replace("Ừ", "U");
        input = input.Replace("Ử", "U");
        input = input.Replace("Ữ", "U");
        input = input.Replace("Ự", "U");
        //---------------------------------y
        input = input.Replace("ý", "y");
        input = input.Replace("ỳ", "y");
        input = input.Replace("ỷ", "y");
        input = input.Replace("ỹ", "y");
        input = input.Replace("ỵ", "y");
        //---------------------------------Y
        input = input.Replace("Ý", "Y");
        input = input.Replace("Ỳ", "Y");
        input = input.Replace("Ỷ", "Y");
        input = input.Replace("Ỹ", "Y");
        input = input.Replace("Ỵ", "Y");
        //---------------------------------DD
        input = input.Replace("Đ", "D");
        input = input.Replace("Đ", "D");
        input = input.Replace("đ", "d");
        //---------------------------------o
        input = input.Replace("ó", "o");
        input = input.Replace("ò", "o");
        input = input.Replace("ỏ", "o");
        input = input.Replace("õ", "o");
        input = input.Replace("ọ", "o");
        input = input.Replace("ô", "o");
        input = input.Replace("ơ", "o");
        //---------------------------------O
        input = input.Replace("Ó", "O");
        input = input.Replace("Ò", "O");
        input = input.Replace("Ỏ", "O");
        input = input.Replace("Õ", "O");
        input = input.Replace("Ọ", "O");
        input = input.Replace("Ô", "O");
        input = input.Replace("Ơ", "O");
        //---------------------------------u
        input = input.Replace("ú", "u");
        input = input.Replace("ù", "u");
        input = input.Replace("ủ", "u");
        input = input.Replace("ũ", "u");
        input = input.Replace("ụ", "u");
        input = input.Replace("ư", "u");
        //---------------------------------U
        input = input.Replace("Ú", "U");
        input = input.Replace("Ù", "U");
        input = input.Replace("Ủ", "U");
        input = input.Replace("Ũ", "U");
        input = input.Replace("Ụ", "U");
        input = input.Replace("Ư", "U");
        //---------------------------------
        return input;
    }

    public static string TextToUrl(string input)
    {
        input = input.Replace(" ", "-");

        input = VNString.vietDecode(input.ToLower());
        input = Regex.Replace(input, "[^\\w\\-]", "-");
        input = Regex.Replace(input, "\\-{2,}", "-");

        return input;
    }
}
