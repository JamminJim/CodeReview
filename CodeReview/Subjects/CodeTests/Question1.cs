using System;
namespace CodeReview.Subjects.CodeTests
{
	public static class Question1
	{
		public static void Run() {
			var input = new[] { 1, 4, -1, 3, 2 };
			var output = solution(input);
		}

		private static int solution(int[] A) {

			if (A == null || A.Length == 0) {
				return 0;
			}
			var count = 1;
			var input = A[0];
			while (input != -1) {
				input = A[input];
				count++;
			}
			Console.WriteLine("Count {0}", count);

			return 0;
		}
	}
}
