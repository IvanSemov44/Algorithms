namespace ExamPreparation
{
    internal static class ConditionalExpressionResolver
    {
        public static void Solution()
        {
            var expression = Console.ReadLine()
                .Split()
                .Select(x => x[0])
                .ToArray();

            Console.WriteLine(ParseExpression(expression, 0));
        }
        private static int ParseExpression(char[] expression, int idx)
        {
            if (char.IsDigit(expression[idx]))
                return expression[idx] - '0';

            if (expression[idx] == 't')
                return ParseExpression(expression, idx + 2);

            var foundConditions = 0;

            for (int i = idx + 2; i < expression.Length; i++)
            {
                var currentSymbol = expression[i];
                if (currentSymbol == '?')
                {
                    foundConditions++;
                }
                else if (currentSymbol == ':')
                {
                    foundConditions--;

                    if (foundConditions < 0)
                        return ParseExpression(expression, i + 1);
                }
            }

            throw new InvalidOperationException();
        }
    }
}
