using System;
using System.Collections.Generic;
namespace CodeReview
{
	public class ParseEquation
	{
		const char PLUS = '+';
		const char MINUS = '-';
		const char MULTIPLY = '*';

		public static void Run() {
			Console.WriteLine("Running Parse Equation");

			var input = "45+16*3-2*6+1";
			Eval(input);
			var output = solution(input);
			Console.WriteLine("Output {0}", output);
		}

		private static void Eval(string s)
		{
			Stack<int> operands = new Stack<int>();
			Stack<char> operators = new Stack<char>();
			var startIndex = 0;
			var length = 0;


			//var operand1 = Int32.Parse(s.Substring(startIndex, length));
			//var operator1 = char.Parse(s[pos]);

			var i = 0;
			var op1 = 0;
			var op2 = 0;
			char op;

			var pos = 0;
			for (i = 0; i < s.Length; i++)
			{
				if (s[i] == PLUS || s[i] == MINUS || s[i] == MULTIPLY)
				{
					// parse the operator
					op = s[i];
					Console.WriteLine("Found Operator: {0} ", op);
					// parse the (left side) operand
					op2 = Int32.Parse(s.Substring(pos, i-pos));
					Console.WriteLine("Found value {0}", op2);

					pos = i+1;
				}
				else if (s[i] == MULTIPLY)
				{
					//
				}
				else
				{
					//
				}
			}
		}


	


		/// <summary>
		/// Takes a string and parses the equation
		/// </summary>
		/// <returns>The solution.</returns>
		/// <param name="input">Input.</param>
		private static int solution(string input) {



			// parse until operator is found
			// save number
			// if operator is +, push number and operator
			// if operator is *,/  perform operator, and continue

			// 4 5 +   =   45 push + push, restart
			// 1 6 * , scan 3 -

			// 45 16 3 2 6 1
			//   +   * - * +









			return 0;
		}

	}
}
