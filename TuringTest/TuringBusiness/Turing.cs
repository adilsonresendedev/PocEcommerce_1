using System.Collections.Generic;
using System.Linq;

namespace TuringBusiness
{
    public class Turing
    {
        public IList<IList<int>> SubSet(int[] nums)
        {
            int lenght = nums.Length;
            int powerSetCount = 1 << lenght;
            IList<IList<int>> result = new List<IList<int>>();

            for (int setMask = 0; setMask < powerSetCount; setMask++)
            {
                IList<int> currentRecord = new List<int>();
                for (int i = 0; i < lenght; i++)
                {
                    if ((setMask & (1 << i)) > 0)
                    {
                        currentRecord.Add(nums[i]);
                    }
                }
                result.Add(currentRecord);
            }

            return result;
        }
    }
}
