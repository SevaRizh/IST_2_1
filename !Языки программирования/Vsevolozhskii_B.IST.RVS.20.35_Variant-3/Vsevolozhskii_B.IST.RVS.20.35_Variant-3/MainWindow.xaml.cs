using System;
using System.Windows;
using System.Windows.Input;

namespace Vsevolozhskii_B.IST.RVS._20._35_Variant_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string t_Encryption = string.Empty;
        private string t_Decryption = string.Empty;
        private string temp = string.Empty;
        private int shift_n;

        private enum Symbol
        {
            а = 1, б, в, г, д, е, ё, ж, з, и, й, к, л, м, н, о, п, р, с, т, у, ф, х, ц, ч, ш, щ, ъ, ы, ь, э, ю, я,
            А, Б, В, Г, Д, Е, Ё, Ж, З, И, Й, К, Л, М, Н, О, П, Р, С, Т, У, Ф, Х, Ц, Ч, Ш, Щ, Ъ, Ы, Ь, Э, Ю, Я,
            a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z,
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }

        public MainWindow()
        {
            shift_n = Convert.ToInt32(shift_num);

            if (shift_n < 3 || shift_n > 15)
            {
                shift_n = 4;
            }

            InitializeComponent();
        }

        private void btn_Encryption(object sender, RoutedEventArgs e)
        {
            t_Decryption = decryption.Text;

            temp = Trans_Info(t_Decryption, shift_n);

            encryption.Text = temp;
        }

        private void btn_Decryption(object sender, RoutedEventArgs e)
        {
            t_Encryption = encryption.Text;

            temp = Trans_Info(t_Encryption, shift_n, false);

            decryption.Text = temp;
        }

        private string Trans_Info(string str, int shift, bool check = true)
        {
            string temp_str = string.Empty;
            shift = check ? shift : -1 * shift;

            int enum_Count = Enum.GetNames(typeof(Symbol)).Length;
            int index;
            int temp_Index;

            for (int i = 0; i < str.Length; i++)
            {
                if (Enum.IsDefined(typeof(Symbol), Convert.ToString(str[i])))
                {
                    index = Convert.ToInt32(Enum.Parse(typeof(Symbol), str[i].ToString()));
                    temp_Index = index + shift;

                    if (temp_Index <= 0)
                    {
                        temp_str += Enum.GetName(typeof(Symbol), enum_Count - (Math.Abs(shift) - index));
                    }
                    else if (temp_Index > enum_Count)
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
            return temp_str;
        }

        private void check_key(object sender, KeyEventArgs e)
        {
            char number = (char)e.Key;

            if(Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
