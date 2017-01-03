﻿using System;
namespace CodeReview.Subjects.Other
{

	/// <summary>
	/// Codility Lesson
	/// Title: MaxCounters
	/// Link: https://codility.com/programmers/lessons/4-counting_elements/max_counters/
	/// Desc: You are given N counters, initially set to 0, and you have two possible operations on them:
	/// 	increase(X) − counter X is increased by 1,
	/// 	max counter − all counters are set to the maximum value of any counter.
	/// 	A non-empty zero-indexed array A of M integers is given.This array represents consecutive operations:
	/// 
	/// if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
	/// if A[K] = N + 1 then operation K is max counter.
	/// For example, given integer N = 5 and array A such that:
	/// A[0] = 3
	/// A[1] = 4
	/// A[2] = 4
	/// A[3] = 6
	/// A[4] = 1
	/// A[5] = 4
	/// A[6] = 4
	/// 
	/// the values of the counters after each consecutive operation will be:
	///     (0, 0, 1, 0, 0)
	///     (0, 0, 1, 1, 0)
	///     (0, 0, 1, 2, 0)
	///     (2, 2, 2, 2, 2)
	///     (3, 2, 2, 2, 2)
	///     (3, 2, 2, 3, 2)
	///     (3, 2, 2, 4, 2)
	/// 
	/// The goal is to calculate the value of every counter after all operations.
	/// 
	/// Write a function:
	/// 				class Solution { public int[] solution(int N, int[] A); }
	/// 
	/// that, given an integer N and a non-empty zero-indexed array A consisting of M integers, returns a sequence of integers representing the values of the counters.
	/// 
	/// The sequence should be returned as:
	/// a structure Results(in C), or
	/// a vector of integers(in C++), or
	/// a record Results(in Pascal), or
	/// an array of integers(in any other programming language).
	/// For example, given:
	///     A[0] = 3
	///     A[1] = 4
	///     A[2] = 4
	///     A[3] = 6
	///     A[4] = 1
	///     A[5] = 4
	///     A[6] = 4
	/// the function should return [3, 2, 2, 4, 2], as explained above.
	/// 
	/// Assume that:
	/// N and M are integers within the range [1..100,000];
	/// each element of array A is an integer within the range[1..N + 1].
	/// 
	/// Complexity:
	/// expected worst-case time complexity is O(N+M);
	/// expected worst-case space complexity is O(N), beyond input storage(not counting the storage required for input arguments).
	/// Elements of input arrays can be modified.
	/// 
	/// </summary>

	public static class MaxCounters
	{
		public static void Run() {
			Console.WriteLine("--- MaxCounters Running ---");

			var array = new[] { 3, 4, 4, 6, 1, 4, 4 };
			FindMaxCounters(5, array);
		}

		private static void FindMaxCounters(int n, int[] a) {

			var currentMax = 0;
			var currentCmd = 0;

			int[] counters = new int[n];

			// func to increase value by 1
			// func to set all values to current Max

			for (int i = 0; i < a.Length; i++) {

				// get current command
				currentCmd = a[i];
				Console.WriteLine("Command is {0}", currentCmd);

				// if increment by 1
				if (0 < currentCmd && currentCmd <= n) {
					// increment value by one
					counters[currentCmd - 1] += 1;
					// update current max if necessary
					currentMax = (currentMax < counters[currentCmd - 1]) ? counters[currentCmd - 1] : currentMax;
					Console.WriteLine("Command: {0} and Counter is{1}", currentCmd - 1, string.Join("", counters));

				} else if (currentCmd == n + 1) {
					for (var j = 0; j < counters.Length; j++) {
						counters[j] = currentMax;
					}
					Console.WriteLine("Command: {0} and Counter is{1}", currentCmd - 1, string.Join("", counters));
				}
			}

		}
	}
}
