using System;
using System.Collections.Generic;

namespace CodeReview
{
	public static class OddOccurrencesInArray
	{
		/// <summary>
		/// Codility Lesson
		/// Title: OddOccurrencesInArray
		/// Link: https://codility.com/programmers/lessons/2-arrays/odd_occurrences_in_array/
		/// Desc:
		/// 	A non-empty zero-indexed array A consisting of N integers is given. The array contains an odd number 
		/// of elements, and each element of the array can be paired with another element that has the same value, 
		/// except for one element that is left unpaired.
		/// 
		/// For example, in array A such that:
		/// 
		/// A[0] = 9  A[1] = 3  A[2] = 9
		/// A[3] = 3  A[4] = 9  A[5] = 7
		/// A[6] = 9
		/// 
		/// the elements at indexes 0 and 2 have value 9,
		/// the elements at indexes 1 and 3 have value 3,
		/// the elements at indexes 4 and 6 have value 9,
		/// the element at index 5 has value 7 and is unpaired.
		/// 
		/// Write a function:
		///					 class Solution { public int solution(int[] A); }
		///	that, given an array A consisting of N integers fulfilling the above conditions, returns the value of
		/// the unpaired element.
		/// 
		/// For example, given array A such that:
		/// 
		/// A[0] = 9  A[1] = 3  A[2] = 9
		/// A[3] = 3  A[4] = 9  A[5] = 7
		/// A[6] = 9
		/// the function should return 7, as explained in the example above.
		/// 
		/// Assume that:
		/// 			N is an odd integer within the range [1..1,000,000];
		/// each element of array A is an integer within the range[1..1, 000, 000, 000];
		/// all but one of the values in A occur an even number of times.
		/// 
		/// Complexity:
		/// 
		/// expected worst-case time complexity is O(N);
		/// expected worst-case space complexity is O(1), beyond input storage(not counting the storage required for 
		/// input arguments).
		/// 
		/// Elements of input arrays can be modified.
		/// 
		///</summary>

		public static void Run() {
			Console.WriteLine("--- OddOccurrencesInArray Running ---");

			var array = new[] { 9, 3, 9, 3, 9, 7, 9 };
			var result = 0;

			result = FindOddOccurance1(array);
			Console.WriteLine("Found odd occurrence in array {0} using dictionary {1}", string.Join("", array), result);

			result = FindOddOccurance2(array);
			Console.WriteLine("Found odd occurrence in array {0} using xor {1}", string.Join("", array), result);

		}

		/// <summary>
		/// Description: Finds the odd occurance in array
		/// Method: First approach uses dictionary to store values
		/// 	when value already exists in dictionary, value is removed
		/// 	after all indices are checked, remaining entries in dictionary are odd occurances
		/// </summary>
		/// <returns>The odd occurance.</returns>
		/// <param name="a">array consistaing of N integers</param>
		private static int FindOddOccurance1(int[] a) {

			var result = 0;

			// use dictionary to store values from array
			var dict = new Dictionary<int, int>();

			// loop through array adding values which do not exist in dictionary and removing values that do exist
			for (int i = 0; i < a.Length; i++) {
				if (dict.ContainsKey(a[i]) == false) {
					dict.Add(a[i], 1);
				} else {
					dict.Remove(a[i]);
				}
			}

			// loop through dictionary to find odd occurance
			foreach (KeyValuePair<int, int> odd in dict) {
				result = odd.Key;
			}

			return result;
		}


		/// <summary>
		/// Description: Finds the odd occurance in array
		/// Method: Second approach uses ^ xor to toggle the bits
		/// 	uses the first element in the array as storage
		/// 	loop through array and ^ xor element with storage
		/// 	remaining value is odd occurance
		/// </summary>
		/// <returns>The odd occurance.</returns>
		/// <param name="a">array consistaing of N integers</param>
		private static int FindOddOccurance2(int[] a) {

			for (int i = 1; i < a.Length; i++) {
				a[0] = a[0] ^ a[i];
			}
			return a[0];
		}

	}
}
