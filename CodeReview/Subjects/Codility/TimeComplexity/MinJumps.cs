using System;

namespace CodeReview.Subjects.Codility.TimeComplexity
{
	/// <summary>
	/// Codility Lesson
	/// Title: FrogJmp
	/// Link: https://codility.com/programmers/lessons/3-time_complexity/frog_jmp/
	/// Desc:
	/// A small frog wants to get to the other side of the road. The frog is currently located at position X and wants 
	/// to get to a position greater than or equal to Y. The small frog always jumps a fixed distance, D.
	/// 
	/// Count the minimal number of jumps that the small frog must perform to reach its target.
	/// 
	/// Write a function:
	/// 			class Solution { public int solution(int X, int Y, int D); }
	/// that, given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal 
	/// to or greater than Y.
	/// 
	/// For example, given:
	/// X = 10
	/// Y = 85
	/// D = 30
	/// the function should return 3, because the frog will be positioned as follows:
	/// 
	/// after the first jump, at position 10 + 30 = 40
	/// after the second jump, at position 10 + 30 + 30 = 70
	/// after the third jump, at position 10 + 30 + 30 + 30 = 100
	/// 
	/// Assume that:
	/// 			X, Y and D are integers within the range[1..1, 000, 000, 000];
	/// X ≤ Y.
	/// 
	/// Complexity:
	/// expected worst-case time complexity is O(1);
	/// expected worst-case space complexity is O(1).
	/// 
	///</summary>

	public static class MinJumps
	{
		public static void Run() {
			Console.WriteLine("--- MinJumps Running ---");

			var result = TheirSolution(10, 85, 30);
			Console.WriteLine("Given a position of {0} and a target of {1}, with jump size of {2}, results in {3} jumps", 10, 85, 30, result);
		}

		/// <summary>
		/// Description: Given a position find the min jumps to reach position or greater
		/// Method: uses seconary array to copy elements. 
		/// 	subtract current position from destination, then divide by jump size
		/// 	note, due to size, must use double
		/// </summary>
		/// <param name="a">The alpha component.</param>
		/// <param name="k">K.</param>
		private static double TheirSolution(int currentPos, int targetPos, int jumpSize) {
			double result = 0;

			// if end point is less than starting point or jumpsize is invalid, throw error.
			if (targetPos < currentPos || jumpSize == 0) {
				throw new System.ArgumentOutOfRangeException("jumpsize");
			}

			// calculate the distance between starting and ending point
			var distance = targetPos - currentPos;

			// if distance is exactly divisble, then return result, else add 1 additional jump to total and return
			if (distance % jumpSize == 0) {
				result = distance / jumpSize;
			} else {
				result = distance / jumpSize + 1;
			}

			return result;
		}


		private static double MySolution(int currentPos, int targetPos, int jumpSize) {
			double result = 0;

			if (targetPos < currentPos || jumpSize == 0) {
				throw new System.ArgumentOutOfRangeException("jumpsize");
			}

			result = Math.Abs(targetPos - currentPos) / Convert.ToDouble(jumpSize);

			// pass back as integer value
			return (int)Math.Ceiling(result);
		}
	}
}
