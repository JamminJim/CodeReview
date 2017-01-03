using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL : https://www.youtube.com/watch?v=gfkuD_eWM5Y
	/// </summary>
	public static class TaskParallel
	{
		public static void Run() {
			Console.WriteLine("TaskParallel running...");
			Example9();
		}

		// Creating a task, used lambda expression
		private static void Example1() {

			var t1 = new Task(() => {
				Console.WriteLine("Task 1 is begininng");
				Thread.Sleep(1000);
				Console.WriteLine("Task 1 has completed");
			});
			t1.Start();
		}

		// use helper method 
		private static void Example2() {
			var t1 = new Task(() => DoSomeVeryImportantWork(1, 1500));
			t1.Start();
		}


		// execute in parallel
		private static void Example3() {
			var t1 = new Task(() => DoSomeVeryImportantWork(1, 1500));
			t1.Start();

			var t2 = new Task(() => DoSomeVeryImportantWork(2, 3000));
			t2.Start();

			var t3 = new Task(() => DoSomeVeryImportantWork(3, 1000));
			t3.Start();
		}

		// 'Task Factory' - alternate way for creating tasks using task factory
		private static void Example4() {
#if DEBUG
#pragma warning disable 0219
#endif
			// creates and executes at same time
			var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500));
			var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
			var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));
#if DEBUG
#pragma warning restore 0219
#endif

		}

		// 'Continuing' - chain them together
		private static void Example5() {

#if DEBUG
#pragma warning disable 0219
#endif
			var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500)).ContinueWith((prevTask) => DoSomeOtherVeryImportantWork(1, 1000));
			var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
			var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));
#if DEBUG
#pragma warning restore 0219
#endif
		}


		// 'Continuing' - chain them together
		private static void Example6() {
#if DEBUG
#pragma warning disable 0219
#endif
			var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500)).ContinueWith((prevTask) => DoSomeOtherVeryImportantWork(1, 1000));
			var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000)).ContinueWith((prevTask) => DoSomeOtherVeryImportantWork(2, 2000));
			var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000)).ContinueWith((prevTask) => DoSomeOtherVeryImportantWork(3, 500));
#if DEBUG
#pragma warning disable 0219
#endif
		}

		// Task Wait For All - wait for all tasks until they complete
		private static void Example7() {

			var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1500));
			var t2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
			var t3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

			var taskList = new List<Task> { t1, t2, t3 };
			Task.WaitAll(taskList.ToArray());

			// waits until all above tasks are completed
			for (var i = 0; i < 10; i++) {
				Console.WriteLine("Doing some other work");
				Thread.Sleep(250);
				Console.WriteLine("i = {0}", i);
			}
		}

		// Parallel ForEach - to loop Async
		private static void Example8() {

			var intList = new List<int> { 1, 2, 5, 6, 8, 76, 5, 3, 54, 6, 78, 89, 9, 7, 6, 5, 4, 4 };

			Parallel.ForEach(intList, (i) => Console.WriteLine(i));

			// code after this line will not be executed until all above code has completed

			Console.WriteLine("This will not be printed until the above code has completed");


			// blocking operation - loops 100 time before moving on
			Parallel.For(0, 100, (i) => Console.WriteLine(i));

			Console.WriteLine("This too will not be printed until the above code has completed");
		}


		// Cancelation Token - Stop executing tasks
		private static void Example9() {

			var source = new CancellationTokenSource();
			try {
				var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWorkWithToken(1, 1200, source.Token)).ContinueWith((prevTask) => DoSomeOtherVeryImportantWorkWithToken(1, 3000, source.Token));

				source.Cancel();  // this causes us to cancel
			} catch (Exception ex) {
				Console.WriteLine(ex.GetType());
			}
		}



		/// <summary>
		/// Helper methods
		/// </summary>
		private static void DoSomeVeryImportantWork(int id, int sleepTime) {
			Console.WriteLine("Task {0} is begininng", id);
			Thread.Sleep(sleepTime);
			Console.WriteLine("Task {0} has completed", id);
		}

		// used in example 5
		private static void DoSomeOtherVeryImportantWork(int id, int sleepTime) {
			Console.WriteLine("Task {0} is begininng more work", id);
			Thread.Sleep(sleepTime);
			Console.WriteLine("Task {0} has completed more work", id);
		}

		// used in example 9
		private static void DoSomeVeryImportantWorkWithToken(int id, int sleepTime, CancellationToken token) {

			if (token.IsCancellationRequested) {
				Console.WriteLine("Cancellation requested.");
				token.ThrowIfCancellationRequested();
			}
			Console.WriteLine("Task {0} is begininng", id);
			Thread.Sleep(sleepTime);
			Console.WriteLine("Task {0} has completed", id);
		}

		private static void DoSomeOtherVeryImportantWorkWithToken(int id, int sleepTime, CancellationToken token) {
			if (token.IsCancellationRequested) {
				Console.WriteLine("Cancellation requested.");
				token.ThrowIfCancellationRequested();
			}
			Console.WriteLine("Task {0} is begininng more work", id);
			Thread.Sleep(sleepTime);
			Console.WriteLine("Task {0} has completed more work", id);
		}


	}
}
