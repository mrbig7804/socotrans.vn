using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.Utilities
{
    public class SearchUtility
    {

        private static void SplitString(string words, ref ArrayList ar)
        {
            char[] charSeparators = new char[] { '"' };
            char[] charSpacer = new char[] { ' ' };
            string[] splitedWord;

            //Nếu tồn tại 2 dấu " trở nên
            if (words.LastIndexOf('"') >= 0 & words.LastIndexOf('"') != words.IndexOf('"'))
            {
                //Nếu dấu " thứ nhất ở đầu
                if (words.IndexOf('"') == 0)
                {
                    splitedWord = words.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries);
                    //nếu dấu " thứ 2 không ở cuối
                    if (splitedWord.Length == 2)
                    {
                        ar.Add(splitedWord[0].Trim());
                        SplitString(splitedWord[1], ref ar);
                    }
                    else//nếu dấu " thứ 2 ở cuối
                    {
                        ar.Add(words.Substring(1, words.Length - 2).Trim());
                    }
                }
                else
                {
                    splitedWord = words.Split(charSeparators, 3, StringSplitOptions.RemoveEmptyEntries);
                    if (splitedWord.Length == 3)
                    {
                        ar.AddRange(splitedWord[0].Split(charSpacer, StringSplitOptions.RemoveEmptyEntries));

                        ar.Add(splitedWord[1].Trim());

                        SplitString(splitedWord[2], ref ar);
                    }
                    else
                    {
                        ar.Add(splitedWord[1].Trim());
                    }
                }
            }
            else ar.AddRange(words.Split(charSpacer, StringSplitOptions.RemoveEmptyEntries));

        }

        /// <summary>
        /// Thay thế các ký tự đặc biệt bằng dấu cách
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string ReplaceSpecialChar(string s)
        {
            string specialChar = @"'-%*";// Chuỗi ký tự đặc biệt

            for (int i = 0; i < specialChar.Length; i++)
            {
                s = s.Replace(specialChar[i], ' ');
            }

            s = s.Replace("&", "&amp;");
            s = s.Replace("<", "&lt;");
            s = s.Replace(">", "&gt;");

            return s;
        }

        /// <summary>
        /// Tạo chuỗi tìm kiếm từ một danh sách các từ khóa cần tìm
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        private static string BuildSQLQuery(string fieldName, ArrayList keywords)
        {
            string ret;

            ret = fieldName + " LIKE N'%" + keywords[0].ToString() + "%' ";

            //chỉ tìm kiếm trong phạm vi 10 từ
            int keywordsCount = (keywords.Count > 10) ? 10 : keywords.Count;

            for (int i = 1; i < keywordsCount; i++)
            {
                ret = ret + " AND " + fieldName + " LIKE N'%" + keywords[i].ToString() + "%' ";
            }
            return ret;
        }       

        /// <summary>
        /// Tạo mệnh đề tìm kiếm
        /// Mệnh đề sẽ được tạo với trường mặc định là SEARCH
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public static string BuildSQLQuery(string keywords)
        {

            if (string.IsNullOrEmpty(keywords)) return "";

            keywords = ReplaceSpecialChar(keywords);

            ArrayList ar = new ArrayList();

            SplitString(keywords, ref ar);

            if (ar.Count == 0) return "";

            for (int i = 0; i < ar.Count; i++)
            {
                ar[i] = ar[i].ToString().ToUpper();
            }

           return BuildSQLQuery("SEARCH", ar);
        }

        public static string MarkKeyword(string input, string keywords)
        {
            //string[] BACK_COLOR_MARK_KEYWORD = { "#000099", "#000000", "#333300", "#990033" };


            if (string.IsNullOrEmpty(keywords)) return input;

            keywords = ReplaceSpecialChar(keywords);

            ArrayList ar = new ArrayList();

            SplitString(keywords, ref ar);

            //int colorIndex = 0;
            foreach (string s in ar)
            {


                string beginTag = @"<span  style=background-color:#ffffcc;color:#000;font-weight:bolder;>";
                string endTag = @"</span>";

                int j;
                int k;
                int startIndex=0;

                int i =input.IndexOf(s, StringComparison.OrdinalIgnoreCase);
                while (i>=0)
                {
                    j = input.IndexOf('>', i);
                    k = input.IndexOf('<', i);


                    if (k <= j)
                    {

                        input = input.Insert(i + s.Length, endTag);
                        input = input.Insert(i, beginTag);
                        startIndex = i + s.Length + endTag.Length + beginTag.Length;
                    }
                    else startIndex = i + s.Length; ;


                        i = input.IndexOf(s, startIndex, StringComparison.CurrentCultureIgnoreCase);
                }

                //colorIndex++;
            }

            return input;
        }
    }
}
