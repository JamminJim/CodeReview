using System;
namespace CodeReview.Subjects.Arrays
{
	/// <summary>
	/// Codility Lesson
	/// Title: IsPermutation
	/// Link: https://codility.com/programmers/lessons/4-counting_elements/perm_check/
	/// Desc:
	/// 	A non-empty zero-indexed array A consisting of N integers is given.
	/// 	A permutation is a sequence containing each element from 1 to N once, and only once.
	/// 
	/// For example, array A such that:
	/// A[0] = 4
	/// A[1] = 1
	/// A[2] = 3
	/// A[3] = 2
	/// 
	/// is a permutation, but array A such that:
	/// A[0] = 4
	/// A[1] = 1
	/// A[2] = 3
	/// is not a permutation, because value 2 is missing.
	/// 
	/// The goal is to check whether array A is a permutation.
	/// 
	/// Write a function:
	/// 				class Solution { public int solution(int[] A); }
	/// 
	/// that, given a zero-indexed array A, returns 1 if array A is a permutation and 0 if it is not.
	/// 
	/// For example, given array A such that:
	/// A[0] = 4
	/// A[1] = 1
	/// A[2] = 3
	/// A[3] = 2
	/// the function should return 1.
	/// 
	/// Given array A such that:
	/// A[0] = 4
	/// A[1] = 1
	/// A[2] = 3
	/// the function should return 0.
	/// 
	/// Assume that:
	/// 	N is an integer within the range[1..100, 000];
	/// 	each element of array A is an integer within the range[1..1, 000, 000, 000].
	/// 
	/// Complexity:
	/// expected worst-case time complexity is O(N);
	/// expected worst-case space complexity is O(N), beyond input storage
	/// (not counting the storage required for input arguments).
	/// 
	/// Elements of input arrays can be modified.
	/// 
	/// </summary>
	/// 
	public static class IsPermutation
	{
		public static void Run() {
			Console.WriteLine("--- IsPermutation Running ---");

			var result = false;
			var array = new[] { 4, 1, 3, 2 };

			result = FindIsPermutation(array);
			Console.WriteLine("Checking array {0} if permutation {1}", string.Join("", array), result);

			array = new[] { 4, 1, 3 };
			result = FindIsPermutation(array);
			Console.WriteLine("Checking array {0} if permutation {1}", string.Join("", array), result);

		}

		private static bool FindIsPermutation(int[] a) {

			var length = a.Length;
			var result = true;

			// create an secondary array
			bool[] b = new bool[length + 1];

			for (int i = 0; i < length; i++) {
				if (a[i] < b.Length) {
					b[a[i]] = true;
				} else {
					return false;
				}
			}

			for (int j = 1; j < b.Length; j++) {
				if (b[j] == false) {
					return false;
				}
			}


			return result;
		}
	}
}
