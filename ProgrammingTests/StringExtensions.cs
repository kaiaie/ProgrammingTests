using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTests
{
    public static class StringExtensions
    {
        public static string ReverseWords(this string sentence)
        {
            return string.IsNullOrEmpty(sentence) ? string.Empty :
                string.Join(" ",
                sentence.Split(new char[] { ' ' })
                .Reverse());
        }
    }
}
