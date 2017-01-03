using System;


namespace CodeReview.Subjects.Other
{
	/// <summary>
	/// Codility Lesson
	/// Link: https://codility.com/programmers/lessons/1-iterations/binary_gap/
	/// Desc:
	/// A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones
	/// at both ends in the binary representation of N.
	/// 
	/// For example, number 9 has binary representation 1001 and contains a binary gap of length 2. The number 529 has
	/// binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3. The number
	/// 20 has binary representation 10100 and contains one binary gap of length 1. The number 15 has binary 
	/// representation 1111 and has no binary gaps.
	/// 
	/// Write a function:
	/// 				int solution(int N);
	/// that, given a positive integer N, returns the length of its longest binary gap.The function should return 0 if 
	/// N doesn't contain a binary gap.
	/// 
	/// For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and 
	/// so its longest binary gap is of length 5.
	/// 
	/// Assume that:
	/// 				N is an integer within the range[1..2, 147, 483, 647].
	/// 
	/// Complexity:
	/// expected worst-case time complexity is O(log(N));
	/// expected worst-case space complexity is O(1).
	/// </summary>

	public static class BinaryGap
	{
		public static int Run(int n) {
			Console.WriteLine("--- BinaryGap Running ---");

			int result;

			result = FindBinaryGap(1041);
			Console.WriteLine("Longest binary gap for {0} is: {1}", 9, result);

			return 0;
		}

		/// <summary>
		/// Description: Given a positive integer N, returns the length f its longest binary gap.
		/// Method: Shift the number by one bit and check the lsb for 1 or 0.
		/// 	if 1, we turn on counting, if counting already on, then we calculate the gap size
		/// 	if 0, if we are in counting mode, we increment the gap size
		/// </summary>
		/// <param name="n">N.</param>
		/// <returns>Gap Size</returns>
		private static int FindBinaryGap(int n) {

			// check if N is between 1 and -1
			if (n < 1 || n > int.MaxValue) {
				throw new System.ArgumentOutOfRangeException(Convert.ToString(n));
			}

			bool isCounting = false;    // flag used to indicate if we are counting zeros
			int currentGapSize = 0;
			int largestGapSize = 0;

			// loop through all bits of the integeger
			while (n > 0) {

				// check lsb
				if ((n & 1) == 1) {
					// check if end of gap, and update our largest gap size if necessary
					if (isCounting == true && currentGapSize > 0) {
						largestGapSize = (currentGapSize > largestGapSize) ? currentGapSize : largestGapSize;
					}
					isCounting = true;          // turn on counting if not already set
					currentGapSize = 0;         // reset gap size
				} else {
					if (isCounting == true) {
						currentGapSize++;       // increment gap size if we are in counting mode
					}
				}

				// shift by 1
				n = n >> 1;
			}

			return largestGapSize;
		}

	}
}
