using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerHelperClasses
{
    public class PrimeNumberCalculator
    {
        static LinkedList<Int64> primes;
        static HashSet<Int64> primeHash;
        static long highestChecked;
        public static void Reset()
        {
            primes = new LinkedList<long>();
            primes.AddLast(2);
            primeHash = new HashSet<long>{2};
            highestChecked = 2;
        }
        public static void FindPrimesLowerThan(Int64 limit)
        {
            List<long> newprimes = new List<long>();
            if (highestChecked < ((Int64)Math.Sqrt((double) limit)))
            {
                FindPrimesLowerThan((Int64)Math.Sqrt((double) limit));
            }
            bool[] primearray = new bool[limit - highestChecked];
            var result = Parallel.For(highestChecked + 1L, limit + 1L, (i, state) =>
                  {
                      primearray[i - highestChecked - 1L] = IsPrime(i);
                  });
            for (int i = 0; i<primearray.Length; i++)
            {
                if (primearray[i])
                {
                    primes.AddLast(i + highestChecked + 1);
                    primeHash.Add(i + highestChecked + 1);
                }
            }
            highestChecked = limit;
        }
        public static LinkedList<long> GetPrimes() { return primes; }
        static private bool IsPrime(long i)
        {
            bool isprime = true;
            foreach (long j in primes)
            {
                if ((i % j) == 0) { isprime = false; break; }
            }
            return isprime;
        }
        static public bool IsPrimeLookup(long i)
        {
            return primeHash.Contains(i);
        }
    }
}
