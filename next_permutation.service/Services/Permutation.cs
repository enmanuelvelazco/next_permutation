using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextPermutation.Service
{
    public class Permutation : IPermutation
    {
        public Permutation()
        {
        }

        public int[] GetNextPermutation(int[] seed)
        {
            int pivot = -1;
            for (int i = seed.Length - 1; i > 0; i--)
                if (seed[i - 1] < seed[i])
                {
                    pivot = i - 1;
                    break;
                }
            if (pivot == -1)
                Reverse(ref seed, 0, seed.Length - 1);
            else
            {
                int pivot2 = seed.Length - 1;
                for (int i = seed.Length - 1; i > pivot; i--)
                    if (seed[pivot] < seed[i])
                    {
                        pivot2 = i;
                        break;
                    }

                Interchange(ref seed, pivot, pivot2);
                Reverse(ref seed, pivot + 1, seed.Length - 1);
            }
            return seed;
        }

        private void Reverse(ref int[] seed, int i, int j)
        {
            while (i < j)
            {
                Interchange(ref seed, i, j);
                i++;
                j--;
            }
        }

        private void Interchange(ref int[] seed, int i, int j)
        {
            seed[i] = seed[i] + seed[j];
            seed[j] = seed[i] - seed[j];
            seed[i] = seed[i] - seed[j];
        }
    }
}
