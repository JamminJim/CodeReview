using System;
using System.Threading;
using System.Collections.Generic;

namespace CodeReview.Subjects.LinkedLists
{
	public class SubjectMenu_LinkedLists
	{
		#region review subject information
		private static bool exitLinkedListMenu = false;
		/*
		private enum reviewSubjects
		{
			ReturnToMainMenu,
			CreateLinkedList,
			CreateDoublyLinkedList,
			PrintLinkedList,
			PrintLinkedListReversed,
			PrintLinkedListRecursively,
			PrintLinkedListRecursivelyReversed,
			CreateLoopInLinkedList,
			FindLoopInLinkedList,
			InsertNodeIntoLinkedList,
			RemoveNodeFromLinkedList,
			DeleteLinkedList
		};

		private static string[] reviewSubjectNames = { "ReturnToMainMenu", "Create Linked List", "Create Doubly Linked List", "Print Linked List", "Print Linked List Reversed",
													   "Print Linked List Recursively", "Print Linked List Recursively Reversed", "Create Loop in Linked List",
													   "Find Loop in Linked List", "Insert Node into Linked List", "Remove Node from Linked List", "Delete Linked List"};

		private static int[] reviewSubjectIds = {   (int)reviewSubjects.ReturnToMainMenu,
													(int)reviewSubjects.CreateLinkedList,
													(int)reviewSubjects.CreateDoublyLinkedList,
													(int)reviewSubjects.PrintLinkedList,
													(int)reviewSubjects.PrintLinkedListReversed,
													(int)reviewSubjects.PrintLinkedListRecursively,
													(int)reviewSubjects.PrintLinkedListRecursivelyReversed,
													(int)reviewSubjects.CreateLoopInLinkedList,
													(int)reviewSubjects.FindLoopInLinkedList,
													(int)reviewSubjects.InsertNodeIntoLinkedList,
													(int)reviewSubjects.RemoveNodeFromLinkedList,
													(int)reviewSubjects.DeleteLinkedList,
												};
		*/


		private enum reviewSubjects
		{
			ReturnToMainMenu,
			CreateLinkedList,
			PrintLinkedList,
			InsertNodeIntoLinkedList,
			RemoveNodeFromLinkedList,
			ReverseLinkedList,
			CreateLoopInLinkedList,
			FindLoopInLinkedList,
			DeleteLinkedList,
		};

		private static string[] reviewSubjectNames = {
			"Return To Main Menu",
			"Create Linked List",
			"Print Linked List",
			"Insert Node into Linked List",
			"Remove Node from Linked List",
			"Reverse Linked List",
			"Create Loop in Linked List",
			"Find Loop in Linked List",
			"Delete Linked List"
		};

		private static int[] reviewSubjectIds = {
			(int)reviewSubjects.ReturnToMainMenu,
			(int)reviewSubjects.CreateLinkedList,
			(int)reviewSubjects.PrintLinkedList,
			(int)reviewSubjects.InsertNodeIntoLinkedList,
			(int)reviewSubjects.RemoveNodeFromLinkedList,
			(int)reviewSubjects.ReverseLinkedList,
			(int)reviewSubjects.CreateLoopInLinkedList,
			(int)reviewSubjects.FindLoopInLinkedList,
			(int)reviewSubjects.DeleteLinkedList
		};


		private static LinkedListNode head;

		#endregion

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void ShowMenu() {
			ConsoleKeyInfo cki;
			PrintMainMenu();

			do {
				cki = Console.ReadKey();
				HandleKeyInput(cki);
			} while (exitLinkedListMenu == false);

			exitLinkedListMenu = false;
		}

		/// <summary>
		/// Prints the list of main review subjects
		/// </summary>
		private static void PrintMainMenu() {
			Console.Clear();
			Console.WriteLine("Subject: LinkedLists");
			Console.WriteLine("-------------------------- \n");

			Console.WriteLine("Lessons:\n");

			for (var i = 0; i < reviewSubjectIds.Length; i++) {
				Console.WriteLine("{0} : {1}", i.ToString(), reviewSubjectNames[i]);
			}
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

			// exit sub menu
			if (exitLinkedListMenu == true) return;

			Console.WriteLine("\n\nPress 'SPACE' key to continue.");
			do {
				cki = Console.ReadKey();
			} while (cki.Key != ConsoleKey.Spacebar);
			PrintMainMenu();
		}

