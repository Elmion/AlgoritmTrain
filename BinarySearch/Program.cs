using System;

namespace BinarySearch
{
	class Program
	{
		//static void Main(string[] args)
		//{
  //        int d =  new Solution().Search(new int[] { -1, 0, 3, 5, 9, 12 }, 9);

  //      }

	}

    public class Solution
    {
        public int Search(int[] nums, int target)
        {

            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                var pivotIndex = left + (right - left) / 2;
                if (nums[pivotIndex] == target) return pivotIndex;
                if (nums[pivotIndex] < target)
                {
                    left = pivotIndex + 1;
                }
                else
                {
                    right = pivotIndex - 1;
                }

            }
            return -1;

        }
    }
    //public class Solution2 : VersionControl
    //{
    //    public int FirstBadVersion(int n)
    //    {

    //        int left = 0;
    //        int right = n;
    //        while (left <= right)
    //        {
    //            var pivotIndex = left + (right - left) / 2;
    //            if (!IsBadVersion(pivotIndex))
    //            {
    //                left = pivotIndex + 1;
    //            }
    //            else
    //            {
    //                right = pivotIndex - 1;
    //            }
    //        }
    //        return left <= right ? right : left;
    //    }
    //}
}
