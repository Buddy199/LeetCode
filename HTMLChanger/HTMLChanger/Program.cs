using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HTMLChanger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var originalHtml = File.ReadAllText("/Users/buddy/Downloads/021905_793_actlog.html");
            var targetText = RegexLi.Matches(originalHtml);
            var strList = new List<string>();
            for (var i = 0; i < targetText.Count; i++)
            {
                strList.Add(targetText[i].Value);
            }
            strList.RemoveAt(0);
            strList.RemoveAt(strList.Count - 1);
            strList.Sort((a, b) =>
            {
                var aContent = GetContent(a);
                var bContent = GetContent(b);
                return string.Compare(aContent, bContent,StringComparison.OrdinalIgnoreCase);
            });

            var sb = new StringBuilder();
            foreach (var str in strList)
            {
                sb.Append("<li>").Append(str).Append("</li></br>");
            }
            
            File.WriteAllText("output.txt",sb.ToString());
        }
        
        public static Regex Regex = new Regex("(?<=(" + "<b>" + "))[.\\s\\S]*?(?=(" + "</b>" + "))", RegexOptions.Multiline | RegexOptions.Singleline);
        
        public static Regex RegexLi = new Regex("(?<=(" + "<li>" + "))[.\\s\\S]*?(?=(" + "</li>" + "))", RegexOptions.Multiline | RegexOptions.Singleline);
        public static string GetContent(string str)
        {
            return Regex.Match(str).Value;
        }
    }
}