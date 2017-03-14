using System;
namespace CodeReview.Subjects.RandomIdeas
{

	public class SubjectMenu_RandomIdeas
	{

		#region review subject information
		private enum reviewSubjects
		{
			none,
			ParseEquation,
		};

		private static string[] reviewSubjectNames = { "", "Parse Equation" };

		private static int[] reviewSubjectIds = { 0, (int)reviewSubjects.ParseEquation };
		#endregion

		public static void ShowMenu() {
			ConsoleKeyInfo cki;

			PrintMainMenu();

			do {
				cki = Console.ReadKey();
				HandleKeyInput(cki);
			} while (cki.Key != ConsoleKey.Escape);
		}

		private static void PrintMainMenu() {
			Console.Clear();
			Console.WriteLine("Menu:");
			Console.WriteLine("-------------------------- \n");

			Console.WriteLine("Questions:\n");

			for (var i = 1; i < reviewSubjectIds.Length; i++) {
				Console.WriteLine("{0} : {1}", i.ToString(), reviewSubjectNames[i]);
			}

			Console.WriteLine("\n\nPress 'ESC' key to exit.");
		}

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

			Console.WriteLine("\n\nPress 'SPACE' key to continue.");
			do {
				cki = Console.ReadKey();
			} while (cki.Key != ConsoleKey.Spacebar);
			PrintMainMenu();
		}

		private static void ParseMenuOptions(int menuOption, int menuKey, ConsoleKeyInfo cki) {

			Console.WriteLine("Menu Option Pressed: " + reviewSubjectNames[menuKey] + "\n");
			switch (menuOption) {
				case (int)reviewSubjects.ParseEquation:
					Console.WriteLine("Parse Equation...\n");
					ParseEquation.Run();
					break;
				default:
					Console.WriteLine("Warning...Menu Option " + cki.KeyChar.ToString() + " not found.");
					break;
			}
		}
	}  // end of class
}  // end of namespace
