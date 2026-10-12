using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Extensions
{
    public static class StringExtension
    {
        public static string Multiply(this string str, int times)
        {
            if (times < 0)
                throw new ArgumentException("Количество повторений не может быть отрицательным.");

            return string.Concat(Enumerable.Repeat(str, times));
        }
    }
}
