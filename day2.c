#include <stdio.h>
#include <stdlib.h>

#include "day2.h"

void d2p1()
{
	int l, w, h;
	int totalarea = 0;
	FILE *file = fopen("data/d2_input.txt", "r");

	if (!file)
	{
		printf("d2p1 error: Couldn't open d2_input.txt\n");
		return;
	}

	while (fscanf(file, "%dx%dx%d\n", &l, &w, &h) == 3)
	{
		int area = 2 * l * w + 2 * w * h + 2 * h * l;
		int slack = min(min(l * w, w * h), h * l);
		totalarea += area + slack;
	}

	printf("Day 2, Part 1, The elves need %d feet of wrapping paper.\n", totalarea);
	fclose(file);
}

void d2p2()
{
	int l, w, h;
	int totalfeet = 0;
	FILE *file = fopen("data/d2_input.txt", "r");

	if (!file)
	{
		printf("d2p2 error: Couldn't open d2_input.txt\n");
		return;
	}

	while (fscanf(file, "%dx%dx%d\n", &l, &w, &h) == 3)
	{
		int perimeter = min(min(l + l + w + w, w + w + h + h), h + h + l + l);
		int volume = l * w * h;
		totalfeet += perimeter + volume;
	}

	printf("Day 2, Part 2, The elves need %d feet of ribbon.\n", totalfeet);
	fclose(file);
}
