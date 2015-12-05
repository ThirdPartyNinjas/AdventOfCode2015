using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015_csharp
{
	class Day5
	{
		public static void Part1()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day5_input.txt");
			string line;
			int niceStrings = 0;

			while ((line = file.ReadLine()) != null)
			{
				bool foundDouble = false;
				bool containsBad = false;
				int vowelCount = 0;

				char last = '0';
				foreach (var c in line)
				{
					if (c == last)
						foundDouble = true;

					if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
						vowelCount++;

					last = c;
				}

				containsBad = (line.Contains("ab") || line.Contains("cd") || line.Contains("pq") || line.Contains("xy"));

				if (vowelCount >= 3 && foundDouble && !containsBad)
					niceStrings++;
			}

			Console.WriteLine(string.Format("Day 5, Part 1, Found {0} nice strings", niceStrings));
		}

		public static void Part2()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day5_input.txt");
			string line;
			int niceStrings = 0;

			while ((line = file.ReadLine()) != null)
			{
				bool foundPair = false;
				bool foundRepeat = false;

				for (int i = 0; i < line.Length-1; i++)
				{
					string pairToFind = line.Substring(i, 2);
					int firstPosition = line.IndexOf(pairToFind);
					if (firstPosition + 2 >= line.Length)
						continue;
					int secondPosition = line.IndexOf(pairToFind, firstPosition + 2);

					if (secondPosition != -1)
					{
						foundPair = true;
						break;
					}
				}

				for (int i = 0; i < line.Length - 2; i++)
				{
					if (line[i] == line[i + 2])
					{
						foundRepeat = true;
						break;
					}
				}

				if (foundPair && foundRepeat)
					niceStrings++;

			}

			Console.WriteLine(string.Format("Day 5, Part 2, Found {0} nice strings", niceStrings));
		}
	}
}
