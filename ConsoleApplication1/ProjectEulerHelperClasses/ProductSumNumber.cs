using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerHelperClasses
{
    public class ProductSumNumber
    {
        public static Dictionary<Int64, ProductSumNumber> lookup = new Dictionary<Int64, ProductSumNumber>();
        private Int64 res;
        private List<Int64> numset;
        public ProductSumNumber(Int64 result, List<Int64> numberset)
        {
            res = result;
            numset = numberset;
        }
        public Int64 GetRes() { return res; }
        public List<Int64> GetNumset() { return numset; }
        public List<Int64> Expander()
        {
            List<Int64> expanded = new List<Int64>();
            foreach (Int64 num in numset)
            {
                if (lookup.ContainsKey(num))
                {
                    expanded.AddRange(lookup[num].Expander());
                }
                else
                {
                    expanded.Add(num);
                }
            }
            return expanded;
        }
    }
}
