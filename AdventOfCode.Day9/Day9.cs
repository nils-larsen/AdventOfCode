namespace AdventOfCode.Day9
{
    public static class Day9
    {
        public static (int, int) ProcessStreamOfCharacters(string input)
        {
            var stream = input.ToCharArray();
            var lengthOfStream = stream.Length;

            var garbage = false;
            var groupScore = 0;
            var totalScore = 0;
            var totalGarbage = 0;

            for (var s = 0; s < lengthOfStream; s++)
            {
                if (stream[s] == '!')
                {
                    s++;
                }
                else if (garbage && stream[s] != '>')
                {
                    totalGarbage++;
                }
                else if (stream[s] == '<')
                {
                    garbage = true;
                }
                else if (stream[s] == '>')
                {
                    garbage = false;
                }
                else if (stream[s] == '{')
                {
                    groupScore++;
                    totalScore += groupScore;
                }
                else if (stream[s] == '}')
                {
                    groupScore--;
                }
            }

            return (totalScore, totalGarbage);
        }
    }
}
