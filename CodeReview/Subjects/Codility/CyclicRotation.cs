using System;
namespace CodeReview.Subjects.Arrays
{
	public static class CyclicRotation
	{
		/// <summary>
		/// Codility Lesson
		/// Title: CyclicRotation
		/// Link: https://codility.com/programmers/lessons/1-iterations/binary_gap/
		/// Desc:
		/// A zero-indexed array A consisting of N integers is given. Rotation of the array means that each element 
		/// is shifted right by one index, and the last element of the array is also moved to the first place.
		/// 
		/// For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7]. The goal is to rotate array A K
		/// times; that is, each element of A will be shifted to the right by K indexes.
		/// 
		/// Write a function:
		/// 				struct Results solution(int A[], int N, int K);
		/// 
		/// that, given a zero-indexed array A consisting of N integers and an integer K, returns the array A 
		/// rotated K times.
		/// 
		/// For example, given array A = [3, 8, 9, 7, 6] and K = 3, the function should return [9, 7, 6, 3, 8].
		/// 
		/// Assume that:
		/// 		N and K are integers within the range[0..100];
		/// each element of array A is an integer within the range[−1, 000..1, 000].
		/// 
		/// In your solution, focus on correctness.The performance of your solution will not be the
		/// focus of the assessment.
		/// 
		/// </summary>


		public static void Run() {
			Console.WriteLine("--- CyclicRotation Running ---");

			var array = new[] { 3, 8, 9, 7, 6 };
			var k = 3;

			Console.WriteLine("Rotating Array {0} by {1}", string.Join(",", array), k);

			RotateArray(ref array, k);
			Console.WriteLine("Array After Rotation {0}", string.Join(",", array));
		}

		/// <summary>
		/// Description: Given an array, shift the element of the array by k
		/// Method: uses seconary array to copy elements. 
		/// 	new index is determined by adding k offset to each index
		/// 	modulus % is used to cacluate wrap around index.
		/// </summary>
		/// <param name="a">The alpha component.</param>
		/// <param name="k">K.</param>
		private static void RotateArray(ref int[] a, int k) {

			var size = a.Length;
			var newIndex = 0;

			// create secondary array to store new order
			int[] result = new int[size];

			for (int i = 0; i < size; i++) {
				newIndex = (i + k) % size;      // add offset to current index and mod by array length to find new index
				result[newIndex] = a[i];        // move value to new position
			}

			a = result;
		}

	}
}
