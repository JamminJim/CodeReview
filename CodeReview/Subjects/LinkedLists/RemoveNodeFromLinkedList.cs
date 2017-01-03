using System;

namespace CodeReview.Subjects.LinkedLists
{
	/// <summary>
	/// Removes a node from a ordered linked list
	/// </summary>
	public static class RemoveNodeFromLinkedList
	{
		/// <summary>
		/// Removes a node from a linked list
		/// </summary>
		/// <param name="head">Head.</param>
		/// <param name="key">Key.</param>
		/// <param name="isDoublyLinked">If set to <c>true</c> is doubly linked.</param>
		public static void Run(ref LinkedListNode head, int key, bool isDoublyLinked) {

			LinkedListNode node;
			LinkedListNode prev;

			if (head == null) {
				throw new System.ArgumentNullException(nameof(head), "RemoveNodeFromLinkedList Error, head cannot be a null value");
			}

			// Check #1 - Check if we are removing head
			if (head.key == key) {
				node = head;
				head = head.next;

				if (isDoublyLinked == true && head != null) {
					head.prev = null;
				}
				node = null;
			} else {
				node = null;
				prev = head;

				// look for value within the linked list
				while (prev.next != null && prev.next.key != key) {
					prev = prev.next;
				}

				// if found
				if (prev.next != null && prev.next.key == key) {

					// save target node to remove
					node = prev.next;

					// set prev node to the target's next node
					prev.next = node.next;

					// if doubly linked list, set the target nodes next node prev pointer to point to prev
					if (isDoublyLinked == true && node.next != null) {
						node.next.prev = prev;
					}

					node = null;
				} else {
					Console.WriteLine("RemoveNodeFromLinkedList Warning - value {0} was not found in linked list", key);
				}
			}
		}


		/// <summary>
		/// Removes a node from a linked list using recursion
		/// </summary>
		/// <remarks>
		/// Note this approach only works when removing nodes other than head
		/// </remarks>
		/// <returns>The removed node.</returns>
		/// <param name="node">Node.</param>
		/// <param name="key">Key.</param>
		public static LinkedListNode RunRecusively(LinkedListNode node, int key) {
			if (node != null) {
				if (node.key == key) {
					node = node.next;       // advance the pointer
				} else {
					node.next = RunRecusively(node.next, key);
				}
			}
			return node;
		}

	}  // end of class
}  // end of namespace
