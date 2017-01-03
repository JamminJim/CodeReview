using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL : https://www.youtube.com/watch?v=-O4pwV3ElAk
	/// </summary>
	public static class AnonymousTypes
	{
		public static void Run() {
			Console.WriteLine("AnonymousTypes running...");
			Example2();
		}

		// create a linq query
		private static void Example1() {

			var people = new List<AnonPerson> {
				new AnonPerson{FirstName = "John", LastName = "Doe", Age = 20},
				new AnonPerson{FirstName = "Jane", LastName = "Doe", Age = 30},
				new AnonPerson{FirstName = "Bill", LastName = "Johnson", Age = 15},
				new AnonPerson{FirstName = "Sally", LastName = "Johnson", Age = 17},
				new AnonPerson{FirstName = "Rupert", LastName = "LastName", Age = 55},
			};

			var result = from p in people
						 where p.LastName == "Doe"
						 select p;
			foreach (var p in result) {
				Console.WriteLine(p.FirstName + " " + p.LastName);
			}
		}

		// trim down the object p to something smaller using anonymous type using 'new'
		private static void Example2() {

			var people = new List<AnonPerson> {
				new AnonPerson{FirstName = "John", LastName = "Doe", Age = 20},
				new AnonPerson{FirstName = "Jane", LastName = "Doe", Age = 30},
				new AnonPerson{FirstName = "Bill", LastName = "Johnson", Age = 15},
				new AnonPerson{FirstName = "Sally", LastName = "Johnson", Age = 17},
				new AnonPerson{FirstName = "Rupert", LastName = "LastName", Age = 55},
			};

			var result = from p in people
						 where p.LastName == "Doe"
						 select new { FName = p.FirstName, LName = p.LastName };    // only properties can be used

			// p is now an anonymous type. It is read-only and cannot be passed as a type
			foreach (var p in result) {
				Console.WriteLine(p.FName + " " + p.LName);
			}
		}
	}


	/// <summary>
	/// Helper Method
	/// </summary>

	public class AnonPerson
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public int MyProperty1 { get; set; }
		public int MyProperty2 { get; set; }
		public int MyProperty3 { get; set; }
	}
}