		/// <summary>
		/// Parses the menu options.
		/// </summary>
		/// <param name="menuOption">Menu option.</param>
		/// <param name="menuKey">Menu key.</param>
		/// <param name="cki">Cki.</param>
		private static void ParseMenuOptions(int menuOption, int menuKey, ConsoleKeyInfo cki) {

			switch (menuOption) {
				case (int)reviewSubjects.ReturnToMainMenu:
					exitLinkedListMenu = true;
					break;
				case (int)reviewSubjects.CreateLinkedList:
					Console.WriteLine("Example_CreateLinkedList - created linked list\n");
					Example_CreateLinkedList();
					break;
				case (int)reviewSubjects.PrintLinkedList:
					Console.WriteLine("Example_PrintLinkedList - printing linked list\n");
					Example_PrintLinkedList();
					break;
				case (int)reviewSubjects.CreateLoopInLinkedList:
					Console.WriteLine("Example_FindLoopInLinkedList - finds a loop in a linked list\n");
					Example_CreateLoopInLinkedList();
					break;
				case (int)reviewSubjects.FindLoopInLinkedList:
					Console.WriteLine("Example_FindLoopInLinkedList - finds a loop in a linked list\n");
					Example_FindLoopInLinkedList();
					break;
				case (int)reviewSubjects.InsertNodeIntoLinkedList:
					Console.WriteLine("Example_InsertNodeIntoLinkedList - inserts node into a linked list\n");
					Example_InsertNodeIntoLinkedList();
					break;
				case (int)reviewSubjects.RemoveNodeFromLinkedList:
					Console.WriteLine("Example_RemoveNodeFromLinkedList - removes a node from a linked list\n");
					Example_RemoveNodeFromLinkedList();
					break;
				case (int)reviewSubjects.ReverseLinkedList:
					Console.WriteLine("Example_ReverseLinkedList - reverse a singly linked list\n");
					Example_ReverseLinkedList();
					break;

				case (int)reviewSubjects.DeleteLinkedList:
					Console.WriteLine("Delete Link List - deletes linked list\n");
					DeleteLinkedList();
					break;
				default:
					Console.WriteLine("LinkedList Menu Warning...Menu Option " + cki.KeyChar.ToString() + " not found.");
					break;
			}
		}
		/*
		private static void ParseMenuOptions(int menuOption, int menuKey, ConsoleKeyInfo cki) {

			switch (menuOption) {
				case (int)reviewSubjects.ReturnToMainMenu:
					exitLinkedListMenu = true;
					break;
				case (int)reviewSubjects.CreateLinkedList:
					Console.WriteLine("Example_CreateLinkedList - created linked list\n");
					Example_CreateLinkedList();
					break;
				case (int)reviewSubjects.CreateDoublyLinkedList:
					Console.WriteLine("CreateDoublyLinkedList - created doubly linked list\n");
					Example_CreateDoublyLinkedList();
					break;
				case (int)reviewSubjects.PrintLinkedList:
					Console.WriteLine("Example_PrintLinkedList - printing linked list\n");
					Example_PrintLinkedList();
					break;
				case (int)reviewSubjects.PrintLinkedListReversed:
					Console.WriteLine("Example_PrintLinkedListReversed - printing linked list in reverse\n");
					Example_PrintLinkedListReversed();
					break;
				case (int)reviewSubjects.PrintLinkedListRecursively:
					Console.WriteLine("Example_PrintLinkedListRecursively - printing linked list recursively\n");
					Example_PrintLinkedListRecursively();
					break;
				case (int)reviewSubjects.PrintLinkedListRecursivelyReversed:
					Console.WriteLine("Example_PrintLinkedListRecursivelyReversed - printing linked list reversed using recursion\n");
					Example_PrintLinkedListReversed();
					break;
				case (int)reviewSubjects.CreateLoopInLinkedList:
					Console.WriteLine("Example_FindLoopInLinkedList - finds a loop in a linked list\n");
					Example_CreateLoopInLinkedList();
					break;
				case (int)reviewSubjects.FindLoopInLinkedList:
					Console.WriteLine("Example_FindLoopInLinkedList - finds a loop in a linked list\n");
					Example_FindLoopInLinkedList();
					break;
				case (int)reviewSubjects.InsertNodeIntoLinkedList:
					Console.WriteLine("Example_InsertNodeIntoLinkedList - inserts node into a linked list\n");
					Example_InsertNodeIntoLinkedList();
					break;
				case (int)reviewSubjects.RemoveNodeFromLinkedList:
					Console.WriteLine("Example_RemoveNodeFromLinkedList - removes a node from a linked list\n");
					Example_RemoveNodeFromLinkedList();
					break;
				case (int)reviewSubjects.DeleteLinkedList:
					Console.WriteLine("Delete Link List - deletes linked list\n");
					DeleteLinkedList();
					break;
				default:
					Console.WriteLine("LinkedList Menu Warning...Menu Option " + cki.KeyChar.ToString() + " not found.");
					break;
			}
		}
		*/

