using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015_csharp
{
	public static class Day7
	{
		enum Command
		{
			NONE,
			LSHIFT,
			RSHIFT,
			NOT,
			AND,
			OR
		}

		static ushort ResolveConnections(string wire, Dictionary<string, string> inputs, Dictionary<string, ushort> wires)
		{
			ushort result = 0;
			string[] instruction;

			if (inputs[wire].Contains(" "))
				instruction = inputs[wire].Split(' ');
			else
				instruction = new string[] { inputs[wire] };

			Command command = Command.NONE;

			foreach (var p in instruction)
			{
				switch (p)
				{
					case "LSHIFT": command = Command.LSHIFT; break;
					case "RSHIFT": command = Command.RSHIFT; break;
					case "NOT": command = Command.NOT; break;
					case "AND": command = Command.AND; break;
					case "OR": command = Command.OR; break;
					default:
						switch(command)
						{
							case Command.NONE:
								ushort temp;
								if (ushort.TryParse(p, out temp))
									result = ushort.Parse(p);
								else
								{
									if (!wires.ContainsKey(p))
										wires[p] = ResolveConnections(p, inputs, wires);
									result = wires[p];
								}
								break;
							case Command.LSHIFT:
								result <<= int.Parse(p);
								break;
							case Command.RSHIFT:
								result >>= int.Parse(p);
								break;
							case Command.NOT:
								result = (ushort)~ResolveConnections(p, inputs, wires);
								break;
							case Command.AND:
								result &= ResolveConnections(p, inputs, wires);
								break;
							case Command.OR:
								result |= ResolveConnections(p, inputs, wires);
								break;
							default:
								Console.WriteLine("What now?");
								break;
						}
						command = Command.NONE;
						break;
				}

			}

			return result;
		}

		public static ushort Part1()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day7_input.txt");
			string line;

			Dictionary<string, ushort> wires = new Dictionary<string, ushort>();
			Dictionary<string, string> inputs = new Dictionary<string, string>();

			while ((line = file.ReadLine()) != null)
			{
				string[] temp = line.Split(new string[] { " -> " }, StringSplitOptions.None);

				inputs[temp[1]] = temp[0];
			}

			ushort value = ResolveConnections("a", inputs, wires);
			Console.WriteLine("d5p1: The value of a is: " + value);

			return value;
		}

		public static void Part2()
		{
			System.IO.StreamReader file = new System.IO.StreamReader(@"day7_input.txt");
			string line;

			Dictionary<string, ushort> wires = new Dictionary<string, ushort>();
			Dictionary<string, string> inputs = new Dictionary<string, string>();

			while ((line = file.ReadLine()) != null)
			{
				string[] temp = line.Split(new string[] { " -> " }, StringSplitOptions.None);

				inputs[temp[1]] = temp[0];
			}

			wires["b"] = Part1();

			Console.WriteLine("d5p2: The value of a is: " + ResolveConnections("a", inputs, wires));
		}

	}
}
