using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015_csharp
{
	public static class Day10
	{
		public static string LookAndSay(string numbers)
		{
			StringBuilder output = new StringBuilder();

			char current = numbers[0];
			int count = 1;

			for(int i=1; i<numbers.Length; i++)
			{
				if(numbers[i] != current)
				{
					output.Append(count.ToString());
					output.Append(current);

					current = numbers[i];
					count = 1;
				}
				else
				{
					count++;
				}
			}

			output.Append(count);
			output.Append(numbers[numbers.Length - 1]);

			return output.ToString();
		}

		public static void Part1()
		{
			string numbers = "1113122113";

			for (int i = 0; i < 40; i++)
			{
				numbers = LookAndSay(numbers);
			}

			Console.WriteLine("d10p1: " + numbers.Length);
		}

		public static void Part2()
		{
			string numbers = "1113122113";

			for (int i = 0; i < 50; i++)
			{
				numbers = LookAndSay(numbers);
			}

			Console.WriteLine("d10p2: " + numbers.Length);
		}
	}
}
