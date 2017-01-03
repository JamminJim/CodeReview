using System;
using System.Collections.Generic;

namespace CodeReview.Subjects.Other
{
	/// <summary>
	/// /// Codility Lesson
	/// Title: TapeEquilibrium
	/// Link: https://codility.com/programmers/lessons/3-time_complexity/tape_equilibrium/
	/// Desc:
	/// A non-empty zero-indexed array A consisting of N integers is given. Array A represents numbers on a tape.
	/// Any integer P, such that 0 less than P less than N, splits this tape into two non-empty parts: 
	/// 
	/// 					A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].
	/// 
	/// The difference between the two parts is the value of: 
	/// 
	/// 					|(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|
	/// 
	/// In other words, it is the absolute difference between the sum of the first part and the sum of the second part.
	/// 
	/// For example, consider array A such that:
	/// A[0] = 3
	/// A[1] = 1
	/// A[2] = 2
	/// A[3] = 4
	/// A[4] = 3
	/// 
	/// We can split this tape in four places:
	/// 	P = 1, difference = | 3 − 10| = 7 
	/// 	P = 2, difference = | 4 − 9| = 5 
	/// 	P = 3, difference = | 6 − 7| = 1 
	/// 	P = 4, difference = | 10 − 3| = 7 
	/// 
	/// Write a function:
	/// 			class Solution { public int solution(int[] A); }
	/// 
	/// that, given a non-empty zero-indexed array A of N integers, returns the minimal difference that can be achieved.
	/// 
	/// For example, given:
	/// A[0] = 3
	/// A[1] = 1
	/// A[2] = 2
	/// A[3] = 4
	/// A[4] = 3
	/// the function should return 1, as explained above.
	/// 
	/// Assume that:
	/// N is an integer within the range[2..100, 000];
	/// each element of array A is an integer within the range[−1, 000..1, 000].
	/// 
	/// Complexity:
	/// expected worst-case time complexity is O(N);
	/// expected worst-case space complexity is O(N), beyond input storage(not counting the storage required for input arguments).
	/// 
	/// Elements of input arrays can be modified.
	/// </summary>

	public static class TapeEquilibrium
	{
		public static void Run() {
			Console.WriteLine("--- TapeEquilibrium Running ---");
			var array = new[] { 3, 1, 2, 4, 3 };
			var result = TheirSolution(array);
			Console.WriteLine("The min difference in array {0} is {1}", string.Join("", array), result);
		}


		/// <summary>
		/// URL: https://www.martinkysel.com/codility-tape-equilibrium-solution/
		/// Method: In the first run I compute the left part up to the point i and the overall sum last. Then I compute
		/// the minimal difference between 0..i and i+1..n.
		/// </summary>
		/// <returns>The solution.</returns>
		/// <param name="a">The alpha component.</param>
		private static int TheirSolution(int[] a) {

			var size = a.Length;

			List<long> parts = new List<long>(size + 1);
			long last = 0;

			// compute the left hand side up to i and the overall sum
			for (var i = 0; i < size - 1; i++) {
				if (i == 0) {
					parts.Add(a[i]);
				} else {
					parts.Add(a[i] + parts[i - 1]);
				}
				if (i == size - 2) {
					last = parts[i] + a[i + 1];
				}
			}

			// compute the minimal difference between 0..i and i+1..n
			long solution = long.MaxValue;
			for (var i = 0; i < parts.Count; i++) {
				solution = Math.Min(solution, Math.Abs(last - 2 * parts[i]));
			}

			return (int)solution;
		}


		/// <summary>
		/// Finds the minimum difference.
		/// Description: Given an array finds the element which splits the array such that both sized have similar value
		/// Method: Loop through array and tally up the values of the entire array as well as storing the running total into the current index
		/// 		Next, loop through the array again using the tally values to compare the left and right sides
		/// 		save and passback the minimum difference while looping
		/// </summary>
		/// <returns>The minimum difference.</returns>
		private static int MySolution(int[] a) {

			var size = a.Length;
			var totalSum = 0;
			var leftSum = 0;
			var rightSum = 0;
			var delta = 0;
			var result = 0;

			for (int i = 0; i < size; i++) {
				// determine the sum of all values of the array
				totalSum += a[i];
				// update the index of the array to contain the running total values index so far
				a[i] = totalSum;
			}

			// before we begin, set the result to be passed back as the total sum of all values (ie., largest possible difference)
			result = totalSum;

			// loop through the array again and use the updated total values in the array to determine best spot
			for (int j = 1; j < size; j++) {

				// find the sum of the left side
				leftSum = a[j - 1];

				// find the sum of the right side by subtracting the left side from the total;
				rightSum = totalSum - leftSum;

				// calculate the delta between left and right side
				delta = Math.Abs(leftSum - rightSum);

				// update result if delta is smallest value
				result = (delta < result) ? delta : result;
			}

			// return the smallest delta found
			return result;
		}

	}
}
