namespace Lab2;
public class Program
{
    public static void Main(string[] args)
    {
        IsBalanced("{ ( < > ) }");  // true
        IsBalanced("<> {(})");      // false
    }

    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        // iterate over all chars in string
        foreach(var c in s)
        {
            // if char is an open thing, push it
            if ( c=='<' || c=='(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            // if char is a close thing,
            // compare it to top of stack;
            else if (c == '>' || c == ')' || c == '}' || c == ']')
            {
                char top;
                bool result = stack.TryPeek(out top);
                // handle result == false
                bool something = Matches(c, top);
                // if they match, pop()
                if (something == true) 
                {
                    stack.Pop();
                }
                // else, return false
                else if( something == false)
                {
                    return false;
                }
            }
            
        }

        // if stack is empty, return true
        if( stack.Count == 0)
        {
            return true;
        }

        return false;

    }

    private static bool Matches(char closing, char opening)
    {
        if (closing == ')')
        {
            if(opening == '(')
            {
                return true;
            }
            return false;
        }

        else if(closing == ']')
        {
            if (opening == '[')
            {
                return true;
            }
            return false;

        }

        else if (closing == '}')
        {
            if (opening == '{') 
            {
                return true;
            }
            return false;
        }

        else if (closing == '>')
        {
            if (opening == '<')
            {
                return true;
            }
            return false;
        }

        return false;
    }

    public static double? Evaluate(string s)
    {
        Stack<double> stack = new Stack<double>();

        if (string.IsNullOrEmpty(s))
        {
            return null;
        }
        // parse string into tokens
        string[] tokens = s.Split();

        // foreach token

        foreach (string token in tokens)
        {
            
            if(token == "+"|| token == "-" || token == "*" || token == "/")
            {
                // if it's a math operator, pop twice;
                double pop1 = stack.Pop();
                double pop2 = stack.Pop();


                // compute result;
                if (token == "+")
                {
                    double result = pop2 + pop1;

                    // push result onto stack
                    stack.Push(result);
                }

                else if (token == "-")
                {
                    double result = pop2 - pop1;
                    stack.Push(result);
                }

                else if (token == "*")
                {
                    double result = pop2 * pop1;
                    stack.Push(result);
                }

                else if (token == "/")
                {
                    double result = pop2 / pop1;
                    stack.Push(result);
                }

            }

            // if it's a number, push to stack
            else
            {
                double nowInt = Convert.ToDouble(token);
                stack.Push(nowInt);
            }
        }



        // return top of stack (if the stack has 1 element)
        if( stack.Count == 1)
        {
            return stack.Peek();
        }

        return null;
    }

}

