using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProject
{
    class Program
    {
        private enum Symbol
        {
            а = 1, б, в, г, д, е, ё, ж, з, и, й, к, л, м, н, о, п, р, с, т, у, ф, х, ц, ч, ш, щ, ъ, ы, ь, э, ю, я,
            А, Б, В, Г, Д, Е, Ё, Ж, З, И, Й, К, Л, М, Н, О, П, Р, С, Т, У, Ф, Х, Ц, Ч, Ш, Щ, Ъ, Ы, Ь, Э, Ю, Я,
            a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z,
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }

        static string str = "а бв4Z";

        static void Main(string[] args)
        {
            string temp_str = string.Empty;
            bool check = true;
            int shift = 4;
            shift = check ? shift : -1 * shift;

            int enum_Count = Enum.GetNames(typeof(Symbol)).Length;
            int index;
            int temp_Index;

           for(int i = 0; i < str.Length; i++)
            {
                if(Enum.IsDefined(typeof(Symbol), Convert.ToString(str[i])))
                {
                    index = Convert.ToInt32(Enum.Parse(typeof(Symbol), str[i].ToString()));
                    temp_Index = index + shift;

                    if(temp_Index <= 0)
                    {
                        temp_str += Enum.GetName(typeof(Symbol), enum_Count - (Math.Abs(shift) - index));
                    }
                    else if(temp_Index > enum_Count)
                        {
                        temp_str += Enum.GetName(typeof(Symbol), temp_Index - enum_Count);
                    }
                    else
                    {
                        temp_str += Enum.GetName(typeof(Symbol), index + shift);
                    }
                }
                else
                {
                    temp_str += str[i];
                }
            }
        }
    }
}
