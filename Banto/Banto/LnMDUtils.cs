using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banto
{
    internal static class LnMDUtils
    {
        public static List<string> GerarListaDeLexicos(this string text)
        {
            return text.ToUpper().
                        Replace("{", " {").
                        Replace("}", "} ").
                        Replace(" ", "§").
                        Split('§').ToList();
        }
        
        public static string ValidarExpressao(this string text)
        {
            return text.Replace(".", string.Empty).
                        Replace(",", string.Empty).
                        Trim();
        }

        public static string[] ListarSequenciador(this string text)
        {
            return text.Replace("{", string.Empty).
                        Replace("}", string.Empty).
                        Split(',');
        }
    }
}
