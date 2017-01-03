using System;
namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// https://www.youtube.com/watch?v=OxuJstbHPyE
	/// </summary>
	public static class ImplicitTyping
	{
		public static void Run() {
			Console.WriteLine("ImplicitTyping running...");

#if DEBUG
#pragma warning disable 0219
#endif
			// example of explicit typing
			string firstName = "John";

			// example of implicit typing
			var lastName = "Doe";

#if DEBUG
#pragma warning restore 0219
#endif
			/// <summary>
			/// Desc: implicit typing allows the compiler to determine the type from the value
			/// PROS:   Quicker to type 'var' rather than the reference type object name 
			/// 		Faster for refactoring and casting	
			/// 
			/// CONS: Value must be specified at declariation. Cannot be assigned to null
			/// 	  Should name variables more descriptive since it does not have an explicit type
			/// </summary>
		}
	}
}
