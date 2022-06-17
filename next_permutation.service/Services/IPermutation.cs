using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextPermutation.Service
{
    public interface IPermutation
    {
        public abstract int[] GetNextPermutation(int[] seed);
    }
}
