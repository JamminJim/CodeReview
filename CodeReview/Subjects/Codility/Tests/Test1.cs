using System;
namespace CodeReview.Subjects.Tests
{
	public class Test1
	{
		/// <summary>
		/// Codility Test
		/// Title: 
		/// Link: 
		/// Desc:
		/// </summary>

		public static void Run() {
			Console.WriteLine("--- Test 1 Running ---");

			var value = 553;
			var result = solution(value);
			Console.WriteLine("Result of Test 1 from value {0} is {1}", string.Join("", value), result);
		}

		public static int solution(int N) {
			var result = -1;

			if (N < 0 || N > 10000) { return -1; }

			// convert number to string
			var str = Convert.ToString(N);

			// convert to characters
			char[] digits = str.ToCharArray();

			// sort the digits largest to smallest
			Array.Sort(digits, (x, y) => y.CompareTo(x));

			// pass back the largest sibling
			result = Convert.ToInt32(new string(digits));

			return result;
		}
	}
}
