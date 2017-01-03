using System;

namespace CodeReview.Subjects.LinkedLists
{
	public static class ReverseLinkedList
	{

		/// <summary>
		/// Reverses a linked list
		/// </summary>
		/// <remarks>
		/// This uses an iterative approach using a current, previous and next pointer.
		/// 
		/// Steps:
		///     Get handle to next node, assign next to point to next node
		///     Break link to next node, assign current's next to previous
		///     No longer need previous, reassign previous to current
		///     Advance current to next
		///     Repeat until current is null		/// </remarks>
		/// <param name="head">Head.</param>
		public static void Run(ref LinkedListNode head) {
			LinkedListNode current = head;
			LinkedListNode prev = null;
			LinkedListNode next = null;

			while (current != null) {
				next = current.next;            // get ref to next node
				current.next = prev;            // break link list by assign current to prev
				prev = current;                 // advance prev to current for next loop
				current = next;                 // use ref to next node and set it as current
			}
			head = prev;
		}


		/// <summary>
		/// Runs the recursively.
		/// </summary>
		/// <remarks>
		/// Steps:
		///     If we reach null, pass back node (recursive termination condition)
		///     Get next node, by recusively calling function and passing node's next
		///     Switch pointer, point heads.next's next pointer back at head
		///     Break head's next link, set next to null
		///     return the node
		/// 
		///  /* PROCESS OF RECURSION
		///* (1) -> (2) -> (3) -> (4) -> null
		///* Call pass 1
		///*  Call pass 2
		///*   Call pass 3
		///*    Call pass 4
		///*      4->Next == null, pop off and pass head
		///* 	A:  Head = 3, Node = 4      (1) -> (2) -> (3) -> (4) -> null;
		///*        head.next.next = head(1) -> (2) -> (3) -> (4) -> (3)
		///*        head.next = null;       (1) -> (2) -> (3) -> null   (4) -> (3)
		///*        
		///*    B: Head = 2, Node = 4
		///*       head.next.next = head(1) -> (2) -> (3) -> (2)
		///*       head.next = null         (1) -> (2) -> null (4) -> (3) -> (2)
		///*       
		///*    C: Head = 1, Node = 4
		///*       head.next.next = head(1) -> (2) -> (1)
		///*       head.next = null         (1) -> null      (4) -> (3) -> (2) -> (1)
		///*       
		///*     return, Node = 4           (4) -> (3) -> (2) -> (1)
		///*/
		/// 
		/// </remarks>
		/// <returns>The recursively.</returns>
		/// <param name="head">Head.</param>
		public static LinkedListNode RunRecursively(LinkedListNode head) {

			LinkedListNode node;

			if (head.next == null) {
				return head;                    // terminate recursion
			}

			node = RunRecursively(head.next);   // dive down into the linked list

			head.next.next = head;              // point to head's next node pointer back at head
			head.next = null;                   // break linked list from head to next node
			return node;                        // return node
		}

	}  // end of class
}  // end of namespace
