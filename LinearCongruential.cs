using System;

namespace RandomPasswordGenerators
{
    public class LinearCongruential
    {
        public int Next(int seed, int min, int max)
        {
            seed += Guid.NewGuid().GetHashCode();
            int temp = ((1927 * seed + 393) % (max - min));

            return temp <= 0 ? -temp + min : temp + min;
        }
    }
}
