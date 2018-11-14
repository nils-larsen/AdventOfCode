using System.Text;
using System.Security.Cryptography;

namespace AdventOfCode.Day4
{
    public static class AdventCoin
    {
        public static long Mine(string input, int nrOfZeroes)
        {
            var searching = true;
            string comparer = new string('0', nrOfZeroes);
            var counter = 0;

            using (MD5 md5Hash = MD5.Create())
            {
                while (searching)
                {
                    var secretKey = input + counter.ToString();
                    var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(secretKey));

                    var sBuilder = new StringBuilder();
                    for (int i = 0; i < 3; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    if (sBuilder.ToString().Substring(0, nrOfZeroes) == comparer)
                    {
                        return counter;
                    }
                    counter++;
                }
            }
            return 0;
        }
    }
}
