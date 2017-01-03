using System;
using System.Collections.Generic;

namespace CodeReview.Subjects.CodeTests
{
	public static class Question2
	{
		public static void Run() {
			var input = "00:01:07,400-234-090\n00:05:01,701-080-080\n00:05:00,400-234-090";
			var output = solution(input);
			Console.WriteLine("Output {0}", output);
		}

		private static int solution(string S) {

			var phoneNumbers = new Dictionary<string, int>();
			string[] callLogs = S.Split('\n');

			// parse the phone number and duration
			string key;
			int value;
			int currentCharge;
			foreach (var callLog in callLogs) {
				string[] log = callLog.Split(',');
				key = log[1];
				value = DetermineCharge(log[0]);

				// update dictionary if phone number exists
				if (phoneNumbers.ContainsKey(key) == true) {
					phoneNumbers.TryGetValue(key, out currentCharge);
					phoneNumbers[key] = currentCharge + value;
				} else {
					phoneNumbers.Add(key, value);
				}
			}


			var largestValue = 0;
			var largestPhone = "";
			var totalCharges = 0;

			// determine phone number with largest duration
			foreach (KeyValuePair<string, int> pair in phoneNumbers) {
				key = pair.Key;
				value = pair.Value;

				if (value > largestValue) {
					largestValue = value;
					largestPhone = key;
				}
				totalCharges += value;
			}

			// remove the largest charge 
			var charge = 0;
			if (phoneNumbers.ContainsKey(largestPhone) == true) {
				phoneNumbers.TryGetValue(largestPhone, out charge);
				totalCharges -= charge;
			}


			return totalCharges;
		}



		/// <summary>
		/// Processes number of seconds from string in 00:00:00 format
		/// </summary>
		/// <returns>The duration in seconds.</returns>
		/// <param name="duration">Duration.</param>
		private static int DetermineCharge(string duration) {
			string[] time = duration.Split(':');
			var seconds = Int32.Parse(time[2]) + Int32.Parse(time[1]) * 60 + Int32.Parse(time[0]) * 3600;
			var charge = 0;

			if (seconds < 5 * 60) {
				charge = seconds * 3;
			} else {
				var minutes = (int)Math.Floor((double)seconds / 60);

				if ((seconds % minutes) > 0) {
					minutes += 1;
				}
				charge = (minutes) * 150;
			}
			return charge;
		}




	}
}
