using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// I started out doing this, then completely changed directions.
//   I built the second method on the remains of the first. Sorry for the mess.
//   There's a Dictionary of Dictionaries, and then I built all of the possibilities
//   recursively and barely used any of that nonsense. Wacky stuff. :P

namespace AdventOfCode2015_csharp
{
	public static class Day9
	{
		public static void Generate(string next, List<string> current, List<string> names, List<List<string>> results)
		{
			List<string> myCurrent = new List<string>();
			foreach (var s in current)
				myCurrent.Add(s);
			if(next != "")
				myCurrent.Add(next);

			if (myCurrent.Count == 8)
			{
				results.Add(myCurrent);
				return;
			}

			foreach(var n in names)
			{
				if(!myCurrent.Contains(n))
				{
					Generate(n, myCurrent, names, results);
				}
			}
		}

		public static void Part1()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day9_input.txt");
			string line;

			Dictionary<string, int> AlphaCentauri = new Dictionary<string, int>();
			Dictionary<string, int> Snowdin = new Dictionary<string, int>();
			Dictionary<string, int> Tambi = new Dictionary<string, int>();
			Dictionary<string, int> Faerun = new Dictionary<string, int>();
			Dictionary<string, int> Norrath = new Dictionary<string, int>();
			Dictionary<string, int> Straylight = new Dictionary<string, int>();
			Dictionary<string, int> Tristram = new Dictionary<string, int>();
			Dictionary<string, int> Arbre = new Dictionary<string, int>();

			Dictionary<string, Dictionary<string, int>> collection = new Dictionary<string, Dictionary<string, int>>();
			collection["AlphaCentauri"] = AlphaCentauri;
			collection["Snowdin"] = Snowdin;
			collection["Tambi"] = Tambi;
			collection["Faerun"] = Faerun;
			collection["Norrath"] = Norrath;
			collection["Straylight"] = Straylight;
			collection["Tristram"] = Tristram;
			collection["Arbre"] = Arbre;

			List<string> names = new List<string>();
			names.Add("AlphaCentauri");
			names.Add("Snowdin");
			names.Add("Tambi");
			names.Add("Faerun");
			names.Add("Norrath");
			names.Add("Straylight");
			names.Add("Tristram");
			names.Add("Arbre");

			while ((line = file.ReadLine()) != null)
			{
				var words = line.Split(' ');
				collection[words[0]][words[2]] = int.Parse(words[4]);
				collection[words[2]][words[0]] = int.Parse(words[4]);
			}

			List<List<string>> results = new List<List<string>>();
			List<string> current = new List<string>();
			Generate("", current, names, results);

			int minimum = int.MaxValue;
			int minimumIndex = 0;

			for(int i=0; i<results.Count; i++)
			{
				int total = 0;
				for(int j=0; j<results[i].Count-1; j++)
				{
					total += collection[results[i][j]][results[i][j + 1]];
				}
				if(total < minimum)
				{
					minimum = total;
					minimumIndex = i;
				}
			}

			Console.WriteLine("d9p1: The minimum is " + minimum);
		}

		public static void Part2()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day9_input.txt");
			string line;

			Dictionary<string, int> AlphaCentauri = new Dictionary<string, int>();
			Dictionary<string, int> Snowdin = new Dictionary<string, int>();
			Dictionary<string, int> Tambi = new Dictionary<string, int>();
			Dictionary<string, int> Faerun = new Dictionary<string, int>();
			Dictionary<string, int> Norrath = new Dictionary<string, int>();
			Dictionary<string, int> Straylight = new Dictionary<string, int>();
			Dictionary<string, int> Tristram = new Dictionary<string, int>();
			Dictionary<string, int> Arbre = new Dictionary<string, int>();

			Dictionary<string, Dictionary<string, int>> collection = new Dictionary<string, Dictionary<string, int>>();
			collection["AlphaCentauri"] = AlphaCentauri;
			collection["Snowdin"] = Snowdin;
			collection["Tambi"] = Tambi;
			collection["Faerun"] = Faerun;
			collection["Norrath"] = Norrath;
			collection["Straylight"] = Straylight;
			collection["Tristram"] = Tristram;
			collection["Arbre"] = Arbre;

			List<string> names = new List<string>();
			names.Add("AlphaCentauri");
			names.Add("Snowdin");
			names.Add("Tambi");
			names.Add("Faerun");
			names.Add("Norrath");
			names.Add("Straylight");
			names.Add("Tristram");
			names.Add("Arbre");

			while ((line = file.ReadLine()) != null)
			{
				var words = line.Split(' ');
				collection[words[0]][words[2]] = int.Parse(words[4]);
				collection[words[2]][words[0]] = int.Parse(words[4]);
			}

			List<List<string>> results = new List<List<string>>();
			List<string> current = new List<string>();
			Generate("", current, names, results);

			int maximum = int.MinValue;
			int maximumIndex = 0;

			for (int i = 0; i < results.Count; i++)
			{
				int total = 0;
				for (int j = 0; j < results[i].Count - 1; j++)
				{
					total += collection[results[i][j]][results[i][j + 1]];
				}
				if (total > maximum)
				{
					maximum = total;
					maximumIndex = i;
				}
			}

			Console.WriteLine("d9p2: The maximum is " + maximum);
		}
	}
}