		/// <summary>
		/// Example - Creates a Linked List
		/// </summary>
		private static void Example_CreateLinkedList() {
			ConsoleKeyInfo cki;
			bool isDouble = false;

			var numbers = new int[] { 1, 2, 3, 4, 5 };

			Console.Write("\n\nInsert into Singly or Doubly Linked List (S/D)?: ");
			cki = Console.ReadKey();
			if (cki.KeyChar.ToString() == "d" || cki.KeyChar.ToString() == "D") {
				isDouble = true;
			}

			if (isDouble) {
				CreateLinkedList.CreateDoublyLinkedList(numbers, out head);
			} else {
				CreateLinkedList.CreateSinglyLinkedList(numbers, out head);
			}
		}

		/// <summary>
		/// Example - Creates a Linked List
		/// </summary>
		private static void Example_CreateDoublyLinkedList() {
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			CreateLinkedList.CreateDoublyLinkedList(numbers, out head);
		}

		/// <summary>
		/// Example - Prints a Linked List
		/// </summary>
		private static void Example_PrintLinkedList() {
			if (head == null) {
				User_Input_LinkedList_NotFound();
			}
			PrintLinkedList.RunIteratively(head);
		}

		/// <summary>
		/// Example - Prints a Linked List reversed
		/// </summary>
		private static void Example_PrintLinkedListReversed() {
			if (head == null) {
				User_Input_LinkedList_NotFound();
			}
			PrintLinkedList.RunIterativelyReverse(head);
		}

		/// <summary>
		/// Example - Prints a Linked List using recursion
		/// </summary>
		private static void Example_PrintLinkedListRecursively() {
			if (head == null) {
				Example_CreateLinkedList();
			}
			PrintLinkedList.RunRecursively(head);
		}

		/// <summary>
		/// Example - Prints a Linked List reversed using recursion
		/// </summary>
		private static void Example_PrintLinkedListRecursivelyReversed() {
			if (head == null) {
				Example_CreateLinkedList();
			}
			PrintLinkedList.RunRecursivelyReverse(head);
		}

		/// <summary>
		/// Examples - Reverses a Singly Linked List
		/// </summary>
		private static void Example_ReverseLinkedList() {
			if (head == null) {
				Example_CreateLinkedList();
			}

			ConsoleKeyInfo cki;
			bool useRecursion = false;

			Console.Write("\n\n Reverse linked list using Iterative/Recursive? (I/R)");
			cki = Console.ReadKey();
			if (cki.KeyChar.ToString() == "r" || cki.KeyChar.ToString() == "R") {
				useRecursion = true;
			}

			if (useRecursion) {
				ReverseLinkedList.RunRecursively(head);
			} else {
				ReverseLinkedList.Run(ref head);
			}
		}

