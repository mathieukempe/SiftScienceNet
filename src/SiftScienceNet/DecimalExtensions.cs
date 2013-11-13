using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiftScienceNet
{
    public static class DecimalExtensions
    {
         public static int ToMicros(this decimal value)
         {
             return(int)((value*100)*10000);
         }
    }
}
