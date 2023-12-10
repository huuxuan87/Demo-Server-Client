using System.Security.Cryptography;

namespace Server.Commons
{
    public class SecureRandom
    {
        private readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

        public int Next()
        {
            byte[] randomBytes = new byte[4];
            rng.GetBytes(randomBytes);

            return BitConverter.ToInt32(randomBytes, 0);
        }

        public int Next(int maxValue)
        {
            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxValue));

            return Math.Abs(Next()) % maxValue;
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException(nameof(minValue));

            int range = maxValue - minValue;
            return minValue + Next(range);
        }
    }
}
