using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Nombre
    {
        static public int CompterChiffres(long n)
        {
            int resultat = 1;
            long p10 = 10;
            while (n >= p10)
            {
                n /= 10;
                resultat++;
            }
            return resultat;
        }

        static public string ToRoman(int n)
        {
            string romain = "";
            int[] arab = { 1000, 900, 500, 400, 100, 99, 90, 50, 49, 10, 9, 5, 4, 1 };
            string[] roman = { "M", "CM", "D", "CD", "C", "XCIX", "XC", "L", "XLIX", "X", "IX", "V", "IV", "I" };
            for (int i = 0; i < arab.Length; i++)
            {
                while (n >= arab[i])
                {
                    romain += roman[i];
                    n -= arab[i];
                }
            }
            return romain;
        }
    }
}
