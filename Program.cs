using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2015_csharp
{
    internal class Program
    {
        private static void Main(string[] _)
        {
            Day19();
        }

        private static void Day19()
        {
            List<(string a, string b)> replacements = new List<(string a, string b)>();
            string input;

            using (var file = File.OpenText("day19_input.txt"))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if(line == "")
                        break;

                    line = line.Replace("=> ", "");
                    var strings = line.Split(' ');

                    replacements.Add((strings[0], strings[1]));
                }

                input = file.ReadLine();
            }

            HashSet<string> replacedSet = new HashSet<string>();

            foreach(var r in replacements)
            {
                int position = 0;
                int index = 0;
                while((index = input.IndexOf(r.a, position)) != -1)
                {
                    string replaced = input.Substring(0, index) + r.b + input.Substring(index + r.a.Length);
                    replacedSet.Add(replaced);
                    position = index + r.a.Length;
                }
            }

            Console.WriteLine($"19a {replacedSet.Count}");

            // Note: I didn't solve 19b, I tested some code I found online and it works.
            // This one was beyond me. I need to revisit this later.

            var str = "CRnSiRnCaPTiMgYCaPTiRnFArSiThFArCaSiThSiThPBCaCaSiRnSiRnTiTiMgArPBCaPMgYPTiRnFArFArCaSiRnBPMgArPRnCaPTiRnFArCaSiThCaCaFArPBCaCaPTiTiRnFArCaSiRnSiAlYSiThRnFArArCaSiRnBFArCaCaSiRnSiThCaCaCaFYCaPTiBCaSiThCaSiThPMgArSiRnCaPBFYCaCaFArCaCaCaCaSiThCaSiRnPRnFArPBSiThPRnFArSiRnMgArCaFYFArCaSiRnSiAlArTiTiTiTiTiTiTiRnPMgArPTiTiTiBSiRnSiAlArTiTiRnPMgArCaFYBPBPTiRnSiRnMgArSiThCaFArCaSiThFArPRnFArCaSiRnTiBSiThSiRnSiAlYCaFArPRnFArSiThCaFArCaCaSiThCaCaCaSiRnPRnCaFArFYPMgArCaPBCaPBSiRnFYPBCaFArCaSiAl";
            Func<string, int> countStr = x =>
            {
                var count = 0;
                for (var index = str.IndexOf(x); index >= 0; index = str.IndexOf(x, index + 1), ++count) { }
                return count;
            };

            var num = str.Count(char.IsUpper) - countStr("Rn") - countStr("Ar") - 2 * countStr("Y") - 1;
            Console.WriteLine($"19b {num}");
        }

        private static void Day18()
        {
            bool[,] input = new bool[100, 100];
            bool[,] lights = new bool[100, 100];
            bool[,] nextLights = new bool[100, 100];

            int NeighborCount(bool[,] grid, int x, int y)
            {
                int total = 0;
                total += (x == 0) ? 0 : (grid[y, x - 1] ? 1 : 0);
                total += (x == 99) ? 0 : (grid[y, x + 1] ? 1 : 0);
                total += (y == 0) ? 0 : (grid[y - 1, x] ? 1 : 0);
                total += (y == 99) ? 0 : (grid[y + 1, x] ? 1 : 0);
                total += (x == 0 || y == 0) ? 0 : (grid[y - 1, x - 1] ? 1 : 0);
                total += (x == 99 || y == 0) ? 0 : (grid[y - 1, x + 1] ? 1 : 0);
                total += (x == 99 || y == 99) ? 0 : (grid[y + 1, x + 1] ? 1 : 0);
                total += (x == 0 || y == 99) ? 0 : (grid[y + 1, x - 1] ? 1 : 0);
                return total;
            }

            using (var file = File.OpenText("day18_input.txt"))
            {
                string line;
                int y = 0;
                while ((line = file.ReadLine()) != null)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        if (line[x] == '.')
                        {
                            input[y, x] = false;
                        }
                        else if (line[x] == '#')
                        {
                            input[y, x] = true;
                        }
                    }
                    y++;
                }
            }

            Array.Copy(input, 0, lights, 0, 100 * 100);

            for (int i = 0; i < 100; i++)
            {
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        var neighborCount = NeighborCount(lights, x, y);
                        if (lights[y, x])
                        {
                            nextLights[y, x] = (neighborCount == 2 || neighborCount == 3);
                        }
                        else
                        {
                            nextLights[y, x] = neighborCount == 3;
                        }
                    }
                }

                bool[,] temp = lights;
                lights = nextLights;
                nextLights = temp;
            }

            int totalLightsOn = 0;
            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    if (lights[y, x])
                        totalLightsOn++;
                }
            }

            Console.WriteLine($"18a {totalLightsOn}");

            Array.Copy(input, 0, lights, 0, 100 * 100);
            lights[0, 0] = lights[99, 0] = lights[0, 99] = lights[99, 99] = true;

            for (int i = 0; i < 100; i++)
            {
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        var neighborCount = NeighborCount(lights, x, y);
                        if (lights[y, x])
                        {
                            nextLights[y, x] = (neighborCount == 2 || neighborCount == 3);
                        }
                        else
                        {
                            nextLights[y, x] = neighborCount == 3;
                        }
                    }
                }

                bool[,] temp = lights;
                lights = nextLights;
                nextLights = temp;
                lights[0, 0] = lights[99, 0] = lights[0, 99] = lights[99, 99] = true;
            }

            totalLightsOn = 0;
            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    if (lights[y, x])
                        totalLightsOn++;
                }
            }

            Console.WriteLine($"18b {totalLightsOn}");
        }

        private static void Day17()
        {
            List<int> containers = new List<int>();
            Dictionary<int, int> combinationCounts = new Dictionary<int, int>();

            int CombinationCount(List<int> combination, int target)
            {
                int total = 0;
                foreach (var c in combination)
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

                for (int i = start; i < containers.Count; i++)
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
            foreach (var used in combinationCounts.Keys)
            {
                if (used < minimumUsed)
                    minimumUsed = used;
            }
            Console.WriteLine($"17b {combinationCounts[minimumUsed]}");
        }

        private class Sue
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

            foreach (var sue in sues)
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