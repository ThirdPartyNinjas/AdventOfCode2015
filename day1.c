#include <stdio.h>

#include "day1.h"

void d1p1()
{
	int c;
	int floor = 0;
	FILE *file = fopen("data/d1_input.txt", "r");

	if (!file)
	{
		printf("d1p1 error: Couldn't open d1_input.txt\n");
		return;
	}

	while ((c = fgetc(file)) != EOF)
	{
		if (c == '(')
			floor++;
		else if (c == ')')
			floor--;
	}

	printf("Day 1, Part 1, Santa was sent to floor %d\n", floor);
	fclose(file);
}

void d1p2()
{
	int c;
	int floor = 0;
	int position = 1;
	FILE *file = fopen("data/d1_input.txt", "r");

	if (!file)
	{
		printf("d1p2 error: Couldn't open d1_input.txt\n");
		return;
	}

	while ((c = fgetc(file)) != EOF)
	{
		if (c == '(')
			floor++;
		else if (c == ')')
			floor--;

		if (floor == -1)
			break;

		position++;
	}

	printf("Day 1, Part 2, Santa was first sent to the basement at position %d\n", position);
	fclose(file);
}

