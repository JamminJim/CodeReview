using System;
namespace CodeReview.Subjects.Arrays
{
	/// <summary>
	/// Codility Lesson
	/// Title: MinPosInteger
	/// Link: https://codility.com/programmers/lessons/1-iterations/binary_gap/
	/// Desc:
	/// Write a function:
	/// 			class Solution { public int solution(int[] A); }
	/// 
	/// that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer
	/// (greater than 0) that does not occur in A.
	/// 
	/// For example, given:
	/// A[0] = 1
	/// A[1] = 3
	/// A[2] = 6
	/// A[3] = 4
	/// A[4] = 1
	/// A[5] = 2
	/// the function should return 5.
	/// 
	/// Assume that:
	/// 
	/// N is an integer within the range[1..100, 000];
	/// each element of array A is an integer within the range[−2,147,483,648 .. 2,147,483,647].
	/// 
	/// Complexity:
	/// expected worst-case time complexity is O(N);
	/// expected worst-case space complexity is O(N), beyond input storage
	/// (not counting the storage required for input arguments).
	/// 
	/// Elements of input arrays can be modified.
	/// 
	/// </summary>

	public static class MinPosInteger
	{
		public static void Run() {
			Console.WriteLine("--- MinPosInteger Running ---");

			var result = 0;
			var array = new[] { 1, 3, 6, 4, 1, 2 };

			result = FindMinPosInteger(array);
			Console.WriteLine("MinPosInteger in {0} is {1}", string.Join("", array), result);
		}

		private static int FindMinPosInteger(int[] a) {
			// check array to be non empty
			// must consider negative and positive values in array
			// must consider duplicates values in array

			var result = 1;

			if (a == null || a.Length == 0) {
				throw new System.ArgumentOutOfRangeException(Convert.ToString(a.Length));
			}

			var size = a.Length;

			// allocate an array of bool
			bool[] b = new bool[size];

			// loop through array and set index of b to value of a
			for (int i = 0; i < size; i++) {
				if (a[i] > 0 && a[i] < size) {
					b[a[i]] = true;
				}
			}

			// loop through b and pick first false index
			for (int j = 1; j < b.Length; j++) {
				if (b[j] == false) {
					result = j;
					break;
				}
			}

			return result;
		}
	}
}
