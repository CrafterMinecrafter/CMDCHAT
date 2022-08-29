using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMDCHAT
{
    class strtools
    {
        public static int[] FindSubStrings(string input, string substring)
        {
            List<int> t = new List<int>(0);
            int index = 0;
            while ((index = input.IndexOf(substring, index)) != -1)
            {
                t.Add(index);
                index += substring.Length;
            }
            return t.ToArray();
        }
        public static int StrToMD5(string input)
        {
            var md = MD5.Create();
            int hash = BitConverter.ToInt32(md.ComputeHash(Encoding.UTF8.GetBytes(input)),0);
            return hash;
        }
    }
}
