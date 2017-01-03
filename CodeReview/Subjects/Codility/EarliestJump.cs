using System;
namespace CodeReview.Subjects.Arrays
{

	/// <summary>
	/// Codility Lesson
	/// Title: FrogRiverOne
	/// Link: https://codility.com/programmers/lessons/4-counting_elements/frog_river_one/
	/// Desc:
	/// A small frog wants to get to the other side of a river. The frog is initially located on one bank of the river 
	/// (position 0) and wants to get to the opposite bank (position X+1). Leaves fall from a tree onto the surface of 
	/// the river.
	/// 
	/// You are given a zero-indexed array A consisting of N integers representing the falling leaves.A[K] represents 
	/// the position where one leaf falls at time K, measured in seconds.
	/// 
	/// The goal is to find the earliest time when the frog can jump to the other side of the river.The frog can cross
	/// only when leaves appear at every position across the river from 1 to X(that is, we want to find the earliest 
	/// moment when all the positions from 1 to X are covered by leaves). You may assume that the speed of the current 
	/// in the river is negligibly small, i.e.the leaves do not change their positions once they fall in the river.
	/// 
	/// For example, you are given integer X = 5 and array A such that:
	///   A[0] = 1
	///   A[1] = 3
	///   A[2] = 1
	///   A[3] = 4
	///   A[4] = 2
	///   A[5] = 3
	///   A[6] = 5
	///   A[7] = 4
	/// 
	/// In second 6, a leaf falls into position 5. This is the earliest time when leaves appear in every position 
	/// across the river.
	/// 
	/// Write a function:
	/// 				class Solution { public int solution(int X, int[] A); }
	/// 
	/// that, given a non-empty zero-indexed array A consisting of N integers and integer X, returns the earliest time 
	/// when the frog can jump to the other side of the river.
	/// 
	/// If the frog is never able to jump to the other side of the river, the function should return −1.
	/// 
	/// For example, given X = 5 and array A such that:
	///   A[0] = 1
	///   A[1] = 3
	///   A[2] = 1
	///   A[3] = 4
	///   A[4] = 2
	///   A[5] = 3
	///   A[6] = 5
	///   A[7] = 4
	/// the function should return 6, as explained above.
	/// 
	/// Assume that:
	/// 
	/// N and X are integers within the range [1..100,000];
	/// each element of array A is an integer within the range[1..X].
	/// 
	/// Complexity:
	/// expected worst-case time complexity is O(N);
	/// expected worst-case space complexity is O(X), beyond input storage(not counting the storage required for input 
	/// arguments).
	/// 
	/// Elements of input arrays can be modified.
	/// 
	///</summary>

	public static class EarliestJump
	{
		public static void Run() {
			Console.WriteLine("--- EarliestJump Running ---");

			var result = 0;

			var array = new[] { 1, 3, 1, 4, 2, 3, 5, 4 };
			result = FindEarliest(array, 5);
			Console.WriteLine("Earliest jump to position 5 for array {0} is {1}", string.Join("", array), result);

			array = new[] { 4, 5, 3, 2, 1 };
			result = FindEarliest(array, 5);
			Console.WriteLine("Earliest jump to position 5 for array {0} is {1}", string.Join("", array), result);

			array = new[] { 1, 3, 1, 4, 2, 3, 6, 1 };
			result = FindEarliest(array, 5);
			Console.WriteLine("Earliest jump to position 5 for array {0} is {1}", string.Join("", array), result);
		}

		private static int FindEarliest(int[] a, int k) {
			var result = -1;

			// consecutive numbers we can use math formula  sum = x* (x+1) / 2;
			var sum = k * (k + 1) / 2;

			// create an alternate array to store path
			int[] count = new int[k];

			int i = 0;
			// loop through the array while sum is greater than zero
			for (; i < a.Length && sum != 0; i++) {

				// if value of a is less than path and has not already been marked, increment count. Note -1 used to 0 based path
				if (a[i] <= k && count[a[i] - 1] == 0) {
					count[a[i] - 1]++;
					sum -= a[i];
				}
			}

			result = (sum == 0) ? i - 1 : result;

			return result;
		}

		private static int FindEarliestWrong(int[] a, int k) {
			// a[second] = position 

			var length = a.Length;

			int[] b = new int[k + 1];
			for (int x = 0; x < b.Length; x++) {
				b[x] = -1;
			}

			// loop through each second and find position. mark that position as complete
			for (int i = 0; i < length; i++) {
				if (a[i] <= k) {
					b[a[i]] = i;
				}
			}

			// loop through b and check each value is set to non zero value
			for (int j = 1; j < b.Length; j++) {
				if (b[j] == -1) {
					return -1;
				} else if (j == k) {
					return b[j];
				}
			}

			return -1;
		}
	}
}
