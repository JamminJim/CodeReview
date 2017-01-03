using System;
namespace CodeReview.Subjects.Codility.TimeComplexity
{
	/// <summary>
	/// Codility Lesson
	/// Title: PermMissingElem
	/// Link: https://codility.com/programmers/lessons/3-time_complexity/perm_missing_elem/
	/// Desc:
	/// A zero-indexed array A consisting of N different integers is given. The array contains integers in the range 
	/// [1..(N + 1)], which means that exactly one element is missing.
	/// 
	/// Your goal is to find that missing element.
	/// 
	/// Write a function:
	/// 			class Solution { public int solution(int[] A); }
	/// 
	/// that, given a zero-indexed array A, returns the value of the missing element.
	/// For example, given array A such that:
	/// A[0] = 2
	/// A[1] = 3
	/// A[2] = 1
	/// A[3] = 5
	/// 
	/// the function should return 4, as it is the missing element.
	/// 
	/// Assume that:
	/// N is an integer within the range[0..100, 000];
	/// the elements of A are all distinct;
	/// each element of array A is an integer within the range[1..(N + 1)].
	/// Complexity:
	/// expected worst-case time complexity is O(N);
	/// expected worst-case space complexity is O(1), beyond input storage(not counting the storage required for input 
	/// arguments).
	/// 
	/// Elements of input arrays can be modified.
	/// </summary>

	public static class PermMissingElement
	{
		public static void Run() {
			Console.WriteLine("--- MissingElement Running ---");

			//var array = new[] { 2, 3, 1, 5 };
			var array = new[] { 4, 3, 2, 1 };
			var result = TheirSolution(array);
			Console.WriteLine("Missing element in {0} is: {1}", string.Join("", array), result);
		}


		/// <summary>
		/// Method: Sum all elements that should be in the list and sum all elements that actually are in the list. 
		/// The sum is 0 based, so +1 is required. The first solution using the + operator can cause int overflow in 
		/// not-python languages. Therefore the use of a binary XOR is adequate.
		/// </summary>
		/// <returns>The solution.</returns>
		/// <param name="a">The alpha component.</param>
		private static int TheirSolution(int[] a) {
			int missingElement = a.Length + 1;  // 1 based

			for (var i = 0; i < a.Length; i++) {
				missingElement = missingElement ^ a[i] ^ (i + 1);
			}

			return missingElement;
		}

		/// <summary>
		/// Finds the missing element.
		/// Description: Given an array, shift the element of the array by k
		/// Method: uses seconary array to copy elements. 
		/// </summary>
		/// <returns>The missing element.</returns>
		private static int MySolution(int[] a) {
			// using math formula:  n * (n + 1) / 2   with arrays starting from 1, we can calculate sum of predicted size

			var currentSize = a.Length;
			var currentSum = 0;

			// target array size is one bigger than current array to account for missing element.
			var targetSize = currentSize + 1;
			var targetSum = 0;

			// sum up the value of the current array
			for (int i = 0; i < currentSize; i++) {
				currentSum += a[i];
			}

			// find sum of target size array using math formula above
			targetSum = targetSize * (targetSize + 1) / 2;

			// missing element is the difference between the two sums
			return targetSum - currentSum;
		}
	}
}
