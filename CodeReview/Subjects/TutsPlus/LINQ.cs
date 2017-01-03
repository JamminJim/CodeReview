using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL : https://www.youtube.com/watch?v=Z6YWWRUcJis
	/// </summary>
	public static class LINQ
	{
		public static void Run() {
			Console.WriteLine("LINQ running...");
			Example6();
		}

		// create linq query to print out the characters in the string
		private static void Example1() {
			var sample = "I enjoy writting uber-software in C#";

			var result = from c in sample
						 select c;

			foreach (var item in result) {
				Console.WriteLine(item);
			}
		}

		// 'Where' clause - add filter to print out only the vowels using the 'where' clause
		private static void Example2() {

			var sample = "I enjoy writting uber-software in C#";

			var result = from c in sample.ToLower()
						 where c == 'a' | c == 'e' || c == 'i' || c == 'o' || c == 'u'
						 select c;

			foreach (var item in result) {
				Console.WriteLine(item);
			}
		}

		// 'Order By' clause - order the results using the 'order by' clause
		private static void Example3() {

			var sample = "I enjoy writting uber-software in C#";

			var result = from c in sample.ToLower()
						 where c == 'a' | c == 'e' || c == 'i' || c == 'o' || c == 'u'
						 orderby c ascending        // optional keyword(s) ascending or decending order
						 select c;

			foreach (var item in result) {
				Console.WriteLine(item);
			}
		}

		// 'Group By' clause - count the number of each letter using the 'group by' clause
		private static void Example4() {

			var sample = "I enjoy writting uber-software in C#";

			var result = from c in sample.ToLower()
						 where c == 'a' | c == 'e' || c == 'i' || c == 'o' || c == 'u'
						 orderby c
						 group c by c;
			//select c;		// 'group by' removes the need for the 'select'

			// result becomes a group enumerable and item becomes a grouping
			foreach (var item in result) {
				Console.WriteLine("{0} - {1}", item.Key, item.Count());    // 'key' is what we are grouping by  'a' 'e' 'i' 'o' 'u'
			}
		}

		// Filter on properties
		private static void Example5() {

			var people = new List<LinqPerson>
			{
				// note use { } instead of ( ) because we are intializing and not passing to a constructor
				new LinqPerson{FirstName = "John", LastName = "Doe", Age = 25},
				new LinqPerson{FirstName = "Jane", LastName = "Doe", Age = 26},
				new LinqPerson{FirstName = "John", LastName = "Williams", Age = 40},
				new LinqPerson{FirstName = "Samantha", LastName = "Williams", Age = 35},
				new LinqPerson{FirstName = "Bob", LastName = "Walters", Age = 12},
			};

			var result = from p in people
						 where p.Age < 30 && p.LastName == "Doe"    // filter on properties
						 select p;

			// result becomes a group enumerable and item becomes a grouping
			foreach (var item in result) {
				Console.WriteLine("{0}, {1}", item.LastName, item.FirstName);
			}
		}

		// 'Group By' example using class properties
		private static void Example6() {

			var people = new List<LinqPerson>
			{
				// note use { } instead of ( ) because we are intializing and not passing to a constructor
				new LinqPerson{FirstName = "John", LastName = "Doe", Age = 25},
				new LinqPerson{FirstName = "Jane", LastName = "Doe", Age = 26},
				new LinqPerson{FirstName = "John", LastName = "Williams", Age = 40},
				new LinqPerson{FirstName = "Samantha", LastName = "Williams", Age = 35},
				new LinqPerson{FirstName = "Bob", LastName = "Walters", Age = 12},
			};

			var result = from p in people
						 orderby p.LastName descending
						 group p by p.LastName;
			//select p;

			// result becomes a group enumerable and item becomes a grouping
			foreach (var item in result) {
				Console.WriteLine(item.Key + " - " + item.Count());
				foreach (var p in item) {
					Console.WriteLine("\t{0}, {1}", p.LastName, p.FirstName);
				}

			}
		}

	}

	/// <summary>
	/// Helper class for example 5 and example 6
	/// </summary>
	public class LinqPerson
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
	}


}
