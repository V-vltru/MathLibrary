namespace Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ExpressionParsingHelpers
    {
        /// <summary>
        /// Method removes all brackets which contain nothing inside
        /// </summary>
        /// <param name="expression">The initial string where the process of removing empty brackets will be executed</param>
        /// <returns>New string without empty brackets</returns>
        public static string DeleteEmptyBrackets(string expression)
        {
            return expression.Replace("()", string.Empty);
        }

        /// <summary>
        /// Method removes all brackets from expression string
        /// </summary>
        /// <param name="expression">Initial expression string where the process of removing spaces will be executed</param>
        /// <returns>New expression string without spaces</returns>
        public static string RemoveSpaces(string expression)
        {
            return expression.Replace(" ", string.Empty);
        }

        /// <summary>
        /// Method checks whether the bracket balance is observed in expression
        /// </summary>
        /// <param name="expression">Initial expression for bracket balance checking process</param>
        /// <returns>The flag: true - bracket balance is observed, otherwise - false</returns>
        public static bool CheckBracketBalance(string expression)
        {
            bool result = true;
            int bracketBalance = 0;

            foreach (char symbol in expression)
            {
                if (symbol == '(')
                {
                    bracketBalance++;
                }

                if (symbol == ')')
                {
                    bracketBalance--;
                }

                if (bracketBalance < 0)
                {
                    return false;
                }
            }

            if (bracketBalance != 0)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Adds (-1)* instead of - in the beginning of the expression
        /// </summary>
        /// <param name="expression">Expression to analyze</param>
        /// <returns>New expression with (-1)* instead of -</returns>
        public static string AddMinusOne(string expression)
        {
            string ins = "(-1)*";

            if (expression[0] == '-' && (!(expression[1] >= '0' && expression[1] <= '9')))
            {
                return ins + expression.Substring(1);
            }

            return expression;
        }

        /// <summary>
        /// Removes the brackets which are wrapping up the whole expression
        /// For instance: (a + b) -> a + b
        /// ((a / b - 1)) - > a / b - 1
        /// </summary>
        /// <param name="expression">The initial expression</param>
        /// <returns>New expression without wrapping brackets</returns>
        public static string RemoveWrappedBrackets(string expression)
        {
            while (true)
            {
                if (expression[0] == '(')
                {
                    int bracketBalance = 1;
                    bool toContinue = false;
                    for (int expressionStringIndex = 1; expressionStringIndex < expression.Length; expressionStringIndex++)
                    {
                        if (expression[expressionStringIndex] == '(')
                        {
                            bracketBalance++;
                        }
                        else if (expression[expressionStringIndex] == ')')
                        {
                            bracketBalance--;

                            if (bracketBalance == 0 && expressionStringIndex == expression.Length - 1)
                            {
                                expression = COPY(expression, 1, expression.Length - 2);
                                toContinue = true;
                                break;
                            }

                            if (bracketBalance == 0 && expressionStringIndex < expression.Length - 1)
                            {
                                toContinue = false;
                                break;
                            }
                        }
                    }

                    if (bracketBalance != 0)
                    {
                        throw new Exception("Bracket balance is not observed!");
                    }

                    if (toContinue == true)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            string result = expression;
            return result;
        }

        /// <summary>
        /// Method copies the substring from initial string from start index to end one
        /// </summary>
        /// <param name="source">Initial string</param>
        /// <param name="idxFrom">Begin index</param>
        /// <param name="idxTo">End index</param>
        /// <returns>The substring in interval: [indexFrom; indexTo]</returns>
        public static string COPY(string source, int idxFrom, int idxTo)
        {
            string result = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();

            for (int sourceIndex = idxFrom; sourceIndex <= idxTo; sourceIndex++)
            {
                stringBuilder.Append(source[sourceIndex]);
            }

            result = stringBuilder.ToString();
            return result;
        }

        /// <summary>
        /// Gets all occurrences of a substring in a string
        /// </summary>
        /// <param name="source">The initial string for searching of substrings</param>
        /// <param name="substring">The substring to search for its occurrence</param>
        /// <returns>The the list of substring occurrence indexes</returns>
        public static List<int> GetAllSubstringIndexes(string source, string substring)
        {
            List<int> result = new List<int>();

            int firstIdx = source.IndexOf(substring);

            while (firstIdx > -1)
            {
                result.Add(firstIdx);
                firstIdx = source.IndexOf(substring, firstIdx + substring.Length);
            }

            return result;
        }
    }
}
