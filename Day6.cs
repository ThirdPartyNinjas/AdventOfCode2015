using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015_csharp
{
	public static class Day6
	{
		public static void Part1()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day6_input.txt");
			string line;

			bool[,] lights = new bool[1000, 1000];

			while ((line = file.ReadLine()) != null)
			{
				string[] parts = line.Split(' ');
				string[] firstNumbers;
				string[] secondNumbers;

				if (parts[0] == "turn")
				{
					firstNumbers = parts[2].Split(',');
					secondNumbers = parts[4].Split(',');

					bool value = parts[1] == "on";

					for (int j = int.Parse(firstNumbers[0]); j <= int.Parse(secondNumbers[0]); j++)
					{
						for (int i = int.Parse(firstNumbers[1]); i <= int.Parse(secondNumbers[1]); i++)
						{
							lights[i, j] = value;
						}
					}
				}
				else
				{
					firstNumbers = parts[1].Split(',');
					secondNumbers = parts[3].Split(',');

					for (int j = int.Parse(firstNumbers[0]); j <= int.Parse(secondNumbers[0]); j++)
					{
						for (int i = int.Parse(firstNumbers[1]); i <= int.Parse(secondNumbers[1]); i++)
						{
							lights[i, j] = !lights[i, j];
						}
					}
				}
			}

			int count = 0;

			for (int j = 0; j < 1000; j++)
			{
				for (int i = 0; i < 1000; i++)
				{
					if (lights[i, j])
						count++;
				}
			}

			Console.WriteLine(string.Format("d6p1: There are {0} lights on", count));
		}

		public static void Part2()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day6_input.txt");
			string line;

			int[,] lights = new int[1000, 1000];

			while ((line = file.ReadLine()) != null)
			{
				string[] parts = line.Split(' ');
				string[] firstNumbers;
				string[] secondNumbers;

				if (parts[0] == "turn")
				{
					firstNumbers = parts[2].Split(',');
					secondNumbers = parts[4].Split(',');

					int value = (parts[1] == "on") ? 1 : -1;

					for (int j = int.Parse(firstNumbers[0]); j <= int.Parse(secondNumbers[0]); j++)
					{
						for (int i = int.Parse(firstNumbers[1]); i <= int.Parse(secondNumbers[1]); i++)
						{
							lights[i, j] += value;
							lights[i, j] = Math.Max(lights[i, j], 0);
						}
					}
				}
				else
				{
					firstNumbers = parts[1].Split(',');
					secondNumbers = parts[3].Split(',');

					for (int j = int.Parse(firstNumbers[0]); j <= int.Parse(secondNumbers[0]); j++)
					{
						for (int i = int.Parse(firstNumbers[1]); i <= int.Parse(secondNumbers[1]); i++)
						{
							lights[i, j] += 2;
						}
					}
				}
			}

			UInt64 total = 0;

			for (int j = 0; j < 1000; j++)
			{
				for (int i = 0; i < 1000; i++)
				{
					total += (UInt64)lights[i, j];
				}
			}

			Console.WriteLine(string.Format("d6p2: The total brightness is {0}", total));
		}

	}
}
