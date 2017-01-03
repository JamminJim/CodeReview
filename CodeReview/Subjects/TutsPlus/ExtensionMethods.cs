using System;
namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL: https://www.youtube.com/watch?v=D3OCSkXLFuk
	/// </summary>
	public static class ExtensionMethods
	{
		public static void Run() {
			Console.WriteLine("ExtensionMethods running...");
			Example1();
		}


		// add functionality to a class where you do not have access to the source
		private static void Example1() {
			var ct = new clockTower();  // ignore this, im using the person class used in another example to reduce code
			var p = new Person("John", ct);
			p.SayHello();

			var op = new Person("Sally", ct);
			p.SayHelloToOtherPerson(op);
		}


	}


	// step 1 create a public static class for the extension
	public static class Extension
	{
		// step 2 create a static method for each new extension; first input params must be the class
		// step 3 preference the type with the this keyword	
		public static void SayHello(this Person person) {
			Console.WriteLine("{0} says hello", person._name);
		}


		// example 2 - adding additional parameters to the method to show off what you can do
		public static void SayHelloToOtherPerson(this Person person, Person anotherPerson) {
			Console.WriteLine("{0} says hello to {1}", person._name, anotherPerson._name);
		}
	}

}
