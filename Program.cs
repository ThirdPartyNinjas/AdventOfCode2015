using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2015_csharp
{
    class Program
    {
        static void Main(string[] _)
        {
            //Day4.Part1();
            //Day4.Part2();

            //Day5.Part1();
            //Day5.Part2();

            //Day6.Part1();
            //Day6.Part2();

            //// part 2 calls part 1
            //Day7.Part2();

            //Day8.Part1();
            //Day8.Part2();

            //Day9.Part1();
            //Day9.Part2();

            //Day10.Part1();
            //Day10.Part2();

            Day17();
        }

        private static void Day17()
        {
            List<int> containers = new List<int>();
            Dictionary<int, int> combinationCounts = new Dictionary<int, int>();

            int CombinationCount(List<int> combination, int target)
            {
                int total = 0;
                foreach(var c in combination)
                {
                    total += containers[c];
                }

                if (total == target)
                {
                    if (!combinationCounts.ContainsKey(combination.Count))
                        combinationCounts[combination.Count] = 1;
                    else
                        combinationCounts[combination.Count]++;
                    return 1;
                }

                total = 0;
                int start = 0;
                if (combination.Count > 0)
                    start = combination[combination.Count - 1] + 1;

                for (int i = start; i< containers.Count; i++)
                {
                    List<int> newCombination = new List<int>(combination);
                    newCombination.Add(i);
                    total += CombinationCount(newCombination, target);
                }
                return total;
            }

            using (var file = File.OpenText("day17_input.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    containers.Add(int.Parse(line));
                }
            }

            int result = CombinationCount(new List<int>() { }, 150);
            Console.WriteLine($"17a {result}");

            int minimumUsed = int.MaxValue;
            foreach(var used in combinationCounts.Keys)
            {
                if (used < minimumUsed)
                    minimumUsed = used;
            }
            Console.WriteLine($"17b {combinationCounts[minimumUsed]}");
        }

        class Sue
        {
            public int Number { get; set; } = 0;
            public int Children { get; set; } = -1;
            public int Cats { get; set; } = -1;
            public int Samoyeds { get; set; } = -1;
            public int Pomeranians { get; set; } = -1;
            public int Akitas { get; set; } = -1;
            public int Vizslas { get; set; } = -1;
            public int Goldfish { get; set; } = -1;
            public int Trees { get; set; } = -1;
            public int Cars { get; set; } = -1;
            public int Perfumes { get; set; } = -1;
        }

        private static void Day16()
        {
            List<Sue> sues = new List<Sue>();

            using (var file = File.OpenText("day16_input.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Replace(":", "");
                    line = line.Replace(",", "");
                    var strings = line.Split(' ');

                    var sue = new Sue();
                    sue.Number = int.Parse(strings[1]);

                    for (int i = 2; i < strings.Length; i += 2)
                    {
                        switch (strings[i])
                        {
                            case "children": sue.Children = int.Parse(strings[i + 1]); break;
                            case "cats": sue.Cats = int.Parse(strings[i + 1]); break;
                            case "samoyeds": sue.Samoyeds = int.Parse(strings[i + 1]); break;
                            case "pomeranians": sue.Pomeranians = int.Parse(strings[i + 1]); break;
                            case "akitas": sue.Akitas = int.Parse(strings[i + 1]); break;
                            case "vizslas": sue.Vizslas = int.Parse(strings[i + 1]); break;
                            case "goldfish": sue.Goldfish = int.Parse(strings[i + 1]); break;
                            case "trees": sue.Trees = int.Parse(strings[i + 1]); break;
                            case "cars": sue.Cars = int.Parse(strings[i + 1]); break;
                            case "perfumes": sue.Perfumes = int.Parse(strings[i + 1]); break;
                        }
                    }

                    sues.Add(sue);
                }
            }

            Sue input = new Sue()
            {
                Children = 3,
                Cats = 7,
                Samoyeds = 2,
                Pomeranians = 3,
                Akitas = 0,
                Vizslas = 0,
                Goldfish = 5,
                Trees = 3,
                Cars = 2,
                Perfumes = 1,
            };

            foreach(var sue in sues)
            {
                if (sue.Children != -1 && sue.Children != input.Children)
                    continue;
                if (sue.Cats != -1 && sue.Cats != input.Cats)
                    continue;
                if (sue.Samoyeds != -1 && sue.Samoyeds != input.Samoyeds)
                    continue;
                if (sue.Pomeranians != -1 && sue.Pomeranians != input.Pomeranians)
                    continue;
                if (sue.Akitas != -1 && sue.Akitas != input.Akitas)
                    continue;
                if (sue.Vizslas != -1 && sue.Vizslas != input.Vizslas)
                    continue;
                if (sue.Goldfish != -1 && sue.Goldfish != input.Goldfish)
                    continue;
                if (sue.Trees != -1 && sue.Trees != input.Trees)
                    continue;
                if (sue.Cars != -1 && sue.Cars != input.Cars)
                    continue;
                if (sue.Perfumes != -1 && sue.Perfumes != input.Perfumes)
                    continue;

                Console.WriteLine($"16a: {sue.Number}");
                break;
            }

            foreach (var sue in sues)
            {
                if (sue.Children != -1 && sue.Children != input.Children)
                    continue;
                if (sue.Cats != -1 && sue.Cats <= input.Cats)
                    continue;
                if (sue.Samoyeds != -1 && sue.Samoyeds != input.Samoyeds)
                    continue;
                if (sue.Pomeranians != -1 && sue.Pomeranians >= input.Pomeranians)
                    continue;
                if (sue.Akitas != -1 && sue.Akitas != input.Akitas)
                    continue;
                if (sue.Vizslas != -1 && sue.Vizslas != input.Vizslas)
                    continue;
                if (sue.Goldfish != -1 && sue.Goldfish >= input.Goldfish)
                    continue;
                if (sue.Trees != -1 && sue.Trees <= input.Trees)
                    continue;
                if (sue.Cars != -1 && sue.Cars != input.Cars)
                    continue;
                if (sue.Perfumes != -1 && sue.Perfumes != input.Perfumes)
                    continue;

                Console.WriteLine($"16b: {sue.Number}");
                break;
            }
        }
    }
}
