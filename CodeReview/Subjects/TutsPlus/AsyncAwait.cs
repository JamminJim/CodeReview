using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL Link : https://www.youtube.com/watch?v=DqjIQiZ_ql4
	/// </summary>
	public static class AsyncAwait
	{
		public static void Run() {
			Console.WriteLine("AsyncAwait running...");
			Example4();
		}

		// Running a simple thread to show a name in a textfield
		private static void Example1() {
			ButtonClick();
		}

		// Using Tasks
		private static void Example2() {
			ButtonClick2();
		}

		// Task Scheduler
		private static void Example3() {
			ButtonClick3();
		}

		// Async and Await does not need to worry about task schedulers
		private static void Example4() {
			ButtonClick4();
		}

		/// <summary>
		/// Helper methods
		/// </summary>

		// used in example 1 - result is a laggy ui
		private static void ButtonClick() {
			Console.WriteLine("Button Pressed");
			var result = BigLongImportantMethod("John");

			var tf = new TextField { Text = result };
			tf.Print();
		}

		// used in example 2 -
		private static void ButtonClick2() {
			var tf = new TextField { Text = "" };
			// Cross thread operation - this fails because it is not the main ui thread
			Task.Factory.StartNew(() => BigLongImportantMethod("Sally")).ContinueWith(t => tf.Text = t.Result);
			tf.Print();
		}

		// Task Scheduler - what contents do you want the task to run
		private static void ButtonClick3() {
			var tf = new TextField();
			// Cross thread operation - this fails because it is not the main ui thread
			Task.Factory.StartNew(() => BigLongImportantMethod("Sally")).ContinueWith(t => tf.Text = t.Result, TaskScheduler.Current);
			tf.Print();
		}

		// Sync and Await
		private static void ButtonClick4() {
			CallBigImportantMethod();
		}


		// used by Example 4 - need async and sync
		private static async void CallBigImportantMethod() {
			var result = await BigLongImportantMethodAsync("Andrew");
			var tf = new TextField { Text = result };
			tf.Print();
		}

		// used in example 1 and 2 and 3
		private static string BigLongImportantMethod(string name) {
			Thread.Sleep(2000);
			return "Hello, " + name;
		}

		// used in example 4
		private static Task<string> BigLongImportantMethodAsync(string name) {
			return Task.Factory.StartNew(() => BigLongImportantMethod(name));
		}

	}

	public class TextField
	{
		public string Text { get; set; }
		public void Print() {
			Console.WriteLine("Textfield: " + Text);
		}
	}

}
