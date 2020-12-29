using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SensitiveService
    {
        private class TrieNode
        {
            private readonly Dictionary<char,TrieNode> _subNodes = new Dictionary<char, TrieNode>();
            private bool _isEnd = false;

            public void AddSubNode(char key, TrieNode subNode)
            {
                _subNodes.Add(key,subNode);
            }

            public TrieNode GetSubNode(char key)
            {
                _subNodes.TryGetValue(key, out var value);
                return value;
            }
            
            public bool IsEnd(){
                return _isEnd;
            }
            
            public void SetEnd(bool end){
                this._isEnd = end;
            }
            
            public int GetSubNodesCount(){
                return _subNodes.Count;
            }
        }
        
        private readonly TrieNode _root = new TrieNode();

        public void AddWord(string word)
        {
            TrieNode tempNode = _root;
            for (var i = 0; i < word.Length; i++)
            {
                char c = word[i];
                TrieNode node = tempNode.GetSubNode(c);
                if (node == null)
                {
                    node = new TrieNode();
                    tempNode.AddSubNode(c,node);
                }

                tempNode = node;
                if (i == word.Length - 1)
                {
                    tempNode.SetEnd(true);
                }
            }
        }
        
        public string FiltSensitiveWord(string str){
            if(str==null)
                return str;

            //结果字符串
            StringBuilder sb = new StringBuilder();
            int begin = 0;
            int position = 0;
            TrieNode tempNode = _root;

            while(position<str.Length){
                char c = str[position];
                //过滤掉符号字符
                tempNode = tempNode.GetSubNode(c);
                //当前字符不在敏感词树中
                if(tempNode == null){
                    sb.Append(c);
                    begin++;
                    position = begin;
                    tempNode = _root;
                }else{
                    if(tempNode.IsEnd()){
                        sb.Append("***");
                        position++;
                        begin = position;
                    }else{
                        position++;
                    }
                }
            }
            //append最后一个子串
            sb.Append(str.Substring(begin));

            return sb.ToString();
        }
    }
}