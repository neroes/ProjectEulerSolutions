using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerHelperClasses
{
    public class PrimeNumberCalculator
    {
        static LinkedList<Int64> primes;
        static long highestChecked;
        public static void Reset()
        {
            primes = new LinkedList<long>();
            primes.AddLast(2);
            highestChecked = 2;
        }
        public static void FindPrimesLowerThan(Int64 limit)
        {
            List<long> newprimes = new List<long>();
            if (highestChecked < ((Int64)Math.Sqrt((double) limit)))
            {
                FindPrimesLowerThan((Int64)Math.Sqrt((double) limit));
            }
            var result = Parallel.For(highestChecked+1,limit+1,(i, state) => {
                if (IsPrime(i)) { newprimes.Add(i); }
                    });
            newprimes.Sort();
            foreach(long prime in newprimes)
            {
                primes.AddLast(prime);
            }
            highestChecked = limit;
        }
        public static LinkedList<long> GetPrimes() { return primes; }
        static bool IsPrime(long i)
        {
            bool isprime = true;
            foreach (long j in primes)
            {
                if ((i % j) == 0) { isprime = false; break; }
            }
            return isprime;
        }
    }
}
