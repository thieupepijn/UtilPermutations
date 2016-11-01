using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace MiniCSharp
{
    public class UtilPermutations
    {
        public static IEnumerable<string> Permute(string zin)
        {
            if (zin.Length < 2)
            {
                yield return zin;
            }
            else if (zin.Length == 2)
            {
                yield return zin;
                yield return Verwissel(zin,0,1);
            }
            else
            {
                for (int t=0;t<zin.Length;t++)
                {
                    string zinChanged = Verwissel(zin, 0, t);
                    foreach (string subzin in Permute(zinChanged.Substring(1)))
                    {
                        yield return zinChanged.Substring(0,1) + subzin;
                    }
                }
            }
        }
        public static string Verwissel2(string zin, int pos1, int pos2)
        {
            if (pos1 > pos2)
            {
                int getalBuf = pos1;
                pos1 = pos2;
                pos2 = getalBuf;
            }
            string buf1 = zin.Substring(pos1, 1);
            string buf2 = zin.Substring(pos2, 1);
            zin =  zin.Insert(pos1, buf2);
            zin =  zin.Remove(pos1, 1);
            zin =  zin.Insert(pos2, buf1);
            zin =  zin.Remove(pos2, 1);
            return zin;
        }

        public static string Verwissel(string zin, int pos1, int pos2)
        {
            List<char> listChars = String2CharList(zin);
            char buf = listChars[pos1];
            listChars[pos1] = listChars[pos2];
            listChars[pos2] = buf;
            return CharList2String(listChars);
        }
        public static List<char> String2CharList(string zin)
        {
            List<char> returnList = new List<char>();
            foreach(char letter in zin)
            {
                returnList.Add(letter);
            }
            return returnList;
        }
        public static string CharList2String(List<char> listChars)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char letter in listChars)
            {
                sb.Append(letter);
            }
            return sb.ToString();
        }
        public static string IEnumerableList2String(IEnumerable<string> listStrings)
        {
            if (listStrings == null)
            {
                return String.Empty;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string stringetje in listStrings)
                {
                    sb.AppendLine(stringetje);
                }
                return sb.ToString();
            }
        }
        public static string DoStuff()
        {
            return IEnumerableList2String(Permute("1234"));
        }
    }
}




































































































