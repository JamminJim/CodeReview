using System;
using System.Collections.Generic;

namespace CodeReview.Subjects.Tests
{
	public static class Test2
	{
		/// <summary>
		/// Codility Test
		/// Title: 
		/// Link: 
		/// Desc:
		/// </summary>

		public static void Run() {
			Console.WriteLine("--- Test 2 Running ---");

			var array = new[] { 9, 1, 4, 9, 0, 4, 8, 9, 0, 1 };
			var result = solution(array);
			Console.WriteLine("Result of Test 2 from array {0} is {1}", string.Join("", array), result);
		}

		public static int[] solution(int[] A) {
			int[] result = new int[1];

			var dict = new Dictionary<int, List<int>>();
			var capital = -1;
			List<int> list;
			var numCities = 0;


			for (int i = 0; i < A.Length; i++) {
				if (A[i] > numCities) {
					numCities = A[i];
				}
				if (A[i] == i) {
					capital = i;
				} else {
					// if dictionary does not contain city, add city
					if (dict.ContainsKey(A[i]) == false) {
						list = new List<int>();
						list.Add(i);
						dict.Add(A[i], list);
					} else {
						// else add new connection to city
						dict.TryGetValue(A[i], out list);
						list.Add(i);
						dict[A[i]] = list;
					}
				}
			}

			// create a return list with at most numCities 
			result = new int[numCities];

			// determine the number of cities connected to our capital
			List<int> connections;
			if (dict.ContainsKey(capital) == true) {
				dict.TryGetValue(capital, out connections);
				// save the number of connections to our results
				result[0] = connections.Count;
				Console.WriteLine("Num Connections " + GetCount(connections[0], dict));
			}


			return result;
		}


		private static int GetCount(int key, Dictionary<int, List<int>> dict) {
			var count = 0;

			List<int> connections;
			if (dict.ContainsKey(key) == true) {
				dict.TryGetValue(key, out connections);
				count = connections.Count;

				foreach (int i in connections) {
					if (dict.ContainsKey(i) == true) {
						count += GetCount(i, dict);
					}
				}
			}
			return count;
		}

	}
}
