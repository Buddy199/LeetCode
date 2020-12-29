using System.Collections.Generic;

namespace LeetCode
{
    public static class Utility
    {
        public static int RomanToInt(string s)
        {
            Dictionary<string, int> romanDic = new Dictionary<string, int>
            {
                {"I", 1},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"M", 1000}
            };

            var ans = 0;
            for (var i = 0; i < s.Length;)
            {
                if (i + 1 < s.Length&&romanDic.ContainsKey(s.Substring(i,2)))
                {
                    ans += romanDic[s.Substring(i, 2)];
                    i += 2;
                }
                else
                {
                    ans += romanDic[s.Substring(i, 1)];
                    i += 1;
                }
            }

            return ans;
        }
    }
}