using System.Text.RegularExpressions;

namespace TibaEvaluationExercise.Utilities
{
    public static class StringHelpers
    {
        public static int ExtractNumberFromString(string text)
        {
            var numbers = System.Text.RegularExpressions.Regex.Match(text, @"\d+").Value;
            return int.TryParse(numbers, out int result) ? result : 0;
        }
    }
}
