using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;


namespace CodeReview.Subjects.TutsPlus
{

	/// <summary>
	/// Youtube URL: https://www.youtube.com/watch?v=mGkO7oM5Vl8
	/// </summary>
	public static class Attributes
	{
		public static void Run() {
			Console.WriteLine("Attributes running...");

			//Example 2 - precursor to next video, using Linq and Reflection with Attributes
			var types = from t in Assembly.GetExecutingAssembly().GetTypes()
						where t.GetCustomAttributes<SampleAttribute>().Count() > 0
						select t;

			// write out the objects assicaited with the attribute ie., Test
			foreach (var t in types) {
				Console.WriteLine(t.Name);

				// write out properties (ie., variables) within any class marked with the attribute
				foreach (var p in t.GetProperties()) {
					Console.WriteLine(p.Name);
				}

			}
		}

		/// <summary>
		/// Example - Attribute example
		/// Desc - The base purpose of an Attribute is to assign meta-data to a class, method, ...
		/// 	   Attributes can be assigned to anything
		/// Note - Extends from class 'Attribute'
		/// </summary>


		[AttributeUsage(AttributeTargets.Class)]      // can restrict attribute to be used on a class, method, ... by using the AttributeUsage
		public class SampleAttribute : Attribute
		{
			public string Name { get; set; }
			public int Version { get; set; }
		}

		[Sample(Name = "John", Version = 1)]  // could write [SampleAttribute] as well
		public class Test
		{
			// [Sample] <-- cannot assign attribute to class property because SampleAttribute has a restricution to class
			public int IntValue { get; set; }

			// [Sample] <-- cannot use unless we specify in attribute usage [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]  
			public void Method() {

			}
		}

		// this class is used in example 2
		public class NoAttribute
		{
			// when the LINQ in example 2 above is procesed, this class is not grouped because it does not have the Attribute tag
		}

	}
}
