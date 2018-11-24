using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class CheckBrackets : Processor
    {
        public Dictionary<char, char> Brackets = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}'} };


        public CheckBrackets(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public bool isClosingBracket(char ch)
        {
            if (ch.Equals(')') || ch.Equals(']') || ch.Equals('}'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public long Solve(string str)
        {
            string legalBrackets = "[]{}()";
            string bracketsString = "";

            Stack<Tuple<char, long>> bracketStack = new Stack<Tuple<char, long>>();
            for (long i = 0; i < str.Length; i++)
            {
                char ch = str[(int)i];
                if (legalBrackets.Contains(ch))
                {
                    Tuple<char, long> topItem = Tuple.Create(ch, i);
                    bracketStack.Push(topItem);
                    if (isClosingBracket(topItem.Item1))
                    {
                        bracketStack.Pop();
                        if (bracketStack.Count() >= 1 && Brackets[bracketStack.Peek().Item1] == topItem.Item1)
                        {
                            bracketStack.Pop();
                        }
                        else if (bracketStack.Count() == 0)
                        {
                            return topItem.Item2 + 1;
                        }
                        else if (bracketStack.Count() >= 1 && Brackets[bracketStack.Peek().Item1] != topItem.Item1)
                        {
                            return topItem.Item2 + 1;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            if (bracketStack.Count() == 0)
            {
                return -1;
            }
            else
            {
                while(bracketStack.Count > 1)
                {
                    bracketStack.Pop();
                }
                return bracketStack.Peek().Item2 + 1;
            }
        }
    }
}
