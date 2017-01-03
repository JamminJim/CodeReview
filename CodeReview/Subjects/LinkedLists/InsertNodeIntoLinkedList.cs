using System;
namespace CodeReview.Subjects.LinkedLists
{
	public static class InsertNodeIntoLinkedList
	{
		public static void Run(LinkedListNode head, int key, bool isDoublyLinked = false) {

			LinkedListNode node;
			LinkedListNode prev;


			node = new LinkedListNode();
			node.key = key;

			// Check #1 - Insert as new head if no head exists
			if (head == null) {
				node.next = null;
				node.prev = null;
				head = node;
				return;
			}

			// Check #2 - Insert as new head
			if (head.key > key) {

				// Option 1 - use "ref" keyword and change what the head points to
				node.prev = null;
				node.next = head;
				if (isDoublyLinked) {
					head.prev = node;
				}
				head = node;

				// Options 2 - insert a new node after head and swap head and new node's key, retaining heads reference
				/*
				node.next = head.next;
				head.next = node;
				node.key = head.key;
				head.key = key;
				if (isDoublyLinked) {
					if (node.next != null) {
						node.next.prev = node;
					}
					node.prev = head;
				}
				*/
			} else {
				// find location by using the trailing pointer
				prev = head;
				while (prev.next != null && key > prev.next.key) {
					prev = prev.next;
				}

				node.next = prev.next;
				prev.next = node;

				if (isDoublyLinked) {
					if (node.next != null) {
						node.next.prev = node;
					}
					node.prev = head;
				}
			}

		}
	}
}
