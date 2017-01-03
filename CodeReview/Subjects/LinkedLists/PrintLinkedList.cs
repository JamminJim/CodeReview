using System;
using System.Collections.Generic;


namespace CodeReview.Subjects.LinkedLists
{
	/// <summary>
	/// Prints a Singly and Doubly linked list
	/// </summary>
	public static class PrintLinkedList
	{
		/// <summary>
		/// Prints the contents of a linked list
		/// </summary>
		/// <param name="head">Head.</param>
		public static void RunIteratively(LinkedListNode head) {
			LinkedListNode node;

			if (head == null) {
				throw new System.ArgumentNullException(nameof(head), "PrintLinkedList error, head arguement null.");
			}

			node = head;

			// check for loop
			if (FindLoopInLinkedList.Run(head) == true) {
				Console.WriteLine("PrintLinkedList Warning, list contains loops, unable to print.");
				return;
			}

			while (node != null) {
				node.PrintNode(false, false);

				if (node.next != null && node.next.prev != null) {
					if (node.next.prev != node) {
						Console.Write("* ERROR *");
					} else {
						Console.Write("<->");
					}
				} else {
					Console.Write("->");
				}

				node = node.next;
				if (node == null) {
					Console.Write("(null)\n");
				}
			}
		}

		/// <summary>
		/// Prints the contents of a list in reverse
		/// </summary>
		/// <remarks>
		/// This approach uses a stack to push and pop off the values.
		/// </remarks>
		/// <param name="node"></param>
		public static void RunIterativelyReverse(LinkedListNode node) {

			Stack<LinkedListNode> stack = new Stack<LinkedListNode>();

			// Step #1 - push all the elements into a stack
			for (var n = node; n != null; n = n.next) {
				stack.Push(n);                              // PUSH
			}

			Console.Write("(null)<-");

			// Step #2 - pop each element off and print
			while (stack.Count != 0) {
				node = stack.Pop();
				node.PrintNode(false, false);        // POP
				if (node.prev != null) {
					Console.Write("<->");                   // (doubly linked list check)
				} else {
					if (stack.Count > 0) {
						Console.Write("<-");                // (singly linked list check)
					}
				}
			}
		}

		/// <summary>
		/// Prints the contents of a linked list
		/// </summary>
		/// <remarks>
		/// Recursively traverses the linked list and prints out node values
		/// </remarks>
		/// <param name="node"></param>
		public static void RunRecursively(LinkedListNode node) {

			if (node == null) {                         // end condition
				Console.Write("(null)\n");
				return;
			} else {
				node.PrintNode(false, false);

				if (node.prev != null && node.next != null) {
					Console.Write("<->");               // (doubly linked list check)
				} else {
					Console.Write("->");                // (singly linked list check)
				}
				RunRecursively(node.next);
			}
		}

		/// <summary>
		/// Prints the contents of a linked list in reverse
		/// </summary>
		/// <param name="node"></param>
		public static void RunRecursivelyReverse(LinkedListNode node) {
			if (node == null) {                         // end condition
				Console.Write("(null)");
				return;
			} else {
				RunRecursivelyReverse(node.next);       // <- Note the order, very important!!!
				if (node.next != null) {                // we check for "next" instead of "prev"
					Console.Write("<->");
				} else {
					Console.Write("<-");                // we write arrow before writting number
				}
				node.PrintNode(false, false);
			}
		}

	}  // end of class
}  // end of namespace
