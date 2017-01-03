using System;
namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL : https://www.youtube.com/watch?v=dpoVo9sfs2A
	/// </summary>
	public static class OptionalParameters
	{
		public static void Run() {
			Console.WriteLine("OptionalParameters running...");

			Example4();
		}

		// Example 1 - shows normal method call
		private static void Example1() {
			PrintData("John", "Doe", 35);
		}

		// Example 2 - shows when we want to change the signature of a method, we have to overload it
		private static void Example2() {

			// if we only had two parameters, we would need to overload the method as shown below
			PrintData("John", "Doe");

			// if we had only one paremeter, we would need to overload the method again as shown below
			PrintData("John");

			// and so on
		}

		// Example 3 - use optional parameters for lastName and Age
		private static void Example3() {
			PrintDataWithOptionalParams("John");
		}

		// Example 4 - named parameters to skip over unknown parameters
		private static void Example4() {
			PrintDataWithOptionalParams("John", age: 35);
		}

		/// <summary>
		/// Helper methods for Examples
		/// </summary>
		/// <param name="firstName">First name.</param>
		/// <param name="lastName">Last name.</param>
		/// <param name="age">Age.</param>
		private static void PrintData(string firstName, string lastName, int age) {
			Console.WriteLine("{0} {1} is {2} years old", firstName, lastName, age);
		}


		// Example 2 - overload method with less parameters
		private static void PrintData(string firstName, string lastName) {
			PrintData(firstName, lastName, 0);
		}

		// Example 2 cont. - overload method with even less parameters
		private static void PrintData(string firstName) {
			PrintData(firstName, null, 0);
		}

		// Example 3 - optional parameters for lastName and age. Required Parameters must come first followed by optional parameters
		private static void PrintDataWithOptionalParams(string firstName, string lastName = null, int age = 0) {
			Console.WriteLine("{0} {1} is {2} years old", firstName, lastName, age);
		}


	}
}
