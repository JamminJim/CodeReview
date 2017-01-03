using System;
namespace CodeReview.Subjects.LinkedLists
{
	public static class FindLoopInLinkedList
	{
		/// <summary>
		/// Determines if linked list contains a loop
		/// Method: Use two pointers to traverse the list, one slow (increments by 1) and one fast (increments by 2)
		///         If the faster pointer reaches null, the linked list does not contain a loop.
		///         If the slower pointer is ahead of the faster pointer or equal to it, then a loop is present.
		/// Performance:    Leading pointer ends at n nodes, trailing pointer would have reached n/2
		///                 3/2n = O(n)     1 1/2 nodes examined
		/// </summary>
		/// <param name="head"></param>
		/// <returns></returns>
		public static bool Run(LinkedListNode head) {
			if (head == null) {
				throw new System.ArgumentException("FindLoopInLinkedList error, argument head cannot be null");
			}

			LinkedListNode leadingPtr;
			LinkedListNode trailingPtr;

			trailingPtr = head;
			leadingPtr = trailingPtr.next;

			if (leadingPtr == null) {
				return false;
			}

			while (leadingPtr != null && trailingPtr != null) {

				if (trailingPtr == leadingPtr) {        // if either pointer is null, no loop exists
					return true;
				}

				trailingPtr = trailingPtr.next;         // advance both the pointers
				leadingPtr = leadingPtr.next;

				if (leadingPtr != null) {               // advance the leading pointer again (2x faster than trailing pointer)
					leadingPtr = leadingPtr.next;
				} else {
					return false;
				}
			}
			return false;
		}


		/// <summary>
		/// Creates an intentional loop in a list for testing
		/// </summary>
		/// <param name="head">Head.</param>
		public static void CreateLoop(LinkedListNode head) {
			if (head == null) {
				throw new System.ArgumentException("FindLoopInLinkedList error, argument head cannot be null");
			}

			LinkedListNode currentPtr = head;
			while (currentPtr.next != null) {
				currentPtr = currentPtr.next;
			}

			currentPtr.next = head;                      // create an intentional loop

		}

	} // end of class
}  // end of namespace