		/// <summary>
		/// Example - Creates a loop in a linked list
		/// </summary>
		private static void Example_CreateLoopInLinkedList() {
			if (head == null) {
				Example_CreateLinkedList();
			}
			FindLoopInLinkedList.CreateLoop(head);
		}

		/// <summary>
		/// Example - Finds a loop in a linked list
		/// </summary>
		private static void Example_FindLoopInLinkedList() {
			if (head == null) {
				Example_CreateLinkedList();
			}

			if (FindLoopInLinkedList.Run(head) == true) {
				Console.WriteLine("Loop found in Linked List");
			} else {
				Console.WriteLine("No Loop found in Linked List");
			}
		}

		/// <summary>
		/// Example - Inserts value into a singly linked list
		/// </summary>
		private static void Example_InsertNodeIntoLinkedList() {
			ConsoleKeyInfo cki;
			bool isDouble = false;
			int val;

			if (head == null) {
				User_Input_LinkedList_NotFound();
			}

			Console.Write("\n\nInsert into Singly or Doubly Linked List (S/D)?: ");
			cki = Console.ReadKey();
			if (cki.KeyChar.ToString() == "d" || cki.KeyChar.ToString() == "D") {
				isDouble = true;
			}
			Console.Write("\n\nEnter value to insert: ");
			cki = Console.ReadKey();
			Int32.TryParse(cki.KeyChar.ToString(), out val);

			InsertNodeIntoLinkedList.Run(head, val, isDouble);
		}


		/// <summary>
		/// Example - Inserts value into a singly linked list
		/// </summary>
		private static void Example_RemoveNodeFromLinkedList() {
			ConsoleKeyInfo cki;
			bool isDouble = false;
			bool isRecurisve = false;
			int val;

			if (head == null) {
				User_Input_LinkedList_NotFound();
			}

			Console.Write("\n\n Remove Iteratively or Recursively (I/R)?: ");
			cki = Console.ReadKey();
			if (cki.KeyChar.ToString() == "r" || cki.KeyChar.ToString() == "R") {
				isRecurisve = true;
			}

			Console.Write("\n\n Remove from Singly or Doubly Linked List (S/D)?: ");
			cki = Console.ReadKey();
			if (cki.KeyChar.ToString() == "d" || cki.KeyChar.ToString() == "D") {
				isDouble = true;
			}
			Console.Write("\n\nEnter value to remove: ");
			cki = Console.ReadKey();
			Int32.TryParse(cki.KeyChar.ToString(), out val);

			if (isRecurisve == true) {
				RemoveNodeFromLinkedList.RunRecusively(head, val);
			} else {
				RemoveNodeFromLinkedList.Run(ref head, val, isDouble);
			}

		}


		/// <summary>
		/// Helper method to ask user to create singly or doubly linked list
		/// </summary>
		private static void User_Input_LinkedList_NotFound() {
			ConsoleKeyInfo cki;
			Console.Write("\n\nWarning - linked list not found.");
			Console.Write("\n\nCreate Singly or Doubly Linked List (S/D)?: ");
			cki = Console.ReadKey();
			if (cki.KeyChar.ToString() == "d" || cki.KeyChar.ToString() == "D") {
				Example_CreateDoublyLinkedList();
			} else {
				Example_CreateLinkedList();
			}
			Console.WriteLine("");

		}

		/// <summary>
		/// Helper method to delete any linked list
		/// </summary>
		/// <param name="head">Head.</param>
		private static void DeleteLinkedList() {

			Stack<LinkedListNode> stack = new Stack<LinkedListNode>();
			LinkedListNode node;

			if (head != null) {

				// Step #1 - push all the elements into a stack
				for (var n = head; n != null; n = n.next) {
					stack.Push(n);                              // PUSH
				}

				// Step #2 - pop each element off and print
				while (stack.Count != 0) {
					node = stack.Pop();
					node.prev = null;
					node.next = null;
					node = null;
				}
				head = null;
			}
		}


	}  // end of class
}  // end of namespace
