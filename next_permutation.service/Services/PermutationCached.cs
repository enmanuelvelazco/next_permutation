using System;
using Microsoft.Extensions.Caching.Memory;

namespace NextPermutation.Service
{
    public class PermutationCached : IPermutation
    {
        readonly IMemoryCache cache;
        public PermutationCached(IMemoryCache _cache)
        {
            cache = _cache;
        }

        public int[] GetNextPermutation(int[] array)
        {
            if (!cache.TryGetValue(GetKeyFromArray(array), out int[] array2))
            {
                string key = GetKeyFromArray(array);
                array = NextPermutationHelper(array);
                cache.Set(key, array, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(10),
                    Size = array.Length
                });
            }

            return array2 ?? array;
        }

        private int[] NextPermutationHelper(int[] array)
        {
            int pivot = -1;
            for (int i = array.Length - 1; i > 0; i--)
                if (array[i - 1] < array[i])
                {
                    pivot = i - 1;
                    break;
                }
            if (pivot == -1)
                IPermutation.Reverse(ref array, 0, array.Length - 1);
            else
            {
                int pivot2 = array.Length - 1;
                for (int i = array.Length - 1; i > pivot; i--)
                    if (array[pivot] < array[i])
                    {
                        pivot2 = i;
                        break;
                    }

                IPermutation.Interchange(ref array, pivot, pivot2);
                IPermutation.Reverse(ref array, pivot + 1, array.Length - 1);
            }
            return array;
        }

        private string GetKeyFromArray(int[] array)
        {
            string key = "";
            foreach (int item in array)
            {
                key += (item.ToString() + ",");
            }

            return key;
        }
    }
}
