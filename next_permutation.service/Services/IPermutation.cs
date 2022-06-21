using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextPermutation.Service
{
    public interface IPermutation
    {
        public abstract int[] GetNextPermutation(int[] seed);

        protected static void Reverse(ref int[] seed, int i, int j)
        {
            while (i < j)
            {
                Interchange(ref seed, i, j);
                i++;
                j--;
            }
        }

        protected static void Interchange(ref int[] seed, int i, int j)
        {
            seed[i] = seed[i] + seed[j];
            seed[j] = seed[i] - seed[j];
            seed[i] = seed[i] - seed[j];
        }
    }
}
