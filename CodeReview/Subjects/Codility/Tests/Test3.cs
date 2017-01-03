using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeReview.Subjects.Codility.TimeComplexity
{
	public static class Test3
	{
		/// <summary>
		/// Codility Test
		/// Title: 
		/// Link: 
		/// Desc:
		/// </summary>

		public static void Run() {
			Console.WriteLine("--- Test 3 Running ---");

			var inputRows = 1;
			var inputSeats = "";
			var output = solution(inputRows, inputSeats);
			Console.WriteLine("Output is {0}", output);
		}

		/// <summary>
		/// Solution the specified N and S.
		/// </summary>
		/// <param name="N">N number of rows of seats on the plane</param>
		/// <param name="S">S spaced-dimlimited string of reserved seats i.e., 34J </param>
		private static int solution(int N, string S) {
			var result = 0;

			// Rows of seat contain A->K (no seat I)
			// Rows are configured with two aisles  x x x | x x x x | x x x

			// Lets treat aisles the same as reserved seats. Thus rows are 12 wide
			var rowWidth = 12;

			// create a multi-dimensional array to store reservation data
			int[,] planeSeats = new int[N, rowWidth];

			// initalize the plane seats to available, mark aisles as not available
			for (var i = 0; i < N; i++) {
				for (var j = 0; j < rowWidth; j++) {
					if (j == 3 || j == 8) {
						planeSeats[i, j] = 1;   // mark aisles as not available
					} else {
						planeSeats[i, j] = 0;
					}
				}
			}

			// parse the plane reservation list using a regexp
			var numAlpha = new Regex("(?<Numeric>[0-9]*/*[0-9]*)(?<Alpha>[a-zA-Z]*)"); // here we look for any number letter
			Match match;
			int rowNumber;
			string seatLetter;

			// split the space dimilited string into an array for easier parsing for row number and seat letter
			if (S.Length > 0) {
				string[] reservationArray = S.Split(' ');
				foreach (string res in reservationArray) {
					match = numAlpha.Match(res);
					rowNumber = int.Parse(match.Groups["Numeric"].Value) - 1;       // zero base array, seats are 1 based
					seatLetter = match.Groups["Alpha"].Value.ToUpper();

					// mark the appropriate seat as 
					planeSeats[rowNumber, GetSeatIndex(seatLetter)] = 1;
				}
			}

			// loop through the array one row at a time, everytime we find 3 avaialble seats, increment result
			var consecutiveSeats = 0;
			for (var i = 0; i < N; i++) {
				for (var j = 0; j < rowWidth; j++) {

					if (planeSeats[i, j] == 1) {
						consecutiveSeats = 0;
					} else {
						consecutiveSeats++;
						if (consecutiveSeats == 3) {
							consecutiveSeats = 0;
							result++;                   // if we have found 3 or more consecutive seats, update available configs
						}
					}
				}
			}

			return result;
		}


		/// <summary>
		/// Helper method to convert seat letter into a index value.
		/// Note, seat values are A to K, ignore I
		/// Note, we treat aisles as index 3 and 8 respectively.
		/// </summary>
		/// <returns>The seat index.</returns>
		/// <param name="seatLetter">Seat letter.</param>
		private static int GetSeatIndex(string seatLetter) {
			var col = 0;

			switch (seatLetter) {
				case "A": col = 0; break;
				case "B": col = 1; break;
				case "C": col = 2; break;
				// aisle
				case "D": col = 4; break;
				case "E": col = 5; break;
				case "F": col = 6; break;
				case "G": col = 7; break;
				//aisle
				case "H": col = 9; break;
				case "J": col = 10; break;
				case "K": col = 11; break;
				default: break;
			}
			return col;
		}



	}
}
