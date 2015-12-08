using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015_csharp
{
	public static class Day8
	{
		public static void Part1()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day8_input.txt");
			string line;

			int count = 0;

			while ((line = file.ReadLine()) != null)
			{
				count += 2; // ignore the quotes
				for (int i = 1; i < line.Length - 1; i++)
				{
					if (line[i] == '\\')
					{
						if (line[i + 1] == '\\' || line[i + 1] == '\"')
						{
							count += 1;
							i++;
						}
						else if (line[i + 1] == 'x')
						{
							count += 3;
							i += 3;
						}
					}
				}
			}

			Console.WriteLine("d8p1: " + count);
		}
		public static void Part2()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day8_input.txt");
			string line;

			int count = 0;

			while ((line = file.ReadLine()) != null)
			{
				count += 2; // add even more quotes
				for (int i = 0; i < line.Length; i++)
				{
					if (line[i] == '\\' || line[i] == '\"')
					{
						count++;
					}
				}
			}

			Console.WriteLine("d8p2: " + count);
		}
	}
}