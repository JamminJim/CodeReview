using System;
namespace CodeReview.Subjects.LinkedLists
{
	/// <summary> CreateLinkedList class constructs a linked list </summary>
	/// <remarks> This class is capable of creating a singly or doubly linked list</remarks>
	public static class CreateLinkedList
	{

		/// <summary>
		/// Creates a singly linked list
		/// </summary>
		/// <param name="values">Values.</param>
		/// <param name="head">Head.</param>
		public static void CreateSinglyLinkedList(int[] values, out LinkedListNode head) {
			LinkedListNode node = null;

			if (values == null || values.Length == 0) {
				throw new System.ArgumentException("CreateList error, values must contain at least one value.");
			}

			head = new LinkedListNode();
			head.key = values[0];
			node = head;

			for (var i = 1; i < values.Length; i++) {
				node.next = new LinkedListNode();       // assign the next pointer of current node
				node = node.next;                       // advance pointer to newly created node
				node.key = values[i];                   // assign value to new node from passed in arguments
			}
		}

		/// <summary>
		/// Creates a doubly linked list.
		/// </summary>
		/// <param name="values">Values.</param>
		/// <param name="head">Head.</param>
		public static void CreateDoublyLinkedList(int[] values, out LinkedListNode head) {
			LinkedListNode node = null;

			if (values == null | values.Length == 0) {
				throw new System.ArgumentException("CreateList error, values must contain at least one value");
			}

			head = new LinkedListNode();
			head.key = values[0];
			node = head;

			for (var i = 1; i < values.Length; i++) {
				node.next = new LinkedListNode();       // assign the next pointer of current node
				node.next.prev = node;                  // assign the prev pointer to point to last created node
				node = node.next;                       // advance pointer to newly created node
				node.key = values[i];                   // assign value to new node from passed in arguments
			}
		}

	}  // end of class
}  // end of namespace
