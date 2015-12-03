#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "day3.h"

// note: Using a sorted list or a hashset would be much better but I don't
//       want to go overboard for a simple project. So just a simple linked list.
struct House
{
	int visits;
	char *location;
	struct House *next;
};

void d3p1()
{
	int c;
	int x = 0, y = 0;
	int houseCount;
	char location[512];
	struct House *houses;
	struct House *tail;
	struct House *iterator;
	FILE *file = fopen("data/d3_input.txt", "r");

	if (!file)
	{
		printf("d3p1 error: Couldn't open d3_input.txt\n");
		return;
	}

	houseCount = 1;
	houses = (struct House*)malloc(sizeof(struct House));
	houses->location = (char*)malloc(4);
	sprintf(houses->location, "0,0");
	houses->next = 0;
	houses->visits = 1;
	tail = houses;

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
	
		sprintf(location, "%d,%d", x, y);

		iterator = houses;
		while (iterator)
		{
			if (strcmp(iterator->location, location) == 0)
			{
				iterator->visits++;
				break;
			}
			iterator = iterator->next;
		}
		if (!iterator)
		{
			houseCount++;
			iterator = (struct House*)malloc(sizeof(struct House));
			iterator->location = (char*)malloc(strlen(location)+1);
			strcpy(iterator->location, location);
			iterator->next = 0;
			iterator->visits = 1;
			tail->next = iterator;
			tail = iterator;
		}
	}

	fclose(file);

	while (houses)
	{
		iterator = houses;
		houses = houses->next;
		free(iterator->location);
		free(iterator);
	}

	printf("Day 3, Part 1, Santa visited %d houses.\n", houseCount);
}

void d3p2()
{
	int c;
	int x = 0, y = 0, rx = 0, ry = 0;
	int houseCount;
	bool santasTurn = true;
	char location[512];
	struct House *houses;
	struct House *tail;
	struct House *iterator;
	FILE *file = fopen("data/d3_input.txt", "r");

	if (!file)
	{
		printf("d3p2 error: Couldn't open d3_input.txt\n");
		return;
	}

	houseCount = 1;
	houses = (struct House*)malloc(sizeof(struct House));
	houses->location = (char*)malloc(4);
	sprintf(houses->location, "0,0");
	houses->next = 0;
	houses->visits = 1;
	tail = houses;

	while ((c = fgetc(file)) != EOF)
	{
		if (santasTurn)
		{
			switch (c)
			{
			case '<': x--; break;
			case '>': x++; break;
			case '^': y--; break;
			case 'v': y++; break;
			default: continue;
			}
			sprintf(location, "%d,%d", x, y);
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
			sprintf(location, "%d,%d", rx, ry);
		}

		santasTurn = !santasTurn;

		iterator = houses;
		while (iterator)
		{
			if (strcmp(iterator->location, location) == 0)
			{
				iterator->visits++;
				break;
			}
			iterator = iterator->next;
		}
		if (!iterator)
		{
			houseCount++;
			iterator = (struct House*)malloc(sizeof(struct House));
			iterator->location = (char*)malloc(strlen(location) + 1);
			strcpy(iterator->location, location);
			iterator->next = 0;
			iterator->visits = 1;
			tail->next = iterator;
			tail = iterator;
		}
	}

	fclose(file);

	while (houses)
	{
		iterator = houses;
		houses = houses->next;
		free(iterator->location);
		free(iterator);
	}

	printf("Day 3, Part 2, Santa and Robo-Santa visited %d houses.\n", houseCount);
}
