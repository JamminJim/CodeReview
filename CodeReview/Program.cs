using System;
using CodeReview.Subjects.LinkedLists;
using CodeReview.Subjects.CodeTests;

namespace CodeReview
{
	/// <summary>
	/// Main entry point into app.</summary>
	/// <remarks>
	/// This class processes user inputs and launches subject submenu.
	/// </remarks>
	class Program
	{
		#region review subject information
		private static bool refreshMenu = false;

		private enum reviewSubjects
		{
			ArrayLists,
			LinkedLists,
			Trees,
			Strings,
			Sorting,
			Questions
		};

		private static string[] reviewSubjectNames = { "ArrayLists", "LinkedLists", "Trees", "Strings", "Sorting", "Questions" };

		private static int[] reviewSubjectIds = {   (int)reviewSubjects.ArrayLists,
													(int)reviewSubjects.LinkedLists,
													(int)reviewSubjects.Trees,
													(int)reviewSubjects.Strings,
													(int)reviewSubjects.Sorting,
													(int)reviewSubjects.Questions};
		#endregion

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args) {
			ConsoleKeyInfo cki;

			PrintMainMenu();

			do {
				cki = Console.ReadKey();
				HandleKeyInput(cki);
				if (refreshMenu == true) PrintMainMenu();
			} while (cki.Key != ConsoleKey.Escape);

			Console.WriteLine("Exiting Main Menu Today");
		}

		/// <summary>
		/// Prints the list of main review subjects
		/// </summary>
		private static void PrintMainMenu() {
			Console.Clear();
			Console.WriteLine("Code Review by Jim");
			Console.WriteLine("-------------------------- \n");
			Console.WriteLine("Subjects:\n");

			for (var i = 0; i < reviewSubjectIds.Length; i++) {
				Console.WriteLine("{0} : {1}", i.ToString(), reviewSubjectNames[i]);
			}
			Console.WriteLine("\n\nPress 'ESC' key to exit.");
		}

		/// <summary>
		/// Handles the key input from the main menu.
		/// </summary>
		/// <param name="cki">Cki.</param>
		private static void HandleKeyInput(ConsoleKeyInfo cki) {
			int menuKey;
			int menuOption = -1;

			// clear console before displaying subject
			Console.Clear();

			// parse the key and look up subject
			if (Int32.TryParse(cki.KeyChar.ToString(), out menuKey) && menuKey < reviewSubjectIds.Length) {
				menuOption = reviewSubjectIds[menuKey];
			}

			ParseMenuOptions(menuOption, menuKey, cki);
		}

		/// <summary>
		/// Parses the menu options.
		/// </summary>
		/// <param name="menuOption">Menu option.</param>
		/// <param name="menuKey">Menu key.</param>
		/// <param name="cki">Cki.</param>
		private static void ParseMenuOptions(int menuOption, int menuKey, ConsoleKeyInfo cki) {

			Console.WriteLine("Menu Option Pressed: " + reviewSubjectNames[menuKey]);
			switch (menuOption) {
				case (int)reviewSubjects.ArrayLists:
					break;
				case (int)reviewSubjects.LinkedLists:
					refreshMenu = true;
					SubjectMenu_LinkedLists.ShowMenu();
					break;
				case (int)reviewSubjects.Trees:
					break;
				case (int)reviewSubjects.Strings:
					break;
				case (int)reviewSubjects.Sorting:
					break;
				case (int)reviewSubjects.Questions:
					SubjectMenu_CodeTests.ShowMenu();
					break;
				default:
					PrintMainMenu();
					//Console.WriteLine("Warning...Menu Option " + cki.KeyChar.ToString() + " not found.");
					break;
			}
		}

	}  // end of class
}  // end of program
