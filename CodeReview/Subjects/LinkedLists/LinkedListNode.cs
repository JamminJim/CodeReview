using System;
namespace CodeReview.Subjects.LinkedLists
{
	/// <summary>
	/// Linked list node.
	/// Desc: Node used by linked list code review
	/// </summary>
	public class LinkedListNode
	{

		#region public class properties

		/// <summary>
		/// Pointer to the next node in the linked list structure
		/// </summary>
		/// <value>The next.</value>
		public LinkedListNode next { get; set; }

		/// <summary>
		/// Pointer to the prev node in the linked list structure
		/// </summary>
		/// <value>The previous.</value>
		public LinkedListNode prev { get; set; }

		/// <summary>
		/// Value contained in the node
		/// </summary>
		/// <value>The key.</value>
		public int key { get; set; }

		#endregion


		/// <summary>
		/// Class constructor
		/// </summary>
		public LinkedListNode() {
			this.next = null;
			this.prev = null;
			this.key = 0;
		}

		/// <summary>
		/// Class destructor
		/// </summary>
		~LinkedListNode() {
			this.next = null;
			this.prev = null;

		}


		#region public class methods
		/// <summary>
		/// Prints out the value of the key to the console
		/// </summary>
		/// <param name="verbose">If set to <c>true</c> writes message before value.</param>
		/// <param name="writeline">If set to <c>true</c> uses writeline compared to write.</param>
		public void PrintNode(bool verbose = true, bool writeline = true) {
			if (verbose == true) {
				if (writeline == true) {
					Console.WriteLine("Node value is: {0}", key);
				} else {
					Console.Write("Node value is: {0}", key);
				}
			} else {
				if (writeline == true) {
					Console.WriteLine(key.ToString());
				} else {
					Console.Write(key.ToString());
				}
			}
		}
		#endregion

	} // end of class
}  // end of namespace
