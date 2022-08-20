namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var stack = new Stack<char>();

            foreach (var ch in parentheses)
            {
                switch (ch)
                {
                    case '{':
                    case '[':
                    case '(':
                        stack.Push(ch);
                        break;
                    case '}':
                        if (stack.Count == 0)
                        {
                            return false;
                        }
                        if (stack.Peek() != '{')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                    case ']':
                        if (stack.Count == 0)
                        {
                            return false;
                        }
                        if (stack.Peek() != '[')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                    case ')':
                        if (stack.Count == 0)
                        {
                            return false;
                        }
                        if (stack.Peek() != '(')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                }
            }

            return stack.Count == 0;
        }
    }
}
