using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banto
{
    public static class BantoQuery
    {
        public static string ToSQLCommand(this string text)
        {
            LnMD lmd = new LnMD();
            return lmd.Execute(text);
        }
    }
}
