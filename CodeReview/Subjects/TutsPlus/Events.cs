using System;
namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL: https://www.youtube.com/watch?v=KVp_E-hTG0k
	/// </summary>

	public static class Events
	{
		public static void Run() {
			Console.WriteLine("Events running...");
			Example1();
		}

		/// <summary>
		/// Steps:
		/// 	Example 1: Create a delegate "EventHandler" 
		/// 			   Create a instance of this event handler in the object dispatching the event ie., clock tower
		///                Pass a reference of this instance to the objec that will listen
		/// 			   Use this reference to "wire up" code to respond using anonymous methods, lambda expression,...
		/// </summary>


		private static void Example1() {
			var tower = new clockTower();

#if DEBUG
#pragma warning disable 0219
#endif
			var john = new Person("John", tower);
#if DEBUG
#pragma warning restore 0219
#endif

			tower.ChimeFivePM();
			tower.ChimeSixAM();

			// cannot differentiate between the two chimes, see Example 2
		}

		// using event arguments
		private static void Example2() {
			// note all code changes are in person and clocktower classes
		}

		// using custom event args to pass parameters; see ClockTowerEventArgs
		private static void Example3() {

		}

	}


	/// <summary>
	/// Helper methods
	/// </summary>


	// Example 1 delegate
	public delegate void ChimeEventHandler();

	// Example 2 delegate using parameters
	public delegate void ChimeEventHandler2(object sender, EventArgs args);

	// Example 3 
	public delegate void ChimeEventHandler3(object sender, ClockTowerEventArgs args);


	// Used in Example 3
	public class ClockTowerEventArgs : EventArgs
	{
		public int Time { get; set; }
	}


	public class Person
	{

		public string _name;
		private clockTower _tower;

		// note we have to pass in 
		public Person(string name, clockTower tower) {
			_name = name;
			_tower = tower;     // has ref to tower

			// wireup a anonymous method, method, lambda,...
			_tower.Chime += () => Console.WriteLine("{0} heard the clock chime", _name);

			// example two - have to take in two parameters
			_tower.Chime2 += (object sender, EventArgs args) => Console.WriteLine("{0} heard the clock chime", _name);

			// example three - using custom event args
			_tower.Chime3 += (object sender, ClockTowerEventArgs args) => {
				Console.WriteLine("{0} heard the clock chime", _name);
				switch (args.Time) {
					case 6:
						Console.WriteLine("{0} is waking up.", _name);
						break;
					case 17:
						Console.WriteLine("{0} is going home.", _name);
						break;
				}
			};

		}
	}

	public class clockTower
	{

		public event ChimeEventHandler Chime;       // event other objects can watch for
		public event ChimeEventHandler2 Chime2;       // event other objects can watch for
		public event ChimeEventHandler3 Chime3;      // using custom event handler to pass parameters

		public void ChimeFivePM() {
			Chime();
			Chime2(this, EventArgs.Empty);                               // broadcast chime event
			Chime3(this, new ClockTowerEventArgs { Time = 6 });


		}
		public void ChimeSixAM() {
			Chime();
			Chime2(this, EventArgs.Empty);
			Chime3(this, new ClockTowerEventArgs { Time = 17 });
		}

	}

}
