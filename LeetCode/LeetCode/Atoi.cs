using System;

namespace ConsoleApplication1
{
    public static class Atoi
    {
        public static int MyAtoi(string str)
        {
            int i = 0;
            long result = 0;
            int bol = 1;
            while (i < str.Length && str[i] == ' ')
            {
                i++;
            }

            if (i == str.Length)
                return 0;
            if (str[i] == '-')
            {
                bol = -1;
                ++i;
            }
            else if (str[i] == '+')
            {
                bol = 1;
                ++i;
            }

            while (i < str.Length && str[i] >= '0' && str[i] <= '9')
            {
                result = result * 10 + str[i++] - '0';
                if (result >= 2147483648)
                {
                    if (bol == 1)
                        return Int32.MaxValue;
                    return Int32.MinValue;
                }
            }

            return (int)result * bol;
            
        }
    }
}