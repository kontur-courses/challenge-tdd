namespace App
{
    public static class MathSolver
    {
        public static string Solve(string question)
        {
            var postfixExpression = PostfixBuilder.BuildPostfixExpression(question);
            var answer = PostfixCalculator.Calculate(postfixExpression).ToString();
            return answer;
        }
    }
}
