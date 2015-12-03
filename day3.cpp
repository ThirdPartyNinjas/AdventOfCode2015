// This was my original solution in C++ because I didn't want to write a hashset in C.
// Leaving this here, but check out day3.c instead.

#include <cstdio>
#include <map>

#include "day3.h"

using namespace std;

extern "C"
{
	void d3p1()
	{
		int c;
		int x = 0, y = 0;
		int houses = 0;
		map<int, map<int, int>> data;
		FILE *file = fopen("data/d3_input.txt", "r");

		if (!file)
		{
			printf("d3p1 error: Couldn't open d3_input.txt\n");
			return;
		}

		data[0][0] = 1;

		while ((c = fgetc(file)) != EOF)
		{
			switch (c)
			{
			case '<': x--; break;
			case '>': x++; break;
			case '^': y--; break;
			case 'v': y++; break;
			default: continue;
			}

			data[x][y]++;
		}

		fclose(file);

		for (auto &kv : data)
		{
			houses += kv.second.size();
		}

		printf("Day 3, Part 1, Santa visited %d houses.\n", houses);
	}

	void d3p2()
	{
		int c;
		int x = 0, y = 0;
		int rx = 0, ry = 0;
		int houses = 0;
		bool santaTurn = true;
		map<int, map<int, int>> data;
		FILE *file = fopen("data/d3_input.txt", "r");

		if (!file)
		{
			printf("d3p2 error: Couldn't open d3_input.txt\n");
			return;
		}

		data[0][0] = 2;
	
		while ((c = fgetc(file)) != EOF)
		{
			if (santaTurn)
			{
				switch (c)
				{
				case '<': x--; break;
				case '>': x++; break;
				case '^': y--; break;
				case 'v': y++; break;
				default: continue;
				}
				data[x][y]++;
			}
			else
			{
				switch (c)
				{
				case '<': rx--; break;
				case '>': rx++; break;
				case '^': ry--; break;
				case 'v': ry++; break;
				default: continue;
				}
				data[rx][ry]++;
			}
			santaTurn = !santaTurn;
		}

		fclose(file);

		for (auto &kv : data)
		{
			houses += kv.second.size();
		}

		printf("Day 3, Part 2, Santa and Robo-Santa visited %d houses.\n", houses);
	}
}