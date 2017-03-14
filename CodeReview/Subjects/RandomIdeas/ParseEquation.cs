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

			var input = "1+3*6-4*10*2*3-3*2";
			Eval(input);
			var output = solution(input);
			Console.WriteLine("Output {0}", output);
		}

		private static void Eval(string s) {
			Stack<int> operands = new Stack<int>();
			Stack<char> operators = new Stack<char>();

			// parse the string and save operands and operators into stacks
			var pos = 0;
			char _operator;
			int _operand;
			for (int i = 0; i < s.Length; i++) {
				if (s[i] == PLUS || s[i] == MINUS || s[i] == MULTIPLY) {

					// parse the (left side) operand
					_operand = Int32.Parse(s.Substring(pos, i - pos));
					operands.Push(_operand);
					Console.WriteLine("Found value {0}", _operand);

					// parse the operator
					_operator = s[i];
					operators.Push(_operator);
					Console.WriteLine("Found Operator: {0} ", _operator);

					pos = i + 1;
				} else if (i == s.Length - 1) {

					// final value
					_operand = Int32.Parse(s.Substring(pos, s.Length - pos));
					operands.Push(_operand);
					Console.WriteLine("Found value {0}", _operand);
				}
			}

			// pop operator stack and evaluate
			int val;
			while (operators.Count > 0) {

				_operator = operators.Pop();
				val = operands.Pop();   // hold left side value

				// order of operations, if we parse a +/- 
				if (_operator != MULTIPLY) {

					// parse all multiplication
					while (operators.Count > 0 && operators.Peek() == MULTIPLY) {
						operators.Pop();
						operands.Push(operands.Pop() * operands.Pop());
					}

					if (_operator == MINUS) {
						val = operands.Pop() - val;
						operands.Push(val);
					} else if (_operator == PLUS) {
						val = operands.Pop() + val;
						operands.Push(val);
					}

				} else if (_operator == MULTIPLY) {
					val = val * operands.Pop();
					operands.Push(val);
				}
			}

			int finalValue = operands.Pop();
			Console.WriteLine("Final Value is {0}", finalValue);
		}

		/// <summary>
		/// Takes a string and parses the equation
		/// </summary>
		/// <returns>The solution.</returns>
		/// <param name="input">Input.</param>
		private static int solution(string input) {


			return 0;
		}

	}
}
